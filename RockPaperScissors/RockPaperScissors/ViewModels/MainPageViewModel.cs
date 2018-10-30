using RockPaperScissors.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUniversity.Infrastructure;

namespace RockPaperScissors.ViewModels
{
    public class MainPageViewModel : SimpleViewModel
    {
        public ICommand StartCommand => new DelegateCommand(async ()=> await NavigateToGame());

        public MainPageViewModel()
        {
        }

        private async Task NavigateToGame()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GamePage());
        }
    }
}
