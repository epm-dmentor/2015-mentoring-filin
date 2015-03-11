using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Convestudo.Unmanaged
{
    public class FileWriter : IFileWriter, IDisposable
    {
        private readonly IntPtr _fileHandle;
        private bool _disposed;

        public FileWriter(string fileName)
        {
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(string str)
        {
            Byte[] bytes = GetBytes(str);

            uint bytesWritten = 0;
            WriteFile(_fileHandle, bytes, (uint) bytes.Length, ref bytesWritten, IntPtr.Zero);
            //throw new System.NotImplementedException();
        }

        public void WriteLine(string str)
        {
            Write(String.Format("{0}{1}", str, Environment.NewLine));
        }

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

        private void ThrowLastWin32Err()
        {
            Marshal.ThrowExceptionForHR(
                Marshal.GetHRForLastWin32Error());
        }

        /// <summary>
        ///     Converts string to byte array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetBytes(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    CloseHandle(_fileHandle);
                }
            }
            _disposed = true;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr hObject);
    }
}