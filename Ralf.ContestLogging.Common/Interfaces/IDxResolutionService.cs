using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface IDxResolutionService
    {
        IList<DxccEntity> Resolve(string callsign);
        DxccEntity Resolve(int adifId);
        IList<ContinentDetail> ResolveContinentDetail(string callsign);
        IList<ItuZoneDetail> ResolveItuZoneDetail(string callsign);
        IList<CqZoneDetail> ResolveCqZoneDetail(string callsign);
        IList<DxccEntitySelection> ResolveAsCqEntitySelections(string callsign);
        IList<DxccEntitySelection> ResolveAsItuEntitySelections(string callsign);
        IList<DxccEntitySelection> ResolveAsEntitySelections(string callsign);
    }
}
