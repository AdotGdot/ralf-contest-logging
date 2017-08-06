using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MississippiCountyListBuilder : CountyListBuilder
    {
        public MississippiCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MS";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adams";
                case "ALC": return "Alcorn";
                case "AMI": return "Amite";
                case "ATT": return "Attala";
                case "BEN": return "Benton";
                case "BOL": return "Bolivar";
                case "CAL": return "Calhoun";
                case "CAR": return "Carroll";
                case "CHI": return "Chickasaw";
                case "CHO": return "Choctaw";
                case "CLA": return "Clay";
                case "CLB": return "Claiborne";
                case "CLK": return "Clarke";
                case "COA": return "Coahoma";
                case "COP": return "Copiah";
                case "COV": return "Covington";
                case "DES": return "Desoto";
                case "FOR": return "Forrest";
                case "FRA": return "Franklin";
                case "GEO": return "George";
                case "GRE": return "Grenada";
                case "GRN": return "Greene";
                case "HAN": return "Hancock";
                case "HAR": return "Harrison";
                case "HIN": return "Hinds";
                case "HOL": return "Holmes";
                case "HUM": return "Humphreys";
                case "ISS": return "Issaquena";
                case "ITA": return "Itawamba";
                case "JAC": return "Jackson";
                case "JAS": return "Jasper";
                case "JDV": return "Jefferson Davis";
                case "JEF": return "Jefferson";
                case "JON": return "Jones";
                case "KEM": return "Kemper";
                case "LAF": return "Lafayette";
                case "LAM": return "Lamar";
                case "LAU": return "Lauderdale";
                case "LAW": return "Lawrence";
                case "LEA": return "Leake";
                case "LEE": return "Lee";
                case "LEF": return "Leflore";
                case "LIN": return "Lincoln";
                case "LOW": return "Lowndes";
                case "MAD": return "Madison";
                case "MAR": return "Marshall";
                case "MGY": return "Montgomery";
                case "MON": return "Monroe";
                case "MRN": return "Marion";
                case "NES": return "Neshoba";
                case "NEW": return "Newton";
                case "NOX": return "Noxubee";
                case "OKT": return "Oktibbeha";
                case "PAN": return "Panola";
                case "PEA": return "Pearl River";
                case "PER": return "Perry";
                case "PIK": return "Pike";
                case "PON": return "Pontotoc";
                case "PRE": return "Prentiss";
                case "QUI": return "Quitman";
                case "RAN": return "Rankin";
                case "SCO": return "Scott";
                case "SHA": return "Sharkey";
                case "SIM": return "Simpson";
                case "SMI": return "Smith";
                case "STO": return "Stone";
                case "SUN": return "Sunflower";
                case "TAL": return "Tallahatchie";
                case "TAT": return "Tate";
                case "TIP": return "Tippah";
                case "TIS": return "Tishomingo";
                case "TUN": return "Tunica";
                case "UNI": return "Union";
                case "WAL": return "Walthall";
                case "WAR": return "Warren";
                case "WAS": return "Washington";
                case "WAY": return "Wayne";
                case "WEB": return "Webster";
                case "WIL": return "Wilkinson";
                case "WIN": return "Winston";
                case "YAL": return "Yalobusha";
                case "YAZ": return "Yazoo";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ALC","AMI","ATT","BEN",
                "BOL","CAL","CAR","CHI","CHO",
                "CLA","CLB","CLK","COA","COP",
                "COV","DES","FOR","FRA","GEO",
                "GRE","GRN","HAN","HAR","HIN",
                "HOL","HUM","ISS","ITA","JAC",
                "JAS","JDV","JEF","JON","KEM",
                "LAF","LAM","LAU","LAW","LEA",
                "LEE","LEF","LIN","LOW","MAD",
                "MAR","MGY","MON","MRN","NES",
                "NEW","NOX","OKT","PAN","PEA",
                "PER","PIK","PON","PRE","QUI",
                "RAN","SCO","SHA","SIM","SMI",
                "STO","SUN","TAL","TAT","TIP",
                "TIS","TUN","UNI","WAL","WAR",
                "WAS","WAY","WEB","WIL","WIN",
                "YAL","YAZ"};
        }
    }
}
