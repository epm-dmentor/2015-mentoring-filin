using System;
using System.IO;
using System.Linq;

namespace Command.Commands
{
    internal class FileList
    {
        public string RunCommand()
        {
            string ouput = string.Empty;
            try
            {
                string[] files = Directory.GetFiles(@"c:\");
                return files.Aggregate(ouput, (current, file) => current + Environment.NewLine + file).Trim();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}