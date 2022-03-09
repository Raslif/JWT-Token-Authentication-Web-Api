using JWT_TokenAuth.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JWT_TokenAuth.Controllers
{
    public class AuthenticateController : ApiController
    {
        private readonly IUser _user = null;
        private readonly ITokenManager _tokenManager = null;
        public AuthenticateController(IUser user, ITokenManager tokenManager)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
        }

        [HttpGet]
        public async Task<HttpResponseMessage> AuthenticateUser(string userName, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Input is not valid");

                if (await _user.Authenticate(userName, password))
                    return Request.CreateResponse(HttpStatusCode.OK, new { Token = await _tokenManager.GenerateToken() });

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not Found.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
        }
    }
}
