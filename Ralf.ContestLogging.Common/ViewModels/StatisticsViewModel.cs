using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public abstract class StatisticsViewModel : BaseViewModel, IStatisticsViewModel
    {
        public StatisticsViewModel(ILogService service)
            : base(service)
        {
            refreshStatistics();
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
        }

        private void onLogChangedNotification(object details)
        {
            refreshStatistics();
        }

        protected abstract void refreshStatistics();
    }
}