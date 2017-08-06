using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ContestLogging.Common.ViewModels;
using Ralf.Multipliers.Zones.Models;
using System.Linq;

namespace Ralf.Multipliers.Zones.ViewModels
{
    public class CqZonesViewModel : BaseViewModel, IZonesViewModel
    {
        public ZoneList ZoneList { get; protected set; }
        public CqZonesViewModel(ILogService service)
            : base(service)
        {
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
            updateZoneList();
        }

        private void onLogChangedNotification(object details)
        {
            updateZoneList();
        }

        protected ZoneList getZoneList()
        {
            return ZoneListBuilder.getCqZoneList();
        }
        public string Title { get { return "CQ Zones"; } }
        protected void updateZoneList()
        {
            ZoneList = getZoneList();
            var worked = (from Qso qso in service.GetLog()
                          select qso.CqZone).Distinct();
            foreach (Zone zone in ZoneList)
            {
                zone.Worked = worked.Contains(zone.ZoneNumber);
            }
            NotifyPropertyChanged("ZoneList");
        }
    }
}
