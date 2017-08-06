using Prism.Commands;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.Multipliers.Counties.Interfaces;
using Ralf.Multipliers.Counties.Models;

namespace Ralf.Multipliers.Counties.ViewModels
{
    public class CountyListSelectionViewModel : CountyListViewModel, ICountyListSelectionViewModel
    {
        public CountyListSelectionViewModel(
            ILogService service, 
            ICountyListBuilder countyListBuilder, 
            string title,
            int columnCount) : base(service, countyListBuilder, title, columnCount)
        {
            CountySelected_Command = new DelegateCommand<object>(county => onCountySelection(county));
        }

        private void onCountySelection(object county)
        {
            MessageSink.MessageBus.GetEvent<GeographicAreaSelectionNotification>().Publish(county);
        }

        public DelegateCommand<object> CountySelected_Command { get; set; }
    }
}