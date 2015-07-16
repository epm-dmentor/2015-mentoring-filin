using System.Windows;
using Command.ViewModel;

namespace Command.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PresenterViewModel();
        }
    }
}