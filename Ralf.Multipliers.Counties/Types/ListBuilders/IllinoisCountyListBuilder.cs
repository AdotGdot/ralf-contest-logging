using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class IllinoisCountyListBuilder : CountyListBuilder
    {
        public IllinoisCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "IL";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADAM": return "Adams";
                case "ALEX": return "Alexander";
                case "BOND": return "Bond";
                case "BOON": return "Boone";
                case "BROW": return "Brown";
                case "BURO": return "Bureau";
                case "CALH": return "Calhoun";
                case "CARR": return "Carroll";
                case "CASS": return "Cass";
                case "CHAM": return "Champaign";
                case "CHRS": return "Christian";
                case "CLRK": return "Clark";
                case "CLAY": return "Clay";
                case "CLNT": return "Clinton";
                case "COLE": return "Coles";
                case "COOK": return "Cook";
                case "CRAW": return "Crawford";
                case "CUMB": return "Cumberland";
                case "DEKA": return "Dekalb";
                case "DEWT": return "Dewitt";
                case "DOUG": return "Douglas";
                case "DUPG": return "Dupage";
                case "EDGR": return "Edgar";
                case "EDWA": return "Edward";
                case "EFFG": return "Effingham";
                case "FAYE": return "Fayette";
                case "FORD": return "Ford";
                case "FRNK": return "Franklin";
                case "FULT": return "Fulton";
                case "GALL": return "Gallatin";
                case "GREE": return "Greene";
                case "GRUN": return "Grundy";
                case "HAML": return "Hamilton";
                case "HANC": return "Hancock";
                case "HARD": return "Hardin";
                case "HNDR": return "Henderson";
                case "HENR": return "Henry";
                case "IROQ": return "Iroquois";
                case "JACK": return "Jackson";
                case "JASP": return "Jasper";
                case "JEFF": return "Jefferson";
                case "JERS": return "Jersey";
                case "JODA": return "Jodaviess";
                case "JOHN": return "Johnson";
                case "KANE": return "Kane";
                case "KANK": return "Kankakee";
                case "KEND": return "Kendall";
                case "KNOX": return "Knox";
                case "LAKE": return "Lake";
                case "LASA": return "Lasalle";
                case "LAWR": return "Lawrence";
                case "LEE": return "Lee";
                case "LIVG": return "Livingston";
                case "LOGN": return "Logan";
                case "MACN": return "Macon";
                case "MCPN": return "Macoupin";
                case "MADN": return "Madison";
                case "MARI": return "Marion";
                case "MSHL": return "Marshall";
                case "MASN": return "Mason";
                case "MSSC": return "Massac";
                case "MCDN": return "Mcdonough";
                case "MCHE": return "Mchenry";
                case "MCLN": return "Mclean";
                case "MNRD": return "Menard";
                case "MRCR": return "Mercer";
                case "MNRO": return "Monroe";
                case "MNTG": return "Montgomery";
                case "MORG": return "Morgan";
                case "MOUL": return "Moultrie";
                case "OGLE": return "Ogle";
                case "PEOR": return "Peoria";
                case "PERR": return "Perry";
                case "PIAT": return "Piatt";
                case "PIKE": return "Pike";
                case "POPE": return "Pope";
                case "PULA": return "Pulaski";
                case "PUTN": return "Putnam";
                case "RAND": return "Randolph";
                case "RICH": return "Richland";
                case "ROCK": return "Rock Island";
                case "SALI": return "Saline";
                case "SANG": return "Sangamon";
                case "SCHY": return "Schuyler";
                case "SCOT": return "Scott";
                case "SHEL": return "Shelby";
                case "SCLA": return "St  Clair";
                case "STAR": return "Stark";
                case "STEP": return "Stephenson";
                case "TAZW": return "Tazewell";
                case "UNIO": return "Union";
                case "VERM": return "Vermilion";
                case "WABA": return "Wabash";
                case "WARR": return "Warren";
                case "WASH": return "Washington";
                case "WAYN": return "Wayne";
                case "WHIT": return "White";
                case "WTSD": return "Whiteside";
                case "WILL": return "Will";
                case "WMSN": return "Williamson";
                case "WBGO": return "Winnebago";
                case "WOOD": return "Woodford";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADAM","ALEX","BOND","BOON","BROW",
                "BURO","CALH","CARR","CASS","CHAM",
                "CHRS","CLRK","CLAY","CLNT","COLE",
                "COOK","CRAW","CUMB","DEKA","DEWT",
                "DOUG","DUPG","EDGR","EDWA","EFFG",
                "FAYE","FORD","FRNK","FULT","GALL",
                "GREE","GRUN","HAML","HANC","HARD",
                "HNDR","HENR","IROQ","JACK","JASP",
                "JEFF","JERS","JODA","JOHN","KANE",
                "KANK","KEND","KNOX","LAKE","LASA",
                "LAWR","LEE","LIVG","LOGN","MACN",
                "MCPN","MADN","MARI","MSHL","MASN",
                "MSSC","MCDN","MCHE","MCLN","MNRD",
                "MRCR","MNRO","MNTG","MORG","MOUL",
                "OGLE","PEOR","PERR","PIAT","PIKE",
                "POPE","PULA","PUTN","RAND","RICH",
                "ROCK","SALI","SANG","SCHY","SCOT",
                "SHEL","SCLA","STAR","STEP","TAZW",
                "UNIO","VERM","WABA","WARR","WASH",
                "WAYN","WHIT","WTSD","WILL","WMSN",
                "WBGO","WOOD"};
        }
    }
}
