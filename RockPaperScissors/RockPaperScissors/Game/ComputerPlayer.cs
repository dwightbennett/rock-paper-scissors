using RockPaperScissors.Data;
using System;

namespace RockPaperScissors.Game
{
    public static class ComputerPlayer
    {

        public static Selection GetComputerSelection()
        {
            var rand = new Random();

            var selection = rand.Next(1, 6);
            return (Selection) selection;
        }
    }
}
