using System;
using System.ServiceModel;

namespace WCFClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WcfConsumer();

            //var client = new JokeServiceClient();
            //Console.WriteLine(client.GetJokeAsync().Result.Value[0].Joke);

            Console.ReadKey();
        }

        private static async void WcfConsumer()
        {
            using (var channelFactory = new ChannelFactory<IJokeService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://kiedwm417488/Jokes/")))
            {
                channelFactory.Open();
                var wcfClient = await channelFactory.CreateChannel().GetJokeAsync();

                Console.WriteLine(wcfClient.Value[0].Joke);
            }
        }
    }
}