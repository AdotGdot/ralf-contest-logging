using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NebraskaCountyListBuilder : CountyListBuilder
    {
        public NebraskaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NE";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADMS","ANTE","ARTH","BANN","BLAI",
                "BOON","BOXB","BOYD","BRWN","BUFF",
                "BURT","BUTL","CASS","CEDA","CHAS",
                "CHER","CHEY","CLAY","CLOF","CUMI",
                "CUST","DAKO","DAWE","DAWS","DEUE",
                "DIXO","DODG","DGLS","DUND","FILL",
                "FRNK","FRON","FURN","GAGE","GARD",
                "GARF","GOSP","GRAN","GREE","HALL",
                "HAMI","HRLN","HAYE","HITC","HOLT",
                "HOOK","HOWA","JEFF","JOHN","KEAR",
                "KEIT","KEYA","KIMB","KNOX","LNCS",
                "LINC","LOGA","LOUP","MDSN","MCPH",
                "MERR","MORR","NANC","NEMA","NUCK",
                "OTOE","PAWN","PERK","PHEL","PIER",
                "PLAT","POLK","REDW","RICH","ROCK",
                "SALI","SARP","SAUN","SCOT","SEWA",
                "SHRD","SHRM","SIOU","STAN","THAY",
                "THOM","THUR","VLLY","WASH","WAYN",
                "WEBS","WHEE","YORK"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADMS": return "Adams";
                case "ANTE": return "Antelope";
                case "ARTH": return "Arthur";
                case "BANN": return "Banner";
                case "BLAI": return "Blaine";
                case "BOON": return "Boone";
                case "BOXB": return "Box Butte";
                case "BOYD": return "Boyd";
                case "BRWN": return "Brown";
                case "BUFF": return "Buffalo";
                case "BURT": return "Burt";
                case "BUTL": return "Butler";
                case "CASS": return "Cass";
                case "CEDA": return "Cedar";
                case "CHAS": return "Chase";
                case "CHER": return "Cherry";
                case "CHEY": return "Cheyenne";
                case "CLAY": return "Clay";
                case "CLOF": return "Colfax";
                case "CUMI": return "Cuming";
                case "CUST": return "Custer";
                case "DAKO": return "Dakota";
                case "DAWE": return "Dawes";
                case "DAWS": return "Dawson";
                case "DEUE": return "Deuel";
                case "DIXO": return "Dixon";
                case "DODG": return "Dodge";
                case "DGLS": return "Douglas";
                case "DUND": return "Dundy";
                case "FILL": return "Fillmore";
                case "FRNK": return "Franklin";
                case "FRON": return "Frontier";
                case "FURN": return "Furnas";
                case "GAGE": return "Gage";
                case "GARD": return "Garden";
                case "GARF": return "Garfield";
                case "GOSP": return "Gosper";
                case "GRAN": return "Grant";
                case "GREE": return "Greeley";
                case "HALL": return "Hall";
                case "HAMI": return "Hamilton";
                case "HRLN": return "Harlan";
                case "HAYE": return "Hayes";
                case "HITC": return "Hitchcock";
                case "HOLT": return "Holt";
                case "HOOK": return "Hooker";
                case "HOWA": return "Howard";
                case "JEFF": return "Jefferson";
                case "JOHN": return "Johnson";
                case "KEAR": return "Kearney";
                case "KEIT": return "Keith";
                case "KEYA": return "Keya Paha";
                case "KIMB": return "Kimball";
                case "KNOX": return "Knox";
                case "LNCS": return "Lancaster";
                case "LINC": return "Lincoln";
                case "LOGA": return "Logan";
                case "LOUP": return "Loup";
                case "MDSN": return "Madison";
                case "MCPH": return "Mcpherson";
                case "MERR": return "Merrick";
                case "MORR": return "Morrill";
                case "NANC": return "Nance";
                case "NEMA": return "Nemaha";
                case "NUCK": return "Nuckolls";
                case "OTOE": return "Otoe";
                case "PAWN": return "Pawnee";
                case "PERK": return "Perkins";
                case "PHEL": return "Phelps";
                case "PIER": return "Pierce";
                case "PLAT": return "Platte";
                case "POLK": return "Polk";
                case "REDW": return "Red Willow";
                case "RICH": return "Richardson";
                case "ROCK": return "Rock";
                case "SALI": return "Saline";
                case "SARP": return "Sarpy";
                case "SAUN": return "Saunders";
                case "SCOT": return "Scotts Bluff";
                case "SEWA": return "Seward";
                case "SHRD": return "Sheridan";
                case "SHRM": return "Sherman";
                case "SIOU": return "Sioux";
                case "STAN": return "Stanton";
                case "THAY": return "Thayer";
                case "THOM": return "Thomas";
                case "THUR": return "Thurston";
                case "VLLY": return "Valley";
                case "WASH": return "Washington";
                case "WAYN": return "Wayne";
                case "WEBS": return "Webster";
                case "WHEE": return "Wheeler";
                case "YORK": return "York";
                default: return String.Empty;
            }
        }
    }
}
