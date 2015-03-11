using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger : IDisposable
    {
        private readonly FileStream _memoryStream;
        private readonly StreamWriter _streamWriter;
        private bool _disposed;

        public MemoryStreamLogger()
        {
            _memoryStream = new FileStream(@"log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            _streamWriter = new StreamWriter(_memoryStream);
        }

        public void Log(string message)
        {
            _streamWriter.Write(message);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_streamWriter != null)
                        _streamWriter.Dispose();
                        
                    if (_memoryStream != null)
                        _memoryStream.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}