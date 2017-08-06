using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class IowaCountyListBuilder : CountyListBuilder
    {
        public IowaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "IA";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADR","FLO","MNA","ADM","FRA",
                "MOE","ALL","FRE","MTG","APP",
                "GRE","MUS","AUD","GRU","OBR",
                "BEN","GUT","OSC","BKH","HAM",
                "PAG","BOO","HAN","PLA","BRE",
                "HDN","PLY","BUC","HRS","POC",
                "BNV","HEN","POL","BTL","HOW",
                "POT","CAL","HUM","POW","CAR",
                "IDA","RIN","CAS","IOW","SAC",
                "CED","JAC","SCO","CEG","JAS",
                "SHE","CHE","JEF","SIO","CHI",
                "JOH","STR","CLR","JON","TAM",
                "CLA","KEO","TAY","CLT","KOS",
                "UNI","CLN","LEE","VAN","CRF",
                "LIN","WAP","DAL","LOU","WAR",
                "DAV","LUC","WAS","Dec","LYN",
                "WAY","DEL","MAD","WEB","DSM",
                "MAH","WNB","DIC","MRN","WNS",
                "DUB","MSL","WOO","EMM","MIL",
                "WOR","FAY","MIT","WRI"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADR": return "Adair";
                case "FLO": return "Floyd";
                case "MNA": return "Monona";
                case "ADM": return "Adams";
                case "FRA": return "Franklin";
                case "MOE": return "Monroe";
                case "ALL": return "Allamakee";
                case "FRE": return "Fremont";
                case "MTG": return "Montgomery";
                case "APP": return "Appanoose";
                case "GRE": return "Greene";
                case "MUS": return "Muscatine";
                case "AUD": return "Audubon";
                case "GRU": return "Grundy";
                case "OBR": return "O'Brien";
                case "BEN": return "Benton";
                case "GUT": return "Guthrie";
                case "OSC": return "Osceola";
                case "BKH": return "Blackhawk";
                case "HAM": return "Hamilton";
                case "PAG": return "Page";
                case "BOO": return "Boone";
                case "HAN": return "Hancock";
                case "PLA": return "Palo";
                case "BRE": return "Bremer";
                case "HDN": return "Hardin";
                case "PLY": return "Plymouth";
                case "BUC": return "Buchanan";
                case "HRS": return "Harrison";
                case "POC": return "Pocahontas";
                case "BNV": return "Buena";
                case "HEN": return "Henry";
                case "POL": return "Polk";
                case "BTL": return "Butler";
                case "HOW": return "Howard";
                case "POT": return "Pottawattamie";
                case "CAL": return "Calhoun";
                case "HUM": return "Humboldt";
                case "POW": return "Poweshiek";
                case "CAR": return "Carroll";
                case "IDA": return "Ida";
                case "RIN": return "Ringgold";
                case "CAS": return "Cass";
                case "IOW": return "Iowa";
                case "SAC": return "Sac";
                case "CED": return "Cedar";
                case "JAC": return "Jackson";
                case "SCO": return "Scott";
                case "CEG": return "Cerro";
                case "JAS": return "Jasper";
                case "SHE": return "Shelby";
                case "CHE": return "Cherokee";
                case "JEF": return "Jefferson";
                case "SIO": return "Sioux";
                case "CHI": return "Chickasaw";
                case "JOH": return "Johnson";
                case "STR": return "Story";
                case "CLR": return "Clark";
                case "JON": return "Jones";
                case "TAM": return "Tama";
                case "CLA": return "Clay";
                case "KEO": return "Keokuk";
                case "TAY": return "Taylor";
                case "CLT": return "Clayton";
                case "KOS": return "Kossuth";
                case "UNI": return "Union";
                case "CLN": return "Clinton";
                case "LEE": return "Lee";
                case "VAN": return "Vanburen";
                case "CRF": return "Crawford";
                case "LIN": return "Linn";
                case "WAP": return "Wapello";
                case "DAL": return "Dallas";
                case "LOU": return "Louisa";
                case "WAR": return "Warren";
                case "DAV": return "Davis";
                case "LUC": return "Lucas";
                case "WAS": return "Washington";
                case "Dec": return "Decatur";
                case "LYN": return "Lyon";
                case "WAY": return "Wayne";
                case "DEL": return "Delaware";
                case "MAD": return "Madison";
                case "WEB": return "Webster";
                case "DSM": return "Des";
                case "MAH": return "Mahaska";
                case "WNB": return "Winnebago";
                case "DIC": return "Dickinson";
                case "MRN": return "Marion";
                case "WNS": return "Winneshiek";
                case "DUB": return "Dubuque";
                case "MSL": return "Marshall";
                case "WOO": return "Woodbury";
                case "EMM": return "Emmett";
                case "MIL": return "Mills";
                case "WOR": return "Worth";
                case "FAY": return "Fayette";
                case "MIT": return "Mitchell";
                case "WRI": return "Wright";
                default: return String.Empty;
            }
        }
    }
}