using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.Account.Interfaces
{
    interface IAccountRepository
    {
        void Add(DbAccount account);
        DbAccount Get(int id);
        DbAccount GetByEmail(string email);
    }
}
