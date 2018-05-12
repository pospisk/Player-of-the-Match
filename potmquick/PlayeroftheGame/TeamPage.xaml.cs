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

namespace PlayeroftheGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TeamPage : ContentPage
	{
		public TeamPage ()
		{
			InitializeComponent ();
		}


	    //public async void GetTeam()
	    //{
	    //    HttpClient client = new HttpClient();

	    //    var response = await client.GetStringAsync("http://api.potg-dev.org/umbraco/Api/Club/GetClubs?id=1071");

	    //    var teams = JsonConvert.DeserializeObject<List<Team>>(response);

	    //    teamListView.FlowItemsSource = teams;
	    //}

	    //async void OnTeamOpen(object sender, ItemTappedEventArgs e)
	    //{
	    //    //await Navigation.PushAsync(new TeamPage());

	    //}
    }
}