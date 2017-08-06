using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ralf.ContestLogging.Common.Types
{
    public class Zone : INotifyPropertyChanged
    {
        private int number;
        private bool worked;

        public int ZoneNumber
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool Worked
        {
            get { return worked; }
            set
            {
                if (worked != value)
                {
                    worked = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Zone()
        {
            Worked = false;
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