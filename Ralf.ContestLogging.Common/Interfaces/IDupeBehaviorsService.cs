using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface IDupeBehaviorsService
    {
        IList<Qso> getDupes(string partialCall, Band band, Mode mode, string gridSquare = null);
        bool isDupe(string callsign, Band band, Mode mode, string gridSquare = null);
    }
}
