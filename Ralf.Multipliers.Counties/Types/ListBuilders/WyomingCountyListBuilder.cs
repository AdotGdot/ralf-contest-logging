using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class WyomingCountyListBuilder : CountyListBuilder
    {
        public WyomingCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "WY";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALB", "CRO", "LAR", "PLA", "TET",
                "BIG", "FRE", "LIN", "SHE", "UIN",
                "CAM", "GOS", "NAT", "SUB", "WAS",
                "CAR", "HOT", "NIO", "SWE", "WES",
                "CON", "JOH", "PAR" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALB": return "Albany";
                case "CRO": return "Crook";
                case "LAR": return "Laramie";
                case "PLA": return "Platte";
                case "TET": return "Teton";
                case "BIG": return "Big Horn";
                case "FRE": return "Fremont";
                case "LIN": return "Lincoln";
                case "SHE": return "Sheridan";
                case "UIN": return "Uinta";
                case "CAM": return "Campbell";
                case "GOS": return "Goshen";
                case "NAT": return "Natrona";
                case "SUB": return "Sublette";
                case "WAS": return "Washakie";
                case "CAR": return "Carbon";
                case "HOT": return "Hot Springs";
                case "NIO": return "Niobrara";
                case "SWE": return "Sweetwater";
                case "WES": return "Weston";
                case "CON": return "Converse";
                case "JOH": return "Johnson";
                case "PAR": return "Park";
                default: return String.Empty;
            }
        }
    }
}