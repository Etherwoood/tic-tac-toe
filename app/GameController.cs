using System;
using tic_tac_toe.domain;

namespace tic_tac_toe.app
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
        
        public GameDto Start(int requesterId, int opponentId)
        {
            AccountEntity? requester = this.accounts.GetOne(requesterId);
            AccountEntity? opponent = this.accounts.GetOne(opponentId);

            if (requester == null || opponent == null)
            {
                throw new Exception("error.account.not.found");
            }

            return new GameDto(this.games.CreateGame(requester, opponent));
        }

        public GameDto Play (int gameId, int accountId, int x, int y) {
            GameEntity? game = this.games.GetOne(gameId);
            AccountEntity? account = this.accounts.GetOne(accountId);

            if (game == null) {
                throw new Exception("error.game.not.found");
            }

            if (account == null)
            {
                throw new Exception("error.account.not.found");
            }

            game.Play(account, x, y);

            return new GameDto(game);
        }

        public GameDto GetOne (int gameId) {
            GameEntity? game = this.games.GetOne(gameId);

            if (game == null) {
                throw new Exception("error.game.not.found");
            }

            return new GameDto(game);
        }
    }
}