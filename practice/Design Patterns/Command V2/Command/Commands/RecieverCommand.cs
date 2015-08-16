namespace Command.Commands
{
    internal class RecieverCommand
    {
        private readonly ITriggerCommand receiver;

        public RecieverCommand(ITriggerCommand receiver)
        {
            this.receiver = receiver;
        }

        public string Execute()
        {
            return receiver.RunCommand();
        }
    }
}