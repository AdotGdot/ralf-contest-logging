using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class KentuckyCountyListBuilder : CountyListBuilder
    {
        public KentuckyCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "KY";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ALL","AND","BAL","BAR","BAT","BEL","BOO","BOU","BOY",
                "BOL","BRA","BRE","BRK","BUL","BUT","CAL","CAW","CAM","CAE",
                "CRL","CTR","CAS","CHR","CLA","CLY","CLI","CRI","CUM","DAV",
                "EDM","ELL","EST","FAY","FLE","FLO","FRA","FUL","GAL","GAR",
                "GRT","GRV","GRY","GRE","GRP","HAN","HAR","HRL","HSN","HRT",
                "HEN","HNY","HIC","HOP","JAC","JEF","JES","JOH","KEN","KNT",
                "KNX","LAR","LAU","LAW","LEE","LES","LET","LEW","LIN","LIV",
                "LOG","LYO","MAD","MAG","MAR","MSL","MAT","MAS","MCC","MCY",
                "MCL","MEA","MEN","MER","MET","MON","MOT","MOR","MUH","NEL",
                "NIC","OHI","OLD","OWE","OWS","PEN","PER","PIK","POW","PUL",
                "ROB","ROC","ROW","RUS","SCO","SHE","SIM","SPE","TAY","TOD",
                "TRI","TRM","UNI","WAR","WAS","WAY","WEB","WHI","WOL","WOO"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adair";
                case "ALL": return "Allen";
                case "AND": return "Anderson";
                case "BAL": return "Ballard";
                case "BAR": return "Barren";
                case "BAT": return "Bath";
                case "BEL": return "Bell";
                case "BOO": return "Boone";
                case "BOU": return "Bourbon";
                case "BOY": return "Boyd";
                case "BOL": return "Boyle";
                case "BRA": return "Bracken";
                case "BRE": return "Breathitt";
                case "BRK": return "Breckinridge";
                case "BUL": return "Bullitt";
                case "BUT": return "Butler";
                case "CAL": return "Caldwell";
                case "CAW": return "Calloway";
                case "CAM": return "Campbell";
                case "CAE": return "Carlisle";
                case "CRL": return "Carroll";
                case "CTR": return "Carter";
                case "CAS": return "Casey";
                case "CHR": return "Christian";
                case "CLA": return "Clark";
                case "CLY": return "Clay";
                case "CLI": return "Clinton";
                case "CRI": return "Crittenden";
                case "CUM": return "Cumberland";
                case "DAV": return "Daviess";
                case "EDM": return "Edmonson";
                case "ELL": return "Elliott";
                case "EST": return "Estill";
                case "FAY": return "Fayette";
                case "FLE": return "Fleming";
                case "FLO": return "Floyd";
                case "FRA": return "Franklin";
                case "FUL": return "Fulton";
                case "GAL": return "Gallatin";
                case "GAR": return "Garrard";
                case "GRT": return "Grant";
                case "GRV": return "Graves";
                case "GRY": return "Grayson";
                case "GRE": return "Green";
                case "GRP": return "Greenup";
                case "HAN": return "Hancock";
                case "HAR": return "Hardin";
                case "HRL": return "Harlan";
                case "HSN": return "Harrison";
                case "HRT": return "Hart";
                case "HEN": return "Henderson";
                case "HNY": return "Henry";
                case "HIC": return "Hickman";
                case "HOP": return "Hopkins";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "JES": return "Jessamine";
                case "JOH": return "Johnson";
                case "KEN": return "Kenton";
                case "KNT": return "Knott";
                case "KNX": return "Knox";
                case "LAR": return "Larue";
                case "LAU": return "Laurel";
                case "LAW": return "Lawrence";
                case "LEE": return "Lee";
                case "LES": return "Leslie";
                case "LET": return "Letcher";
                case "LEW": return "Lewis";
                case "LIN": return "Lincoln";
                case "LIV": return "Livingston";
                case "LOG": return "Logan";
                case "LYO": return "Lyon";
                case "MAD": return "Madison";
                case "MAG": return "Magoffin";
                case "MAR": return "Marion";
                case "MSL": return "Marshall";
                case "MAT": return "Martin";
                case "MAS": return "Mason";
                case "MCC": return "Mccracken";
                case "MCY": return "Mccreary";
                case "MCL": return "Mclean";
                case "MEA": return "Meade";
                case "MEN": return "Menifee";
                case "MER": return "Mercer";
                case "MET": return "Metcalfe";
                case "MON": return "Monroe";
                case "MOT": return "Montgomery";
                case "MOR": return "Morgan";
                case "MUH": return "Muhlenberg";
                case "NEL": return "Nelson";
                case "NIC": return "Nicholas";
                case "OHI": return "Ohio";
                case "OLD": return "Oldham";
                case "OWE": return "Owen";
                case "OWS": return "Owsley";
                case "PEN": return "Pendleton";
                case "PER": return "Perry";
                case "PIK": return "Pike";
                case "POW": return "Powell";
                case "PUL": return "Pulaski";
                case "ROB": return "Robertson";
                case "ROC": return "Rockcastle";
                case "ROW": return "Rowan";
                case "RUS": return "Russell";
                case "SCO": return "Scott";
                case "SHE": return "Shelby";
                case "SIM": return "Simpson";
                case "SPE": return "Spencer";
                case "TAY": return "Taylor";
                case "TOD": return "Todd";
                case "TRI": return "Trigg";
                case "TRM": return "Trimble";
                case "UNI": return "Union";
                case "WAR": return "Warren";
                case "WAS": return "Washington";
                case "WAY": return "Wayne";
                case "WEB": return "Webster";
                case "WHI": return "Whitley";
                case "WOL": return "Wolfe";
                case "WOO": return "Woodford";
                default: return String.Empty;
            }
        }
    }
}
