using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Win32;
using tic_tac_toe.domain;
using tic_tac_toe.printer;

namespace tic_tac_toe.domain
{
    public class AccountRepository
    {
        private Dictionary<int, AccountEntity> list = new Dictionary<int,AccountEntity>();
        private static int id = 0;

        public AccountEntity Create(string username)
        {
            int id = GetNextId();
            AccountEntity account = new AccountEntity(username, id);
            list.Add(id, account);
            return account;
        }
        private static int GetNextId()
        {
            id += 1;
            return AccountRepository.id;
        }
        
        public AccountEntity? GetOne(int id)
        {
            AccountEntity? account = null;
            list.TryGetValue(id, out account);
            return account;
        }
        public AccountEntity? FindByUsername (string username)
        {
            foreach (AccountEntity account in this.list.Values)
            {
                if (account.username == username) return account;
            }

            return null;
        }
    }
}