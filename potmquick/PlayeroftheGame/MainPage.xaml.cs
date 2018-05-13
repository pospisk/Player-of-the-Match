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
	public partial class MainPage : ContentPage
	{
       
        public MainPage()
		{
			InitializeComponent();


            Models.Page currentPage = new Models.Page
            {
                HeaderText = "Heading"
            };

            BindingContext = currentPage;

        }

        protected override void OnAppearing()
        {
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
