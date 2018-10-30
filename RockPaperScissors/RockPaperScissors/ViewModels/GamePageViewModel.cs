using RockPaperScissors.Data;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUniversity.Infrastructure;

namespace RockPaperScissors.ViewModels
{
    public class GamePageViewModel : SimpleViewModel
    {
        private Selection playerSelection;

        public Selection PlayerSelection
        {
            get => playerSelection;
            set => SetPropertyValue(ref playerSelection, value);
        }
        public ICommand ChoiceCommand => new Command((choice)=> AcceptPlayerChoice((Selection)choice));

        private void AcceptPlayerChoice(Selection choice)
        {
            PlayerSelection = choice;
        }

        public GamePageViewModel()
        {
        }
    }
}
