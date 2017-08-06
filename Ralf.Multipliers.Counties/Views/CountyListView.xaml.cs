using Ralf.Multipliers.Counties.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.Counties.Views
{
    /// <summary>
    /// Interaction logic for CountyListView.xaml
    /// </summary>
    public partial class CountyListView : UserControl
    {
        public CountyListView(ICountyListViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
