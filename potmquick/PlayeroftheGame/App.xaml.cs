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
        private Xamarin.Forms.Button bthMatches;

		public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage())
            //{

            //  //  BarBackgroundColor = Color.IndianRed,
            //  //  BarTextColor = Color.Blue
            //};
		    MainPage = new NavigationPage(new PlayeroftheGame.MainPage());

            

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
	}
}
