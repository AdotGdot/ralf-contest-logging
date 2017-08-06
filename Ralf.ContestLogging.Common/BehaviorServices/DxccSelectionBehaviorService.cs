using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.BehaviorServices
{
    public class DxccSelectionBehaviorService : BaseDxccBehaviorService
    {
        public DxccSelectionBehaviorService(IDxResolutionService dxService)
            : base(dxService) { }
        public override IList<DxccEntitySelection> Resolve(string partialCall)
        {
            return dxService.ResolveAsEntitySelections(partialCall);
        }
    }
}
