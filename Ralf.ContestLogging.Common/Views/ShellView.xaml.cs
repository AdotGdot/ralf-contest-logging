using Ralf.ContestLogging.Common.Models;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : UserControl
    {
        public ShellView(IShellViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            KeyDown += viewModel.OnKeyDown;
        }
    }
}
