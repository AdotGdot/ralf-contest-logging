using System;

namespace WinKeyer3.KeyerEvents
{
    public class EchoEventArgs : EventArgs
    {
        private readonly string echo;
        public string Echo { get { return echo; } }

        public EchoEventArgs(string echo)
            : base()
        {
            this.echo = echo;
        }
    }
    public delegate void EchoEventHandler(object sender, EchoEventArgs e);
}
