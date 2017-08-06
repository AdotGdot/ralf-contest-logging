using System;
using System.IO.Ports;
using System.Threading;

namespace YaesuXcvr
{
    public class CatPort
    {
        private object lockObject = new object();
        private SerialPort port;

        public CatPort(
            string commPortName,
            int baud,
            Parity parity,
            int dataBits,
            StopBits stopBits,
            int millisecondsToTimeOut)
        {
            port = new SerialPort(commPortName, baud, parity, dataBits, stopBits);
            port.ReadTimeout = millisecondsToTimeOut;
        }
        public bool IsOpen
        {
            get { return port.IsOpen; }
        }

        public void Open()
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
        }
        public void Close()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }

        /// <summary>
        /// A sychronous method that writes a CAT command and returns the response
        /// </summary>
        /// <param name="command">array of bytes containing CAT command</param>
        /// <param name="rxBytes">size of response</param>
        /// <returns>array of bytes containing response to CAT command.</returns>
        public byte[] ExecuteCommand(byte[] command, int rxBytes)
        {
            lock (lockObject)
            {
                byte[] bytes;
                try
                {
                    // start fresh
                    port.DiscardInBuffer();
                    port.DiscardOutBuffer();
                    // write the command
                    port.Write(command, 0, command.Length);
                    // wait for port to send command
                    while (port.BytesToWrite > 0) ;
                    // let SerialPort object's worker thread load the response buffer
                    Thread.Sleep(20);
                    bytes = getByteArray(rxBytes);
                    port.Read(bytes, 0, rxBytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                    bytes = new byte[rxBytes];
                    for (int i = 0; i < rxBytes; i++)
                    {
                        bytes[i] = 0x00;
                    }
                }
                return bytes;
            }
        }

        private byte[] getByteArray(int size)
        {
            byte[] bytes = new byte[size];
            for (int n = 0; n < size; n++)
            {
                bytes[n] = Convert.ToByte(0xff);
            }
            return bytes;
        }
    }
}