using RockPaperScissors.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RockPaperScissors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		public GamePage ()
		{
			InitializeComponent ();
		    NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new GamePageViewModel();
            BackButton.Clicked += BackButton_Clicked;
		}

        private async void BackButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
            BackButton.Clicked -= BackButton_Clicked;
        }
    }
}