using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class MissouriCountyListBuilder : CountyListBuilder
    {
        public MissouriCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "MO";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADR","AND","ATC","AUD","BAR",
                "BTN","BAT","BEN","BOL","BOO",
                "BUC","BTR","CWL","CAL","CAM",
                "CPG","CRL","CAR","CAS","CED",
                "CHN","CHR","CLK","CLA","CLN",
                "COL","COP","CRA","DAD","DAL",
                "DVS","DEK","DEN","DGL","DUN",
                "FRA","GAS","GEN","GRN","GRU",
                "HAR","HEN","HIC","HLT","HOW",
                "HWL","IRN","JAC","JAS","JEF",
                "JON","KNX","LAC","LAF","LAW",
                "LEW","LCN","LIN","LIV","MAC",
                "MAD","MRE","MAR","MCD","MER",
                "MIL","MIS","MNT","MON","MGM",
                "MOR","NMD","NWT","NOD","ORE",
                "OSA","OZA","PEM","PER","PET",
                "PHE","PIK","PLA","POL","PUL",
                "PUT","RAL","RAN","RAY","REY",
                "RIP","SAL","SCH","SCT","SCO",
                "SHA","SHL","STC","SCL","STF",
                "STG","STL","SLC","STD","STN",
                "SUL","TAN","TEX","VRN","WAR",
                "WAS","WAY","WEB","WOR","WRT"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADR": return "Adair";
                case "AND": return "Andrew";
                case "ATC": return "Atchison";
                case "AUD": return "Audrain";
                case "BAR": return "Barry";
                case "BTN": return "Barton";
                case "BAT": return "Bates";
                case "BEN": return "Benton";
                case "BOL": return "Bollinger";
                case "BOO": return "Boone";
                case "BUC": return "Buchanan";
                case "BTR": return "Butler";
                case "CWL": return "Caldwell";
                case "CAL": return "Callaway";
                case "CAM": return "Camden";
                case "CPG": return "Cape Girardeau";
                case "CRL": return "Carroll";
                case "CAR": return "Carter";
                case "CAS": return "Cass";
                case "CED": return "Cedar";
                case "CHN": return "Chariton";
                case "CHR": return "Christian";
                case "CLK": return "Clark";
                case "CLA": return "Clay";
                case "CLN": return "Clinton";
                case "COL": return "Cole";
                case "COP": return "Cooper";
                case "CRA": return "Crawford";
                case "DAD": return "Dade";
                case "DAL": return "Dallas";
                case "DVS": return "Daviess";
                case "DEK": return "Dekalb";
                case "DEN": return "Dent";
                case "DGL": return "Douglas";
                case "DUN": return "Dunklin";
                case "FRA": return "Franklin";
                case "GAS": return "Gasconade";
                case "GEN": return "Gentry";
                case "GRN": return "Greene";
                case "GRU": return "Grundy";
                case "HAR": return "Harrison";
                case "HEN": return "Henry";
                case "HIC": return "Hickory";
                case "HLT": return "Holt";
                case "HOW": return "Howard";
                case "HWL": return "Howell";
                case "IRN": return "Iron";
                case "JAC": return "Jackson";
                case "JAS": return "Jasper";
                case "JEF": return "Jefferson";
                case "JON": return "Johnson";
                case "KNX": return "Knox";
                case "LAC": return "Laclede";
                case "LAF": return "Lafayette";
                case "LAW": return "Lawrence";
                case "LEW": return "Lewis";
                case "LCN": return "Lincoln";
                case "LIN": return "Linn";
                case "LIV": return "Livingston";
                case "MAC": return "Macon";
                case "MAD": return "Madison";
                case "MRE": return "Maries";
                case "MAR": return "Marion";
                case "MCD": return "Mcdonald";
                case "MER": return "Mercer";
                case "MIL": return "Miller";
                case "MIS": return "Mississippi";
                case "MNT": return "Moniteau";
                case "MON": return "Monroe";
                case "MGM": return "Montgomery";
                case "MOR": return "Morgan";
                case "NMD": return "New Madrid";
                case "NWT": return "Newton";
                case "NOD": return "Nodaway";
                case "ORE": return "Oregon";
                case "OSA": return "Osage";
                case "OZA": return "Ozark";
                case "PEM": return "Pemiscot";
                case "PER": return "Perry";
                case "PET": return "Pettis";
                case "PHE": return "Phelps";
                case "PIK": return "Pike";
                case "PLA": return "Platte";
                case "POL": return "Polk";
                case "PUL": return "Pulaski";
                case "PUT": return "Putnam";
                case "RAL": return "Ralls";
                case "RAN": return "Randolph";
                case "RAY": return "Ray";
                case "REY": return "Reynolds";
                case "RIP": return "Ripley";
                case "SAL": return "Saline";
                case "SCH": return "Schuyler";
                case "SCT": return "Scotland";
                case "SCO": return "Scott";
                case "SHA": return "Shannon";
                case "SHL": return "Shelby";
                case "STC": return "St. Charles";
                case "SCL": return "St. Clair";
                case "STF": return "St. Francois";
                case "STG": return "St. Genevieve";
                case "STL": return "St. Louis City";
                case "SLC": return "St. Louis County";
                case "STD": return "Stoddard";
                case "STN": return "Stone";
                case "SUL": return "Sullivan";
                case "TAN": return "Taney";
                case "TEX": return "Texas";
                case "VRN": return "Vernon";
                case "WAR": return "Warren";
                case "WAS": return "Washington";
                case "WAY": return "Wayne";
                case "WEB": return "Webster";
                case "WOR": return "Worth";
                case "WRT": return "Wright";
                default: return String.Empty;
            }
        }
    }
}
