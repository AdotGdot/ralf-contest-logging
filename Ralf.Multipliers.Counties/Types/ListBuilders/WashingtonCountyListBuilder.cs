using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class WashingtonCountyListBuilder : CountyListBuilder
    {
        public WashingtonCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "WA";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","DOU","KLI","PAC","STE",
                "ASO","FER","KNG","PEN","THU",
                "BEN","FRA","KTP","PIE","WAH",
                "CHE","GAR","KTT","SAN","WAL",
                "CLL","GRN","LEW","SKG","WHA",
                "CLR","GRY","LIN","SKM","WHI",
                "COL","ISL","MAS","SNO","YAK",
                "COW","JEF","OKA","SPO"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adams";
                case "DOU": return "Douglas";
                case "KLI": return "Klickitat";
                case "PAC": return "Pacific";
                case "STE": return "Stevens";
                case "ASO": return "Asotin";
                case "FER": return "Ferry";
                case "KNG": return "King";
                case "PEN": return "Pend Oreille";
                case "THU": return "Thurston";
                case "BEN": return "Benton";
                case "FRA": return "Franklin";
                case "KTP": return "Kitsap";
                case "PIE": return "Pierce";
                case "WAH": return "Wahkiakum";
                case "CHE": return "Chelan";
                case "GAR": return "Garfield";
                case "KTT": return "Kittitas";
                case "SAN": return "San Juan";
                case "WAL": return "Walla Walla";
                case "CLL": return "Clallam";
                case "GRN": return "Grant";
                case "LEW": return "Lewis";
                case "SKG": return "Skagit";
                case "WHA": return "Whatcom";
                case "CLR": return "Clark";
                case "GRY": return "Grays Harbor";
                case "LIN": return "Lincoln";
                case "SKM": return "Skamania";
                case "WHI": return "Whitman";
                case "COL": return "Columbia";
                case "ISL": return "Island";
                case "MAS": return "Mason";
                case "SNO": return "Snohomish";
                case "YAK": return "Yakima";
                case "COW": return "Cowlitz";
                case "JEF": return "Jefferson";
                case "OKA": return "Okanogan";
                case "SPO": return "Spokane";
                default: return String.Empty;
            }
        }
    }
}