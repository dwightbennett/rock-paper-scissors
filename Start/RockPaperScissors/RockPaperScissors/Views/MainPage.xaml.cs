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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartButton.Clicked += StartButton_Clicked;
        }

        private async void StartButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            StartButton.Clicked -= StartButton_Clicked;
        }
    }
}
