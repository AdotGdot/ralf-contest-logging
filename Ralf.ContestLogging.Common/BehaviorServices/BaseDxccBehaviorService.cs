using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.BehaviorServices
{
    public abstract class BaseDxccBehaviorService : IDxccSelectionBehaviorService
    {
        protected IDxResolutionService dxService;
        public BaseDxccBehaviorService(IDxResolutionService dxService)
        {
            this.dxService = dxService;
        }

        public abstract IList<DxccEntitySelection> Resolve(string partialCall);
    }
}
