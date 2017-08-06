using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class WestVirginiaCountyListBuilder : CountyListBuilder
    {
        public WestVirginiaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "WV";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BAR","BER","BOO","BRA","BRO",
                "CAB","CAL","CLA","DOD","FAY",
                "GIL","GRA","GRE","HAM","HAN",
                "HDY","HAR","JAC","JEF","KAN",
                "LEW","LIN","LOG","MRN","MAR",
                "MAS","MCD","MER","MIN","MGO",
                "MON","MRO","MOR","NIC","OHI",
                "PEN","PLE","POC","PRE","PUT",
                "RAL","RAN","RIT","ROA","SUM",
                "TAY","TUC","TYL","UPS","WAY",
                "WEB","WET","WIR","WOO","WYO" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BAR": return "Barbour";
                case "BER": return "Berkeley";
                case "BOO": return "Boone";
                case "BRA": return "Braxton";
                case "BRO": return "Brooke";
                case "CAB": return "Cabell";
                case "CAL": return "Calhoun";
                case "CLA": return "Clay";
                case "DOD": return "Doddridge";
                case "FAY": return "Fayette";
                case "GIL": return "Gilmer";
                case "GRA": return "Grant";
                case "GRE": return "Greenbrier";
                case "HAM": return "Hampshire";
                case "HAN": return "Hancock";
                case "HDY": return "Hardy";
                case "HAR": return "Harrison";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "KAN": return "Kanawha";
                case "LEW": return "Lewis";
                case "LIN": return "Lincoln";
                case "LOG": return "Logan";
                case "MRN": return "Marion";
                case "MAR": return "Marshall";
                case "MAS": return "Mason";
                case "MCD": return "Mcdowell";
                case "MER": return "Mercer";
                case "MIN": return "Mineral";
                case "MGO": return "Mingo";
                case "MON": return "Monongalia";
                case "MRO": return "Monroe";
                case "MOR": return "Morgan";
                case "NIC": return "Nicholas";
                case "OHI": return "Ohio";
                case "PEN": return "Pendleton";
                case "PLE": return "Pleasants";
                case "POC": return "Pocahontas";
                case "PRE": return "Preston";
                case "PUT": return "Putnam";
                case "RAL": return "Raleigh";
                case "RAN": return "Randolph";
                case "RIT": return "Ritchie";
                case "ROA": return "Roane";
                case "SUM": return "Summers";
                case "TAY": return "Taylor";
                case "TUC": return "Tucker";
                case "TYL": return "Tyler";
                case "UPS": return "Upshur";
                case "WAY": return "Wayne";
                case "WEB": return "Webster";
                case "WET": return "Wetzel";
                case "WIR": return "Wirt";
                case "WOO": return "Wood";
                case "WYO": return "Wyoming";
                default: return String.Empty;
            }
        }
    }
}
