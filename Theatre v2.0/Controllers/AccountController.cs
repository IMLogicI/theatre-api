using System.Web.Http;
using Theatre_v2._0.Models;
using Theatre_v2._0.Services.Account;
using Theatre_v2._0.Services.Account.Interfaces;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountDomain accountDomain;

        public AccountController()
        {
            accountDomain = AccountDomain.GetAccountDomain();
        }

        [Route("authorize")]
        [HttpGet]
        public IHttpActionResult Authorize([FromBody] AuthorizationData authorizationData)
        {
            if (!accountDomain.Check(authorizationData))
            {
                return NotFound();
            }

            return Ok();
        }

        [Route("registration")]
        [HttpPost]
        public IHttpActionResult Registration([FromBody] AuthorizationData registrationData)
        {
            if (accountDomain.Exists(registrationData))
            {
                return NotFound();
            }

            accountDomain.Add(registrationData);
            return Ok();
        }
    }
}
