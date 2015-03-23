﻿using System;
using System.IO;

namespace Epam.NetMentoring
{
	public class MemoryStreamLogger : IDisposable
	{
		private readonly FileStream _memoryStream;
		private readonly StreamWriter _streamWriter;
		private const string LogFile = "log.txt";
		private bool _disposed;

		public MemoryStreamLogger()
		{
			//BK: This is not about disposal, but more about style of coding. Try to avoid such hardcoding @"log.txt", change that to something more flexible (like passing this value outside to const) or at least put that to sting const
			//F: Corrected. 
			_memoryStream = new FileStream(LogFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
			_streamWriter = new StreamWriter(_memoryStream);
		}

		//BK: what will happen, if you call this after disposal?
		//F: ObjectDisposedException will occure
		public void Log(string message)
		{
			_streamWriter.Write(message);
		}

		
		
		//protected virtual void Dispose(bool disposing)
		//{
		//    if (!_disposed)
		//    {
		//        //IT: do not change anything, just anwer the question - why the code you writen inside block if (disposing) ...
		//        //IT: what will happen if we remove if and run code in any case?
				
				
		//    //F: There are 2 scenarios:
		//// If disposing equals true, the method has been called directly or indirectly by a user's code. 
		////Managed and unmanaged resources can be disposed. 
		//// If disposing equals false, the method has been called from inside the finalizer and we should not reference other objects. Only unmanaged resources must be disposed. 
				
		//        if (disposing)
		//        {
		//            if (_streamWriter != null)
		//                _streamWriter.Dispose();
						
		//            if (_memoryStream != null)
		//                _memoryStream.Dispose();
		//        }
				
		//         _disposed = true;
		//    }
		//}

		//BK: If you don't have unmanaged resources in your class and you're almost 100% sure they won't be incorporated soon, try to avoid (bool disposing) There is no much sense in using that, while we don't have unmanaged resources
		//F: 
		public void Dispose()
		{
			if (_disposed) return;

			if (_streamWriter != null)
				_streamWriter.Dispose();

			if (_memoryStream != null)
				_memoryStream.Dispose();

			_disposed = true;
			GC.SuppressFinalize(this);
		}
	}
}
