using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NewJerseyCountyListBuilder : CountyListBuilder
    {
        public NewJerseyCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NJ";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ATLA": return "Atlantic";
                case "BERG": return "Bergen";
                case "BURL": return "Burlington";
                case "CAPE": return "Cape May";
                case "CMDN": return "Camden";
                case "CUMB": return "Cumberland";
                case "ESSE": return "Essex";
                case "GLOU": return "Glouster";
                case "HUDS": return "Hudson";
                case "HUNT": return "Hunterdon";
                case "MERC": return "Mercer";
                case "MIDD": return "Middlesex";
                case "MONM": return "Monmouth";
                case "MORR": return "Morris";
                case "OCEA": return "Ocean";
                case "PASS": return "Passaic";
                case "SALE": return "Salem";
                case "SOME": return "Somerset";
                case "SUSS": return "Sussex";
                case "UNIO": return "Union";
                case "WRRN": return "Warren";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ATLA","BERG","BURL","CAPE","CMDN",
                "CUMB","ESSE","GLOU","HUDS","HUNT",
                "MERC","MIDD","MONM","MORR","OCEA",
                "PASS","SALE","SOME","SUSS","UNIO",
                "WRRN"};
        }
    }
}
