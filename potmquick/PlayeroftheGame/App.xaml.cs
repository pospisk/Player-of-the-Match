using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace PlayeroftheGame
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage())
            //{

            //  //  BarBackgroundColor = Color.IndianRed,
            //  //  BarTextColor = Color.Blue
            //};
		    MainPage = new MatchesPage();
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
