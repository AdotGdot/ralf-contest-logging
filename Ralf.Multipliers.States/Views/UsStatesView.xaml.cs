using Ralf.Multipliers.States.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.States.Views
{
    /// <summary>
    /// Interaction logic for UsStatesView.xaml
    /// </summary>
    public partial class UsStatesView : UserControl
    {
        public UsStatesView(IUsStatesViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}