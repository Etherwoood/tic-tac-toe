using System;
using tic_tac_toe.core.entities;
using tic_tac_toe.core.repositories;

namespace tic_tac_toe
{
    public class GameController
    {
        private GameRepository games;
        private AccountRepository accounts;
        public GameController (GameRepository games, AccountRepository accounts)
        {
            this.games = games;
            this.accounts = accounts;
        }
        
        public void GameStart(int requesterId, int opponentId)
        {
            AccountEntity requester = accounts.GetOne(requesterId);
            AccountEntity opponent = accounts.GetOne(opponentId);

            if (requester == null || opponent == null)
            {
                throw new Exception("error.account.not.found");
            }

            this.games.CreateGame(requester, opponent);
        }
    }
}