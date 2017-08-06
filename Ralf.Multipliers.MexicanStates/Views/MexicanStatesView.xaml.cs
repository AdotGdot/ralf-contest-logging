using Ralf.Multipliers.MexicanStates.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.MexicanStates.Views
{
    /// <summary>
    /// Interaction logic for MexicanStatesView.xaml
    /// </summary>
    public partial class MexicanStatesView : UserControl
    {
        public MexicanStatesView(IMexicanStatesViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
