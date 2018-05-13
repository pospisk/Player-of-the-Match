using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayeroftheGame.Models;
using PlayeroftheGame.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayeroftheGame.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VotePlayersPage : ContentPage
	{
        private static string apiPath = "http://www.api.potg-dev.org/umbraco/api/Player/getPlayers?parentId=";

        public VotePlayersPage (int matchId, int teamId)
		{
			InitializeComponent ();
		}
        public async void GetPlayers(int teamId)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(apiPath + teamId);

            var players = JsonConvert.DeserializeObject<List<Player>>(response);

            PlayersListView.ItemsSource = players;
        }

    }
}