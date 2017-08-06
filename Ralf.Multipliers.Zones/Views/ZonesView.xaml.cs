using Ralf.Multipliers.Zones.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.Zones.Views
{
    /// <summary>
    /// Interaction logic for ZonesView.xaml
    /// </summary>
    public partial class ZonesView : UserControl
    {
        public ZonesView(IZonesViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
