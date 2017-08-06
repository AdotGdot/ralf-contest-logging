using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class KansasCountyListBuilder : CountyListBuilder
    {
        public KansasCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "KS";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALL": return "Allen";
                case "AND": return "Anderson";
                case "ATC": return "Atchison";
                case "BAR": return "Barber";
                case "BOU": return "Bourbon";
                case "BRO": return "Brown";
                case "BRT": return "Barton";
                case "BUT": return "Butler";
                case "CHE": return "Cherokee";
                case "CHS": return "Chase";
                case "CHT": return "Chautauqua";
                case "CHY": return "Cheyenne";
                case "CLK": return "Clark";
                case "CLO": return "Cloud";
                case "CLY": return "Clay";
                case "COF": return "Coffey";
                case "COM": return "Comanche";
                case "COW": return "Cowley";
                case "CRA": return "Crawford";
                case "DEC": return "Decatur";
                case "DIC": return "Dickinson";
                case "DON": return "Doniphan";
                case "DOU": return "Douglas";
                case "EDW": return "Edwards";
                case "ELK": return "Elk";
                case "ELL": return "Ellis";
                case "ELS": return "Ellsworth";
                case "FIN": return "Finney";
                case "FOR": return "Ford";
                case "FRA": return "Franklin";
                case "GEA": return "Geary";
                case "GLY": return "Greeley";
                case "GOV": return "Gove";
                case "GRE": return "Greenwood";
                case "GRM": return "Graham";
                case "GRT": return "Grant";
                case "GRY": return "Gray";
                case "HAM": return "Hamilton";
                case "HAS": return "Haskell";
                case "HOG": return "Hodgeman";
                case "HPR": return "Harper";
                case "HVY": return "Harvey";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "JEW": return "Jewell";
                case "JOH": return "Johnson";
                case "KEA": return "Kearny";
                case "KIN": return "Kingman";
                case "KIO": return "Kiowa";
                case "LAB": return "Labette";
                case "LAN": return "Lane";
                case "LCN": return "Lincoln";
                case "LEA": return "Leavenworth";
                case "LIN": return "Linn";
                case "LOG": return "Logan";
                case "LYO": return "Lyon";
                case "MCP": return "Mcpherson";
                case "MEA": return "Meade";
                case "MGY": return "Montgomery";
                case "MIA": return "Miami";
                case "MIT": return "Mitchell";
                case "MOR": return "Morris";
                case "MRN": return "Marion";
                case "MSH": return "Marshall";
                case "MTN": return "Morton";
                case "NEM": return "Nemaha";
                case "NEO": return "Neosho";
                case "NES": return "Ness";
                case "NOR": return "Norton";
                case "OSA": return "Osage";
                case "OSB": return "Osborne";
                case "OTT": return "Ottawa";
                case "PAW": return "Pawnee";
                case "PHI": return "Phillips";
                case "POT": return "Pottawatomie";
                case "PRA": return "Pratt";
                case "RAW": return "Rawlins";
                case "REN": return "Reno";
                case "REP": return "Republic";
                case "RIC": return "Rice";
                case "RIL": return "Riley";
                case "ROO": return "Rooks";
                case "RSL": return "Russell";
                case "RUS": return "Rush";
                case "SAL": return "Saline";
                case "SCO": return "Scott";
                case "SED": return "Sedgwick";
                case "SEW": return "Seward";
                case "SHA": return "Shawnee";
                case "SHE": return "Sheridan";
                case "SMI": return "Smith";
                case "SMN": return "Sherman";
                case "STA": return "Stafford";
                case "STE": return "Stevens";
                case "STN": return "Stanton";
                case "SUM": return "Sumner";
                case "THO": return "Thomas";
                case "TRE": return "Trego";
                case "WAB": return "Wabaunsee";
                case "WAL": return "Wallace";
                case "WAS": return "Washington";
                case "WIC": return "Wichita";
                case "WIL": return "Wilson";
                case "WOO": return "Woodson";
                case "WYA": return "Wyandotte";
                default: return String.Empty;
            }
        }
        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALL","AND","ATC","BAR","BOU",
                "BRO","BRT","BUT","CHE","CHS",
                "CHT","CHY","CLK","CLO","CLY",
                "COF","COM","COW","CRA","DEC",
                "DIC","DON","DOU","EDW","ELK",
                "ELL","ELS","FIN","FOR","FRA",
                "GEA","GLY","GOV","GRE","GRM",
                "GRT","GRY","HAM","HAS","HOG",
                "HPR","HVY","JAC","JEF","JEW",
                "JOH","KEA","KIN","KIO","LAB",
                "LAN","LCN","LEA","LIN","LOG",
                "LYO","MCP","MEA","MGY","MIA",
                "MIT","MOR","MRN","MSH","MTN",
                "NEM","NEO","NES","NOR","OSA",
                "OSB","OTT","PAW","PHI","POT",
                "PRA","RAW","REN","REP","RIC",
                "RIL","ROO","RSL","RUS","SAL",
                "SCO","SED","SEW","SHA","SHE",
                "SMI","SMN","STA","STE","STN",
                "SUM","THO","TRE","WAB","WAL",
                "WAS","WIC","WIL","WOO","WYA"};
        }
    }
}
