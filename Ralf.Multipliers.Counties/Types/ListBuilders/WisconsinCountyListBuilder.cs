using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class WisconsinCountyListBuilder : CountyListBuilder
    {
        public WisconsinCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "WI";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adams";
                case "ASH": return "Ashland";
                case "BAR": return "Barron";
                case "BAY": return "Bayfield";
                case "BRO": return "Brown";
                case "BUF": return "Buffalo";
                case "BUR": return "Burnett";
                case "CAL": return "Calumet";
                case "CHI": return "Chippewa";
                case "CLA": return "Clark";
                case "COL": return "Columbia";
                case "CRA": return "Crawford";
                case "DAN": return "Dane";
                case "DOD": return "Dodge";
                case "DOO": return "Door";
                case "DOU": return "Douglas";
                case "DUN": return "Dunn";
                case "EAU": return "Eau Claire";
                case "FLO": return "Florence";
                case "FON": return "Fond du Lac";
                case "FOR": return "Forest";
                case "GRA": return "Grant";
                case "GRE": return "Green";
                case "GRL": return "Green Lake";
                case "IOW": return "Iowa";
                case "IRO": return "Iron";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "JUN": return "Juneau";
                case "KEN": return "Kenosha";
                case "KEW": return "Kewaunee";
                case "LAC": return "La Crosse";
                case "LAF": return "Lafayette";
                case "LAN": return "Langlade";
                case "LIN": return "Lincoln";
                case "MAN": return "Manitowoc";
                case "MAR": return "Marathon";
                case "MEN": return "Menominee";
                case "MIL": return "Milwaukee";
                case "MON": return "Monroe";
                case "MRN": return "Marinette";
                case "MRQ": return "Marquette";
                case "OCO": return "Oconto";
                case "ONE": return "Oneida";
                case "OUT": return "Outagamie";
                case "OZA": return "Ozaukee";
                case "PEP": return "Pepin";
                case "PIE": return "Pierce";
                case "POL": return "Polk";
                case "POR": return "Portage";
                case "PRI": return "Price";
                case "RAC": return "Racine";
                case "RIC": return "Richland";
                case "ROC": return "Rock";
                case "RUS": return "Rusk";
                case "SAU": return "Sauk";
                case "SAW": return "Sawyer";
                case "SHA": return "Shawano";
                case "SHE": return "Sheboygan";
                case "STC": return "St Croix";
                case "TAY": return "Taylor";
                case "TRE": return "Trempealeau";
                case "VER": return "Vernon";
                case "VIL": return "Vilas";
                case "WAL": return "Walworth";
                case "WAP": return "Waupaca";
                case "WAS": return "Washington";
                case "WAU": return "Waukesha";
                case "WIN": return "Winnebago";
                case "WOO": return "Wood";
                case "WSB": return "Washburn";
                case "WSR": return "Waushara";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ASH","BAR","BAY","BRO",
                "BUF","BUR","CAL","CHI","CLA",
                "COL","CRA","DAN","DOD","DOO",
                "DOU","DUN","EAU","FLO","FON",
                "FOR","GRA","GRE","GRL","IOW",
                "IRO","JAC","JEF","JUN","KEN",
                "KEW","LAC","LAF","LAN","LIN",
                "MAN","MAR","MEN","MIL","MON",
                "MRN","MRQ","OCO","ONE","OUT",
                "OZA","PEP","PIE","POL","POR",
                "PRI","RAC","RIC","ROC","RUS",
                "SAU","SAW","SHA","SHE","STC",
                "TAY","TRE","VER","VIL","WAL",
                "WAP","WAS","WAU","WIN","WOO",
                "WSB","WSR"};
        }
    }
}
