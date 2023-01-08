using tic_tac_toe.domain;
using tic_tac_toe.app;
using System;
using tic_tac_toe.printer;

namespace tic_tac_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameRepository games = new GameRepository();
            AccountRepository accounts = new AccountRepository();
            GameController gameController = new GameController(games, accounts);
            StatsPrinter printer = new StatsPrinter(games);
            AccountController accountController = new AccountController(accounts, printer);
            View view = new View(accountController, gameController);
            view.Initialize("Oleg", "Sergey", 30);
            view.Initialize("Oleg", "Sergey", 14);
            accountController.GetStats("Oleg");
        }
    }
}