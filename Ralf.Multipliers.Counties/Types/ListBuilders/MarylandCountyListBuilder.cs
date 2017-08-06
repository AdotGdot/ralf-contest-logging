using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MarylandCountyListBuilder : CountyListBuilder
    {
        public MarylandCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MD";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALY","HWD","ANA","KEN","BAL",
                "MON","BCT","PGE","CLV","QAN",
                "CLN","STM","CRL","SMR","CEC",
                "TAL","CHS","WAS","DRC","WIC",
                "FRD","WRC","GAR","HFD"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALY": return "Allegany";
                case "HWD": return "Howard";
                case "ANA": return "Anne Arundel";
                case "KEN": return "Kent";
                case "BAL": return "Baltimore	City";
                case "MON": return "Montgomery";
                case "BCT": return "Baltimore	County";
                case "PGE": return "Prince George's";
                case "CLV": return "Calvert";
                case "QAN": return "Queen Anne's";
                case "CLN": return "Caroline";
                case "STM": return "St Mary's";
                case "CRL": return "Carroll";
                case "SMR": return "Somerset";
                case "CEC": return "Cecil";
                case "TAL": return "Talbot";
                case "CHS": return "Charles";
                case "WAS": return "Washington";
                case "DRC": return "Dorchester";
                case "WIC": return "Wicomico";
                case "FRD": return "Frederick";
                case "WRC": return "Worcester";
                case "GAR": return "Garrett";
                case "HFD": return "Harford";

                default: return String.Empty;
            }
        }
    }
}