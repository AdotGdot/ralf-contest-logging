using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MinnesotaCountyListBuilder : CountyListBuilder
    {
        public MinnesotaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MN";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "AIT","ISA","PIP","ANO","ITA",
                "POL","BEC","JAC","POP","BEL",
                "KNB","RAM","BEN","KND","RDL",
                "BIG","KIT","RDW","BLU","KOO",
                "REN","BRO","LAC","RIC","CRL",
                "LAK","ROC","CRV","LKW","ROS",
                "CAS","LES","STL","CHP","LIN",
                "SCO","CHS","LYO","SHE","CLA",
                "MCL","SIB","CLE","MAH","STR",
                "COO","MRS","STE","COT","MRT",
                "STV","CRO","MEE","SWI","DAK",
                "MIL","TOD","DOD","MOR","TRA",
                "DOU","MOW","WAB","FAI","MUR",
                "WAD","FIL","NIC","WSC","FRE",
                "NOB","WSH","GOO","NOR","WAT",
                "GRA","OLM","WIL","HEN","OTT",
                "WIN","HOU","PEN","WRI","HUB",
                "PIN","YEL"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "AIT": return "Aitkin";
                case "ISA": return "Isanti";
                case "PIP": return "Pipestone";
                case "ANO": return "Anoka";
                case "ITA": return "Itasca";
                case "POL": return "Polk";
                case "BEC": return "Becker";
                case "JAC": return "Jackson";
                case "POP": return "Pope";
                case "BEL": return "Beltrami";
                case "KNB": return "Kanabec";
                case "RAM": return "Ramsey";
                case "BEN": return "Benton";
                case "KND": return "Kandiyohi";
                case "RDL": return "Red Lake";
                case "BIG": return "Big Stone";
                case "KIT": return "Kittson";
                case "RDW": return "Redwood";
                case "BLU": return "Blue Earth";
                case "KOO": return "Koochiching";
                case "REN": return "Renville";
                case "BRO": return "Brown";
                case "LAC": return "Lac Qui Parle";
                case "RIC": return "Rice";
                case "CRL": return "Carlton";
                case "LAK": return "Lake";
                case "ROC": return "Rock";
                case "CRV": return "Carver";
                case "LKW": return "Lake of the Woods";
                case "ROS": return "Roseau";
                case "CAS": return "Cass";
                case "LES": return "Le Sueur";
                case "STL": return "St Louis";
                case "CHP": return "Chippewa";
                case "LIN": return "Lincoln";
                case "SCO": return "Scott";
                case "CHS": return "Chisago";
                case "LYO": return "Lyon";
                case "SHE": return "Sherburne";
                case "CLA": return "Clay";
                case "MCL": return "McLeod";
                case "SIB": return "Sibley";
                case "CLE": return "Clearwater";
                case "MAH": return "Mahnomen";
                case "STR": return "Stearns";
                case "COO": return "Cook";
                case "MRS": return "Marshall";
                case "STE": return "Steele";
                case "COT": return "Cottonwood";
                case "MRT": return "Martin";
                case "STV": return "Stevens";
                case "CRO": return "Crow Wing";
                case "MEE": return "Meeker";
                case "SWI": return "Swift";
                case "DAK": return "Dakota";
                case "MIL": return "Mille Lacs";
                case "TOD": return "Todd";
                case "DOD": return "Dodge";
                case "MOR": return "Morrison";
                case "TRA": return "Traverse";
                case "DOU": return "Douglas";
                case "MOW": return "Mower";
                case "WAB": return "Wabasha";
                case "FAI": return "Faribault";
                case "MUR": return "Murray";
                case "WAD": return "Wadena";
                case "FIL": return "Fillmore";
                case "NIC": return "Nicollet";
                case "WSC": return "Waseca";
                case "FRE": return "Freeborn";
                case "NOB": return "Nobles";
                case "WSH": return "Washington";
                case "GOO": return "Goodhue";
                case "NOR": return "Norman";
                case "WAT": return "Watonwan";
                case "GRA": return "Grant";
                case "OLM": return "Olmsted";
                case "WIL": return "Wilkin";
                case "HEN": return "Hennepin";
                case "OTT": return "Ottertail";
                case "WIN": return "Winona";
                case "HOU": return "Houston";
                case "PEN": return "Pennington";
                case "WRI": return "Wright";
                case "HUB": return "Hubbard";
                case "PIN": return "Pine";
                case "YEL": return "Yellow Medicine";
                default: return String.Empty;
            }
        }
    }
}