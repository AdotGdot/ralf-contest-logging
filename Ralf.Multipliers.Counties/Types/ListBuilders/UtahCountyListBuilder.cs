using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class UtahCountyListBuilder : CountyListBuilder
    {
        public UtahCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "UT";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BEA", "DUC", "KAN", "SNJ", "UTA",
                "BOX", "EME", "MIL", "SNP", "WST",
                "CAC", "GAR", "MOR", "SEV", "WSH",
                "CAR", "GRA", "PIU", "SUM", "WAY",
                "DAG", "IRO", "RIC", "TOO", "WEB",
                "DAV", "JUA", "SAL", "UIN" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BEA": return "Beaver";
                case "DUC": return "Duchesne";
                case "KAN": return "Kane";
                case "SNJ": return "San Juan";
                case "UTA": return "Utah";
                case "BOX": return "Box Elder";
                case "EME": return "Emery";
                case "MIL": return "Millard";
                case "SNP": return "Sanpete";
                case "WST": return "Wasatch";
                case "CAC": return "Cache";
                case "GAR": return "Garfield";
                case "MOR": return "Morgan";
                case "SEV": return "Sevier";
                case "WSH": return "Washington";
                case "CAR": return "Carbon";
                case "GRA": return "Grand";
                case "PIU": return "Piute";
                case "SUM": return "Summit";
                case "WAY": return "Wayne";
                case "DAG": return "Daggett";
                case "IRO": return "Iron";
                case "RIC": return "Rich";
                case "TOO": return "Tooele";
                case "WEB": return "Weber";
                case "DAV": return "Davis";
                case "JUA": return "Juab";
                case "SAL": return "Salt Lake";
                case "UIN": return "Uintah";
                default: return String.Empty;
            }
        }
    }
}