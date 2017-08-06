using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public abstract class BaseViewModel : IBaseViewModel
    {
        protected ILogService service;

        public BaseViewModel(ILogService service)
        {
            this.service = service;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName]string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
