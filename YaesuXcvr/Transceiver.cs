using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System;
using System.IO.Ports;

namespace YaesuXcvr
{
    public class Transceiver : ITransceiver, IDisposable
    {
        private const int baud = 38400;
        private const Parity parity = Parity.None;
        private const int dataBits = 8;
        private const StopBits stopBits = StopBits.Two;
        private const int millisecondsToTimeOut = 100;

        private readonly byte[] setSplitOffBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x82 };
        private readonly byte[] setSplitOnBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x02 };
        private readonly byte[] readDataBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x03 };
        private readonly byte[] toggleVfoBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x81 };

        private CatPort port;
        protected double lastFrequency;
        protected TransceiverMode lastRigMode;

        private byte[] YaesuDigitsToHex = new byte[]
        {
            0x00, 0x01, 0x02, 0x03,0x04, 0x05, 0x06, 0x07,0x08, 0x09,
            0x10, 0x11, 0x12, 0x13,0x14, 0x15, 0x16, 0x17,0x18, 0x19,
            0x20, 0x21, 0x22, 0x23,0x24, 0x25, 0x26, 0x27,0x28, 0x29,
            0x30, 0x31 ,0x32, 0x33,0x34, 0x35, 0x36, 0x37,0x38, 0x39,
            0x40, 0x41, 0x42, 0x43,0x44, 0x45, 0x46, 0x47,0x48, 0x49,
            0x50, 0x51, 0x52, 0x53,0x54, 0x55, 0x56, 0x57,0x58, 0x59,
            0x60, 0x61, 0x62, 0x63,0x64, 0x65, 0x66, 0x67,0x68, 0x69,
            0x70, 0x71, 0x72, 0x73,0x74, 0x75, 0x76, 0x77,0x78, 0x79,
            0x80, 0x81, 0x82, 0x83,0x84, 0x85, 0x86, 0x87,0x88, 0x89,
            0x90, 0x91, 0x92, 0x93,0x94, 0x95, 0x96, 0x97,0x98, 0x99
        };

        public Transceiver(string commPortName, int millisecondsToTimeOut)
        {
            // if a mock is used there will be no comm port
            try
            {
                initializeCatPort(commPortName, baud, parity, dataBits, stopBits, millisecondsToTimeOut);
            }
            catch
            {

            }
        }

        public void Dispose()
        {
            Close();
        }
        #region interface implementation
        public TransceiverData ReadTransceiverData()
        {
            TransceiverData data = new TransceiverData() { Success = false, Frequency = 0.0, TransceiverMode = TransceiverMode.CW };
            try
            {
                byte[] responseBytes = port.ExecuteCommand(readDataBytes, 5);

                lastFrequency = getFrequency(responseBytes);
                data.Frequency = lastFrequency;

                lastRigMode = ((TransceiverMode)responseBytes[4]);
                data.TransceiverMode = lastRigMode;

                data.Success = data.Frequency != 0.0;
                if (!data.Success)
                    throw new Exception("Failed to read frequency and mode.");
            }
            catch (Exception ex)
            {
                data.Success = false;
                data.ErrorMsg = "Failed to read frequency and mode.";
                data.ExceptionMsg = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return data;
        }

        public Band SetFrequency(double frequency)
        {
            Band band = frequency.GetBand();
            try
            {
                byte[] requestBytes = operatingFrequencyToBytes(frequency);
                byte[] responseBytes = port.ExecuteCommand(requestBytes, 5);

                if (responseBytes[4] == 0x00)
                    throw new Exception("Failed to set frequency.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return band;
        }

        public void ToggleVfo()
        {
            try
            {
                byte[] responseBytes = port.ExecuteCommand(toggleVfoBytes, 5);
                if (responseBytes[4] == 0x00)
                    throw new Exception("Failed to toggle VFOs.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetVfosIdentical()
        {
            try
            {
                if (lastFrequency != 0.0)
                {
                    // toggle VFO
                    this.ToggleVfo();
                    // set mode
                    this.SetMode(lastRigMode);
                    // set frequency 
                    this.SetFrequency(lastFrequency);
                    // toggle vfo
                    this.ToggleVfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetMode(TransceiverMode mode)
        {
            try
            {
                byte[] requestBytes = new byte[] { (byte)mode, 0x00, 0x00, 0x00, 0x07 };
                byte[] responseBytes = port.ExecuteCommand(requestBytes, 5);

                if (responseBytes[4] == 0x00)
                    throw new Exception("Failed to set mode.");
            }
            catch
            {
            }
        }

        public void SetSplitOn()
        {
            try
            {
                byte[] responseBytes = port.ExecuteCommand(setSplitOnBytes, 5);

                if (responseBytes[4] == 0x00)
                    throw new Exception("Failed to turn split on.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetSplitOff()
        {
            try
            {
                byte[] responseBytes = port.ExecuteCommand(setSplitOffBytes, 5);

                if (responseBytes[4] == 0x00)
                    throw new Exception("Failed to turn split off.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
        #region private methods
        private void initializeCatPort(
            string commPortName,
            int baud,
            Parity parity,
            int dataBits,
            StopBits stopBits,
            int millisecondsToTimeOut)
        {
            port = new CatPort(commPortName, baud, parity, dataBits, stopBits, millisecondsToTimeOut);
            port.Open();
        }
        private void Open()
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
        }

        private void Close()
        {
            if (port.IsOpen)
            {
                port.Close();
            }
        }

        private byte[] operatingFrequencyToBytes(double kilocycles)
        {
            byte[] bytes = new byte[5];

            string freq = kilocyclesToMegacycleString(kilocycles, 3, 5);
            for (int byteIndex = 0; byteIndex < 4; byteIndex++)
            {
                string s = freq.Substring(0, 2);
                int index = Convert.ToInt32(s);
                freq = freq.Remove(0, 2);
                bytes[byteIndex] = YaesuDigitsToHex[index];
            }
            bytes[4] = 0x01;

            return bytes;
        }

        private string kilocyclesToMegacycleString(double kilocycles, int padLeft, int padRight)
        {
            string megacycles = (kilocycles / 1000).ToString();
            if (!megacycles.Contains("."))
            {
                megacycles += ".0";
            }

            string[] parts = megacycles.Split('.');
            string intValue = parts[0];
            string decValue = parts[1];

            intValue = intValue.PadLeft(padLeft, '0');
            decValue = decValue.PadRight(padRight, '0');
            return intValue + decValue;
        }

        private double getFrequency(byte[] responseBytes)
        {
            string b0 = responseBytes[0].ToString("x").PadLeft(2, '0');
            string b1 = responseBytes[1].ToString("x").PadLeft(2, '0');
            string b2 = responseBytes[2].ToString("x").PadLeft(2, '0');
            string b3 = responseBytes[3].ToString("x").PadLeft(2, '0');

            return Convert.ToDouble((b0 + b1 + b2 + b3).Insert(6, "."));
        }
        #endregion
    }
}