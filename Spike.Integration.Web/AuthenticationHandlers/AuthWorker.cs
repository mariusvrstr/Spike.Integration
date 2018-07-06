
namespace Spike.Integration.Web.AuthenticationHandlers
{
    public class AuthWorker
    {
        public static bool IsValidCredentials(string username, string password)
        {
            //TODO: DO Authentication here
            return (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                   && !username.ToLower().Contains("fail");
        }
    }
}