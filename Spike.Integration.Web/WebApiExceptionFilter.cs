using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;
using Spike.Contracts.Public;

namespace Spike.Integration.Web
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var matched = false;
            var resultCode = ResultCode.Undefined;
            var errorDescription = string.Empty;

            if (context.Exception is UnauthorizedAccessException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                resultCode = ResultCode.NotAuthorized;
                errorDescription = "Not authorized to access resource";

                matched = true;
            }
            
            if (!matched)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                resultCode = ResultCode.GeneralFailure;
                errorDescription = "Internal server exception";
            }

            var response = new
            {
                ResultCode = resultCode,
                ErrorDescription = errorDescription
            };

            var json = new JavaScriptSerializer().Serialize(response);

            context.Response.Content = new StringContent(json);
        }
    }
}
