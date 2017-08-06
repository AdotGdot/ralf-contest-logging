using Ralf.Multipliers.CanadianProvinces.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.CanadianProvinces.Views
{
    /// <summary>
    /// Interaction logic for CanadianProvincesView.xaml
    /// </summary>
    public partial class CanadianProvincesView : UserControl
    {
        public CanadianProvincesView(ICanadianProvinceViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
