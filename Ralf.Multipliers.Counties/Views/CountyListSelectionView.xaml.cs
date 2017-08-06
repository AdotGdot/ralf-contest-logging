using Ralf.Multipliers.Counties.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.Counties.Views
{
    /// <summary>
    /// Interaction logic for CountyListSelectionView.xaml
    /// </summary>
    public partial class CountyListSelectionView : UserControl
    {
        public CountyListSelectionView(ICountyListSelectionViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
