using System;
using tic_tac_toe.domain;

namespace tic_tac_toe.app
{
    public class AccountController
    {
        private AccountRepository accounts;
        public AccountController (AccountRepository accounts)
        {
            this.accounts = accounts;
        }
        
        public AccountDto Create (string username)
        {
            AccountEntity? exists = this.accounts.FindByUsername(username);

            if (exists != null)
            {
                throw new Exception("error.account.already.exists");
            }

            return new AccountDto(this.accounts.Create(username));
        }
    }
}
