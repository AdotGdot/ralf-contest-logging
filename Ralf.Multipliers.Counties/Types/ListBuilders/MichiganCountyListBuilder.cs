using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MichiganCountyListBuilder : CountyListBuilder
    {
        public MichiganCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MI";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALCO","GRTR","MIDL","ALGE","HILL",
                "MISS","ALLE","HOUG","MONR","ALPE",
                "HURO","MTMO","ANTR","INGH","MUSK",
                "AREN","IONI","NEWA","BARA","IOSC",
                "OAKL","BARR","IRON","OCEA","BAY",
                "ISAB","OGEM","BENZ","JACK","ONTO",
                "BERR","KALK","OSCE","BRAN","KENT",
                "OSCO","CALH","KEWE","OTSE","CASS",
                "KZOO","OTTA","CHAR","LAKE","PRES",
                "CHEB","LAPE","ROSC","CHIP","LEEL",
                "SAGI","CLAR","LENA","SANI","CLIN",
                "LIVI","SCHO","CRAW","LUCE","SHIA",
                "DELT","MACK","STCL","DICK","MACO",
                "STJO","EATO","MANI","TUSC","EMME",
                "MARQ","VANB","GENE","MASO","WASH",
                "GLAD","MCLM","WAYN","GOGE","MECO",
                "WEXF","GRAT","MENO"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALCO": return "Alcona";
                case "GRTR": return "Gr. Traverse";
                case "MIDL": return "Midland";
                case "ALGE": return "Alger";
                case "HILL": return "Hillsdale";
                case "MISS": return "Missaukee";
                case "ALLE": return "Allegan";
                case "HOUG": return "Houghton";
                case "MONR": return "Monroe";
                case "ALPE": return "Alpena";
                case "HURO": return "Huron";
                case "MTMO": return "Montmorency";
                case "ANTR": return "Antrim";
                case "INGH": return "Ingham";
                case "MUSK": return "Muskegon";
                case "AREN": return "Arenac";
                case "IONI": return "Ionia";
                case "NEWA": return "Newaygo";
                case "BARA": return "Baraga";
                case "IOSC": return "Iosco";
                case "OAKL": return "Oakland";
                case "BARR": return "Barry";
                case "IRON": return "Iron";
                case "OCEA": return "Oceana";
                case "BAY": return "Bay";
                case "ISAB": return "Isabella";
                case "OGEM": return "Ogemaw";
                case "BENZ": return "Benzie";
                case "JACK": return "Jackson";
                case "ONTO": return "Ontonagon";
                case "BERR": return "Berrien";
                case "KALK": return "Kalkaska";
                case "OSCE": return "Osceola";
                case "BRAN": return "Branch";
                case "KENT": return "Kent";
                case "OSCO": return "Oscoda";
                case "CALH": return "Calhoun";
                case "KEWE": return "Keweenaw";
                case "OTSE": return "Otsego";
                case "CASS": return "Cass";
                case "KZOO": return "Kalamazoo";
                case "OTTA": return "Ottawa";
                case "CHAR": return "Charlevoix";
                case "LAKE": return "Lake";
                case "PRES": return "Presque Isle";
                case "CHEB": return "Cheboygan";
                case "LAPE": return "Lapeer";
                case "ROSC": return "Roscommon";
                case "CHIP": return "Chippewa";
                case "LEEL": return "Leelanau";
                case "SAGI": return "Saginaw";
                case "CLAR": return "Clare";
                case "LENA": return "Lenawee";
                case "SANI": return "Sanilac";
                case "CLIN": return "Clinton";
                case "LIVI": return "Livingston";
                case "SCHO": return "Schoolcraft";
                case "CRAW": return "Crawford";
                case "LUCE": return "Luce";
                case "SHIA": return "Shiawassee";
                case "DELT": return "Delta";
                case "MACK": return "Mackinac";
                case "STCL": return "St Clair";
                case "DICK": return "Dickinson";
                case "MACO": return "Macomb";
                case "STJO": return "St Joseph";
                case "EATO": return "Eaton";
                case "MANI": return "Manistee";
                case "TUSC": return "Tuscola";
                case "EMME": return "Emmet";
                case "MARQ": return "Marquette";
                case "VANB": return "Van Buren";
                case "GENE": return "Genesee";
                case "MASO": return "Mason";
                case "WASH": return "Washtenaw";
                case "GLAD": return "Gladwin";
                case "MCLM": return "Montcalm";
                case "WAYN": return "Wayne";
                case "GOGE": return "Gogebic";
                case "MECO": return "Mecosta";
                case "WEXF": return "Wexford";
                case "GRAT": return "Gratiot";
                case "MENO": return "Menominee";
                default: return String.Empty;
            }
        }
    }
}