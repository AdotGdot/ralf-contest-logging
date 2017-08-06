using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Models;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public class MultiviewViewModel : BaseViewModel, IMultiviewViewModel
    {
        public MultiviewViewModel(ILogService service)
            : base(service)
        {
        }
    }
}
