using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class OhioCountyListBuilder : CountyListBuilder
    {
        public OhioCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "OH";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADAM": return "Adams";
                case "ALLE": return "Allen";
                case "ASHL": return "Ashland";
                case "ASHT": return "Ashtabula";
                case "ATHE": return "Athens";
                case "AUGL": return "Auglaze";
                case "BELM": return "Belmont";
                case "BROW": return "Brown";
                case "BUTL": return "Butler";
                case "CARR": return "Carroll";
                case "CHAM": return "Champaign";
                case "CLAR": return "Clark";
                case "CLER": return "Clermont";
                case "CLIN": return "Clinton";
                case "COLU": return "Columbiana";
                case "COSH": return "Coshocton";
                case "CRAW": return "Crawford";
                case "CUYA": return "Cuyahoga";
                case "DARK": return "Darke";
                case "DEFI": return "Defiance";
                case "DELA": return "Delaware";
                case "ERIE": return "Erie";
                case "FAIR": return "Fairfield";
                case "FAYE": return "Fayette";
                case "FRAN": return "Franklin";
                case "FULT": return "Fulton";
                case "GALL": return "Gallia";
                case "GEAU": return "Geauga";
                case "GREE": return "Greene";
                case "GUER": return "Guernsey";
                case "HAMI": return "Hamilton";
                case "HANC": return "Hancock";
                case "HARD": return "Hardin";
                case "HARR": return "Harrison";
                case "HENR": return "Henry";
                case "HIGH": return "Highland";
                case "HOCK": return "Hocking";
                case "HOLM": return "Holmes";
                case "HURO": return "Huron";
                case "JACK": return "Jackson";
                case "JEFF": return "Jefferson";
                case "KNOX": return "Knox";
                case "LAKE": return "Lake";
                case "LAWR": return "Lawrence";
                case "LICK": return "Licking";
                case "LOGA": return "Logan";
                case "LORA": return "Lorain";
                case "LUCA": return "Lucas";
                case "MADI": return "Madison";
                case "MAHO": return "Mahoning";
                case "MARI": return "Marion";
                case "MEDI": return "Medina";
                case "MEIG": return "Meigs";
                case "MERC": return "Mercer";
                case "MIAM": return "Miami";
                case "MONR": return "Monroe";
                case "MONT": return "Montgomery";
                case "MORG": return "Morgan";
                case "MORR": return "Morrow";
                case "MUSK": return "Muskingum";
                case "NOBL": return "Noble";
                case "OTTA": return "Ottawa";
                case "PAUL": return "Paulding";
                case "PERR": return "Perry";
                case "PICK": return "Pickaway";
                case "PIKE": return "Pike";
                case "PORT": return "Portage";
                case "PREB": return "Preble";
                case "PUTN": return "Putnam";
                case "RICH": return "Richland";
                case "ROSS": return "Ross";
                case "SAND": return "Sandusky";
                case "SCIO": return "Scioto";
                case "SENE": return "Seneca";
                case "SHEL": return "Shelby";
                case "STAR": return "Stark";
                case "SUMM": return "Summit";
                case "TRUM": return "Trumbull";
                case "TUSC": return "Tuscarawas";
                case "UNIO": return "Union";
                case "VANW": return "Vanwert";
                case "VINT": return "Vinton";
                case "WARR": return "Warren";
                case "WASH": return "Washington";
                case "WAYN": return "Wayne";
                case "WILL": return "Williams";
                case "WOOD": return "Wood";
                case "WYAN": return "Wyandot";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADAM","ALLE","ASHL","ASHT","ATHE",
                "AUGL","BELM","BROW","BUTL","CARR",
                "CHAM","CLAR","CLER","CLIN","COLU",
                "COSH","CRAW","CUYA","DARK","DEFI",
                "DELA","ERIE","FAIR","FAYE","FRAN",
                "FULT","GALL","GEAU","GREE","GUER",
                "HAMI","HANC","HARD","HARR","HENR",
                "HIGH","HOCK","HOLM","HURO","JACK",
                "JEFF","KNOX","LAKE","LAWR","LICK",
                "LOGA","LORA","LUCA","MADI","MAHO",
                "MARI","MEDI","MEIG","MERC","MIAM",
                "MONR","MONT","MORG","MORR","MUSK",
                "NOBL","OTTA","PAUL","PERR","PICK",
                "PIKE","PORT","PREB","PUTN","RICH",
                "ROSS","SAND","SCIO","SENE","SHEL",
                "STAR","SUMM","TRUM","TUSC","UNIO",
                "VANW","VINT","WARR","WASH","WAYN",
                "WILL","WOOD","WYAN" };
        }
    }
}
