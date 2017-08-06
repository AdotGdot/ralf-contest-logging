using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class DelawareCountyListBuilder : CountyListBuilder
    {
        public DelawareCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "DE";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] { "KDE", "NDE", "SDE" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "KDE": return "Kent";
                case "NDE": return "New Castle";
                case "SDE": return "Sussex";
                default: return String.Empty;
            }
        }
    }
}
