using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class FloridaCountyListBuilder : CountyListBuilder
    {
        public FloridaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "FL";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALC": return "Alachua";
                case "BAK": return "Baker";
                case "BAY": return "Bay";
                case "BRA": return "Bradford";
                case "BRE": return "Brevard";
                case "BRO": return "Broward";
                case "CAH": return "Calhoun";
                case "CHA": return "Charlotte";
                case "CIT": return "Citrus";
                case "CLA": return "Clay";
                case "CLR": return "Collier";
                case "CLM": return "Columbia";
                case "DES": return "Desoto";
                case "DIX": return "Dixie";
                case "DUV": return "Duval";
                case "ESC": return "Escambia";
                case "FLG": return "Flagler";
                case "FRA": return "Franklin";
                case "GAD": return "Gadsden";
                case "GIL": return "Gilchrist";
                case "GLA": return "Glades";
                case "GUL": return "Gulf";
                case "HAM": return "Hamilton";
                case "HAR": return "Hardee";
                case "HEN": return "Hendry";
                case "HER": return "Hernando";
                case "HIG": return "Highlands";
                case "HIL": return "Hillsborough";
                case "HOL": return "Holmes";
                case "IDR": return "Indian River";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "LAF": return "Lafayette";
                case "LAK": return "Lake";
                case "LEE": return "Lee";
                case "LEO": return "Leon";
                case "LEV": return "Levy";
                case "LIB": return "Liberty";
                case "MAD": return "Madison";
                case "MTE": return "Manatee";
                case "MAO": return "Marion";
                case "MRT": return "Martin";
                case "DAD": return "Miami-Dade";
                case "MON": return "Monroe";
                case "NAS": return "Nassau";
                case "OKA": return "Okaloosa";
                case "OKE": return "Okeechobee";
                case "ORA": return "Orange";
                case "OSC": return "Osceola";
                case "PAL": return "Palm Beach";
                case "PAS": return "Pasco";
                case "PIN": return "Pinellas";
                case "POL": return "Polk";
                case "PUT": return "Putnam";
                case "SAN": return "Santa Rosa";
                case "SAR": return "Sarasota";
                case "SEM": return "Seminole";
                case "STJ": return "St. Johns";
                case "STL": return "St. Lucie";
                case "SUM": return "Sumter";
                case "SUW": return "Suwannee";
                case "TAY": return "Taylor";
                case "UNI": return "Union";
                case "VOL": return "Volusia";
                case "WAK": return "Wakulla";
                case "WAL": return "Walton";
                case "WAG": return "Washington";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALC","BAK","BAY","BRA","BRE",
                "BRO","CAH","CHA","CIT","CLA",
                "CLR","CLM","DES","DIX","DUV",
                "ESC","FLG","FRA","GAD","GIL",
                "GLA","GUL","HAM","HAR","HEN",
                "HER","HIG","HIL","HOL","IDR",
                "JAC","JEF","LAF","LAK","LEE",
                "LEO","LEV","LIB","MAD","MTE",
                "MAO","MRT","DAD","MON","NAS",
                "OKA","OKE","ORA","OSC","PAL",
                "PAS","PIN","POL","PUT","SAN",
                "SAR","SEM","STJ","STL","SUM",
                "SUW","TAY","UNI","VOL","WAK",
                "WAL","WAG"};
        }
    }
}
