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
		}
	}
}