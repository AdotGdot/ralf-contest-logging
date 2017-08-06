using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MassachusettsCountyListBuilder : CountyListBuilder
    {
        public MassachusettsCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MA";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BAR": return "Barnstable";
                case "BER": return "Berkshire";
                case "BRI": return "Bristol";
                case "DUK": return "Dukes";
                case "ESS": return "Essex";
                case "FRA": return "Franklin";
                case "HMD": return "Hampden";
                case "HMP": return "Hampshire";
                case "MID": return "Middlesex";
                case "NAN": return "Nantucket";
                case "NOR": return "Norfolk";
                case "PLY": return "Plymouth";
                case "SUF": return "Suffolk";
                case "WOR": return "Worcester";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BAR","BER","BRI","DUK","ESS",
                "FRA","HMD","HMP","MID","NAN",
                "NOR","PLY","SUF","WOR"};
        }
    }
}
