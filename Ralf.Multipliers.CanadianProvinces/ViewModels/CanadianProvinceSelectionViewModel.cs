using Prism.Commands;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.Multipliers.CanadianProvinces.Models;

namespace Ralf.Multipliers.CanadianProvinces.ViewModels
{
    public class CanadianProvinceSelectionViewModel : CanadianProvinceViewModel, ICanadianProvinceSelectionViewModel
    {
        public CanadianProvinceSelectionViewModel(ILogService service) : base(service)
        {
            ProvinceSelected_Command = new DelegateCommand<object>(province => onProvinceSelection(province));
        }

        private void onProvinceSelection(object province)
        {
            MessageSink.MessageBus.GetEvent<GeographicAreaSelectionNotification>().Publish(province);
        }

        public DelegateCommand<object> ProvinceSelected_Command { get; set; }
    }
}