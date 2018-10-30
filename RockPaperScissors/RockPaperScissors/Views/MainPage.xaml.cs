using RockPaperScissors.ViewModels;
using Xamarin.Forms;

namespace RockPaperScissors.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new MainPageViewModel();
        }
    }
}
