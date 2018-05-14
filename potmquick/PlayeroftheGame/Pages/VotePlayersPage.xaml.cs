using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayeroftheGame.interfaces;
using PlayeroftheGame.Models;
using PlayeroftheGame.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayeroftheGame.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VotePlayersPage : ContentPage
	{
        private static string apiPath = "http://api.potg-dev.org/umbraco/api/";
        private static HttpClient client;
        private string apiEndpoint = "";
        private int matchId;
        private int teamId;
        // hardcode much? 
        private int voteBatchId = 1116;

        public VotePlayersPage (int matchId, int teamId)
		{
            this.matchId = matchId;
            this.teamId = teamId;
            client = new HttpClient();

			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetPlayers(teamId);
        }

        public async void GetPlayers(int teamId)
        {
            apiEndpoint = "Player/getPlayers?parentId=";
            string url = apiPath + apiEndpoint;

            string response = await client.GetStringAsync(url + teamId);

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(response);

            PlayersListView.ItemsSource = players;
        }

        protected async Task<HttpResponseMessage> PostVote(string IMEI, int matchId, int playerId, int voteBatchId)
        {
            apiEndpoint = "Vote/commitVote";
            string url = apiPath + apiEndpoint;

            HttpResponseMessage res = null;

            Vote vote = new Vote
            {
                IMEI = IMEI,
                MatchId = matchId,
                PlayerId = playerId,
                VoteBatchId = voteBatchId
            };
            var jsonRequest = JsonConvert.SerializeObject(vote);

            try
            {
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                res = await client.PostAsync(url, content);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public async void VoteForPlayer(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            Player selectedPlayer = (e.SelectedItem as Player);

            IDevice device = DependencyService.Get<IDevice>();
            string IMEI = device.GetIdentifier();

            HttpResponseMessage res = await PostVote(IMEI, this.matchId, selectedPlayer.Id, this.voteBatchId);

            string statuscode = res.StatusCode.ToString();

            switch (statuscode)
            {
                case "Created":
                    await DisplayAlert("Sucsses", "Thanks for your vote", "dismiss");
                    break;
                case "Conflict":
                    await DisplayAlert("Sorry", "You have already voted in this match", "Okay");
                    break;
                case "BadRequest":
                    await DisplayAlert("Error", "Request error", "dismiss");
                    break;
                default:
                    await DisplayAlert("Error", "Internal error", "dismiss");
                    break;
            }
            
        }

    }
}