using System;
using System.IO;
using System.Text;

namespace Epam.NetMentoring.Patterns.Observer
{
    internal class LoggerSubscriber : ISubscriber
    {
        private readonly FileStream stream;
        private byte[] result;

        public LoggerSubscriber()
        {
            stream = new FileStream("./log.txt", FileMode.Create);
        }

        public void Update(string eventDetails)
        {
            result = Encoding.Default.GetBytes(eventDetails + Environment.NewLine);
            stream.Write(result, 0, result.Length);
            stream.Flush();
        }
    }
}