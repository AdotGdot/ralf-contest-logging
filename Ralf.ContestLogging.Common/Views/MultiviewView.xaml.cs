using Ralf.ContestLogging.Common.Models;
using System.Windows.Controls;

namespace Ralf.ContestLogging.Common.Views
{
    /// <summary>
    /// Interaction logic for MultiviewView.xaml
    /// </summary>
    public partial class MultiviewView : UserControl
    {
        public MultiviewView(IMultiviewViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

