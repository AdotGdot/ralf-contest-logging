using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class SouthDakotaCountyListBuilder : CountyListBuilder
    {
        public SouthDakotaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "SD";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "AURO","BEAD","BENN","BONH","BROO",
                "BRUL","BRWN","BUFF","BUTT","CAMP",
                "CHAR","CLAY","CLRK","CODI","CORS",
                "CUST","DAVI","DAY","DEUE","DEWY",
                "DGLS","EDMU","FALL","FAUL","GRAN",
                "GREG","HAAK","HAML","HAND","HNSN",
                "HRDG","HUGH","HUTC","HYDE","JERA",
                "JKSN","JONE","KING","LAKE","LAWR",
                "LINC","LYMA","MCOO","MCPH","MEAD",
                "MELL","MINE","MINN","MOOD","MRSH",
                "OGLA","PENN","PERK","POTT","ROBE",
                "SANB","SPIN","STAN","SULL","TODD",
                "TRIP","TURN","UNIO","WALW","YANK",
                "ZIEB" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "AURO": return "Aurora";
                case "BEAD": return "Beadle";
                case "BENN": return "Bennett";
                case "BONH": return "Bon Homme";
                case "BROO": return "Brookings";
                case "BRUL": return "Brule";
                case "BRWN": return "Brown";
                case "BUFF": return "Buffalo";
                case "BUTT": return "Butte";
                case "CAMP": return "Campbell";
                case "CHAR": return "Charles Mix";
                case "CLAY": return "Clay";
                case "CLRK": return "Clark";
                case "CODI": return "Codington";
                case "CORS": return "Corson";
                case "CUST": return "Custer";
                case "DAVI": return "Davison";
                case "DAY": return "Day";
                case "DEUE": return "Deuel";
                case "DEWY": return "Dewey";
                case "DGLS": return "Douglas";
                case "EDMU": return "Edmunds";
                case "FALL": return "Fall River";
                case "FAUL": return "Faulk";
                case "GRAN": return "Grant";
                case "GREG": return "Gregory";
                case "HAAK": return "Haakon";
                case "HAML": return "Hamlin";
                case "HAND": return "Hand";
                case "HNSN": return "Hanson";
                case "HRDG": return "Harding";
                case "HUGH": return "Hughes";
                case "HUTC": return "Hutchinson";
                case "HYDE": return "Hyde";
                case "JERA": return "Jerauld";
                case "JKSN": return "Jackson";
                case "JONE": return "Jones";
                case "KING": return "Kingsbury";
                case "LAKE": return "Lake";
                case "LAWR": return "Lawrence";
                case "LINC": return "Lincoln";
                case "LYMA": return "Lyman";
                case "MCOO": return "Mccook";
                case "MCPH": return "Mcpherson";
                case "MEAD": return "Meade";
                case "MELL": return "Mellette";
                case "MINE": return "Miner";
                case "MINN": return "Minnehaha";
                case "MOOD": return "Moody";
                case "MRSH": return "Marshall";
                case "OGLA": return "Oglala Lakota";
                case "PENN": return "Pennington";
                case "PERK": return "Perkins";
                case "POTT": return "Potter";
                case "ROBE": return "Roberts";
                case "SANB": return "Sanborn";
                case "SPIN": return "Spink";
                case "STAN": return "Stanley";
                case "SULL": return "Sully";
                case "TODD": return "Todd";
                case "TRIP": return "Tripp";
                case "TURN": return "Turner";
                case "UNIO": return "Union";
                case "WALW": return "Walworth";
                case "YANK": return "Yankton";
                case "ZIEB": return "Ziebach";
                default: return String.Empty;
            }
        }
    }
}
