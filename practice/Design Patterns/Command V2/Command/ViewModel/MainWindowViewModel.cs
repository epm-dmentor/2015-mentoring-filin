using System.Windows.Input;
using Command.Commands;

namespace Command.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private const string FileList = "File List";
        private const string ProcessesList = "Show Running Processes";
        private const string RestContent = "Show content of a REST request";
        private readonly InvokerCommand invokeCommand;
        private bool canExecute = true;

        public MainWindowViewModel()
        {
            invokeCommand = new InvokerCommand();
            ShowContent = new RelayCommand(ShowOutput, param => canExecute);
        }

        public string FilesListContent
        {
            get { return FileList; }
        }

        public string ProcessesListContent
        {
            get { return ProcessesList; }
        }

        public string HttpContent
        {
            get { return RestContent; }
        }

        public bool CanExecute
        {
            get { return canExecute; }

            set { canExecute = value; }
        }

        public string DisplayText { get; set; }
        public ICommand ShowContent { get; set; }

        public void ShowOutput(object command)
        {
            invokeCommand.SetCommand(command);
            DisplayText = invokeCommand.ExecuteCommand();
            RaisePropertyChangedEvent("DisplayText");
        }
    }
}