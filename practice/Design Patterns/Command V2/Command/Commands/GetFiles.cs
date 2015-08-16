using System;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Command.Commands
{
    internal class GetFiles : ITriggerCommand
    {
        public string RunCommand()
        {
            var ouput = string.Empty;

            var path = Interaction.InputBox("Please specify disk to display", "Confirming disk to display", @"c:\");

            try
            {
                var files = Directory.GetFiles(path);
                return files.Aggregate(ouput, (current, file) => current + Environment.NewLine + file).Trim();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}