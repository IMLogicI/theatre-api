using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Theatre_v2._0.Services.Account.Interfaces;
using Theatre_v2._0.Services.DataAccess;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dataContext;

        private static AccountRepository accountRepository;

        protected AccountRepository()
        {
            _dataContext = DataContext.GetDataContext();
        }

        public static AccountRepository GetAccountRepository()
        {
            return accountRepository ?? (accountRepository = new AccountRepository());
        }

        public void Add(DbAccount account)
        {
            _dataContext.Insert(account);
            _dataContext.Save();
        }

        public DbAccount Get(int id)
        {
            return _dataContext.GetQueryable<DbAccount>().FirstOrDefault(a => a.Id == id);
        }
    }
}