using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Theatre_v2._0.Models;
using Theatre_v2._0.Services.Account.Interfaces;
using Theatre_v2._0.Services.DataAccess.Models;
using Theatre_v2._0.Services.Mapping;

namespace Theatre_v2._0.Services.Account
{
    public class AccountDomain : IAccountDomain
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        private static AccountDomain accountDomain;

        public static AccountDomain GetAccountDomain()
        {
            return accountDomain ?? (accountDomain = new AccountDomain());
        }

        protected AccountDomain()
        {
            accountRepository = AccountRepository.GetAccountRepository();
            mapper = MappingOperations.GetMapper();
        }

        public void Add(AuthorizationData dbAccount)
        {
            accountRepository.Add(dbAccount.Map<AuthorizationData,DbAccount>(mapper));
        }

        public AuthorizationData Get(int id)
        {
            return accountRepository.Get(id).Map<DbAccount,AuthorizationData>(mapper);
        }
    }
}