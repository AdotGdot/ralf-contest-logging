using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public abstract class SummaryViewModel : BaseViewModel, ISummaryViewModel
    {
        public SummaryViewModel(ILogService service)
            : base(service)
        {
            refreshSummary();
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
        }

        private void onLogChangedNotification(object details)
        {
            refreshSummary();
        }

        protected abstract void refreshSummary();
    }
}
