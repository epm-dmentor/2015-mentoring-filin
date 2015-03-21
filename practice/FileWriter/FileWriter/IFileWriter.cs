using System;

namespace Epam.NetMentoring.Unmanaged
{
    public interface IFileWriter : IDisposable
    {
        void Write(string str);
        void WriteLine(string str);
    }
}