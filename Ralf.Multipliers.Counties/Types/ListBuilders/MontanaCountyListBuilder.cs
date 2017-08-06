using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MontanaCountyListBuilder : CountyListBuilder
    {
        public MontanaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MT";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BEA": return "Beaverhead";
                case "BIG": return "Big Horn";
                case "BLA": return "Blaine";
                case "BRO": return "Broadwater";
                case "CAS": return "Cascade";
                case "CHO": return "Chouteau";
                case "CRB": return "Carbon";
                case "CRT": return "Carter";
                case "CUS": return "Custer";
                case "DAN": return "Daniels";
                case "DAW": return "Dawson";
                case "DEE": return "Deer Lodge";
                case "FAL": return "Fallon";
                case "FER": return "Fergus";
                case "FLA": return "Flathead";
                case "GAL": return "Gallatin";
                case "GAR": return "Garfield";
                case "GLA": return "Glacier";
                case "GOL": return "Golden Valley";
                case "GRA": return "Granite";
                case "HIL": return "Hill";
                case "JEF": return "Jefferson";
                case "JUD": return "Judith Basin";
                case "LAK": return "Lake";
                case "LEW": return "Lewis & Clark";
                case "LIB": return "Liberty";
                case "LIN": return "Lincoln";
                case "MAD": return "Madison";
                case "MCC": return "Mccone";
                case "MEA": return "Meagher";
                case "MIN": return "Mineral";
                case "MIS": return "Missoula";
                case "MUS": return "Musselshell";
                case "PAR": return "Park";
                case "PET": return "Petroleum";
                case "PHI": return "Phillips";
                case "PON": return "Pondera";
                case "PRA": return "Prairie";
                case "PWD": return "Powder River";
                case "PWL": return "Powell";
                case "RAV": return "Ravalli";
                case "RIC": return "Richland";
                case "ROO": return "Roosevelt";
                case "ROS": return "Rosebud";
                case "SAN": return "Sanders";
                case "SHE": return "Sheridan";
                case "SIL": return "Silver Bow";
                case "STI": return "Stillwater";
                case "SWE": return "Sweet Grass";
                case "TET": return "Teton";
                case "TOO": return "Toole";
                case "TRE": return "Treasure";
                case "VAL": return "Valley";
                case "WHE": return "Wheatland";
                case "WIB": return "Wibaux";
                case "YEL": return "Yellowstone";
                default: return String.Empty;
            }
        }
        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BEA","BIG","BLA","BRO","CAS",
                "CHO","CRB","CRT","CUS","DAN",
                "DAW","DEE","FAL","FER","FLA",
                "GAL","GAR","GLA","GOL","GRA",
                "HIL","JEF","JUD","LAK","LEW",
                "LIB","LIN","MAD","MCC","MEA",
                "MIN","MIS","MUS","PAR","PET",
                "PHI","PON","PRA","PWD","PWL",
                "RAV","RIC","ROO","ROS","SAN",
                "SHE","SIL","STI","SWE","TET",
                "TOO","TRE","VAL","WHE","WIB",
                "YEL" };
        }
    }
}
