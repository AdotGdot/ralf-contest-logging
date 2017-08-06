using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface IDxccSelectionBehaviorService
    {
        IList<DxccEntitySelection> Resolve(string partialCall);
    }
}
