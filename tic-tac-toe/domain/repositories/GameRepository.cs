using System.Collections.Generic;
using tic_tac_toe.domain;

namespace tic_tac_toe.domain
{
    public class GameRepository
    { 
        private static int id = 0;
        public Dictionary<int, GameEntity> list = new Dictionary<int,GameEntity>();
        
        public GameEntity CreateGame(AccountEntity requester, AccountEntity opponent, int bet)
        {
            int id = GetNextId();
            GameEntity game = new GameEntity(id, requester, opponent, bet);
            list.Add(id, game);
            return game;
        }
        
        public GameEntity? GetOne(int id)
        {
            GameEntity? game = null;
            list.TryGetValue(id, out game);
            return game;
        }

        private static int GetNextId()
        {
            id += 1;
            return GameRepository.id;
        }
    }
}