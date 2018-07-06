using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace Spike.Integration.Client
{
    public class ServiceClientWrapper<TClient, TIService> : IDisposable
            where TClient : ClientBase<TIService>, TIService
            where TIService : class
    {
        private TClient _serviceClient;
        private Binding _binding;
        private EndpointAddress _endpoint;
        private const int RetryCoolDownInSeconds = 1;
        private string Username { get; set; }
        private string Password { get; set; }

        public ServiceClientWrapper() { }
        public ServiceClientWrapper(Binding binding, EndpointAddress endpointAddress)
        {
            _binding = binding;
            _endpoint = endpointAddress;
        }

        public void UpdateBasicCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public TClient ServiceClient
        {
            get
            {
                return this._serviceClient = this._serviceClient ?? this.CreateClient();
            }
        }

        public void Excecute(
            Action<TIService> serviceCall,
            int retryAttempts = 1,
            Action<CommunicationException> exceptionHandler = null)
        {
            Excecute<object>(
                service => { serviceCall.Invoke(service); return null; },
                retryAttempts,
                exceptionHandler);
        }

        public TResult Excecute<TResult>(
            Func<TIService, TResult> serviceCall,
            int retryAttempts = 1,
            Action<CommunicationException> exceptionHandler = null)
        {
            var errors = 0;
            var completed = false;
            CommunicationException exception = null;
            var response = default(TResult);

            while (!completed && errors < retryAttempts)
            {
                try
                {
                    if (!this.ServiceClient.State.IsReady())
                    {
                        this.DisposeClient();

                        if (!this.ServiceClient.State.IsReady())
                        {
                            throw new CommunicationObjectFaultedException($"WCF Client state is not valid. Connection Status [{this.ServiceClient.State}]");
                        }
                    }

                    response = serviceCall.Invoke(this.ServiceClient);
                    completed = true;
                }
                catch (CommunicationException comsException)
                {
                    exception = comsException;
                    if (exceptionHandler != null)
                    {
                        try
                        {
                            exceptionHandler.Invoke(exception);
                        }
                        catch (CommunicationException reThrowException)
                        {
                            exception = reThrowException;
                        }
                    }

                    errors++;
                    var logErrorMessage = $"WCF Operation Failure: Service [{typeof(TClient)}].[{serviceCall.Method.Name}] Attempt ({errors}/{retryAttempts}). Exception [{exception.Message}]";

                    if (retryAttempts > 1)
                    {
                        var logSleepMessage = $"Retry cooldown initiated ({RetryCoolDownInSeconds}s)";

                        Thread.Sleep(new TimeSpan(0, 0, RetryCoolDownInSeconds));
                    }
                }
                finally
                {
                    if (!completed)
                    {
                        this.DisposeClient();
                    }
                    else
                    {
                        this.ServiceClient.Close();
                    }
                }
            }

            if (!completed)
            {
                throw exception ?? new CommunicationException($"WCF Operation Failure: Service [{typeof(TClient)}].[{serviceCall.Method.Name}]");
            }

            return response;
        }

        public void Dispose()
        {
            this.DisposeClient();
        }

        protected virtual TClient CreateClient()
        {
            TClient client = null;

            if (_binding != null && _endpoint != null)
            {
                client = (TClient) Activator.CreateInstance(typeof(TClient), _binding, _endpoint);
            }
            else
            {
                client = (TClient) Activator.CreateInstance(typeof(TClient));

                if (_endpoint != null)
                {
                    client.Endpoint.Address = _endpoint;
                }
            }

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) ||
                client.ClientCredentials == null) return client;
            
            client.ClientCredentials.UserName.UserName = Username;
            client.ClientCredentials.UserName.Password = Password;

            return client;
        }

        private void DisposeClient()
        {
            if (this._serviceClient == null)
            {
                return;
            }

            try
            {
                switch (this._serviceClient.State)
                {
                    case CommunicationState.Faulted:
                        this._serviceClient.Abort();
                        break;

                    default:
                        this._serviceClient.Close();
                        break;
                }
            }
            catch
            {
                this._serviceClient.Abort();
            }
            finally
            {
                this._serviceClient = null;
            }
        }
    }
    public static class ServiceExtentions
    {
        public static bool IsReady(this CommunicationState original)
        {
            switch (original)
            {
                case CommunicationState.Created:
                case CommunicationState.Opened:
                case CommunicationState.Opening:
                    return true;

                default:
                    return false;
            }
        }
    }
}
