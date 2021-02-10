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
            accountDomain.Add(authorizationData);

            return Ok(accountDomain.Get(4));
        }
    }
}
