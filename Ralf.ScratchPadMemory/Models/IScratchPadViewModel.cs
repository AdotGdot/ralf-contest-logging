using Prism.Commands;
using Ralf.ScratchPadMemory.Types;
using System.Windows.Input;

namespace Ralf.ScratchPadMemory.Models
{
    public interface IScratchPadViewModel
    {
        string Callsign { get; set; }
        string ErrorMessage { get; set; }
        MemoryList Memories { get; set; }
        DelegateCommand<object> MemorySelected_Command { get; set; }
        DelegateCommand<object> AddMemory_Command { get; set; }
        DelegateCommand<object> DeleteMemory_Command { get; set; }
        DelegateCommand<object> ClearMemory_Command { get; set; }
        DelegateCommand<object> CloseView_Command { get; set; }
        void callsignTextBox_KeyUp(object sender, KeyEventArgs e);
    }
}
