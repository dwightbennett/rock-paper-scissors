using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissors.Data;

namespace RockPaperScissors.Game
{
    public static class AbilityCalculator
    {
        private static Dictionary<Selection, Dictionary<Selection, string>> abilities =
            new Dictionary<Selection, Dictionary<Selection, string>>
            {
                {
                    Selection.Rock, new Dictionary<Selection, string>
                    {
                        {Selection.Scissors, "Crushes"},
                        {Selection.Lizard, "Crushes"}
                    }
                },
                {
                    Selection.Paper, new Dictionary<Selection, string>
                    {
                        {Selection.Rock, "Covers"},
                        {Selection.Spock, "Disproves"}
                    }
                },
                {
                    Selection.Scissors, new Dictionary<Selection, string>
                    {
                        {Selection.Paper, "Cuts"},
                        {Selection.Lizard, "Decapitates"}
                    }
                },
                {
                    Selection.Lizard, new Dictionary<Selection, string>
                    {
                        {Selection.Spock, "Poisons"},
                        {Selection.Paper, "Eats"}
                    }
                },
                {
                    Selection.Spock, new Dictionary<Selection, string>
                    {
                        {Selection.Scissors, "Smashes"},
                        {Selection.Rock, "Vaporizes"}
                    }
                }
            };

        public static string GetAbility(Selection gameWinner, Selection gameLoser)
        {
            if (abilities.ContainsKey(gameWinner) && abilities[gameWinner].ContainsKey(gameLoser))
            {
                return abilities[gameWinner][gameLoser];
            }

            return string.Empty;
        }
    }
}
