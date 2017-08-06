using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class GeorgiaCountyListBuilder : CountyListBuilder
    {
        public GeorgiaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "GA";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "APPL": return "Appling";
                case "ATKN": return "Atkinson";
                case "BACN": return "Bacon";
                case "BAKR": return "Baker";
                case "BALD": return "Baldwin";
                case "BANK": return "Banks";
                case "BARR": return "Barrow";
                case "BART": return "Bartow";
                case "HILL": return "Ben";
                case "BERR": return "Berrien";
                case "BIBB": return "Bibb";
                case "BLEC": return "Bleckley";
                case "BRAN": return "Brantley";
                case "BROK": return "Brooks";
                case "BRYN": return "Bryan";
                case "BULL": return "Bulloch";
                case "BURK": return "Burke";
                case "BUTT": return "Butts";
                case "CALH": return "Calhoun";
                case "CMDN": return "Camden";
                case "CAND": return "Candler";
                case "CARR": return "Carroll";
                case "CATO": return "Catoosa";
                case "CHAR": return "Charlton";
                case "CHTM": return "Chatham";
                case "CHAT": return "Chattahoochee";
                case "CHGA": return "Chattooga";
                case "CHER": return "Cherokee";
                case "CLKE": return "Clarke";
                case "CLAY": return "Clay";
                case "CLTN": return "Clayton";
                case "CLCH": return "Clinch";
                case "COBB": return "Cobb";
                case "COFF": return "Coffee";
                case "COLQ": return "Colquitt";
                case "COLU": return "Columbia";
                case "COOK": return "Cook";
                case "COWE": return "Coweta";
                case "CRAW": return "Crawford";
                case "CRIS": return "Crisp";
                case "DADE": return "Dade";
                case "DAWS": return "Dawson";
                case "DECA": return "Decatur";
                case "DKLB": return "Dekalb";
                case "DODG": return "Dodge";
                case "DOOL": return "Dooly";
                case "DHTY": return "Dougherty";
                case "DOUG": return "Douglas";
                case "EARL": return "Early";
                case "ECHO": return "Echols";
                case "EFFI": return "Effingham";
                case "ELBE": return "Elbert";
                case "EMAN": return "Emanuel";
                case "EVAN": return "Evans";
                case "FANN": return "Fannin";
                case "FAYE": return "Fayette";
                case "FLOY": return "Floyd";
                case "FORS": return "Forsyth";
                case "FRAN": return "Franklin";
                case "FULT": return "Fulton";
                case "GILM": return "Gilmer";
                case "GLAS": return "Glascock";
                case "GLYN": return "Glynn";
                case "GORD": return "Gordon";
                case "GRAD": return "Grady";
                case "GREE": return "Greene";
                case "GWIN": return "Gwinnett";
                case "HABE": return "Habersham";
                case "HALL": return "Hall";
                case "HANC": return "Hancock";
                case "HARA": return "Haralson";
                case "HARR": return "Harris";
                case "HART": return "Hart";
                case "HEAR": return "Heard";
                case "HNRY": return "Henry";
                case "HOUS": return "Houston";
                case "IRWI": return "Irwin";
                case "JACK": return "Jackson";
                case "JASP": return "Jasper";
                case "DAVIS": return "Jeff";
                case "JEFF": return "Jefferson";
                case "JENK": return "Jenkins";
                case "JOHN": return "Johnson";
                case "JONE": return "Jones";
                case "LAMA": return "Lamar";
                case "LANI": return "Lanier";
                case "LAUR": return "Laurens";
                case "LEE": return "Lee";
                case "LIBE": return "Liberty";
                case "LINC": return "Lincoln";
                case "LONG": return "Long";
                case "LOWN": return "Lowndes";
                case "LUMP": return "Lumpkin";
                case "MACO": return "Macon";
                case "MADI": return "Madison";
                case "MARI": return "Marion";
                case "MCDU": return "Mcduffie";
                case "MCIN": return "Mcintosh";
                case "MERI": return "Meriwether";
                case "MILL": return "Miller";
                case "MITC": return "Mitchell";
                case "MNRO": return "Monroe";
                case "MONT": return "Montgomery";
                case "MORG": return "Morgan";
                case "MURR": return "Murray";
                case "MUSC": return "Muscogee";
                case "NEWT": return "Newton";
                case "OCON": return "Oconee";
                case "OGLE": return "Oglethorpe";
                case "PAUL": return "Paulding";
                case "PEAC": return "Peach";
                case "PICK": return "Pickens";
                case "PIER": return "Pierce";
                case "PIKE": return "Pike";
                case "POLK": return "Polk";
                case "PULA": return "Pulaski";
                case "PUTN": return "Putnam";
                case "QUIT": return "Quitman";
                case "RABU": return "Rabun";
                case "RAND": return "Randolph";
                case "RICH": return "Richmond";
                case "ROCK": return "Rockdale";
                case "SCHL": return "Schley";
                case "SCRE": return "Screven";
                case "SEMI": return "Seminole";
                case "SPAL": return "Spalding";
                case "STEP": return "Stephens";
                case "STWT": return "Stewart";
                case "SUMT": return "Sumter";
                case "TLBT": return "Talbot";
                case "TALI": return "Taliaferro";
                case "TATT": return "Tattnall";
                case "TAYL": return "Taylor";
                case "TELF": return "Telfair";
                case "TERR": return "Terrell";
                case "THOM": return "Thomas";
                case "TIFT": return "Tift";
                case "TOOM": return "Toombs";
                case "TOWN": return "Towns";
                case "TREU": return "Treutlen";
                case "TROU": return "Troup";
                case "TURN": return "Turner";
                case "TWIG": return "Twiggs";
                case "UNIO": return "Union";
                case "UPSO": return "Upson";
                case "WLKR": return "Walker";
                case "WALT": return "Walton";
                case "WARE": return "Ware";
                case "WARR": return "Warren";
                case "WASH": return "Washington";
                case "WAYN": return "Wayne";
                case "WEBS": return "Webster";
                case "WHEE": return "Wheeler";
                case "WHIT": return "White";
                case "WFLD": return "Whitfield";
                case "WCOX": return "Wilcox";
                case "WILK": return "Wilkes";
                case "WKSN": return "Wilkinson";
                case "WORT": return "Worth";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "APPL","ATKN","BACN","BAKR","BALD",
                "BANK","BARR","BART","HILL","BERR",
                "BIBB","BLEC","BRAN","BROK","BRYN",
                "BULL","BURK","BUTT","CALH","CMDN",
                "CAND","CARR","CATO","CHAR","CHTM",
                "CHAT","CHGA","CHER","CLKE","CLAY",
                "CLTN","CLCH","COBB","COFF","COLQ",
                "COLU","COOK","COWE","CRAW","CRIS",
                "DADE","DAWS","DECA","DKLB","DODG",
                "DOOL","DHTY","DOUG","EARL","ECHO",
                "EFFI","ELBE","EMAN","EVAN","FANN",
                "FAYE","FLOY","FORS","FRAN","FULT",
                "GILM","GLAS","GLYN","GORD","GRAD",
                "GREE","GWIN","HABE","HALL","HANC",
                "HARA","HARR","HART","HEAR","HNRY",
                "HOUS","IRWI","JACK","JASP","DAVIS",
                "JEFF","JENK","JOHN","JONE","LAMA",
                "LANI","LAUR","LEE","LIBE","LINC",
                "LONG","LOWN","LUMP","MACO","MADI",
                "MARI","MCDU","MCIN","MERI","MILL",
                "MITC","MNRO","MONT","MORG","MURR",
                "MUSC","NEWT","OCON","OGLE","PAUL",
                "PEAC","PICK","PIER","PIKE","POLK",
                "PULA","PUTN","QUIT","RABU","RAND",
                "RICH","ROCK","SCHL","SCRE","SEMI",
                "SPAL","STEP","STWT","SUMT","TLBT",
                "TALI","TATT","TAYL","TELF","TERR",
                "THOM","TIFT","TOOM","TOWN","TREU",
                "TROU","TURN","TWIG","UNIO","UPSO",
                "WLKR","WALT","WARE","WARR","WASH",
                "WAYN","WEBS","WHEE","WHIT","WFLD",
                "WCOX","WILK","WKSN","WORT"};
        }
    }
}
