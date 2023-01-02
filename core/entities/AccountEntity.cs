namespace tic_tac_toe.core.entities
{
    public class AccountEntity
    {
        public string name;
        public int userId;
        private int  winCount, loseCount;

        public AccountEntity(string user, int userId)
        {
            this.userId = userId;
            name = user;
            winCount = 0;
            loseCount = 0;
        }
    }
}