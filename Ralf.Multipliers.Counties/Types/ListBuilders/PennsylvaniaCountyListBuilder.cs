using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class PennsylvaniaCountyListBuilder : CountyListBuilder
    {
        public PennsylvaniaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "PA";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ELK","MTR","ALL","ERI",
                "NHA","ARM","Fay","NUM","BEA",
                "FUL","PER","BED","FOR","PHI",
                "BER","FRA","PIK","BLA","GRE",
                "POT","BRA","HUN","SCH","BUX",
                "INN","SNY","BUT","JEF","SOM",
                "CMB","JUN","SUL","CRN","LAC",
                "SUS","CAR","LAN","TIO","CEN",
                "LAW","UNI","CHE","LEB","VEN",
                "CLA","LEH","WAR","CLE","LUZ",
                "WAS","CLI","LYC","WAY","COL",
                "MCK","WES","CRA","MER","WYO",
                "CUM","MIF","YOR","DAU","MOE",
                "DCO","MGY"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adams";
                case "ELK": return "Elk";
                case "MTR": return "Montour";
                case "ALL": return "Allegheny";
                case "ERI": return "Erie";
                case "NHA": return "Northhampton";
                case "ARM": return "Armstrong";
                case "Fay": return "Fayette";
                case "NUM": return "Northumberland";
                case "BEA": return "Beaver";
                case "FUL": return "Fulton";
                case "PER": return "Perry";
                case "BED": return "Bedford";
                case "FOR": return "Forest";
                case "PHI": return "Philadelphia";
                case "BER": return "Berks";
                case "FRA": return "Franklin";
                case "PIK": return "Pike";
                case "BLA": return "Blair";
                case "GRE": return "Greene";
                case "POT": return "Potter";
                case "BRA": return "Bradford";
                case "HUN": return "Huntingdon";
                case "SCH": return "Schuylkill";
                case "BUX": return "Bucks";
                case "INN": return "Indiana";
                case "SNY": return "Snyder";
                case "BUT": return "Butler";
                case "JEF": return "Jefferson";
                case "SOM": return "Somerset";
                case "CMB": return "Cambria";
                case "JUN": return "Juniata";
                case "SUL": return "Sullivan";
                case "CRN": return "Cameron";
                case "LAC": return "Lackawanna";
                case "SUS": return "Susquehanna";
                case "CAR": return "Carbon";
                case "LAN": return "Lancaster";
                case "TIO": return "Tioga";
                case "CEN": return "Centre";
                case "LAW": return "Lawrence";
                case "UNI": return "Union";
                case "CHE": return "Chester";
                case "LEB": return "Lebanon";
                case "VEN": return "Venango";
                case "CLA": return "Clarion";
                case "LEH": return "Lehigh";
                case "WAR": return "Warren";
                case "CLE": return "Clearfield";
                case "LUZ": return "Luzerne";
                case "WAS": return "Washington";
                case "CLI": return "Clinton";
                case "LYC": return "Lycoming";
                case "WAY": return "Wayne";
                case "COL": return "Columbia";
                case "MCK": return "McKean";
                case "WES": return "Westmoreland";
                case "CRA": return "Crawford";
                case "MER": return "Mercer";
                case "WYO": return "Wyoming";
                case "CUM": return "Cumberland";
                case "MIF": return "Mifflin";
                case "YOR": return "York";
                case "DAU": return "Dauphin";
                case "MOE": return "Monroe";
                case "DCO": return "Delaware";
                case "MGY": return "Montgomery";
                default: return String.Empty;
            }
        }
    }
}