using Ralf.Multipliers.CanadianProvinces.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.CanadianProvinces.Views
{
    /// <summary>
    /// Interaction logic for CanadianProvinceSelectionView.xaml
    /// </summary>
    public partial class CanadianProvinceSelectionView : UserControl
    {
        public CanadianProvinceSelectionView(ICanadianProvinceSelectionViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
