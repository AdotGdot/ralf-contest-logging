using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ContestLogging.Common.ViewModels;
using Ralf.Multipliers.Sections.Models;
using System;
using System.Linq;

namespace Ralf.Multipliers.Sections.ViewModels
{
    public abstract class BaseSectionsViewModel : BaseViewModel, ISectionsViewModel
    {
        public SectionList SectionList { get; protected set; }
        public BaseSectionsViewModel(ILogService service)
            : base(service)
        {
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
            updateSectionList();
        }

        private void onLogChangedNotification(object details)
        {
            updateSectionList();
        }

        protected abstract SectionList getSectionList();
        public abstract string Title { get; }
        protected void updateSectionList()
        {
            SectionList = getSectionList();
            var worked = (from Qso qso in service.GetLog()
                          where !String.IsNullOrEmpty(qso.ArrlSection)
                          select qso.ArrlSection).Distinct();
            foreach (Section section in SectionList)
            {
                section.Worked = worked.Contains(section.Abbr);
            }
            NotifyPropertyChanged("SectionList");
        }
    }
}
