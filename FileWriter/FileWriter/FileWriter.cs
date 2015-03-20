using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Convestudo.Unmanaged
{
    public class FileWriter : IFileWriter
    {
        private readonly IntPtr _fileHandle;
        private bool _disposed;

        public FileWriter(string fileName)
        {
            //BK:I would recomend to consider some another place for create file. PLease think of some. What if user will create FileWriter, but won't write anything?
            //BK: Also what if user will try to create few file writer instances for the same file? You need to provide some good logic for thta case.
            _fileHandle = CreateFile(
                fileName,
                DesiredAccess.Write,
                ShareMode.Write,
                IntPtr.Zero,
                CreationDisposition.CreateNew,
                FlagsAndAttributes.Normal,
                IntPtr.Zero);

            //ThrowLastWin32Err();
        }
        
        public void Write(string str)
        {
            //BK: What if user will call dispose and then call this method?
            //BK: Get bytes is used only once and it is very small. Do you really need separate method for that?
            Byte[] bytes = GetBytes(str);

            uint bytesWritten = 0;
            WriteFile(_fileHandle, bytes, (uint) bytes.Length, ref bytesWritten, IntPtr.Zero);
            //throw new System.NotImplementedException();
        }

        public void WriteLine(string str)
        {
            //BK: What if user will call dispose and then call this method?
            //BK: String format is excessive here. Please have a look at it's code implementation - this is overhead. Just use string concatamations in such cases
            Write(String.Format("{0}{1}", str, Environment.NewLine));
        }


        //Try to use #region and #endregion, this will make your code more readable
        /// <summary>
        ///     Creates file
        ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx" />
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CreateFile(string lpFileName, DesiredAccess dwDesiredAccess, ShareMode dwShareMode,
            IntPtr lpSecurityAttributes, CreationDisposition dwCreationDisposition,
            FlagsAndAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

       
        /// <summary>
        ///     Writes data into a file
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="aBuffer"></param>
        /// <param name="cbToWrite"></param>
        /// <param name="cbThatWereWritten"></param>
        /// <param name="pOverlapped"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool WriteFile(IntPtr hFile, Byte[] aBuffer, UInt32 cbToWrite,
            ref UInt32 cbThatWereWritten, IntPtr pOverlapped);

        /// <summary>
        ///     Converts string to byte array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetBytes(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hObject);

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                //IT: you want to say, that if we disposing resources from finalizer we do not need to close handle?
                //IT: what should be inside shuch kind of block and why?
                
                ////According to dispose patern we should free any unmanaged objects here, so code should look like:
                CloseHandle(_fileHandle);
                //BK: You don't have managed resources here. So remove that
                if (disposing)
                {
                     //Here we free managed objects
                }
            }
           
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FileWriter()
        {
            Dispose(false);
        }

    }
}
