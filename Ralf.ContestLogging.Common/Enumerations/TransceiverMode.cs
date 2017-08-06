namespace Ralf.ContestLogging.Common.Enumerations
{
    public enum TransceiverMode
    {
        LSB = 0x00,
        USB = 0x01,
        CW = 0x02,
        CWR = 0x03,
        AM = 0x04,
        FM = 0x08,
        DIG = 0x0a,
        PKT = 0x0c,
        FMN = 0x88,
        CW1 = 130,
        CWR1 = 131
    }

    public static class TransceiverModeExtensions
    {
        public static Mode ToMode(this TransceiverMode transceiverMode)
        {
            switch (transceiverMode)
            {
                case TransceiverMode.AM: return Mode.AM;
                case TransceiverMode.CW:
                case TransceiverMode.CW1:
                case TransceiverMode.CWR:
                case TransceiverMode.CWR1: return Mode.CW;
                case TransceiverMode.DIG: return Mode.Digital;
                case TransceiverMode.FM:
                case TransceiverMode.FMN: return Mode.FM;
                default: return Mode.Other;
                case TransceiverMode.LSB:
                case TransceiverMode.USB: return Mode.SSB;
                case TransceiverMode.PKT: return Mode.Packet;
            }
        }
    }
}