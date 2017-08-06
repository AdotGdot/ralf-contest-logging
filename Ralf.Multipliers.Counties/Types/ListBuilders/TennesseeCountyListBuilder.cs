using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class TennesseeCountyListBuilder : CountyListBuilder
    {
        public TennesseeCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "TN";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ANDE","BEDF","BENT","BLED","BLOU",
                "BRAD","CAMP","CANN","CARR","CART",
                "CHEA","CHES","CLAI","CLAY","COCK",
                "COFF","CROC","CUMB","DAVI","DECA",
                "DEKA","DICK","DYER","FAYE","FENT",
                "FRAN","GIBS","GILE","GRAI","GREE",
                "GRUN","HAMB","HAMI","HANC","HARD",
                "HARN","HAWK","HAYW","HEND","HENR",
                "HICK","HOUS","HUMP","JACK","JEFF",
                "JOHN","KNOX","LAKE","LAUD","LAWR",
                "LEWI","LINC","LOUD","MACO","MADI",
                "MARI","MARS","MAUR","MCMI","MCNA",
                "MEIG","MONR","MONT","MOOR","MORG",
                "OBIO","OVER","PERR","PICK","POLK",
                "PUTN","RHEA","ROAN","ROBE","RUTH",
                "SCOT","SEQU","SEVI","SHEL","SMIT",
                "STEW","SULL","SUMN","TIPT","TROU",
                "UNIC","UNIO","VANB","WARR","WASH",
                "WAYN","WEAK","WHIT","WILL","WILS"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ANDE": return "Anderson";
                case "BEDF": return "Bedford";
                case "BENT": return "Benton";
                case "BLED": return "Bledsoe";
                case "BLOU": return "Blount";
                case "BRAD": return "Bradley";
                case "CAMP": return "Campbell";
                case "CANN": return "Cannon";
                case "CARR": return "Carroll";
                case "CART": return "Carter";
                case "CHEA": return "Cheatham";
                case "CHES": return "Chester";
                case "CLAI": return "Claiborne";
                case "CLAY": return "Clay";
                case "COCK": return "Cocke";
                case "COFF": return "Coffee";
                case "CROC": return "Crockett";
                case "CUMB": return "Cumberland";
                case "DAVI": return "Davidson";
                case "DECA": return "Decatur";
                case "DEKA": return "Dekalb";
                case "DICK": return "Dickson";
                case "DYER": return "Dyer";
                case "FAYE": return "Fayette";
                case "FENT": return "Fentress";
                case "FRAN": return "Franklin";
                case "GIBS": return "Gibson";
                case "GILE": return "Giles";
                case "GRAI": return "Grainger";
                case "GREE": return "Greene";
                case "GRUN": return "Grundy";
                case "HAMB": return "Hamblen";
                case "HAMI": return "Hamilton";
                case "HANC": return "Hancock";
                case "HARD": return "Hardeman";
                case "HARN": return "Hardin";
                case "HAWK": return "Hawkins";
                case "HAYW": return "Haywood";
                case "HEND": return "Henderson";
                case "HENR": return "Henry";
                case "HICK": return "Hickman";
                case "HOUS": return "Houston";
                case "HUMP": return "Humphreys";
                case "JACK": return "Jackson";
                case "JEFF": return "Jefferson";
                case "JOHN": return "Johnson";
                case "KNOX": return "Knox";
                case "LAKE": return "Lake";
                case "LAUD": return "Lauderdale";
                case "LAWR": return "Lawrence";
                case "LEWI": return "Lewis";
                case "LINC": return "Lincoln";
                case "LOUD": return "Loudon";
                case "MACO": return "Macon";
                case "MADI": return "Madison";
                case "MARI": return "Marion";
                case "MARS": return "Marshall";
                case "MAUR": return "Maury";
                case "MCMI": return "Mcminn";
                case "MCNA": return "Mcnairy";
                case "MEIG": return "Meigs";
                case "MONR": return "Monroe";
                case "MONT": return "Montgomery";
                case "MOOR": return "Moore";
                case "MORG": return "Morgan";
                case "OBIO": return "Obion";
                case "OVER": return "Overton";
                case "PERR": return "Perry";
                case "PICK": return "Pickett";
                case "POLK": return "Polk";
                case "PUTN": return "Putnam";
                case "RHEA": return "Rhea";
                case "ROAN": return "Roane";
                case "ROBE": return "Robertson";
                case "RUTH": return "Rutherford";
                case "SCOT": return "Scott";
                case "SEQU": return "Sequatchie";
                case "SEVI": return "Sevier";
                case "SHEL": return "Shelby";
                case "SMIT": return "Smith";
                case "STEW": return "Stewart";
                case "SULL": return "Sullivan";
                case "SUMN": return "Sumner";
                case "TIPT": return "Tipton";
                case "TROU": return "Trousdale";
                case "UNIC": return "Unicoi";
                case "UNIO": return "Union";
                case "VANB": return "Van Buren";
                case "WARR": return "Warren";
                case "WASH": return "Washington";
                case "WAYN": return "Wayne";
                case "WEAK": return "Weakley";
                case "WHIT": return "White";
                case "WILL": return "Williamson";
                case "WILS": return "Wilson";
                default: return String.Empty;
            }
        }
    }
}
