using System.Windows.Input;

namespace Command.ViewModel
{
    internal class PresenterViewModel : BaseViewModel
    {
        private readonly HttpContent content;
        private readonly FileList files;
        private readonly ProcessList processes;

        public PresenterViewModel()
        {
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