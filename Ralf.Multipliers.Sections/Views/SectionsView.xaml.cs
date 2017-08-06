using Ralf.Multipliers.Sections.Models;
using System.Windows.Controls;

namespace Ralf.Multipliers.Sections.Views
{
    /// <summary>
    /// Interaction logic for SectionsView.xaml
    /// </summary>
    public partial class SectionsView : UserControl
    {
        public SectionsView(ISectionsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

