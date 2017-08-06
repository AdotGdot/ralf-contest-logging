using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class VermontCountyListBuilder : CountyListBuilder
    {
        public VermontCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "VT";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADD": return "Addison";
                case "BEN": return "Bennington";
                case "CAL": return "Caledonia";
                case "CHI": return "Chittenden";
                case "ESS": return "Essex";
                case "FRA": return "Franklin";
                case "GRA": return "Grand Isle";
                case "LAM": return "Lamoille";
                case "ORA": return "Orange";
                case "ORL": return "Orleans";
                case "RUT": return "Rutland";
                case "WAS": return "Washington";
                case "WNH": return "Windham";
                case "WNS": return "Windsor";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADD","BEN","CAL","CHI","ESS",
                "FRA","GRA","LAM","ORA","ORL",
                "RUT","WAS","WNH","WNS"};
        }
    }
}
