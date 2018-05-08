using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Input;
using PlayeroftheGame.Helpers;
using PlayeroftheGame.Services;
using Xamarin.Forms;


namespace PlayeroftheGame.ViewModels
{
    public class LoginViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string UsErNaMe { get; set; }
        public string PaSsWoRd { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(UsErNaMe, PaSsWoRd);

                    Settings.AccessToken = accesstoken;
                });
            }
        }

        public LoginViewModel()
        {
            UsErNaMe = Settings.Username;
            PaSsWoRd = Settings.Password;
        }
    }
}
