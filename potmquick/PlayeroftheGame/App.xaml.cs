using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLToolkit.Forms.Controls;
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

            //MainPage = new NavigationPage(new LoginPage())
            //{

            //  //  BarBackgroundColor = Color.IndianRed,
            //  //  BarTextColor = Color.Blue
            //};
		    MainPage = new NavigationPage(new PlayeroftheGame.MainPage());

            //btnMatches.Clicked += (s, e) => Navigation.PushAsync(new MatchesPage());



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
            if (page != "PlayeroftheGame.pages.MatchesPage")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new MatchesPage());
            }
            
        }

        public async void BtnLogin(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "PlayeroftheGame.pages.LoginPage")
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
