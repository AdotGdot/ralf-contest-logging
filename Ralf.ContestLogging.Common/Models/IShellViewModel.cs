using System.Windows;
using System.Windows.Input;

namespace Ralf.ContestLogging.Common.Models
{
    public interface IShellViewModel
    {
        void OnKeyDown(object sender, KeyEventArgs e);
        Visibility KeyerControlVisibility { get; set; }
    }
}
