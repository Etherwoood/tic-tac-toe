using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Win32;
using tic_tac_toe.core.entities;

namespace tic_tac_toe.core.repositories
{
    public class AccountRepository
    {
        private Dictionary<int, AccountEntity> list = new Dictionary<int,AccountEntity>();
        private static int id = 0;
        
        public IDictionary AddAccount(AccountEntity user)
        {
            id = GetNextId();
            list.Add(id, user);
            return list;
        }
        private static int GetNextId()
        {
            id += 1;
            return AccountRepository.id;
        }
        
        public AccountEntity GetOne(int gameId)
        {
            AccountEntity accountEntity = null;
            list.TryGetValue(gameId, out accountEntity);
            return accountEntity;
        }
    }
}