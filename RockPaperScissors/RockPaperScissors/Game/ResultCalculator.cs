using RockPaperScissors.Data;

namespace RockPaperScissors.Game
{
    public static class ResultCalculator
    {
        public static GameResult DeclareWinner(Selection playerSelection, Selection computerSelection)
        {
            if (playerSelection == computerSelection)
            {
                return GameResult.Tied;
            }

            return GameResult.Player;
        }
    }
}
