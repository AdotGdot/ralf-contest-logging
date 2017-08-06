using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class IndianaCountyListBuilder : CountyListBuilder
    {
        public IndianaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "IN";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adams";
                case "ALL": return "Allen";
                case "BAR": return "Bartholomew";
                case "BEN": return "Benton";
                case "BLA": return "Blackford";
                case "BOO": return "Boone";
                case "BRO": return "Brown";
                case "CAR": return "Carroll";
                case "CAS": return "Cass";
                case "CLAR": return "Clark";
                case "CLAY": return "Clay";
                case "CLI": return "Clinton";
                case "CRA": return "Crawford";
                case "DAV": return "Daviess";
                case "DEA": return "Dearborn";
                case "DEC": return "Decatur";
                case "DEK": return "Dekalb";
                case "DEL": return "Delaware";
                case "DUB": return "Dubois";
                case "ELK": return "Elkhart";
                case "FAY": return "Fayette";
                case "FLO": return "Floyd";
                case "FOU": return "Fountain";
                case "FRA": return "Franklin";
                case "FUL": return "Fulton";
                case "GIB": return "Gibson";
                case "GRA": return "Grant";
                case "GRE": return "Greene";
                case "HAM": return "Hamilton";
                case "HAN": return "Hancock";
                case "HAR": return "Harrison";
                case "HEND": return "Hendricks";
                case "HENR": return "Henry";
                case "HOW": return "Howard";
                case "HUN": return "Huntington";
                case "JAC": return "Jackson";
                case "JAS": return "Jasper";
                case "JAY": return "Jay";
                case "JEF": return "Jefferson";
                case "JEN": return "Jennings";
                case "JOH": return "Johnson";
                case "KNO": return "Knox";
                case "KOS": return "Kosciusko";
                case "LAG": return "Lagrange";
                case "LAK": return "Lake";
                case "LAP": return "Laporte";
                case "LAW": return "Lawrence";
                case "MAD": return "Madison";
                case "MARI": return "Marion";
                case "MARS": return "Marshall";
                case "MART": return "Martin";
                case "MIA": return "Miami";
                case "MONR": return "Monroe";
                case "MONT": return "Montgomery";
                case "MOR": return "Morgan";
                case "NEW": return "Newton";
                case "NOB": return "Noble";
                case "OHI": return "Ohio";
                case "ORA": return "Orange";
                case "OWE": return "Owen";
                case "PAR": return "Parke";
                case "PER": return "Perry";
                case "PIK": return "Pike";
                case "POR": return "Porter";
                case "POS": return "Posey";
                case "PUL": return "Pulaski";
                case "PUT": return "Putnam";
                case "RAN": return "Randolph";
                case "RIP": return "Ripley";
                case "RUS": return "Rush";
                case "SCO": return "Scott";
                case "SHE": return "Shelby";
                case "SPE": return "Spencer";
                case "STJ": return "St. Joseph";
                case "STA": return "Starke";
                case "STE": return "Steuben";
                case "SUL": return "Sullivan";
                case "SWI": return "Switzerland";
                case "TIPP": return "Tippecanoe";
                case "TIPT": return "Tipton";
                case "UNI": return "Union";
                case "VAN": return "Vanderburgh";
                case "VER": return "Vermillion";
                case "VIG": return "Vigo";
                case "WAB": return "Wabash";
                case "WARN": return "Warren";
                case "WARK": return "Warrick";
                case "WAS": return "Washington";
                case "WAY": return "Wayne";
                case "WEL": return "Wells";
                case "WHTE": return "White";
                case "WHTL": return "Whitley";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ALL","BAR","BEN","BLA",
                "BOO","BRO","CAR","CAS","CLAR",
                "CLAY","CLI","CRA","DAV","DEA",
                "DEC","DEK","DEL","DUB","ELK",
                "FAY","FLO","FOU","FRA","FUL",
                "GIB","GRA","GRE","HAM","HAN",
                "HAR","HEND","HENR","HOW","HUN",
                "JAC","JAS","JAY","JEF","JEN",
                "JOH","KNO","KOS","LAG","LAK",
                "LAP","LAW","MAD","MARI","MARS",
                "MART","MIA","MONR","MONT","MOR",
                "NEW","NOB","OHI","ORA","OWE",
                "PAR","PER","PIK","POR","POS",
                "PUL","PUT","RAN","RIP","RUS",
                "SCO","SHE","SPE","STJ","STA",
                "STE","SUL","SWI","TIPP","TIPT",
                "UNI","VAN","VER","VIG","WAB",
                "WARN","WARK","WAS","WAY","WEL",
                "WHTE","WHTL"};
        }
    }
}
