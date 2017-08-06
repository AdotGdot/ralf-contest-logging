using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class ArizonaCountyListBuilder : CountyListBuilder
    {
        public ArizonaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "AZ";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "APH","GLA","LPZ","NVO","SCZ",
                "CHS","GHM","MCP","PMA","YVP",
                "CNO","GLE","MHV","PNL","YMA" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "APH": return "Apache";
                case "GLA": return "Gila";
                case "LPZ": return "La Paz";
                case "NVO": return "Navajo";
                case "SCZ": return "Santa Cruz";
                case "CHS": return "Cochise";
                case "GHM": return "Graham";
                case "MCP": return "Maricopa";
                case "PMA": return "Pima";
                case "YVP": return "Yavapai";
                case "CNO": return "Coconino";
                case "GLE": return "Greenlee";
                case "MHV": return "Mohave";
                case "PNL": return "Pinal";
                case "YMA": return "Yuma";
                default: return String.Empty;
            }
        }
    }
}