using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using PlayeroftheGame.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayeroftheGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClubPage : ContentPage
    {
		public ClubPage ()
		{
			InitializeComponent ();

            GetClub();

		}

        public async void GetClub()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://api.potg-dev.org/umbraco/Api/Clubs/GetClubs?id=1071");

            var clubs = JsonConvert.DeserializeObject<List<Club>>(response);

           // testListView.FlowItemsSource = clubs;
        }

        //async void OnClubOpen(object sender, ItemTappedEventArgs e)
        //{
        //    await NavigationPage(new TeamPage());
        //}
    }
}