using RockPaperScissors.Data;
using System;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Input;
using RockPaperScissors.Game;
using Xamarin.Forms;
using XamarinUniversity.Infrastructure;

namespace RockPaperScissors.ViewModels
{
    public class GamePageViewModel : SimpleViewModel
    {
        private Selection computerSelection;

        private Selection playerSelection;
        private string winner;
        private string ability;
        private string loser;
        private string gameResult;

        public Selection ComputerSelection
        {
            get => computerSelection;
            set => SetPropertyValue(ref computerSelection, value);
        }

        public Selection PlayerSelection
        {
            get => playerSelection;
            set => SetPropertyValue(ref playerSelection, value);
        }

        public string Winner
        {
            get => winner;
            set => SetPropertyValue(ref winner, value);
        }

        public string Loser
        {
            get => loser;
            set => SetPropertyValue(ref loser, value);
        }

        public string Ability
        {
            get => ability;
            set => SetPropertyValue(ref ability, value);
        }

        public string GameResult
        {
            get => gameResult;
            set => SetPropertyValue(ref gameResult, value);
        }


        public ICommand StartCommand => new Command(async ()=> await StartGame());

        private async Task StartGame()
        {
            Reset();
            ComputerSelection = ComputerPlayer.GetComputerSelection();
            await Task.Delay(3500);
            DeclareWinner();
        }

        private void Reset()
        {
            PlayerSelection = Selection.None;
            ComputerSelection = Selection.None;
            Winner = string.Empty;
            Loser = string.Empty;
            Ability = string.Empty;
            GameResult = string.Empty;
        }

        private void DeclareWinner()
        {
            if (PlayerSelection == Selection.None)
            {
                HandlePlayerDidntPick();
                return;
            }

            var result = ResultCalculator.DeclareWinner(PlayerSelection, ComputerSelection);

            switch (result)
            {
                case Data.GameResult.Tied:
                    HandleTie();
                    break;
                case Data.GameResult.Player:
                    FinishGame(PlayerSelection, ComputerSelection);
                    GameResult = "Player wins";
                    break;
                case Data.GameResult.Computer:
                    FinishGame(ComputerSelection, PlayerSelection);
                    GameResult = "Computer wins";
                    break;
            }

        }

        private void HandlePlayerDidntPick()
        {
            Winner = "You";
            Ability = "Didn't";
            Loser = "Pick";
            GameResult = "Try making a selection next time";

        }

        private void FinishGame(Selection gameWinner, Selection gameLoser)
        {
            Winner = gameWinner.ToString();
            Loser = gameLoser.ToString();
            Ability = AbilityCalculator.GetAbility(gameWinner, gameLoser);
        }

        private void HandleTie()
        {
            Winner = PlayerSelection.ToString();
            Loser = ComputerSelection.ToString();
            Ability = "Ties";
            GameResult = "Player and Computer tied";
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
