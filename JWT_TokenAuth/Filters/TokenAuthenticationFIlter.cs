using JWT_TokenAuth.App_Start;
using JWT_TokenAuth.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace JWT_TokenAuth.Filters
{
    public class TokenAuthenticationFIlter : AuthorizationFilterAttribute
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are Un-Authorized.");

            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                var tokenManager = NinjectWebCommon._Kernal.GetService(typeof(ITokenManager)) as ITokenManager;

                if(!await tokenManager.VerifyToken(token))
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, 
                                                                    "Token seems expired/You are not authorized");
            }
        }
    }
}