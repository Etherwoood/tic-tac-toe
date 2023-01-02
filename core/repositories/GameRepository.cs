using System.Collections.Generic;
using tic_tac_toe.core.entities;

namespace tic_tac_toe.core.repositories
{
    public class GameRepository
    { 
        private Dictionary<int, GameEntity> dict = new Dictionary<int , GameEntity>();
        private static int id = 0;
        
        public  GameEntity CreateGame(AccountEntity requester, AccountEntity opponent)
        {
            int id = GetNextId();
            GameEntity gameEntity = new GameEntity(requester, opponent, id);
            dict.Add(id, gameEntity);
            return gameEntity;
        }
        
        private static int GetNextId()
        {
            id += 1;
            return GameRepository.id;
        }
    }
}