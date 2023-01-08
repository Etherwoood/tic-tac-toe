namespace tic_tac_toe.domain
{
    public class AccountEntity
    {
        public string username;
        public int id;

        public AccountEntity(string username, int id)
        {
            this.id = id;
            this.username = username;
        }
    }
}