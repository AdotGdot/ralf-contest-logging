using Prism.Commands;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public class QsoListViewModel : BaseViewModel, IQsoListViewModel
    {
        protected int logPageSize;
        public int LogPageSize {  get { return logPageSize; } }
        protected IList<Qso> getLog(int index, int count)
        {
            return service.GetLog((CurrentPage - 1) * logPageSize, logPageSize);
        }
        public QsoListViewModel(ILogService service, int logPageSize)
            : base(service)
        {
            this.logPageSize = logPageSize;
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Subscribe(details => onLogChanged());

            EditQso_Command = new DelegateCommand<object>(onEditQso_Command);
            NextPage_Command = new DelegateCommand<object>(onNextPage_Command);
            PreviousPage_Command = new DelegateCommand<object>(onPreviousPage_Command);
            EarliestPage_Command = new DelegateCommand<object>(onEarliestPage_Command);
            LatestPage_Command = new DelegateCommand<object>(onLatestPage_Command);

            loadLog();

        }

        private void onEditQso_Command(object commandParameter)
        {
            Qso qso = commandParameter as Qso;
            if (qso != null)
            {
                MessageSink.MessageBus.GetEvent<EditEntryNotification>().Publish(qso.Id);
            }
        }
        private void onPreviousPage_Command(object commandParameter)
        {
            if (CurrentPage < PagesAvailable)
            {
                CurrentPage++;
                loadLog();
            }
        }
        private void onNextPage_Command(object commandParameter)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                loadLog();
            }
        }
        private void onEarliestPage_Command(object commandParameter)
        {
            CurrentPage = PagesAvailable;
            loadLog();
        }
        private void onLatestPage_Command(object commandParameter)
        {
            CurrentPage = 1;
            loadLog();
        }

        private void onLogChanged()
        {
            loadLog();
        }

        private void loadLog()
        {
            QsoList = getLog((CurrentPage - 1) * logPageSize, logPageSize);
            setPaging();
        }

        private void setPaging()
        {
            PagesAvailable = getPageCount();
            CanNavigateToNextPage = CurrentPage != 1;
            CanNavigateToPreviousPage = PagesAvailable > 1 && CurrentPage != PagesAvailable;
            CanNavigateToEarliestPage = CanNavigateToPreviousPage;
            CanNavigateToLatestPage = CanNavigateToNextPage;
        }

        private int getPageCount()
        {
            int qsoCount = service.QsoCount;
            int pages = (qsoCount % logPageSize) != 0 ? 1 : 0;
            pages += (int)(qsoCount / logPageSize);
            return pages == 0 ? 1 : pages;
        }

        public DelegateCommand<object> EditQso_Command { get; set; }
        public DelegateCommand<object> NextPage_Command { get; set; }
        public DelegateCommand<object> PreviousPage_Command { get; set; }
        public DelegateCommand<object> EarliestPage_Command { get; set; }
        public DelegateCommand<object> LatestPage_Command { get; set; }

        private IList<Qso> qsoList = new List<Qso>();
        public IList<Qso> QsoList
        {
            get { return qsoList; }
            set
            {
                if (qsoList != value)
                {
                    qsoList = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool canNavigateToLatestPage;
        public bool CanNavigateToLatestPage
        {
            get { return canNavigateToLatestPage; }
            set
            {
                if (canNavigateToLatestPage != value)
                {
                    canNavigateToLatestPage = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool earliestPageAvailable;
        public bool CanNavigateToEarliestPage
        {
            get { return earliestPageAvailable; }
            set
            {
                if (earliestPageAvailable != value)
                {
                    earliestPageAvailable = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool canNavigateToNextPage;
        public bool CanNavigateToNextPage
        {
            get { return canNavigateToNextPage; }
            set
            {
                if (canNavigateToNextPage != value)
                {
                    canNavigateToNextPage = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool canNavigateToPreviousPage;
        public bool CanNavigateToPreviousPage
        {
            get { return canNavigateToPreviousPage; }
            set
            {
                if (canNavigateToPreviousPage != value)
                {
                    canNavigateToPreviousPage = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int currentPage = 1;
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int pagesAvailable;
        public int PagesAvailable
        {
            get { return pagesAvailable; }
            set
            {
                if (pagesAvailable != value)
                {
                    pagesAvailable = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
