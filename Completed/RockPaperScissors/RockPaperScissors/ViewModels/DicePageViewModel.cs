using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUniversity.Infrastructure;

namespace RockPaperScissors.ViewModels
{
    public class DicePageViewModel : SimpleViewModel
	{
		private string diceRoll;

		public string DiceRoll
		{
			get => diceRoll;
			set => SetPropertyValue(ref diceRoll, value);
		}
		public ICommand RollDice => new Command(async () => await StartRoll());

		private async Task StartRoll()
		{

			var rand = new Random(DateTime.Now.Millisecond);

			for(var i =0; i<50; i++)
			{
				DiceRoll = rand.Next(1, 7).ToString();
				await Task.Delay(i * 5);
			}
			
		}
	}
}
