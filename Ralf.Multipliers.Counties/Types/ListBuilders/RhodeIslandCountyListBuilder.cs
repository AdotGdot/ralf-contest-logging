using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class RhodeIslandCountyListBuilder : CountyListBuilder
    {
        public RhodeIslandCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "RI";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BRI": return "Bristol";
                case "KEN": return "Kent";
                case "NEW": return "Newport";
                case "PRO": return "Providence";
                case "WAS": return "Washington";
                default: return String.Empty;
            }
        }
        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] { "BRI", "KEN", "NEW", "PRO", "WAS" };
        }
    }
}
