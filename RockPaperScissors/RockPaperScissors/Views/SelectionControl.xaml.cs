using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RockPaperScissors.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectionControl : ContentView
	{
		public SelectionControl ()
		{
			InitializeComponent ();
		}
	}
}