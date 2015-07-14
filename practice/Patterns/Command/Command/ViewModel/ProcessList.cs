using System;
using System.Diagnostics;
using System.Linq;

namespace Command.ViewModel
{
    internal class ProcessList
    {
        public string RunCommand()
        {
            string ouput = string.Empty;
            try
            {
                Process[] processes = Process.GetProcesses();
                return
                    processes.Aggregate(ouput,
                        (currentProcess, nextProcess) => currentProcess + Environment.NewLine + nextProcess).Trim();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}