using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ContestLogging.Common.ViewModels;
using Ralf.Multipliers.CanadianProvinces.Models;
using Ralf.Multipliers.CanadianProvinces.Types;
using System;
using System.Linq;

namespace Ralf.Multipliers.CanadianProvinces.ViewModels
{
    public class CanadianProvinceViewModel : BaseViewModel, ICanadianProvinceViewModel
    {
        public CanadianProvinceList ProvinceList { get; protected set; }
        public CanadianProvinceViewModel(ILogService logService)
            : base(logService)
        {
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
            updateCanadianProvinceList();
        }

        private void onLogChangedNotification(object details)
        {
            updateCanadianProvinceList();
        }

        protected CanadianProvinceList getCanadianProvinceList()
        {
            return CanadianProvinceListBuilder.getCanadianProvinceList();
        }
        public string Title { get { return "Canadian Provinces"; } }
        protected void updateCanadianProvinceList()
        {
            ProvinceList = getCanadianProvinceList();
            var worked = (from Qso qso in service.GetLog()
                          where !String.IsNullOrEmpty(qso.Multiplier)
                          && qso.AdifId == 1
                          select qso.Multiplier).Distinct();
            foreach (CanadianProvince province in ProvinceList)
            {
                province.Worked = worked.Contains(province.Abbr);
            }
            NotifyPropertyChanged("ProvinceList");
        }
    }
}
