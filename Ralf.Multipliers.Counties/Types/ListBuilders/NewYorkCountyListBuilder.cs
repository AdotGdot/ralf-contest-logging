using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NewYorkCountyListBuilder : CountyListBuilder
    {
        public NewYorkCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NY";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALB": return "Albany";
                case "ALL": return "Allegany";
                case "BRX": return "Bronx";
                case "BRM": return "Broome";
                case "CAT": return "Cattaraugus";
                case "CAY": return "Cayuga";
                case "CHA": return "Chautauqua";
                case "CHE": return "Chemung";
                case "CGO": return "Chenango";
                case "CLI": return "Clinton";
                case "COL": return "Columbia";
                case "COR": return "Cortland";
                case "DEL": return "Delaware";
                case "DUT": return "Dutchess";
                case "ERI": return "Erie";
                case "ESS": return "Essex";
                case "FRA": return "Franklin";
                case "FUL": return "Fulton";
                case "GEN": return "Genesee";
                case "GRE": return "Greene";
                case "HAM": return "Hamilton";
                case "HER": return "Herkimer";
                case "JEF": return "Jefferson";
                case "KIN": return "Kings";
                case "LEW": return "Lewis";
                case "LIV": return "Livingston";
                case "MAD": return "Madison";
                case "MON": return "Monroe";
                case "MTG": return "Montgomery";
                case "NAS": return "Nassau";
                case "NEW": return "New York";
                case "NIA": return "Niagara";
                case "ONE": return "Oneida";
                case "ONO": return "Onondaga";
                case "ONT": return "Ontario";
                case "ORA": return "Orange";
                case "ORL": return "Orleans";
                case "OSW": return "Oswego";
                case "OTS": return "Otsego";
                case "PUT": return "Putnam";
                case "QUE": return "Queens";
                case "REN": return "Rensselaer";
                case "RIC": return "Richmond";
                case "ROC": return "Rockland";
                case "SAR": return "Saratoga";
                case "SCH": return "Schenectady";
                case "SCO": return "Schoharie";
                case "SCU": return "Schuyler";
                case "SEN": return "Seneca";
                case "STL": return "St. Lawrence";
                case "STE": return "Steuben";
                case "SUF": return "Suffolk";
                case "SUL": return "Sullivan";
                case "TIO": return "Tioga";
                case "TOM": return "Tompkins";
                case "ULS": return "Ulster";
                case "WAR": return "Warren";
                case "WAS": return "Washington";
                case "WAY": return "Wayne";
                case "WES": return "Westchester";
                case "WYO": return "Wyoming";
                case "YAT": return "Yates";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALB","ALL","BRX","BRM","CAT",
                "CAY","CHA","CHE","CGO","CLI",
                "COL","COR","DEL","DUT","ERI",
                "ESS","FRA","FUL","GEN","GRE",
                "HAM","HER","JEF","KIN","LEW",
                "LIV","MAD","MON","MTG","NAS",
                "NEW","NIA","ONE","ONO","ONT",
                "ORA","ORL","OSW","OTS","PUT",
                "QUE","REN","RIC","ROC","SAR",
                "SCH","SCO","SCU","SEN","STL",
                "STE","SUF","SUL","TIO","TOM",
                "ULS","WAR","WAS","WAY","WES",
                "WYO","YAT"};
        }
    }
}
