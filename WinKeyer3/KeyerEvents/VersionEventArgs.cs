using System;

namespace WinKeyer3.KeyerEvents
{
    public class VersionEventArgs : EventArgs
    {
        private readonly string version;
        public string Version { get { return version; } }

        public VersionEventArgs(string version)
            : base()
        {
            this.version = version;
        }
    }
    public delegate void VersionEventHandler(object sender, VersionEventArgs e);
}
