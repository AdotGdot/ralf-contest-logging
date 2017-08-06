using System;

namespace WinKeyer3
{
    public class IntermediateCommands
    {
        private static byte zeroByte = 0x00;
        //private static byte sideToneByte = 0x01;
        private static byte wpmSpeedByte = 0x02;
        private static byte weightingByte = 0x03;
        private static byte pttLeadTailByte = 0x04;
        private static byte setSpeedPotByte = 0x05;
        private static byte pauseStateByte = 0x06;
        private static byte getSpeedPotByte = 0x07;
        private static byte backspaceByte = 0x08;
        //private static byte setPinConfigByte = 0x09;
        private static byte clearBufferByte = 0x0a;
        private static byte keyImmediateByte = 0x0b;
        //private static byte setHscwByte = 0x0c;
        private static byte setFarnsWpmByte = 0x0d;
        private static byte setWinKeyerModeByte = 0x0e;
        //private static byte loadDefaultsByte = 0x0f;
        private static byte setKeyCompByte = 0x11;
        private static byte setPaddleSwitchpointByte = 0x12;
        private static byte nullByte = 0x13;
        private static byte softwarePaddleByte = 0x14;
        private static byte requestStatusByte = 0x15;
        //private static byte bufferPointerByte = 0x16;
        //private static byte setDitDahRatioByte = 0x17;
        public static byte[] BackspaceCommand()
        {
            return new byte[] { backspaceByte };
        }
        public static byte[] BufferPointerCommand(int[] values)
        {
            throw new NotImplementedException();
        }
        public static byte[] ClearBufferCommand { get { return new Byte[] { clearBufferByte }; } }
        public static byte[] GetSpeedPotCommand { get { return new byte[] { getSpeedPotByte }; } }
        public static byte[] KeyImmediateCommand(bool keyDown)
        {
            byte keyByte = keyDown ? Convert.ToByte(1) : Convert.ToByte(0);
            return new byte[] { keyImmediateByte, keyByte };
        }
        public static byte[] LoadDefaultsCommand(object[] values)
        {
            throw new NotImplementedException();
        }
        public static byte[] NullCommand { get { return new byte[] { nullByte }; } }
        public static byte[] PauseStateCommand(bool pause)
        {
            byte pauseByte = pause ? Convert.ToByte(1) : Convert.ToByte(0);
            return new byte[] { pauseStateByte, pauseByte };
        }
        public static byte[] PttLeadTailCommand(int leadTime, int tailTime)
        {
            if (leadTime < 0 || leadTime > 250)
            {
                throw new Exception("Invalid leadTime parameter.");
            }
            if (tailTime < 0 || tailTime > 250)
            {
                throw new Exception("Invalid tailTime parameter.");
            }
            return new byte[] { pttLeadTailByte, Convert.ToByte(leadTime), Convert.ToByte(tailTime) };
        }
        public static byte[] RequestStatusCommand { get { return new byte[] { requestStatusByte }; } }
        public static byte[] SetDitDahRatioCommand(int value)
        {
            throw new NotImplementedException();
        }
        public static byte[] SetFarnsWpmCommand(int speed)
        {
            if (speed < 10 || speed > 99)
            {
                throw new Exception("Invalid speed parameter.");
            }
            return new byte[] { setFarnsWpmByte, Convert.ToByte(speed) };
        }
        public static byte[] SetHscwCommand(int lpmRate)
        {
            throw new NotImplementedException();
        }
        public static byte[] SetKeyCompensationCommand(int keyingCompensation)
        {
            if (keyingCompensation < 0 || keyingCompensation > 250)
            {
                throw new Exception("Invalid keyingCompensation parameter.");
            }
            return new byte[] { setKeyCompByte, Convert.ToByte(keyingCompensation) };
        }
        public static byte[] SetPaddleSwitchpointCommand(int switchpoint)
        {
            if (switchpoint < 10 || switchpoint > 90)
            {
                throw new Exception("Invalid switchpoint parameter.");
            }
            return new byte[] { setPaddleSwitchpointByte, Convert.ToByte(switchpoint) };
        }
        public static byte[] SetPinConfigCommand()
        {
            throw new NotImplementedException();
        }
        public static byte[] SetSpeedPotCommand(int minimumSpeed, int maximumSpeed)
        {
            if (minimumSpeed < 5 || minimumSpeed > 99)
            {
                throw new Exception("Invalid minSpeed parameter.");
            }
            if (maximumSpeed < 5 || maximumSpeed > 99)
            {
                throw new Exception("Invalid maxSpeed parameter.");
            }
            if (maximumSpeed < minimumSpeed)
            {
                throw new Exception("maximumSpeed parameter is less than minimumSpeed parameter.");
            }
            int range = maximumSpeed - minimumSpeed;
            return new byte[] { setSpeedPotByte, Convert.ToByte(minimumSpeed), Convert.ToByte(range), zeroByte };
        }
        public static byte[] SetWinKeyerModeCommand(byte modeByte)
        {
            return new byte[] { setWinKeyerModeByte, modeByte };
        }
        public static byte[] SideToneCommand(bool paddleOnlySideTone, int audioFrequency)
        {
            throw new NotImplementedException();
        }
        public static byte[] SoftwarePaddleCommand(int paddleState)
        {
            if (paddleState < 0 || paddleState > 3)
            {
                throw new Exception("Invalid paddleState parameter.");
            }
            return new byte[] { softwarePaddleByte, Convert.ToByte(paddleState) };
        }
        public static byte[] SpeedCommand(int speed)
        {
            return new byte[] { wpmSpeedByte, Convert.ToByte(speed) };
        }
        public static byte[] WeightingCommand(int weight)
        {
            if (weight < 10 || weight > 90)
            {
                throw new Exception("Invalid weight parameter.");
            }
            return new byte[] { weightingByte, Convert.ToByte(weight) };
        }
    }
}