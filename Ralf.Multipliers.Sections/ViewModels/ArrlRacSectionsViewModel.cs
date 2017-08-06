using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System.Linq;

namespace Ralf.Multipliers.Sections.ViewModels
{
    public class ArrlRacSectionsViewModel : BaseSectionsViewModel
    {
        public ArrlRacSectionsViewModel(ILogService service)
            : base(service)
        {

        }
        protected override SectionList getSectionList()
        {
            SectionList list = SectionListBuilder.getAllSections();
            var worked = (from Qso qso in service.GetLog()
                          where qso.AdifId == 291 || qso.AdifId == 1
                          select qso.Multiplier).Distinct().ToArray();
            foreach (Section section in list)
            {
                section.Worked = worked.Contains(section.Abbr);
            }
            return list;
        }
        public override string Title { get { return "ARRL and RAC Sections"; } }
    }
}
