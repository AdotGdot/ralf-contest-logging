using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class IdahoCountyListBuilder : CountyListBuilder
    {
        public IdahoCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "ID";
            buildCountyAbbrArray();
        }
        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Ada";
                case "ADM": return "Adams";
                case "BAN": return "Bannock";
                case "BEA": return "Bear Lake";
                case "BEN": return "Benewah";
                case "BIN": return "Bingham";
                case "BLA": return "Blaine";
                case "BNR": return "Bonner";
                case "BNV": return "Bonneville";
                case "BOI": return "Boise";
                case "BOU": return "Boundary";
                case "BUT": return "Butte";
                case "CAM": return "Camas";
                case "CAN": return "Canyon";
                case "CAR": return "Caribou";
                case "CAS": return "Cassia";
                case "CLA": return "Clark";
                case "CLE": return "Clearwater";
                case "CUS": return "Custer";
                case "ELM": return "Elmore";
                case "FRA": return "Franklin";
                case "FRE": return "Fremont";
                case "GEM": return "Gem";
                case "GOO": return "Gooding";
                case "IDA": return "Idaho";
                case "JEF": return "Jefferson";
                case "JER": return "Jerome";
                case "KOO": return "Kootenai";
                case "LAT": return "Latah";
                case "LEM": return "Lemhi";
                case "LEW": return "Lewis";
                case "LIN": return "Lincoln";
                case "MAD": return "Madison";
                case "MIN": return "Minidoka";
                case "NEZ": return "Nez Perce";
                case "ONE": return "Oneida";
                case "OWY": return "Owyhee";
                case "PAY": return "Payette";
                case "POW": return "Power";
                case "SHO": return "Shoshone";
                case "TET": return "Teton";
                case "TWI": return "Twin Falls";
                case "VAL": return "Valley";
                case "WAS": return "Washington";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ADM","BAN","BEA","BEN",
                "BIN","BLA","BNR","BNV","BOI",
                "BOU","BUT","CAM","CAN","CAR",
                "CAS","CLA","CLE","CUS","ELM",
                "FRA","FRE","GEM","GOO","IDA",
                "JEF","JER","KOO","LAT","LEM",
                "LEW","LIN","MAD","MIN","NEZ",
                "ONE","OWY","PAY","POW","SHO",
                "TET","TWI","VAL","WAS"};
        }
    }
}