using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.BehaviorServices
{
    public class ItuDxccSelectionBehaviorService : BaseDxccBehaviorService
    {
        public ItuDxccSelectionBehaviorService(IDxResolutionService dxService)
            : base(dxService) { }
        public override IList<DxccEntitySelection> Resolve(string partialCall)
        {
            return dxService.ResolveAsItuEntitySelections(partialCall);
        }
    }
}
