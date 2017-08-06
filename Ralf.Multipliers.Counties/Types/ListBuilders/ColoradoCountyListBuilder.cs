using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class ColoradoCountyListBuilder : CountyListBuilder
    {
        public ColoradoCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "CO";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ADA": return "Adams";
                case "ALA": return "Alamosa";
                case "ARA": return "Arapahoe";
                case "ARC": return "Archuleta";
                case "BAC": return "Baca";
                case "BEN": return "Bent";
                case "BOU": return "Boulder";
                case "BRO": return "Broomfield";
                case "CHA": return "Chaffee";
                case "CHE": return "Cheyenne";
                case "CLC": return "Clear Creek";
                case "CON": return "Conejos";
                case "COS": return "Costilla";
                case "CRO": return "Crowley";
                case "CUS": return "Custer";
                case "DEL": return "Delta";
                case "DEN": return "Denver";
                case "DOL": return "Dolores";
                case "DOU": return "Douglas";
                case "EAG": return "Eagle";
                case "ELP": return "El Paso";
                case "ELB": return "Elbert";
                case "FRE": return "Fremont";
                case "GAR": return "Garfield";
                case "GIL": return "Gilpin";
                case "GRA": return "Grand";
                case "GUN": return "Gunnison";
                case "HIN": return "Hinsdale";
                case "HUE": return "Huerfano";
                case "JAC": return "Jackson";
                case "JEF": return "Jefferson";
                case "KIO": return "Kiowa";
                case "KIC": return "Kit Carson";
                case "LAK": return "Lake";
                case "LAP": return "La Plata";
                case "LAR": return "Larimer";
                case "LAA": return "Las Animas";
                case "LIN": return "Lincoln";
                case "LOG": return "Logan";
                case "MES": return "Mesa";
                case "MIN": return "Mineral";
                case "MOF": return "Moffat";
                case "MON": return "Montezuma";
                case "MOT": return "Montrose";
                case "MOR": return "Morgan";
                case "OTE": return "Otero";
                case "OUR": return "Ouray";
                case "PAR": return "Park";
                case "PHI": return "Phillips";
                case "PIT": return "Pitkin";
                case "PRO": return "Prowers";
                case "PUE": return "Pueblo";
                case "RIB": return "Rio Blanco";
                case "RIG": return "Rio Grande";
                case "ROU": return "Routt";
                case "SAG": return "Saguache";
                case "SAJ": return "San Juan";
                case "SAM": return "San Miguel";
                case "SED": return "Sedgwick";
                case "SUM": return "Summit";
                case "TEL": return "Teller";
                case "WAS": return "Washington";
                case "WEL": return "Weld";
                case "YUM": return "Yuma";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ADA","ALA","ARA","ARC","BAC",
                "BEN","BOU","BRO","CHA","CHE",
                "CLC","CON","COS","CRO","CUS",
                "DEL","DEN","DOL","DOU","EAG",
                "ELP","ELB","FRE","GAR","GIL",
                "GRA","GUN","HIN","HUE","JAC",
                "JEF","KIO","KIC","LAK","LAP",
                "LAR","LAA","LIN","LOG","MES",
                "MIN","MOF","MON","MOT","MOR",
                "OTE","OUR","PAR","PHI","PIT",
                "PRO","PUE","RIB","RIG","ROU",
                "SAG","SAJ","SAM","SED","SUM",
                "TEL","WAS","WEL","YUM"};
        }
    }
}
