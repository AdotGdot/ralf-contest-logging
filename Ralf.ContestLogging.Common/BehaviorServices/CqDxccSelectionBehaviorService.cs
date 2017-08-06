using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.BehaviorServices
{
    public class CqDxccSelectionBehaviorService : BaseDxccBehaviorService
    {
        public CqDxccSelectionBehaviorService(IDxResolutionService dxService)
            : base(dxService) { }
        public override IList<DxccEntitySelection> Resolve(string partialCall)
        {
            return dxService.ResolveAsCqEntitySelections(partialCall);
        }
    }
}
