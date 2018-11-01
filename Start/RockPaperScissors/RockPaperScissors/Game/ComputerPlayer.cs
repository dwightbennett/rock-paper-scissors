using RockPaperScissors.Data;
using System;

namespace RockPaperScissors.Game
{
    public static class ComputerPlayer
    {

        public static Selection GetComputerSelection()
        {
            var rand = new Random(DateTime.Now.Second);

            var selection = rand.Next(1, 4);// 6);
            return (Selection) selection;
        }
    }
}
