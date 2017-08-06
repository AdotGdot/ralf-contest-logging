using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class OklahomaCountyListBuilder : CountyListBuilder
    {
        public OklahomaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "OK";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adair";
                case "ALF": return "Alfalfa";
                case "ATO": return "Atoka";
                case "BEA": return "Beaver";
                case "BEC": return "Beckham";
                case "BLA": return "Blaine";
                case "BRY": return "Bryan";
                case "CAD": return "Caddo";
                case "CAN": return "Canadian";
                case "CAR": return "Carter";
                case "CHE": return "Cherokee";
                case "CHO": return "Choctaw";
                case "CIM": return "Cimarron";
                case "CLE": return "Cleveland";
                case "COA": return "Coal";
                case "COM": return "Comanche";
                case "COT": return "Cotton";
                case "CRA": return "Craig";
                case "CRE": return "Creek";
                case "CUS": return "Custer";
                case "DEL": return "Delaware";
                case "DEW": return "Dewey";
                case "ELL": return "Ellis";
                case "GAR": return "Garfield";
                case "GNT": return "Grant";
                case "GRA": return "Grady";
                case "GRE": return "Greer";
                case "GRV": return "Garvin";
                case "HAR": return "Harmon";
                case "HAS": return "Haskell";
                case "HRP": return "Harper";
                case "HUG": return "Hughes";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "JOH": return "Johnston";
                case "KAY": return "Kay";
                case "KIN": return "Kingfisher";
                case "KIO": return "Kiowa";
                case "LAT": return "Latimer";
                case "LEF": return "Le";
                case "LIN": return "Lincoln";
                case "LOG": return "Logan";
                case "LOV": return "Love";
                case "MAJ": return "Major";
                case "MAR": return "Marshall";
                case "MAY": return "Mayes";
                case "MCI": return "McIntosh";
                case "MCL": return "McClain";
                case "MCU": return "McCurtain";
                case "MUR": return "Murray";
                case "MUS": return "Muskogee";
                case "NOB": return "Noble";
                case "NOW": return "Nowata";
                case "OKF": return "Okfuskee";
                case "OKL": return "Oklahoma";
                case "OKM": return "Okmulgee";
                case "OSA": return "Osage";
                case "OTT": return "Ottawa";
                case "PAW": return "Pawnee";
                case "PAY": return "Payne";
                case "PIT": return "Pittsburg";
                case "PON": return "Pontotoc";
                case "POT": return "Pottawatomie";
                case "PUS": return "Pushmataha";
                case "RGM": return "Roger";
                case "ROG": return "Rogers";
                case "SEM": return "Seminole";
                case "SEQ": return "Sequoyah";
                case "STE": return "Stephens";
                case "TEX": return "Texas";
                case "TIL": return "Tillman";
                case "TUL": return "Tulsa";
                case "WAG": return "Wagoner";
                case "WAS": return "Washington";
                case "WAT": return "Washita";
                case "WDW": return "Woodward";
                case "WOO": return "Woods";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ALF","ATO","BEA","BEC",
                "BLA","BRY","CAD","CAN","CAR",
                "CHE","CHO","CIM","CLE","COA",
                "COM","COT","CRA","CRE","CUS",
                "DEL","DEW","ELL","GAR","GNT",
                "GRA","GRE","GRV","HAR","HAS",
                "HRP","HUG","JAC","JEF","JOH",
                "KAY","KIN","KIO","LAT","LEF",
                "LIN","LOG","LOV","MAJ","MAR",
                "MAY","MCI","MCL","MCU","MUR",
                "MUS","NOB","NOW","OKF","OKL",
                "OKM","OSA","OTT","PAW","PAY",
                "PIT","PON","POT","PUS","RGM",
                "ROG","SEM","SEQ","STE","TEX",
                "TIL","TUL","WAG","WAS","WAT",
                "WDW","WOO"};
        }
    }
}
