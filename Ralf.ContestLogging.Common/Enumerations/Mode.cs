namespace Ralf.ContestLogging.Common.Enumerations
{
    public enum Mode
    {
        Other = 0,
        CW = 1,
        AM = 2,
        SSB = 3,
        RTTY = 4,
        TOR = 5,
        FM = 6,
        Packet = 7,
        PSK31 = 8,
        Digital = 9
    }
    public static class ModeExtensions
    {
        public static Mode ToMode(this string modeName)
        {
            switch (modeName)
            {
                case "CW":
                case "CWR":
                case "A1":
                    return Mode.CW;
                case "AM":
                case "A3":
                    return Mode.AM;
                case "SSB":
                case "LSB":
                case "USB":
                case "A3J":
                    return Mode.SSB;
                case "RTTY":
                    return Mode.RTTY;
                case "TOR":
                case "AMTOR":
                case "SITOR":
                    return Mode.TOR;
                case "FM":
                case "FMN":
                    return Mode.FM;
                case "PKT":
                case "Packet":
                    return Mode.Packet;
                case "PSK31":
                    return Mode.PSK31;
                case "Digital":
                    return Mode.Digital;
            }
            return Mode.Other;
        }
        public static Mode ModeUp(this Mode mode)
        {
            switch (mode)
            {
                case Mode.CW: return Mode.AM;
                case Mode.AM: return Mode.SSB;
                case Mode.SSB: return Mode.RTTY;
                case Mode.RTTY: return Mode.TOR;
                case Mode.TOR: return Mode.FM;
                case Mode.FM: return Mode.Packet;
                case Mode.Packet: return Mode.PSK31;
                case Mode.PSK31: return Mode.Digital;
                case Mode.Digital: return Mode.CW;
                default: return Mode.Other;
            }
        }
        public static Mode ModeDown(this Mode mode)
        {
            switch (mode)
            {
                case Mode.CW: return Mode.Digital;
                case Mode.AM: return Mode.CW;
                case Mode.SSB: return Mode.AM;
                case Mode.RTTY: return Mode.SSB;
                case Mode.TOR: return Mode.RTTY;
                case Mode.FM: return Mode.TOR;
                case Mode.Packet: return Mode.FM;
                case Mode.PSK31: return Mode.Packet;
                case Mode.Digital: return Mode.PSK31;
                default: return Mode.Other;
            }
        }
        public static TransceiverMode ToTransceiverMode(this Mode mode, double frequency)
        {
            switch (mode)
            {
                case Mode.AM: return TransceiverMode.AM;
                default:
                case Mode.CW: return TransceiverMode.CW;
                case Mode.PSK31:
                case Mode.RTTY:
                case Mode.TOR:
                case Mode.Digital: return TransceiverMode.DIG;
                case Mode.FM: return TransceiverMode.FM;
                case Mode.Packet: return TransceiverMode.PKT;
                case Mode.SSB: return frequency < 14000 ? TransceiverMode.LSB : TransceiverMode.USB;
            }
        }
        public static TransceiverMode ToTransceiverMode(this Mode mode)
        {
            switch (mode)
            {
                case Mode.AM: return TransceiverMode.AM;
                default:
                case Mode.CW: return TransceiverMode.CW;
                case Mode.PSK31:
                case Mode.RTTY:
                case Mode.TOR:
                case Mode.Digital: return TransceiverMode.DIG;
                case Mode.FM: return TransceiverMode.FM;
                case Mode.Packet: return TransceiverMode.PKT;
                case Mode.SSB: return TransceiverMode.USB;
            }
        }
    }
}

