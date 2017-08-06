using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinKeyer3.KeyerEvents;

namespace WinKeyer3
{
    public class WKLite : IKeyer
    {
        private SerialPort port;

        private int currentSpeed;
        private int maximumSpeed;
        private int minimumSpeed;

        protected int baud = 1200;
        protected Parity parity = Parity.None;
        protected int dataBits = 8;
        protected StopBits stopBits = StopBits.One;
        protected int millisecondsToTimeOut = 100;
        protected string commPortName;
        protected bool versionFound = false;

        public event EchoEventHandler OnEchoReturned;
        public event SpeedPotEventHandler OnSpeedPotChanged;
        public event StatusEventHandler OnStatusReturned;
        public event VersionEventHandler OnVersionReturned;
        public int CurrentSpeed
        {
            get { return currentSpeed; }
            private set
            {
                if (currentSpeed != value)
                {
                    currentSpeed = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public WKLite(int minimumSpeed, int maximumSpeed, int desiredSpeed, string commPortName)
        {
            this.currentSpeed = desiredSpeed;
            this.maximumSpeed = maximumSpeed;
            this.minimumSpeed = minimumSpeed;
            this.commPortName = commPortName;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName]string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public void ClearBuffer()
        {
            write(IntermediateCommands.ClearBufferCommand);
        }

        public void Close()
        {
            closeHostMode();
            closeCommPort();
        }
        public void EchoChar(char c)
        {
            byte[] cmd = AdminCommands.EchoCommand(c);
            write(cmd);
        }
        public void GetSpeedPot()
        {
            write(IntermediateCommands.GetSpeedPotCommand);
        }
        public void GetVcc()
        {
            write(AdminCommands.ReadVccCommand);
        }

        public bool Open(string commPortName)
        {
            this.commPortName = commPortName;
            return Open();
        }
        public bool Open()
        {
            bool result = false;
            try
            {
                openCommPort();
                openHostMode();
                setSpeedPot();
                setSpeed(currentSpeed);
                result = true;
            }
            catch { }
            return result;
        }

        public void Reset()
        {
            write(AdminCommands.ResetCommand);
        }

        public void SendMessage(int msgNumber)
        {
            if (msgNumber > 0 || msgNumber < 7)
            {
                byte[] cmd = AdminCommands.StandAloneMsgCommand(msgNumber);
                write(cmd);
            }
        }

        public void SendMessage(string msg)
        {
            write(msg.ToUpper());
        }

        public void SetSpeed(int speed)
        {
            setSpeed(speed);
        }
        public void SetSpeedPot(int minimumSpeed, int maximumSpeed)
        {
            this.maximumSpeed = maximumSpeed;
            this.minimumSpeed = minimumSpeed;
            setSpeedPot();
        }

        #region private methods
        private void closeCommPort()
        {
            if (port != null)
                port.Close();
        }
        private void closeHostMode()
        {
            write(AdminCommands.CloseHostCommand);
        }
        private void openCommPort()
        {
            port = new SerialPort(commPortName, baud, parity, dataBits, stopBits);
            port.ReadTimeout = millisecondsToTimeOut;
            port.Open();
            port.DataReceived += port_DataReceived;
            port.DiscardInBuffer();
            port.DiscardOutBuffer();
        }
        private void openHostMode()
        {
            // just in case
            closeHostMode();
            Thread.Sleep(100);
            write(AdminCommands.OpenHostCommand);
            Thread.Sleep(100);
            write(AdminCommands.NopCommand);
            Thread.Sleep(100);
            setSpeed(currentSpeed);
            setSpeedPot();
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            byte[] buff = new byte[sp.BytesToRead];
            sp.Read(buff, 0, buff.Length);
            if ((buff[0] & 0xc0) == 0xc0) // status 
            {
                if (OnStatusReturned != null)
                {
                    StatusEventArgs args = new StatusEventArgs(buff[0].ToString());
                    OnStatusReturned(this, args);
                }
            }
            else if ((buff[0] & 0xc0) == 0x80) // speed pot 
            {
                if (OnSpeedPotChanged != null)
                {
                    int speed = calculateSpeedPotSetting(buff[0]);
                    currentSpeed = speed;
                    SpeedPotEventArgs args = new SpeedPotEventArgs(speed);
                    OnSpeedPotChanged(this, args);
                }
            }
            else // echo
            {
                if (!versionFound)
                {
                    versionFound = true;
                    if (OnVersionReturned != null)
                    {
                        VersionEventArgs args = new VersionEventArgs(buff[0].ToString());
                        OnVersionReturned(this, args);
                    }
                }
                else
                {
                    if (OnEchoReturned != null)
                    {
                        EchoEventArgs args = new EchoEventArgs(Encoding.ASCII.GetString(buff));
                        OnEchoReturned(this, args);
                    }
                }

            }
        }

        private int calculateSpeedPotSetting(byte b)
        {
            BitArray ba = new BitArray(new Byte[] { b });

            string s = "00";
            for (int i = ba.Length - 3; i >= 0; i--)
            {
                s += ba.Get(i) ? "1" : "0";
            }
            int sps = Convert.ToInt32(s, 2) + minimumSpeed;
            return sps;
        }

        private void setSpeed(int speed)
        {
            byte[] cmd = IntermediateCommands.SpeedCommand(speed);
            write(cmd);
            CurrentSpeed = speed;
        }
        private void setSpeedPot()
        {
            byte[] cmd = IntermediateCommands.SetSpeedPotCommand(minimumSpeed, maximumSpeed);
            write(cmd);
        }
        private void write(byte[] cmd)
        {
            if (port.IsOpen)
                port.Write(cmd, 0, cmd.Length);
            else
                MessageBox.Show("Keyer port not open.");
        }
        private void write(string msg)
        {
            if (port.IsOpen)
                port.Write(msg);
            else
                MessageBox.Show("Keyer port not open.");
        }
        #endregion
    }
}