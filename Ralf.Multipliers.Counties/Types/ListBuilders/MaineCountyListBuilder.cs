using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MaineCountyListBuilder : CountyListBuilder
    {
        public MaineCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "ME";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "AND": return "Androscoggin";
                case "ARO": return "Aroostook";
                case "CUM": return "Cumberland";
                case "FRA": return "Franklin";
                case "HAN": return "Hancock";
                case "KEN": return "Kennebec";
                case "KNO": return "Knox";
                case "LIN": return "Lincoln";
                case "OXF": return "Oxford";
                case "PEN": return "Penobscot";
                case "PIS": return "Piscataquis";
                case "SAG": return "Sagadahoc";
                case "SOM": return "Somerset";
                case "WAL": return "Waldo";
                case "WAS": return "Washington";
                case "YOR": return "York";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "AND","ARO","CUM","FRA","HAN",
                "KEN","KNO","LIN","OXF","PEN",
                "PIS","SAG","SOM","WAL","WAS",
                "YOR" };
        }
    }
}
