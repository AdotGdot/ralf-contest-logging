using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NorthDakotaCountyListBuilder : CountyListBuilder
    {
        public NorthDakotaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "ND";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "GFK","ADM","BRN","BSN","BLL",
                "BOT","BOW","BRK","BUR","CSS",
                "CAV","DIK","DIV","DUN","EDY",
                "EMN","FOS","GNV","GNT","GRG",
                "HET","KDR","LMR","LOG","MCH",
                "MCI","MCK","MCL","MCR","MTN",
                "MRL","NEL","OLR","PBA","PRC",
                "RMY","RSM","REN","RLD","ROL",
                "SGT","SRN","SIX","SLP","STK",
                "STL","STN","TWR","TRL","WLH",
                "WRD","WLS","WLM"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "GFK": return "Grand Forks";
                case "ADM": return "Adams";
                case "BRN": return "Barnes";
                case "BSN": return "Benson";
                case "BLL": return "Billings";
                case "BOT": return "Bottineau";
                case "BOW": return "Bowman";
                case "BRK": return "Burke";
                case "BUR": return "Burleigh";
                case "CSS": return "Cass";
                case "CAV": return "Cavalier";
                case "DIK": return "Dickey";
                case "DIV": return "Divide";
                case "DUN": return "Dunn";
                case "EDY": return "Eddy";
                case "EMN": return "Emmons";
                case "FOS": return "Foster";
                case "GNV": return "Golden Valley";
                case "GNT": return "Grant";
                case "GRG": return "Griggs";
                case "HET": return "Hettinger";
                case "KDR": return "Kidder";
                case "LMR": return "Lamoure";
                case "LOG": return "Logan";
                case "MCH": return "Mchenry";
                case "MCI": return "Mcintosh";
                case "MCK": return "Mckenzie";
                case "MCL": return "Mclean";
                case "MCR": return "Mercer";
                case "MTN": return "Morton";
                case "MRL": return "Mountrail";
                case "NEL": return "Nelson";
                case "OLR": return "Oliver";
                case "PBA": return "Pembina";
                case "PRC": return "Pierce";
                case "RMY": return "Ramsey";
                case "RSM": return "Ransom";
                case "REN": return "Renville";
                case "RLD": return "Richland";
                case "ROL": return "Rolette";
                case "SGT": return "Sargent";
                case "SRN": return "Sheridan";
                case "SIX": return "Sioux";
                case "SLP": return "Slope";
                case "STK": return "Stark";
                case "STL": return "Steele";
                case "STN": return "Stutsman";
                case "TWR": return "Towner";
                case "TRL": return "Traill";
                case "WLH": return "Walsh";
                case "WRD": return "Ward";
                case "WLS": return "Wells";
                case "WLM": return "Williams";
                default: return String.Empty;
            }
        }
    }
}
