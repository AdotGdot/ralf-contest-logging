using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class OregonCountyListBuilder : CountyListBuilder
    {
        public OregonCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "OR";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BAK","DES","JEF","MAL","UMA",
                "BEN","DOU","JOS","MAR","UNI",
                "CLK","GIL","KLA","MOR","WAL",
                "CLT","GRA","LAK","MUL","WCO",
                "COL","HAR","LAN","POL","WSH",
                "COO","HOO","LCN","SHE","WHE",
                "CRO","JAC","LNN","TIL","YAM",
                "CUR"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BAK": return "Baker";
                case "DES": return "Deschutes";
                case "JEF": return "Jefferson";
                case "MAL": return "Malheur";
                case "UMA": return "Umatilla";
                case "BEN": return "Benton";
                case "DOU": return "Douglas";
                case "JOS": return "Josephine";
                case "MAR": return "Marion";
                case "UNI": return "Union";
                case "CLK": return "Clackamas";
                case "GIL": return "Gilliam";
                case "KLA": return "Klamath";
                case "MOR": return "Morrow";
                case "WAL": return "Wallowa";
                case "CLT": return "Clatsop";
                case "GRA": return "Grant";
                case "LAK": return "Lake";
                case "MUL": return "Multnomah";
                case "WCO": return "Wasco";
                case "COL": return "Columbia";
                case "HAR": return "Harney";
                case "LAN": return "Lane";
                case "POL": return "Polk";
                case "WSH": return "Washington";
                case "COO": return "Coos";
                case "HOO": return "Hood River";
                case "LCN": return "Lincoln";
                case "SHE": return "Sherman";
                case "WHE": return "Wheeler";
                case "CRO": return "Crook";
                case "JAC": return "Jackson";
                case "LNN": return "Linn";
                case "TIL": return "Tillamook";
                case "YAM": return "Yamhill";
                case "CUR": return "Curry";
                default: return String.Empty;
            }
        }
    }
}