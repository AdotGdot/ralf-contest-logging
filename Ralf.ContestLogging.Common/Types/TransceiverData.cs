using Ralf.ContestLogging.Common.Enumerations;

namespace Ralf.ContestLogging.Common.Types
{
    public class TransceiverData
    {
        public Band Band { get; set; }
        public string ErrorMsg { get; set; }
        public string ExceptionMsg { get; set; }
        public double Frequency { get; set; }
        public Mode Mode { get; set; }
        public bool Success { get; set; }
        public TransceiverMode TransceiverMode { get; set; }
    }
}
