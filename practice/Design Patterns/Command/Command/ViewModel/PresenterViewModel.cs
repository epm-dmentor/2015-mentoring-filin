using System.Windows.Input;
using Command.Commands;

namespace Command.ViewModel
{
    //BK: - Don't create DelegateCommands on fly. Create them in constructor.
    //    - Call  RaisePropertyChangedEvent("UpdateText"); from UpdateText property
    //    - Command Pattern is implemented incorrectly. You need to create command objects, whihc will execute work over some object (will populate that). After that you will have to retrieve it's results
    internal class PresenterViewModel : BaseViewModel
    {
        private readonly HttpContent content;
        private readonly FileList files;
        private readonly ProcessList processes;

        public PresenterViewModel()
        {
            //BK: Try to name classes in more explicit way. Names are not very clear.
            files = new FileList();
            processes = new ProcessList();
            content = new HttpContent();
        }

        public string UpdateText { get; set; }


        public ICommand GetFilesCommand
        {
            get { return new DelegateCommand(GetFiles); }
        }

        public ICommand GetProcessesCommand
        {
            get { return new DelegateCommand(GetProcesses); }
        }

        public ICommand GetContentCommand
        {
            get { return new DelegateCommand(GetContent); }
        }

        private void GetFiles()
        {
            UpdateText = files.RunCommand();
            RaisePropertyChangedEvent("UpdateText");
        }

        private void GetProcesses()
        {
            UpdateText = processes.RunCommand();
            RaisePropertyChangedEvent("UpdateText");
        }

        private void GetContent()
        {
            UpdateText = content.RunCommand();
            RaisePropertyChangedEvent("UpdateText");
        }
    }
}