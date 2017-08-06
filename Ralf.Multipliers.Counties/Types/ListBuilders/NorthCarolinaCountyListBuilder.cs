using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NorthCarolinaCountyListBuilder : CountyListBuilder
    {
        public NorthCarolinaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NC";
            buildCountyAbbrArray();
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ALA": return "Alamance";
                case "ALE": return "Alexander";
                case "ALL": return "Alleghany";
                case "ANS": return "Anson";
                case "ASH": return "Ashe";
                case "AVE": return "Avery";
                case "BEA": return "Beaufort";
                case "BER": return "Bertie";
                case "BLA": return "Bladen";
                case "BRU": return "Brunswick";
                case "BUN": return "Buncombe";
                case "BUR": return "Burke";
                case "CAB": return "Cabarrus";
                case "CAL": return "Caldwell";
                case "CAM": return "Camden";
                case "CAR": return "Carteret";
                case "CAS": return "Caswell";
                case "CAT": return "Catawba";
                case "CHA": return "Chatham";
                case "CHE": return "Cherokee";
                case "CHO": return "Chowan";
                case "CLA": return "Clay";
                case "CLE": return "Clevelend";
                case "COL": return "Columbus";
                case "CRA": return "Craven";
                case "CUM": return "Cumberland";
                case "CUR": return "Currituck";
                case "DAR": return "Dare";
                case "DAV": return "Davie";
                case "DUP": return "Duplin";
                case "DUR": return "Durham";
                case "DVD": return "Davidson";
                case "EDG": return "Edgecombe";
                case "FOR": return "Forsyth";
                case "FRA": return "Franklin";
                case "GAS": return "Gaston";
                case "GAT": return "Gates";
                case "GRA": return "Granville";
                case "GRE": return "Greene";
                case "GRM": return "Graham";
                case "GUI": return "Guilford";
                case "HAL": return "Halifax";
                case "HAR": return "Harnett";
                case "HAY": return "Haywood";
                case "HEN": return "Henderson";
                case "HER": return "Hertford";
                case "HOK": return "Hoke";
                case "HYD": return "Hyde";
                case "IRE": return "Iredell";
                case "JAC": return "Jackson";
                case "JOH": return "Johnston";
                case "JON": return "Jones";
                case "LEE": return "Lee";
                case "LEN": return "Lenoir";
                case "LIN": return "Lincoln";
                case "MAC": return "Macon";
                case "MAD": return "Madison";
                case "MAR": return "Martin";
                case "MCD": return "Mcdowell";
                case "MEC": return "Mecklenburg";
                case "MIT": return "Mitchell";
                case "MON": return "Montgomery";
                case "MOO": return "Moore";
                case "NAS": return "Nash";
                case "NEW": return "New Hanover";
                case "NOR": return "Northampton";
                case "ONS": return "Onslow";
                case "ORA": return "Orange";
                case "PAM": return "Pamlico";
                case "PAS": return "Pasquotank";
                case "PEN": return "Pender";
                case "PEQ": return "Perquimans";
                case "PER": return "Person";
                case "PIT": return "Pitt";
                case "POL": return "Polk";
                case "RAN": return "Randolph";
                case "RIC": return "Richmond";
                case "ROB": return "Robeson";
                case "ROC": return "Rockingham";
                case "ROW": return "Rowan";
                case "RUT": return "Rutherford";
                case "SAM": return "Sampson";
                case "SCO": return "Scotland";
                case "STA": return "Stanley";
                case "STO": return "Stokes";
                case "SUR": return "Surry";
                case "SWA": return "Swain";
                case "TRA": return "Transylvania";
                case "TYR": return "Tyrrell";
                case "UNI": return "Union";
                case "VAN": return "Vance";
                case "WAK": return "Wake";
                case "WAR": return "Warren";
                case "WAS": return "Washington";
                case "WAT": return "Watauga";
                case "WAY": return "Wayne";
                case "WIL": return "Wilson";
                case "WLK": return "Wilkes";
                case "YAD": return "Yadkin";
                case "YAN": return "Yancey";
                default: return String.Empty;
            }
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ALA","ALE","ALL","ANS","ASH",
                "AVE","BEA","BER","BLA","BRU",
                "BUN","BUR","CAB","CAL","CAM",
                "CAR","CAS","CAT","CHA","CHE",
                "CHO","CLA","CLE","COL","CRA",
                "CUM","CUR","DAR","DAV","DUP",
                "DUR","DVD","EDG","FOR","FRA",
                "GAS","GAT","GRA","GRE","GRM",
                "GUI","HAL","HAR","HAY","HEN",
                "HER","HOK","HYD","IRE","JAC",
                "JOH","JON","LEE","LEN","LIN",
                "MAC","MAD","MAR","MCD","MEC",
                "MIT","MON","MOO","NAS","NEW",
                "NOR","ONS","ORA","PAM","PAS",
                "PEN","PEQ","PER","PIT","POL",
                "RAN","RIC","ROB","ROC","ROW",
                "RUT","SAM","SCO","STA","STO",
                "SUR","SWA","TRA","TYR","UNI",
                "VAN","WAK","WAR","WAS","WAT",
                "WAY","WIL","WLK","YAD","YAN"};
        }
    }
}
