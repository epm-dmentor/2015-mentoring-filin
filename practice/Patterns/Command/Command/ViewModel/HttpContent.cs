using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Command.ViewModel
{
    internal class HttpContent
    {
        public string RunCommand()
        {
            try
            {
                var content = new HttpClient();
                Task<string> output = content.GetStringAsync("http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/");
                return output.Result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}