using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class LouisianaCountyListBuilder : CountyListBuilder
    {
        public LouisianaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "LA";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ACAD","ALLE","ASCE","ASSU","AVOY",
                "BEAU","BIEN","BOSS","CADD","CALC",
                "CALD","CAME","CATA","CLAI","CONC",
                "DESO","EBR","ECAR","EFEL","EVAN",
                "FRAN","GRAN","IBER","IBVL","JACK",
                "JFDV","JEFF","LASA","LAFA","LAFO",
                "LINC","LIVI","MADI","MORE","NATC",
                "ORLE","OUAC","PLAQ","PCP","RAPI",
                "REDR","RICH","SABI","SBND","SCHL",
                "SHEL","SJAM","SJB","SLAN","SMT",
                "SMAR","STAM","TANG","TENS","TERR",
                "UNIO","VERM","VERN","WASH","WEBS",
                "WBR","WCAR","WFEL","WINN"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ACAD": return "Acadia";
                case "ALLE": return "Allen";
                case "ASCE": return "Ascension";
                case "ASSU": return "Assumption";
                case "AVOY": return "Avoyelles";
                case "BEAU": return "Beauregard";
                case "BIEN": return "Bienville";
                case "BOSS": return "Bossier";
                case "CADD": return "Caddo";
                case "CALC": return "Calcasieu";
                case "CALD": return "Caldwell";
                case "CAME": return "Cameron";
                case "CATA": return "Catahoula";
                case "CLAI": return "Claiborne";
                case "CONC": return "Concordia";
                case "DESO": return "De Soto";
                case "EBR": return "East Baton Rouge";
                case "ECAR": return "East Carroll";
                case "EFEL": return "East Feliciana";
                case "EVAN": return "Evangeline";
                case "FRAN": return "Franklin";
                case "GRAN": return "Grant";
                case "IBER": return "Iberia";
                case "IBVL": return "Iberville";
                case "JACK": return "Jackson";
                case "JFDV": return "Jefferson Davis";
                case "JEFF": return "Jefferson";
                case "LASA": return "La Salle";
                case "LAFA": return "Lafayette";
                case "LAFO": return "Lafourche";
                case "LINC": return "Lincoln";
                case "LIVI": return "Livingston";
                case "MADI": return "Madison";
                case "MORE": return "Morehouse";
                case "NATC": return "Natchitoches";
                case "ORLE": return "Orleans";
                case "OUAC": return "Ouachita";
                case "PLAQ": return "Plaquemines";
                case "PCP": return "Pointe Coupee";
                case "RAPI": return "Rapides";
                case "REDR": return "Red River";
                case "RICH": return "Richland";
                case "SABI": return "Sabine";
                case "SBND": return "St. Bernard";
                case "SCHL": return "St. Charles";
                case "SHEL": return "St. Helena";
                case "SJAM": return "St. James";
                case "SJB": return "St. John Baptist";
                case "SLAN": return "St. Landry";
                case "SMT": return "St. Martin";
                case "SMAR": return "St. Mary";
                case "STAM": return "St. Tammy";
                case "TANG": return "Tangipahoa";
                case "TENS": return "Tensas";
                case "TERR": return "Terrebonne";
                case "UNIO": return "Union";
                case "VERM": return "Vermilion";
                case "VERN": return "Vernon";
                case "WASH": return "Washington";
                case "WEBS": return "Webster";
                case "WBR": return "West Baton Rouge";
                case "WCAR": return "West Carroll";
                case "WFEL": return "West Feliciana";
                case "WINN": return "Winn";
                default: return String.Empty;
            }
        }
    }
}
