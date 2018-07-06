using System.IdentityModel.Selectors;
using System.Security.Authentication;

namespace Spike.Integration.Web.AuthenticationHandlers
{
    public class WcfAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string username, string password)
        {
            if (!AuthWorker.IsValidCredentials(username, password))
            {
                throw new AuthenticationException($"Invalid login details provided. Username [{username}]");
            }
        }
    }
}