using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre_v2._0.Models;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.Account.Interfaces
{
    public interface IAccountDomain
    {
        void Add(AuthorizationData dbAccount);
        AuthorizationData Get(int id);
        bool Check(AuthorizationData authorizationData);
        bool Exists(AuthorizationData authorizationData);
    }
}
