using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ContestLogging.Common.ViewModels;
using Ralf.Multipliers.MexicanStates.Models;
using System;
using System.Linq;

namespace Ralf.Multipliers.MexicanStates.ViewModels
{
    public class MexicanStatesViewModel : BaseViewModel, IMexicanStatesViewModel
    {
        public MexicanStateList MexicanStateList { get; protected set; }
        public MexicanStatesViewModel(ILogService logService)
            : base(logService)
        {
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
            updateMexicanStateList();
        }

        private void onLogChangedNotification(object details)
        {
            updateMexicanStateList();
        }

        protected MexicanStateList getMexicanStateList()
        {
            return MexicanStateListBuilder.getMexicanStateList();
        }
        public string Title { get { return "Mexican States"; } }
        protected void updateMexicanStateList()
        {
            MexicanStateList = getMexicanStateList();
            var worked = (from Qso qso in service.GetLog()
                          where !String.IsNullOrEmpty(qso.Multiplier)
                          && qso.AdifId == 50
                          select qso.Multiplier).Distinct();
            foreach (MexicanState mexicanState in MexicanStateList)
            {
                mexicanState.Worked = worked.Contains(mexicanState.Abbr);
            }
            NotifyPropertyChanged("MexicanStateList");
        }
    }
}
