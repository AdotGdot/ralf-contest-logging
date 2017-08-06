using Ralf.ContestLogging.Common.Enumerations;

namespace Ralf.ContestLogging.Common.Types
{
    public class TransceiverState
    {
        public Band Band { get; set; }
        public TransceiverMode Mode { get; set; }
        public double Frequency { get; set; }
    }
}


