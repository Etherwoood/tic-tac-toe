using tic_tac_toe.core.repositories;

namespace tic_tac_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameRepository games = new GameRepository();
            AccountRepository accounts = new AccountRepository();
            GameController gameController = new GameController(games, accounts);
        }
    }
}


 