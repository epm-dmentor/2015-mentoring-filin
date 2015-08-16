using System;
using System.Net.Http;

namespace Command.Commands
{
    internal class GetHttpContent : ITriggerCommand
    {
        public string RunCommand()
        {
            try
            {
                var content = new HttpClient();
                var output = content.GetStringAsync("http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/");
                return output.Result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}