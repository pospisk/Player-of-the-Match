using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PlayeroftheGame.Helpers;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace PlayeroftheGame.Services
{
    internal class ApiServices
    {
        public async Task<string> LoginAsync(string UsErNaMe, string PaSsWoRd)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", UsErNaMe),
                new KeyValuePair<string, string>("password", PaSsWoRd),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, "http://api.potg-dev.org/Umbraco/oauth/" + "token");
            request.Content = new FormUrlEncodedContent(keyValues);

            Console.WriteLine(request.Content);
            Console.WriteLine(request);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            var accessToken = jwtDynamic.Value<string>("access_token");

            Settings.AccessTokenExpirationDate = accessTokenExpiration;

            Debug.WriteLine(accessTokenExpiration);

            Debug.WriteLine(content);

            return accessToken;
        }
    }
}
