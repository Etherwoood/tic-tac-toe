using tic_tac_toe.domain;
using tic_tac_toe.app;
using System;

namespace tic_tac_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameRepository games = new GameRepository();
            AccountRepository accounts = new AccountRepository();
            GameController gameController = new GameController(games, accounts);
            AccountController accountController = new AccountController(accounts);

            View view = new View(accountController, gameController);
            view.Initialize();
        }
    }
}
