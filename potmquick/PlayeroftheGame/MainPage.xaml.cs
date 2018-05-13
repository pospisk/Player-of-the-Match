using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlayeroftheGame
{
	public partial class MainPage : ContentPage
	{
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create( nameof(HeaderText), typeof(string), typeof(MainPage), "Matches", defaultBindingMode: BindingMode.OneWay);
        

        public MainPage()
		{
			InitializeComponent();
            
        }

        protected override void OnAppearing()
        {

        }

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

    }
}
