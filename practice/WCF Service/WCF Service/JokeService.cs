using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF_Service
{
    public class JokeService : IJokeService
    {
        public async Task<Joke> GetJokeAsync()
        {
            OperationContext.Current.OperationCompleted += (sender, args) =>
                Console.WriteLine("Operation completed");

            var proxy = new WebProxy("primary-proxy", 8080)
            {
                Credentials = CredentialCache.DefaultCredentials
            };

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
                PreAuthenticate = true,
                UseDefaultCredentials = false
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                client.BaseAddress = new Uri("http://api.icndb.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("jokes/random/1");

                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsAsync<Joke>();
            }
        }
    }
}