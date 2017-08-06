﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ralf.Multipliers.States.Types
{
    public class UsState : INotifyPropertyChanged
    {
        private string abbr;
        private bool worked;

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

        public UsState()
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