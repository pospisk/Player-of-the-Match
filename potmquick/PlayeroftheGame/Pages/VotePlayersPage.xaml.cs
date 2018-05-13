using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayeroftheGame.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VotePlayersPage : ContentPage
	{
		public VotePlayersPage (int matchId, int teamId)
		{
			InitializeComponent ();
		}
	}
}