using tic_tac_toe.app;
using tic_tac_toe.common;
using System;
using tic_tac_toe.domain;

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

            AccountDto oleg = this.accounts.Create("Oleg");
            AccountDto sergey = this.accounts.Create("Sergey");

            this.PlayGame(oleg, sergey, 30);
            this.PlayGame(oleg, sergey, 15);  

            this.PrintStats(oleg);      
        }

        private void PlayGame (AccountDto requester, AccountDto opponent, int bet) {
            GameDto game = this.games.Start(requester.id, opponent.id, bet);

            AccountDto turner = requester;

            while (game.status == GameStatus.PROCESS)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                try {
                    Console.Clear();
                    Console.WriteLine("Game session #"+$"{game.id+" ("+requester.username+$" vs "+opponent.username})");
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

            if (game.status != GameStatus.DRAW)
            {
                
                Console.WriteLine($"{game.winner?.username} is win !");   
            }
            else
            {
                Console.WriteLine("Draw !!!");   
            }
        }

        private void PrintBoard(GameDto game)
        {
            for (var i = 0; i < game.size; i++)
            {
                for (int j = 0; j < game.size; j++)
                {
                    Console.Write($"  {game.board[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        public void PrintStats(AccountDto account)
        {

            int winCount = 0;
            int rating = 0;
            int loseCount = 0;

            GameDto[] games = this.games.FindByAccount(account.id);

            foreach (var game in games)
            {
                if (game.requester.id == account.id || game.opponent.id == account.id)
                {
                    if (game.winner?.id == account.id)
                    {
                        winCount++;
                        rating += game.bet;
                    }
                    else
                    {
                        loseCount++;
                        rating -= game.bet;
                    }
                }
            }
            Console.WriteLine("Wins: "+winCount);
            Console.WriteLine("Loses: "+loseCount);
            Console.WriteLine("Rating: "+rating);
        }
    }
}