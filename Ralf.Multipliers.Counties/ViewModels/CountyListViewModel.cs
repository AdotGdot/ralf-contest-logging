using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ContestLogging.Common.ViewModels;
using Ralf.Multipliers.Counties.Interfaces;
using Ralf.Multipliers.Counties.Models;
using Ralf.Multipliers.Counties.Types;
using System;
using System.Linq;

namespace Ralf.Multipliers.Counties.ViewModels
{
    public class CountyListViewModel : BaseViewModel, ICountyListViewModel
    {
        private string title;
        private int columnCount;
        private ICountyListBuilder countyListBuilder;
        public CountyList CountyList { get; protected set; }
        public CountyListViewModel(
            ILogService service, 
            ICountyListBuilder countyListBuilder, 
            string title, 
            int columnCount) : base(service)
        {
            this.countyListBuilder = countyListBuilder;
            this.title = title;
            this.columnCount = columnCount;
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChangedNotification(details));
            updateCountyList();
        }

        public int ColumnCount
        {
            get { return columnCount; }
        }
        private void onLogChangedNotification(object details)
        {
            updateCountyList();
        }

        protected CountyList getCountyList()
        {
            return countyListBuilder.getCountyList();
        }
        public string Title { get { return title; } }
        protected void updateCountyList()
        {
            CountyList = getCountyList();
            var worked = (from Qso qso in service.GetLog()
                          where !String.IsNullOrEmpty(qso.ExchangeRcvd)
                          && qso.AdifId == 291
                          select qso.ExchangeRcvd).Distinct();
            foreach (County county in CountyList)
            {
                county.Worked = worked.Contains(county.Abbr);
            }
            NotifyPropertyChanged("CountyList");
        }
    }
}
