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
        public Match match;
        public Club club;

        public MatchPage (int matchId)
		{
            this.matchId = matchId;
            //this.match = new Match();
            //this.club = new Club();

            client = new HttpClient();


            InitializeComponent();

            startupMatchPage();

            BindingContext = match;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            

        }

        public async void startupMatchPage()
        {
            await GetMatch(matchId);

            await GetClub(match.ClubId);

        }

        public async Task GetMatch(int matchId)
	    {
            apiEndpoint = "Match/GetMatch?matchId=";
            string url = apiPath + apiEndpoint;

            var response = await client.GetStringAsync( url + matchId);

	        this.match = JsonConvert.DeserializeObject<Match>(response);
            
	    }

        public async Task GetClub(int clubId)
        {
            apiEndpoint = "Club/GetClub?clubId=";
            string url = apiPath + apiEndpoint;

            var response = await client.GetStringAsync(url + clubId);

            this.club = JsonConvert.DeserializeObject<Club>(response);
            
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