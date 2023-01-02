namespace tic_tac_toe.core.entities
{
    public class GameEntity
    {
        public readonly AccountEntity requester, opponent;
        public readonly int id;

        public GameEntity(AccountEntity requester, AccountEntity opponent, int id)
        {
            this.id = id;
            this.requester = requester;
            this.opponent = opponent;
        }
    }
}