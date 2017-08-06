using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface ITransceiver
    {
        TransceiverData ReadTransceiverData();
        Band SetFrequency(double frequency);
        void ToggleVfo();
        void SetVfosIdentical();
        void SetMode(TransceiverMode mode);
        void SetSplitOn();
        void SetSplitOff();
    }
}