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

            public string HeaderText = "hello";



        public App ()
		{
			InitializeComponent();

            
		    MainPage = new NavigationPage(new PlayeroftheGame.MainPage());


            BindingContext = HeaderText;


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
