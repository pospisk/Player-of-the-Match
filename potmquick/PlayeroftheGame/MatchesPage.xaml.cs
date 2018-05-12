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
	public partial class MatchesPage : ContentPage
	{
		public MatchesPage ()
		{
			InitializeComponent ();
            GetMatches();

		}


	    public async void GetMatches()
	    {
	        HttpClient client = new HttpClient();

	        var response = await client.GetStringAsync("http://www.api.potg-dev.org/umbraco/api/match/getmatches?parentid=1071");

	        var matches = JsonConvert.DeserializeObject<List<Match>>(response);

	        MatchesListView.ItemsSource = matches;
	    }
    }
}