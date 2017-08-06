using System;

namespace WinKeyer3.KeyerEvents
{
    public class SpeedPotEventArgs : EventArgs
    {
        private readonly int speed;
        public int Speed { get { return speed; } }

        public SpeedPotEventArgs(int speed)
            : base()
        {
            this.speed = speed;
        }
    }
    public delegate void SpeedPotEventHandler(object sender, SpeedPotEventArgs e);
}