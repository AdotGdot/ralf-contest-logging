using Prism.Commands;

namespace Ralf.Multipliers.Counties.Models
{
    public interface ICountyListSelectionViewModel : ICountyListViewModel
    {
        DelegateCommand<object> CountySelected_Command { get; set; }
    }
}
