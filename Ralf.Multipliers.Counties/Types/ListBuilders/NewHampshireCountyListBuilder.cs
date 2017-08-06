using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NewHampshireCountyListBuilder : CountyListBuilder
    {
        public NewHampshireCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NH";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BEL": return "Belknap";
                case "CAR": return "Carroll";
                case "CHE": return "Cheshire";
                case "COO": return "Coos";
                case "GRA": return "Grafton";
                case "HIL": return "Hillsborough";
                case "MER": return "Merrimack";
                case "ROC": return "Rockingham";
                case "STR": return "Strafford";
                case "SUL": return "Sullivan";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BEL","CAR","CHE","COO","GRA",
                "HIL","MER","ROC","STR","SUL"};
        }
    }
}
