using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;

namespace Ralf.Multipliers.Sections.Models
{
    public interface ISectionsViewModel : IBaseViewModel
    {
        SectionList SectionList { get; }
        string Title { get; }
    }
}
