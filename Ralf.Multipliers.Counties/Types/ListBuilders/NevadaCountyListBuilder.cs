using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NevadaCountyListBuilder : CountyListBuilder
    {
        public NevadaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NV";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "CAR", "ELK", "LAN", "MIN", "STO",
                "CHU", "ESM", "LIN", "NYE", "WAS",
                "CLA", "EUR", "LYO", "PER", "WHI",
                "DOU", "HUM" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "CAR": return "Carson City";
                case "ELK": return "Elko";
                case "LAN": return "Lander";
                case "MIN": return "Mineral";
                case "STO": return "Storey";
                case "CHU": return "Churchill";
                case "ESM": return "Esmeralda";
                case "LIN": return "Lincoln";
                case "NYE": return "Nye";
                case "WAS": return "Washoe";
                case "CLA": return "Clark";
                case "EUR": return "Eureka";
                case "LYO": return "Lyon";
                case "PER": return "Pershing";
                case "WHI": return "White Pine";
                case "DOU": return "Douglas";
                case "HUM": return "Humboldt";
                default: return String.Empty;
            }
        }
    }
}