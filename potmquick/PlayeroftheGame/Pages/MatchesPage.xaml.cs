using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlayeroftheGame.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayeroftheGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchesPage : ContentPage
	{
	    private SKPaint redFillPaint = new SKPaint()
	    {
            Style = SKPaintStyle.Fill,
            Color = SKColors.OrangeRed
	    };

	    private SKPaint blueFillPaint = new SKPaint()
	    {
	        Style = SKPaintStyle.Fill,
	        Color = SKColors.DarkSlateBlue
	    };

        public MatchesPage ()
		{
			InitializeComponent ();
            GetMatches();

        }

	    private void OnPaintSample(object sender, SKPaintSurfaceEventArgs e)
	    {
	        SKSurface surface = e.Surface;
	        SKCanvas canvas = surface.Canvas;

	        int width = e.Info.Width;
	        int height = e.Info.Height;

            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 250f);
	        canvas.DrawCircle(-50,0, 70, redFillPaint);
            canvas.DrawCircle(50,0, 70, blueFillPaint);
	    }

	    public async void GetMatches()
	    {
	        HttpClient client = new HttpClient();

	        var response = await client.GetStringAsync("http://www.api.potg-dev.org/umbraco/api/match/getmatches?parentid=1071");

	        var matches = JsonConvert.DeserializeObject<List<Match>>(response);

	        MatchesListView.ItemsSource = matches;
	    }

	    public async void GetMatch(int Id)
	    {
	        HttpClient client = new HttpClient();

	        var response = await client.GetStringAsync("http://www.api.potg-dev.org/umbraco/api/match/getmatches?parentid=" + Id);

	        var match = JsonConvert.DeserializeObject<List<Match>>(response);

	        //MatchListView.ItemsSource = match;
	    }





        public void ListClicked(object sender, SelectedItemChangedEventArgs e)
	    {
	        if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

	            var poopynumber = (e.SelectedItem as Match).Id ;


            ((ListView)sender).SelectedItem = null; // de-select the row

        }
	}
}