using System.Threading.Tasks;
using RockPaperScissors.Animation;
using RockPaperScissors.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RockPaperScissors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
	    readonly Storyboard _storyboard = new Storyboard();

        public enum State
	    {
            Main,
            Picking,
            Result
	    }

		public GamePage ()
		{
			InitializeComponent ();
		    NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new GamePageViewModel();
            _storyboard.Add(State.Main, new []
            {
                new ViewTransition(ResultsStack, AnimationType.Opacity, 0),
                new ViewTransition(StartGameLabel, AnimationType.Opacity, 1),
                new ViewTransition(StartButton, AnimationType.Opacity, 1),
                new ViewTransition(CountdownLabel, AnimationType.Opacity, 0),
                new ViewTransition(SelectionButtons, AnimationType.Opacity, 0),
                new ViewTransition(SelectionButtons, AnimationType.TranslationY, 50),
            });
		    _storyboard.Add(State.Picking, new[]
		    {
		        new ViewTransition(ResultsStack, AnimationType.Opacity, 0),
		        new ViewTransition(StartGameLabel, AnimationType.Opacity, 0),
		        new ViewTransition(StartButton, AnimationType.Opacity, 0),
		        new ViewTransition(CountdownLabel, AnimationType.Opacity, 1, 500),
		        new ViewTransition(CountdownLabel, AnimationType.Opacity, 0, 500, null, 500),
                new ViewTransition(CountdownLabel, AnimationType.Opacity, 1, 500, null, 1500),
                new ViewTransition(CountdownLabel, AnimationType.Opacity, 0, 500, null, 2500),
                new ViewTransition(CountdownLabel, AnimationType.Opacity, 1, 500, null, 3500),
                new ViewTransition(CountdownLabel, AnimationType.Opacity, 0, 500, null, 4500),
                new ViewTransition(SelectionButtons, AnimationType.Opacity, 1),
		        new ViewTransition(SelectionButtons, AnimationType.TranslationY, -50),
		    });
		    _storyboard.Add(State.Result, new[]
		    {
		        new ViewTransition(ResultsStack, AnimationType.Opacity, 1),
		        new ViewTransition(StartGameLabel, AnimationType.Opacity, 1),
		        new ViewTransition(StartButton, AnimationType.Opacity, 1),
		        new ViewTransition(CountdownLabel, AnimationType.Opacity, 0),
		        new ViewTransition(SelectionButtons, AnimationType.TranslationY, 50),
		        new ViewTransition(SelectionButtons, AnimationType.Opacity, 0),
            });
            BackButton.Clicked += BackButton_Clicked;

            _storyboard.Go(State.Main, false);
		}

        private async void BackButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
            BackButton.Clicked -= BackButton_Clicked;
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            StartButton.Clicked += StartButton_Clicked;
	    }

        private async void StartButton_Clicked(object sender, System.EventArgs e)
        {
            _storyboard.Go(State.Picking);
            CountdownLabel.Text = "3";
            await Task.Delay(1500);
            CountdownLabel.Text = "2";
            await Task.Delay(1500);
            CountdownLabel.Text = "1";
            await Task.Delay(1500);
            _storyboard.Go(State.Result);
        }

        protected override void OnDisappearing()
	    {
	        base.OnDisappearing();
	        StartButton.Clicked -= StartButton_Clicked;
        }
	}
}