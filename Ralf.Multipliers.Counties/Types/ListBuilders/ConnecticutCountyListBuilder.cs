using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class ConnecticutCountyListBuilder : CountyListBuilder
    {
        public ConnecticutCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "CT";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "FAI": return "Fairfield";
                case "HAR": return "Hartford";
                case "LIT": return "Litchfield";
                case "MID": return "Middlesex";
                case "NHV": return "New Haven";
                case "NLN": return "New London";
                case "TOL": return "Tolland";
                case "WIN": return "Windham";
                default: return String.Empty;
            }
        }
        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] { "FAI", "HAR", "LIT", "MID", "NHV", "NLN", "TOL", "WIN" };
        }
    }
}
