using System;
using System.Diagnostics;
using System.Linq;

namespace Command.Commands
{
    internal class GetProcess : ITriggerCommand
    {
        public string RunCommand()
        {
            var ouput = string.Empty;
            try
            {
                var processes = Process.GetProcesses();

                return processes.Aggregate(ouput,
                    (currentProcess, nextProcess) => currentProcess + Environment.NewLine + nextProcess).Trim();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}