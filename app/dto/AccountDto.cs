using System;
using tic_tac_toe.domain;

namespace tic_tac_toe.app
{
    public class AccountDto
    {
        public readonly int id;
        public readonly string username;  
        public AccountDto (AccountEntity account)
        {
            this.id = account.id;
            this.username = account.username;
        }
    }
}