namespace Command.Commands
{
    internal class InvokerCommand
    {
        private readonly GetFiles files;
        private readonly GetHttpContent httpContent;
        private readonly GetProcess processes;
        private RecieverCommand command;

        public InvokerCommand()
        {
            files = new GetFiles();
            processes = new GetProcess();
            httpContent = new GetHttpContent();
        }

        public string ExecuteCommand()
        {
            return command.Execute();
        }

        public void SetCommand(object commandParam)
        {
            switch (commandParam.ToString())
            {
                case "GetFiles":
                    command = new RecieverCommand(files);
                    break;
                case "GetProcesses":
                    command = new RecieverCommand(processes);
                    break;
                case "GetHTTPContent":
                    command = new RecieverCommand(httpContent);
                    break;
            }
        }
    }
}