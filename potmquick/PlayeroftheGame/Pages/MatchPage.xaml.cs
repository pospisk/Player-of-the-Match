using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayeroftheGame.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayeroftheGame.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchPage : ContentPage
	{
	    private static string apiPath = "http://api.potg-dev.org/umbraco/Api/Match/GetMatch?matchId=";


        public MatchPage (int matchId)
		{
			InitializeComponent ();
            GetMatch(matchId);
		}

	    public async void GetMatch(int matchId)
	    {
	        HttpClient client = new HttpClient();

	        var response = await client.GetStringAsync( apiPath + matchId);

	        Match match = JsonConvert.DeserializeObject<Match>(response);

	        BindingContext = match;

	    }
	}
}