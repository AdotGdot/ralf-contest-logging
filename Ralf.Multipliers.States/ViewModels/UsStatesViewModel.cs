using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ContestLogging.Common.ViewModels;
using Ralf.Multipliers.States.Models;
using Ralf.Multipliers.States.Types;
using System;
using System.Linq;

namespace Ralf.Multipliers.States.ViewModels
{
    public class UsStatesViewModel : BaseViewModel, IUsStatesViewModel
    {
        public UsStateList UsStateList { get; protected set; }
        public UsStatesViewModel(ILogService service)
            : base(service)
        {
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
            updateUsStateList();
        }

        private void onLogChangedNotification(object details)
        {
            updateUsStateList();
        }

        protected UsStateList getUsStateList()
        {
            return UsStateListBuilder.getUsStateList();
        }
        public string Title { get { return "US States"; } }
        protected void updateUsStateList()
        {
            UsStateList = getUsStateList();
            var worked = (from Qso qso in service.GetLog()
                          where !String.IsNullOrEmpty(qso.USState)
                          select qso.USState).Distinct();
            foreach (UsState usState in UsStateList)
            {
                usState.Worked = worked.Contains(usState.Abbr);
            }
            NotifyPropertyChanged("UsStateList");
        }
    }
}
