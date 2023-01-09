namespace tic_tac_toe.domain
{
    public class GameRepository
    { 
        private static int id = 0;
        private Dictionary<int, GameEntity> list = new Dictionary<int,GameEntity>();
        
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

        public GameEntity[] FindByAccount (AccountEntity account) {
            return this.list.Values
                .Where((game) => game.requester == account || game.opponent == account)
                .ToArray();
        }

        private static int GetNextId()
        {
            id += 1;
            return GameRepository.id;
        }
    }
}