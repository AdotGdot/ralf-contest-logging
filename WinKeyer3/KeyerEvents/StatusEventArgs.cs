using System;

namespace WinKeyer3.KeyerEvents
{
    public class StatusEventArgs : EventArgs
    {
        private readonly string status;
        public string Status { get { return status; } }

        public StatusEventArgs(string status)
            : base()
        {
            this.status = status;
        }
    }
    public delegate void StatusEventHandler(object sender, StatusEventArgs e);
}
