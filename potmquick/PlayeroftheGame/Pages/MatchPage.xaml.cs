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
        private static string apiPath = "http://api.potg-dev.org/umbraco/api/";
        private static HttpClient client;
        private string apiEndpoint = "";
        private int matchId;

        public MatchPage (int matchId)
		{
            this.matchId = matchId;
            client = new HttpClient();

            InitializeComponent ();
            GetMatch(matchId);
		}

	    public async void GetMatch(int matchId)
	    {
            apiEndpoint = "Match/GetMatch?matchId=";
            string url = apiPath + apiEndpoint;

            var response = await client.GetStringAsync( url + matchId);

	        Match match = JsonConvert.DeserializeObject<Match>(response);

	        BindingContext = match;
	    }


	    public async void OnTapped(object sender , EventArgs e)
	    {
	        Button btn = (Button)sender;
	        var matchId = int.Parse(btn.Text.ToString()) ;
	        var teamId = int.Parse(btn.CommandParameter.ToString());
            
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new VotePlayersPage(matchId: matchId, teamId: teamId));
        }

    }
}