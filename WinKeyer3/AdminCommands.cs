using System;

namespace WinKeyer3
{
    public class AdminCommands
    {
        private static byte adminByte = 0x00;
        private static byte resetByte = 0x01;
        private static byte openHostByte = 0x02;
        private static byte closeHostByte = 0x03;
        private static byte echoByte = 0x04;
        private static byte wk1ModeByte = 0x10;
        private static byte wk2ModeByte = 0x11;
        private static byte dumpEepromByte = 0x12;
        // difference is use of byte & its location in the command's byte array
        private static byte loadEepromByte = 0x13;
        private static byte nullByte = 0x13;
        private static byte standAloneMsgByte = 0x0e;
        private static byte loadX1ModeByte = 0x15;
        private static byte highBaudByte = 0x17;
        private static byte lowBaudByte = 0x18;
        private static byte wk3ModeByte = 0x20;
        private static byte readVccByte = 0x21;
        private static byte loadX2ModeByte = 0x22;

        public static byte[] CloseHostCommand { get { return new byte[] { adminByte, closeHostByte }; } }
        public static byte[] DumpEepromCommand { get { return new byte[] { adminByte, dumpEepromByte }; } }
        public static byte[] EchoCommand(char echo) { return new byte[] { adminByte, echoByte, Convert.ToByte(echo) }; }
        public static byte[] HighBaudCommand { get { return new byte[] { adminByte, highBaudByte }; } }
        public static byte[] LoadEepromCommand { get { return new byte[] { adminByte, loadEepromByte }; } }
        public static byte[] LoadX1Command { get { return new byte[] { adminByte, loadX1ModeByte }; } }
        public static byte[] LoadX2Command { get { return new byte[] { adminByte, loadX2ModeByte }; } }
        public static byte[] LowBaudCommand { get { return new byte[] { adminByte, lowBaudByte }; } }
        public static byte[] NopCommand { get { return new byte[] { nullByte, nullByte, nullByte, nullByte }; } }
        public static byte[] OpenHostCommand { get { return new byte[] { adminByte, openHostByte }; } }
        public static byte[] ReadVccCommand { get { return new byte[] { adminByte, readVccByte }; } }
        public static byte[] ResetCommand { get { return new byte[] { adminByte, resetByte }; } }
        public static byte[] StandAloneMsgCommand(int msgIndex) { return new byte[] { adminByte, standAloneMsgByte, Convert.ToByte(msgIndex) }; }
        public static byte[] Wk1ModeCommand { get { return new byte[] { adminByte, wk1ModeByte }; } }
        public static byte[] Wk2ModeCommand { get { return new byte[] { adminByte, wk2ModeByte }; } }
        public static byte[] Wk3ModeCommand { get { return new byte[] { adminByte, wk3ModeByte }; } }
    }
}