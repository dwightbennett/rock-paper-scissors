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

            switch (playerSelection)
            {
                case Selection.Rock:
                    if (computerSelection == Selection.Scissors || computerSelection == Selection.Lizard)
                    {
                        return GameResult.Player;
                    }
                    break;
                case Selection.Paper:
                    if (computerSelection == Selection.Rock || computerSelection == Selection.Spock)
                    {
                        return GameResult.Player;
                    }
                    break;
                case Selection.Scissors:
                    if (computerSelection == Selection.Paper || computerSelection == Selection.Lizard)
                    {
                        return GameResult.Player;
                    }
                    break;
                case Selection.Lizard:
                    if (computerSelection == Selection.Spock || computerSelection == Selection.Paper)
                    {
                        return GameResult.Player;
                    }
                    break;
                case Selection.Spock:
                    if (computerSelection == Selection.Scissors || computerSelection == Selection.Rock)
                    {
                        return GameResult.Player;
                    }
                    break;
            }
            return GameResult.Computer;
        }
    }
}
