using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ralf.Multipliers.CanadianProvinces.Types
{
    public class CanadianProvince : INotifyPropertyChanged
    {
        private string abbr;
        private bool worked;
        private string name;
        public string Abbr
        {
            get { return abbr; }
            set
            {
                if (abbr != value)
                {
                    abbr = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
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

        public CanadianProvince()
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