using System;
using System.IO;
using System.Text;

namespace Epam.NetMentoring.Patterns.Observer
{
    internal class LoggerSubscriber : ISubscriber, IDisposable
    {
        private readonly FileStream stream;
        private byte[] result;
        private bool disposed;

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

        public void Dispose()
        {
            Dispose(disposed);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) return;
            if (stream != null) 
                stream.Dispose();
            disposed = true;
        }
    }
}