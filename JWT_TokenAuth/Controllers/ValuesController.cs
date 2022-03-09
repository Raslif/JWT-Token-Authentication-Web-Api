using JWT_TokenAuth.Filters;
using System.Collections.Generic;
using System.Web.Http;

namespace JWT_TokenAuth.Controllers
{
    public class ValuesController : ApiController
    {
        [TokenAuthenticationFIlter]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return $"value: {id}";
        }
    }
}
