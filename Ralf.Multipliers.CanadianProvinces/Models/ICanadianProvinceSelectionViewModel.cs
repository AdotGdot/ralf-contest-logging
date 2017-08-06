using Prism.Commands;

namespace Ralf.Multipliers.CanadianProvinces.Models
{
    public interface ICanadianProvinceSelectionViewModel : ICanadianProvinceViewModel
    {
        DelegateCommand<object> ProvinceSelected_Command { get; set; }
    }
}
