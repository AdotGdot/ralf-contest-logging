using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class AlaskaCountyListBuilder : CountyListBuilder
    {
        public AlaskaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "AK";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] { "SE", "NW", "SC", "C" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "SE": return "1st";
                case "NW": return "2nd";
                case "SC": return "3rd";
                case "C": return "4th";
                default: return String.Empty;
            }
        }
    }
}