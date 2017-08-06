using System.Configuration;
using System.Windows;

namespace Ralf.ContestShell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            this.Title = ConfigurationManager.AppSettings["ShellCaption"];
        }
    }
}
