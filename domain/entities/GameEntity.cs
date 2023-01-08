using tic_tac_toe.common;

namespace tic_tac_toe.domain
{
    public class GameEntity
    {
        public readonly AccountEntity requester, opponent;
        public readonly int id;
        public readonly int size;
        public readonly int bet;

        public GameStatus status { get; private set; }
        public AccountEntity? winner { get; private set; }
        int[,] board;
        public GameEntity(int id, AccountEntity requester, AccountEntity opponent, int bet)
        {
            this.id = id;
            this.bet = bet;
            this.requester = requester;
            this.opponent = opponent;
            this.status = GameStatus.PROCESS;
            this.size = 3;
            this.board = new int[this.size, this.size];
            this.ResetBoard();
        }

        public GameStatus Play (AccountEntity account, int x, int y)
        {
            if (this.status != GameStatus.PROCESS) {
                throw new System.Exception("error.game.ended");
            }

            if (this.GetAccountNextStep().id != account.id) {
                throw new System.Exception("error.game.wrong.move");
            }

            if (x > this.size || x < 0 || y > this.size || y < 0) {
                throw new System.Exception("error.game.wrong.move");
            }

            if (this.board[y, x] != -1) {
                throw new System.Exception("error.game.wrong.move");
            }

            this.board[y, x] = account.id;

            if (this.IsWin(account))
            {
                this.status = GameStatus.ENDED;
                this.winner = account;
                return this.status;
            }

            if (this.IsDraw()) {
                this.status = GameStatus.DRAW;
            }

            return this.status;
        }

        public string[,] GetBoard () {
            string[,] board = {
                { "  #  ", "  #  ", "  #  " },
                { "  #  ", "  #  ", "  #  " },
                { "  #  ", "  #  ", "  #  " },
            };

            for (int y = 0; y < this.size; y++)
            {
                for (int x = 0; x < this.size; x++)
                {
                    if (this.board[y, x] == -1) continue;
                    board[y, x] = this.board[y, x] == this.requester.id ? "  X  " : "  O  ";
                }
            }

            return board;
        }

        public bool IsWin (AccountEntity account)
        {
            bool TopRow = this.board[0, 0] == account.id 
                && this.board[0, 1] == account.id
                && this.board[0, 2] == account.id;

            bool MidRow = this.board[1, 0] == account.id 
                && this.board[1, 1] == account.id
                && this.board[1, 2] == account.id;

            bool BotRow = this.board[2, 0] == account.id 
                && this.board[2, 1] == account.id
                && this.board[2, 2] == account.id;

            bool FirCol = this.board[0, 0] == account.id 
                && this.board[1, 0] == account.id
                && this.board[2, 0] == account.id;

            bool SecCol = this.board[0, 1] == account.id 
                && this.board[1, 1] == account.id
                && this.board[2, 1] == account.id;

            bool ThiCol = this.board[0, 2] == account.id 
                && this.board[1, 2] == account.id
                && this.board[2, 2] == account.id;

            bool Diagon = this.board[0, 0] == account.id 
                && this.board[1, 1] == account.id
                && this.board[2, 2] == account.id;

            bool RevDia = this.board[0, 2] == account.id 
                && this.board[1, 1] == account.id
                && this.board[2, 0] == account.id;

            return TopRow 
                || MidRow
                || BotRow
                || FirCol
                || SecCol
                || ThiCol
                || Diagon
                || RevDia;
        }

        private bool IsDraw ()
        {
            for (var i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.board[i, j] == -1) return false; 
                }
            }

            return true;
        }

        private void ResetBoard ()
        {
            for (var i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.board[i, j] = -1; 
                }
            }
        }

        private AccountEntity GetAccountNextStep () {
            int requesterSteps = 0;
            int opponentSteps = 0;

            for (var i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.board[i, j] == this.requester.id) {
                        requesterSteps++;
                    } else if (this.board[i, j] != -1) {
                        opponentSteps++;
                    }
                }
            }

            return requesterSteps <= opponentSteps  ? this.requester : this.opponent;
        }
    }

}