using System;

namespace WinKeyer3
{
    public static class BufferCommands
    {
        private static byte pttByte = 0x18;
        private static byte keyBufferedByte = 0x19;
        private static byte waitByte = 0x1a;
        private static byte mergeLettersByte = 0x1b;
        private static byte bufferedSpeedChangeByte = 0x1c;
        //private static byte hscwSpeedChangeByte = 0x1d;
        private static byte cancelBufferedSpeedChangeByte = 0x1e;
        private static byte bufferedNopByte = 0x0f;
        public static byte[] BufferedNopCommand { get { return new byte[] { bufferedNopByte }; } }
        public static byte[] BufferedSpeedChangeCommand(int speed)
        {
            if (speed < 5 || speed > 99)
            {
                throw new Exception("Invalid speed parameter.");
            }
            return new byte[] { bufferedSpeedChangeByte, Convert.ToByte(speed) };
        }
        public static byte[] CancelBufferedSpeedChangeCommand { get { return new byte[] { cancelBufferedSpeedChangeByte }; } }
        public static byte[] HscwSpeedChangeCommand(int speed)
        {
            throw new NotImplementedException();
        }
        public static byte[] KeyBufferedCommand(int interval)
        {
            if (interval < 0 || interval > 99)
            {
                throw new Exception("Invalid interval parameter");
            }
            return new byte[] { keyBufferedByte, Convert.ToByte(interval) };
        }
        public static byte[] MergeLettersCommand { get { return new byte[] { mergeLettersByte }; } }
        public static byte[] PttCommand(bool state)
        {
            byte stateByte = state ? Convert.ToByte(1) : Convert.ToByte(0);
            return new byte[] { pttByte, stateByte };
        }
        public static byte[] WaitCommand(int duration)
        {
            if (duration < 0 || duration > 99)
            {
                throw new Exception("Invalid duration parameter");
            }
            return new byte[] { waitByte, Convert.ToByte(duration) };
        }
    }
}
