using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class HawaiiCountyListBuilder : CountyListBuilder
    {
        public HawaiiCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "HI";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] { "HAW", "HON", "KAL", "KAU", "MAU" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "HAW": return "Hawaii";
                case "HON": return "Honolulu";
                case "KAL": return "Kalawao";
                case "KAU": return "Kauai";
                case "MAU": return "Maui";
                default: return String.Empty;
            }
        }
    }
}