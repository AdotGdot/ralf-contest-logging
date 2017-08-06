using Ralf.ContestLogging.Common.Enumerations;

namespace Ralf.ScratchPadMemory.Types
{
    public class Memory
    {
        public string Callsign { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Mode Mode { get; set; }
        public double Frequency { get; set; }
    }
}
