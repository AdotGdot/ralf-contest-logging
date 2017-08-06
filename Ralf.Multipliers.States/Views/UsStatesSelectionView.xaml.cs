using Ralf.Multipliers.States.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.States.Views
{
    /// <summary>
    /// Interaction logic for UsStatesSelectionView.xaml
    /// </summary>
    public partial class UsStatesSelectionView : UserControl
    {
        public UsStatesSelectionView(IUsStatesSelectionViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

