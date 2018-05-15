using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLToolkit.Forms.Controls;
using PlayeroftheGame.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PlayeroftheGame
{
	public partial class App : Application
	{
        //private Xamarin.Forms.Button bthMatches;




        public App ()
		{
			InitializeComponent();

            //this.BindingContext = this.MainPage.BindingContext;

            //{

            //  //  BarBackgroundColor = Color.IndianRed,
            //  //  BarTextColor = Color.Blue
            //};

		    MainPage = new NavigationPage(new PlayeroftheGame.MatchesPage())
		    {
		        BarTextColor = Color.FromHex("#f6554d"),
		        BarBackgroundColor = Color.FromHex("#17191f")
		    };

            FlowListView.Init();

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public async void BtnMatches(object sender, EventArgs e)
        {

            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "PlayeroftheGame.MatchesPage")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new MatchesPage());
            }
            
        }

        public async void BtnLogin(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "PlayeroftheGame.LoginPage")
            {
                await((NavigationPage)Application.Current.MainPage).PushAsync(new LoginPage());
            }
            

        }

        private async void BtnBack(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PopAsync();
        }
    }
}
