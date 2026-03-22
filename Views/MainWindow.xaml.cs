using ProjektRekrutacjaCore.ViewModels;
using System.Windows;

namespace ProjektRekrutacjaCore.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}