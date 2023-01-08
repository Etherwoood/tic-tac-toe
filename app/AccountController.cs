using System;
using tic_tac_toe.domain;
using tic_tac_toe.printer;

namespace tic_tac_toe.app
{
    public class AccountController
    {
        private AccountRepository accounts;
        private StatsPrinter printer;
        public AccountController (AccountRepository accounts, StatsPrinter printer)
        {
           this.accounts = accounts;
           this.printer = printer;
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
        
        public void GetStats(string username)
        {
            int id = accounts.FindByUsername(username).id;
            Console.WriteLine("Stats for:"+$"{username}");
            printer.PrintStats(id);
        }
    }
}