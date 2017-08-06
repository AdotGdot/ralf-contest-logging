using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class ArkansasCountyListBuilder : CountyListBuilder
    {
        public ArkansasCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "AR";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ARKA","ASHL","BAXT","BENT","BOON",
                "BRAD","CALH","CARR","CHIC","CLRK",
                "CLAY","CLEB","CLEV","COLU","CONW",
                "CRAG","CRAW","CRIT","CROS","DALL",
                "DESH","DREW","FAUL","FRNK","FULT",
                "GARL","GRNT","GREN","HEMP","HSPR",
                "HOWA","INDE","IZRD","JACK","JEFF",
                "JOHN","LAFA","LAWR","LEE","LINC",
                "LRVR","LOGN","LONO","MADI","MARI",
                "MILL","MISS","MONR","MTGY","NEVA",
                "NEWT","OUAC","PERR","PHIL","PIKE",
                "POIN","POLK","POPE","PRAR","PULA",
                "RAND","SALI","SCOT","SRCY","SEBA",
                "SEVR","SHRP","STFR","STON","UNIO",
                "VBRN","WASH","WHIE","WOOD","YELL" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ARKA": return "Arkansas";
                case "ASHL": return "Ashley";
                case "BAXT": return "Baxter";
                case "BENT": return "Benton";
                case "BOON": return "Boone";
                case "BRAD": return "Bradley";
                case "CALH": return "Calhoun";
                case "CARR": return "Carroll";
                case "CHIC": return "Chicot";
                case "CLRK": return "Clark";
                case "CLAY": return "Clay";
                case "CLEB": return "Cleburne";
                case "CLEV": return "Cleveland";
                case "COLU": return "Columbia";
                case "CONW": return "Conway";
                case "CRAG": return "Craighead";
                case "CRAW": return "Crawford";
                case "CRIT": return "Crittenden";
                case "CROS": return "Cross";
                case "DALL": return "Dallas";
                case "DESH": return "Desha";
                case "DREW": return "Drew";
                case "FAUL": return "Faulkner";
                case "FRNK": return "Franklin";
                case "FULT": return "Fulton";
                case "GARL": return "Garland";
                case "GRNT": return "Grant";
                case "GREN": return "Greene";
                case "HEMP": return "Hempstead";
                case "HSPR": return "Hot Spring";
                case "HOWA": return "Howard";
                case "INDE": return "Independence";
                case "IZRD": return "Izard";
                case "JACK": return "Jackson";
                case "JEFF": return "Jefferson";
                case "JOHN": return "Johnson";
                case "LAFA": return "Lafayette";
                case "LAWR": return "Lawrence";
                case "LEE": return "Lee";
                case "LINC": return "Lincoln";
                case "LRVR": return "Little River";
                case "LOGN": return "Logan";
                case "LONO": return "Lonoke";
                case "MADI": return "Madison";
                case "MARI": return "Marion";
                case "MILL": return "Miller";
                case "MISS": return "Mississippi";
                case "MONR": return "Monroe";
                case "MTGY": return "Montgomery";
                case "NEVA": return "Nevada";
                case "NEWT": return "Newton";
                case "OUAC": return "Ouachita";
                case "PERR": return "Perry";
                case "PHIL": return "Phillips";
                case "PIKE": return "Pike";
                case "POIN": return "Poinsett";
                case "POLK": return "Polk";
                case "POPE": return "Pope";
                case "PRAR": return "Prairie";
                case "PULA": return "Pulaski";
                case "RAND": return "Randolph";
                case "SALI": return "Saline";
                case "SCOT": return "Scott";
                case "SRCY": return "Searcy";
                case "SEBA": return "Sebastian";
                case "SEVR": return "Sevier";
                case "SHRP": return "Sharp";
                case "STFR": return "St. Francis";
                case "STON": return "Stone";
                case "UNIO": return "Union";
                case "VBRN": return "Van Buren";
                case "WASH": return "Washington";
                case "WHIE": return "White";
                case "WOOD": return "Woodruff";
                case "YELL": return "Yell";
                default: return String.Empty;
            }
        }
    }
}
