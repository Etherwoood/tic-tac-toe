
using tic_tac_toe.app;
using tic_tac_toe.common;
using System;

namespace tic_tac_toe
{
    class View
    {

        private readonly AccountController accounts;
        private readonly GameController games;

        public View (AccountController accounts, GameController games) {
            this.accounts = accounts;
            this.games = games;
        }

        public void Initialize()
        {

            AccountDto requester = this.accounts.Create("X");
            AccountDto opponent = this.accounts.Create("O");

            GameDto game = this.games.Start(requester.id, opponent.id);

            AccountDto turner = requester;

            while (game.status == GameStatus.PROCESS)
            {
                try {
                    Console.Clear();
                    Console.WriteLine(game.status);
                    this.PrintBoard(game);

                    Console.WriteLine($"{turner.username}'s turn");

                    Console.Write("x coord: ");
                    int x = Convert.ToInt32(Console.ReadLine())-1;

                    Console.Write("y coord: ");
                    int y = Convert.ToInt32(Console.ReadLine())-1;

                    game = this.games.Play(game.id, turner.id, x, y);
                    turner = turner.id == requester.id ? opponent : requester;

                    Console.Clear();
                } catch (Exception e) {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine($"{game.winner?.username} is win !");
        }

        private void PrintBoard(GameDto game)
        {
            for (var i = 0; i < game.size; i++)
            {
                for (int j = 0; j < game.size; j++)
                {
                    Console.Write(game.board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
