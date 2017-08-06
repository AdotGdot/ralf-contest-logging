using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class TexasCountyListBuilder : CountyListBuilder
    {
        public TexasCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "TX";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ANDE": return "Anderson";
                case "ANDR": return "Andrews";
                case "ANGE": return "Angelina";
                case "ARAN": return "Aransas";
                case "ARCH": return "Archer";
                case "ARMS": return "Armstrong";
                case "ATAS": return "Atascosa";
                case "AUST": return "Austin";
                case "BAIL": return "Bailey";
                case "BAND": return "Bandera";
                case "BAST": return "Bastrop";
                case "BAYL": return "Baylor";
                case "BEE": return "Bee";
                case "BELL": return "Bell";
                case "BEXA": return "Bexar";
                case "BLAN": return "Blanco";
                case "BORD": return "Borden";
                case "BOSQ": return "Bosque";
                case "BOWI": return "Bowie";
                case "BZIA": return "Brazoria";
                case "BZOS": return "Brazos";
                case "BREW": return "Brewster";
                case "BRIS": return "Briscoe";
                case "BROO": return "Brooks";
                case "BROW": return "Brown";
                case "BURL": return "Burleson";
                case "BURN": return "Burnet";
                case "CALD": return "Caldwell";
                case "CALH": return "Calhoun";
                case "CALL": return "Callahan";
                case "CMRN": return "Cameron";
                case "CAMP": return "Camp";
                case "CARS": return "Carson";
                case "CASS": return "Cass";
                case "CAST": return "Castro";
                case "CHAM": return "Chambers";
                case "CHER": return "Cherokee";
                case "CHIL": return "Childress";
                case "CLAY": return "Clay";
                case "COCH": return "Cochran";
                case "COKE": return "Coke";
                case "COLE": return "Coleman";
                case "COLN": return "Collin";
                case "COLW": return "Collingsworth";
                case "COLO": return "Colorado";
                case "COML": return "Comal";
                case "COMA": return "Comanche";
                case "CONC": return "Concho";
                case "COOK": return "Cooke";
                case "CORY": return "Coryell";
                case "COTT": return "Cottle";
                case "CRAN": return "Crane";
                case "CROC": return "Crockett";
                case "CROS": return "Crosby";
                case "CULB": return "Culberson";
                case "DALM": return "Dallam";
                case "DALS": return "Dallas";
                case "DAWS": return "Dawson";
                case "DSMI": return "Deaf Smith";
                case "DELT": return "Delta";
                case "DENT": return "Denton";
                case "DEWI": return "Dewitt";
                case "DICK": return "Dickens";
                case "DIMM": return "Dimmit";
                case "DONL": return "Donley";
                case "DUVA": return "Duval";
                case "EAST": return "Eastland";
                case "ECTO": return "Ector";
                case "EDWA": return "Edwards";
                case "EPAS": return "El Paso";
                case "ELLI": return "Ellis";
                case "ERAT": return "Erath";
                case "FALL": return "Falls";
                case "FANN": return "Fannin";
                case "FAYE": return "Fayette";
                case "FISH": return "Fisher";
                case "FLOY": return "Floyd";
                case "FOAR": return "Foard";
                case "FBEN": return "Fort Bend";
                case "FRAN": return "Franklin";
                case "FREE": return "Freestone";
                case "FRIO": return "Frio";
                case "GAIN": return "Gaines";
                case "GALV": return "Galveston";
                case "GARZ": return "Garza";
                case "GILL": return "Gillespie";
                case "GLAS": return "Glasscock";
                case "GOLI": return "Goliad";
                case "GONZ": return "Gonzales";
                case "GRAY": return "Gray";
                case "GRSN": return "Grayson";
                case "GREG": return "Gregg";
                case "GRIM": return "Grimes";
                case "GUAD": return "Guadalupe";
                case "HALE": return "Hale";
                case "HALL": return "Hall";
                case "HAMI": return "Hamilton";
                case "HANS": return "Hansford";
                case "HDMN": return "Hardeman";
                case "HRDN": return "Hardin";
                case "HARR": return "Harris";
                case "HRSN": return "Harrison";
                case "HART": return "Hartley";
                case "HASK": return "Haskell";
                case "HAYS": return "Hays";
                case "HEMP": return "Hemphill";
                case "HEND": return "Henderson";
                case "HIDA": return "Hidalgo";
                case "HILL": return "Hill";
                case "HOCK": return "Hockley";
                case "HOOD": return "Hood";
                case "HOPK": return "Hopkins";
                case "HOUS": return "Houston";
                case "HOWA": return "Howard";
                case "HUDS": return "Hudspeth";
                case "HUNT": return "Hunt";
                case "HUTC": return "Hutchinson";
                case "IRIO": return "Irion";
                case "JACK": return "Jack";
                case "JKSN": return "Jackson";
                case "JASP": return "Jasper";
                case "JDAV": return "Jeff Davis";
                case "JEFF": return "Jefferson";
                case "JHOG": return "Jim Hogg";
                case "JWEL": return "Jim Wells";
                case "JOHN": return "Johnson";
                case "JONE": return "Jones";
                case "KARN": return "Karnes";
                case "KAUF": return "Kaufman";
                case "KEND": return "Kendall";
                case "KENY": return "Kenedy";
                case "KENT": return "Kent";
                case "KERR": return "Kerr";
                case "KIMB": return "Kimble";
                case "KING": return "King";
                case "KINN": return "Kinney";
                case "KLEB": return "Kleberg";
                case "KNOX": return "Knox";
                case "LSAL": return "La Salle";
                case "LAMA": return "Lamar";
                case "LAMB": return "Lamb";
                case "LAMP": return "Lampasas";
                case "LAVA": return "Lavaca";
                case "LEE": return "Lee";
                case "LEON": return "Leon";
                case "LIBE": return "Liberty";
                case "LIME": return "Limestone";
                case "LIPS": return "Lipscomb";
                case "LIVO": return "Live Oak";
                case "LLAN": return "Llano";
                case "LOVI": return "Loving";
                case "LUBB": return "Lubbock";
                case "LYNN": return "Lynn";
                case "MADI": return "Madison";
                case "MARI": return "Marion";
                case "MART": return "Martin";
                case "MASO": return "Mason";
                case "MATA": return "Matagorda";
                case "MAVE": return "Maverick";
                case "MCUL": return "McCulloch";
                case "MLEN": return "McLennan";
                case "MMUL": return "McMullen";
                case "MEDI": return "Medina";
                case "MENA": return "Menard";
                case "MIDL": return "Midland";
                case "MILA": return "Milam";
                case "MILL": return "Mills";
                case "MITC": return "Mitchell";
                case "MONT": return "Montague";
                case "MGMY": return "Montgomery";
                case "MOOR": return "Moore";
                case "MORR": return "Morris";
                case "MOTL": return "Motley";
                case "NACO": return "Nacogdoches";
                case "NAVA": return "Navarro";
                case "NEWT": return "Newton";
                case "NOLA": return "Nolan";
                case "NUEC": return "Nueces";
                case "OCHI": return "Ochiltree";
                case "OLDH": return "Oldham";
                case "ORAN": return "Orange";
                case "PPIN": return "Palo Pinto";
                case "PANO": return "Panola";
                case "PARK": return "Parker";
                case "PARM": return "Parmer";
                case "PECO": return "Pecos";
                case "POLK": return "Polk";
                case "POTT": return "Potter";
                case "PRES": return "Presidio";
                case "RAIN": return "Rains";
                case "RAND": return "Randall";
                case "REAG": return "Reagan";
                case "REAL": return "Real";
                case "RRIV": return "Red River";
                case "REEV": return "Reeves";
                case "REFU": return "Refugio";
                case "ROBE": return "Roberts";
                case "RBSN": return "Robertson";
                case "ROCK": return "Rockwall";
                case "RUNN": return "Runnels";
                case "RUSK": return "Rusk";
                case "SABI": return "Sabine";
                case "SAUG": return "San Augustine";
                case "SJAC": return "San Jacinto";
                case "SPAT": return "San Patricio";
                case "SSAB": return "San Saba";
                case "SCHL": return "Schleicher";
                case "SCUR": return "Scurry";
                case "SHAC": return "Shackelford";
                case "SHEL": return "Shelby";
                case "SHMN": return "Sherman";
                case "SMIT": return "Smith";
                case "SOME": return "Somervell";
                case "STAR": return "Starr";
                case "STEP": return "Stephens";
                case "STER": return "Sterling";
                case "STON": return "Stonewall";
                case "SUTT": return "Sutton";
                case "SWIS": return "Swisher";
                case "TARR": return "Tarrant";
                case "TAYL": return "Taylor";
                case "TERL": return "Terrell";
                case "TERY": return "Terry";
                case "THRO": return "Throckmorton";
                case "TITU": return "Titus";
                case "TGRE": return "Tom Green";
                case "TRAV": return "Travis";
                case "TRIN": return "Trinity";
                case "TYLE": return "Tyler";
                case "UPSH": return "Upshur";
                case "UPTO": return "Upton";
                case "UVAL": return "Uvalde";
                case "VVER": return "Val Verde";
                case "VZAN": return "Van Zandt";
                case "VICT": return "Victoria";
                case "WALK": return "Walker";
                case "WALL": return "Waller";
                case "WARD": return "Ward";
                case "WASH": return "Washington";
                case "WEBB": return "Webb";
                case "WHAR": return "Wharton";
                case "WHEE": return "Wheeler";
                case "WICH": return "Wichita";
                case "WILB": return "Wilbarger";
                case "WILY": return "Willacy";
                case "WMSN": return "Williamson";
                case "WLSN": return "Wilson";
                case "WINK": return "Winkler";
                case "WISE": return "Wise";
                case "WOOD": return "Wood";
                case "YOAK": return "Yoakum";
                case "YOUN": return "Young";
                case "ZAPA": return "Zapata";
                case "ZAVA": return "Zavala";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ANDE","ANDR","ANGE","ARAN","ARCH",
                "ARMS","ATAS","AUST","BAIL","BAND",
                "BAST","BAYL","BEE","BELL","BEXA",
                "BLAN","BORD","BOSQ","BOWI","BZIA",
                "BZOS","BREW","BRIS","BROO","BROW",
                "BURL","BURN","CALD","CALH","CALL",
                "CMRN","CAMP","CARS","CASS","CAST",
                "CHAM","CHER","CHIL","CLAY","COCH",
                "COKE","COLE","COLN","COLW","COLO",
                "COML","COMA","CONC","COOK","CORY",
                "COTT","CRAN","CROC","CROS","CULB",
                "DALM","DALS","DAWS","DSMI","DELT",
                "DENT","DEWI","DICK","DIMM","DONL",
                "DUVA","EAST","ECTO","EDWA","EPAS",
                "ELLI","ERAT","FALL","FANN","FAYE",
                "FISH","FLOY","FOAR","FBEN","FRAN",
                "FREE","FRIO","GAIN","GALV","GARZ",
                "GILL","GLAS","GOLI","GONZ","GRAY",
                "GRSN","GREG","GRIM","GUAD","HALE",
                "HALL","HAMI","HANS","HDMN","HRDN",
                "HARR","HRSN","HART","HASK","HAYS",
                "HEMP","HEND","HIDA","HILL","HOCK",
                "HOOD","HOPK","HOUS","HOWA","HUDS",
                "HUNT","HUTC","IRIO","JACK","JKSN",
                "JASP","JDAV","JEFF","JHOG","JWEL",
                "JOHN","JONE","KARN","KAUF","KEND",
                "KENY","KENT","KERR","KIMB","KING",
                "KINN","KLEB","KNOX","LSAL","LAMA",
                "LAMB","LAMP","LAVA","LEE","LEON",
                "LIBE","LIME","LIPS","LIVO","LLAN",
                "LOVI","LUBB","LYNN","MADI","MARI",
                "MART","MASO","MATA","MAVE","MCUL",
                "MLEN","MMUL","MEDI","MENA","MIDL",
                "MILA","MILL","MITC","MONT","MGMY",
                "MOOR","MORR","MOTL","NACO","NAVA",
                "NEWT","NOLA","NUEC","OCHI","OLDH",
                "ORAN","PPIN","PANO","PARK","PARM",
                "PECO","POLK","POTT","PRES","RAIN",
                "RAND","REAG","REAL","RRIV","REEV",
                "REFU","ROBE","RBSN","ROCK","RUNN",
                "RUSK","SABI","SAUG","SJAC","SPAT",
                "SSAB","SCHL","SCUR","SHAC","SHEL",
                "SHMN","SMIT","SOME","STAR","STEP",
                "STER","STON","SUTT","SWIS","TARR",
                "TAYL","TERL","TERY","THRO","TITU",
                "TGRE","TRAV","TRIN","TYLE","UPSH",
                "UPTO","UVAL","VVER","VZAN","VICT",
                "WALK","WALL","WARD","WASH","WEBB",
                "WHAR","WHEE","WICH","WILB","WILY",
                "WMSN","WLSN","WINK","WISE","WOOD",
                "YOAK","YOUN","ZAPA","ZAVA",};
        }
    }
}
