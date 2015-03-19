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
            //BK: This is not about disposal, but more about style of coding. Try to avoid such hardcoding @"log.txt", change that to something more flexible (like passing this value outside to const) or at least put that to sting const
            _memoryStream = new FileStream(@"log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            _streamWriter = new StreamWriter(_memoryStream);
        }

        //BK: what will happen, if you call this after disposal?
        public void Log(string message)
        {
            _streamWriter.Write(message);
        }

        //BK: If you don't have unmanaged resources in your class and you're almost 100% sure they won't be incorporated soon, try to avoid (bool disposing) There is no much sense in using that, while we don't have unmanaged resources
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                //IT: do not change anything, just anwer the question - why the code you writen inside block if (disposing) ...
                //IT: what will happen if we remove if and run code in any case?
                if (disposing)
                {
                    if (_streamWriter != null)
                        _streamWriter.Dispose();
                        
                    if (_memoryStream != null)
                        _memoryStream.Dispose();
                }
            }
            //BK:Can we move that inside of if statement? If yes, where exactly and into which statement exactly?
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
	    GC.SuppressFinalize(this); 
        }
    }
}