using System;
using tic_tac_toe.domain;
using tic_tac_toe.common;

namespace tic_tac_toe.app
{
    public class GameDto
    {
        public readonly int id;
        public readonly AccountDto? winner;
        public readonly AccountDto requester;
        public readonly AccountDto opponent;
        public readonly int bet;
        public readonly string[,] board;
        public readonly GameStatus status;

        public readonly int size;
        public GameDto (GameEntity game)
        {
            this.id = game.id;
            this.winner = game.winner == null ? null : new AccountDto(game.winner);
            this.requester = new AccountDto(game.requester);
            this.opponent = new AccountDto(game.opponent);
            this.bet = game.bet;
            this.board = game.GetBoard();
            this.status = game.status;
            this.size = game.size;
        }
    }
}