using Prism.Commands;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.Multipliers.States.Models;

namespace Ralf.Multipliers.States.ViewModels
{
    public class UsStatesSelectionViewModel : UsStatesViewModel, IUsStatesSelectionViewModel
    {
        public UsStatesSelectionViewModel(ILogService service) : base(service)
        {
            StateSelected_Command = new DelegateCommand<object>(state => onStateSelection(state));
        }

        private void onStateSelection(object state)
        {
            MessageSink.MessageBus.GetEvent<GeographicAreaSelectionNotification>().Publish(state);
        }

        public DelegateCommand<object> StateSelected_Command { get; set; }
    }
}
