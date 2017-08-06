using System.ComponentModel;
using WinKeyer3.KeyerEvents;

namespace WinKeyer3
{
    public interface IKeyer : INotifyPropertyChanged
    {
        event EchoEventHandler OnEchoReturned;
        event SpeedPotEventHandler OnSpeedPotChanged;
        event StatusEventHandler OnStatusReturned;
        event VersionEventHandler OnVersionReturned;
        int CurrentSpeed { get; }
        void ClearBuffer();
        void Close();
        void EchoChar(char c);
        void GetSpeedPot();
        void GetVcc();
        bool Open(string commPortName);
        void Reset();
        void SendMessage(int msg);
        void SendMessage(string msgNumber);
        void SetSpeed(int speed);
        void SetSpeedPot(int minimumSpeed, int maximumSpeed);
    }
}
