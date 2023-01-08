using tic_tac_toe.domain;

namespace tic_tac_toe.printer;

public class StatsPrinter
{
    private GameRepository games;
    private int rating = 0;
    private int winCount = 0;
    private int loseCount = 0;

    public StatsPrinter(GameRepository games)
    {
        this.games = games;
    }

    public void PrintStats(int id)
    {
        foreach (var game in games.list)
        {
            if (game.Value.requester.id == id || game.Value.opponent.id == id)
            {
                if (game.Value.winner.id == id)
                {
                    winCount++;
                    rating += game.Value.bet;
                }
                else
                {
                    loseCount++;
                    rating -= game.Value.bet;
                }
            }
        }
        Console.WriteLine("Wins:"+winCount);
        Console.WriteLine("Loses:"+loseCount);
        Console.WriteLine("Rating:"+rating);
    }
}