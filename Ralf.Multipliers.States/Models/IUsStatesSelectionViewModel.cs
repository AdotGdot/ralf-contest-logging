using Prism.Commands;

namespace Ralf.Multipliers.States.Models
{
    public interface IUsStatesSelectionViewModel : IUsStatesViewModel
    {
        DelegateCommand<object> StateSelected_Command { get; set; }
    }
}
