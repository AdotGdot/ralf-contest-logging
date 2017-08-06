using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class VirginiaCountyListBuilder : CountyListBuilder
    {
        public VirginiaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "VA";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ACC","DIN","LAN","PRW","ALB",
                "EMX","LEE","PUL","ALX","ESS",
                "LEX","RAX","ALL","FFX","LDN",
                "RAP","AME","FXX","LSA","RIC",
                "AMH","FCX","LUN","RIX","APP",
                "FAU","LYX","ROA","ARL","FLO",
                "MAD","ROX","AUG","FLU","MAT",
                "RBR","BAT","FRA","MAX","RHM",
                "BED","FRX","MPX","RUS","BLA",
                "FRE","MVX","SAX","BOT","FBX",
                "MEC","SCO","BRX","GAX","MID",
                "SHE","BRU","GIL","MON","SMY",
                "BCH","GLO","NEL","SHA","BHM",
                "GOO","NEW","SPO","BVX","GRA",
                "NEWS","STA","CAM","GRN","NFX",
                "STX","CLN","GVL","NHA","SUX",
                "CRL","HAL","NUM","SUR","CCY",
                "HAX","NRX","SUS","CHA","HAN",
                "NOT","TAZ","CHX","HCO","ORG",
                "VBX","CPX","HBX","PAG","WAR",
                "CHE","HRY","PAT","WAS","CLA",
                "HIG","PBX","WAX","COX","HOX",
                "PIT","WES","CVX","IOW","PQX",
                "WMX","CRA","JAM","POX","WIX",
                "CUL","KQN","POW","WIS","CUM",
                "KGE","PRE","WYT","DAX","KWM",
                "PRG","YOR","DIC"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ACC": return "Accomack";
                case "DIN": return "Dinwiddie";
                case "LAN": return "Lancaster";
                case "PRW": return "Prince William";
                case "ALB": return "Albemarle";
                case "EMX": return "Emporia";
                case "LEE": return "Lee";
                case "PUL": return "Pulaski";
                case "ALX": return "Alexandria";
                case "ESS": return "Essex";
                case "LEX": return "Lexington";
                case "RAX": return "Radford";
                case "ALL": return "Alleghany";
                case "FFX": return "Fairfax";
                case "LDN": return "Loudoun";
                case "RAP": return "Rappahannock";
                case "AME": return "Amelia";
                case "FXX": return "Fairfax";
                case "LSA": return "Louisa";
                case "RIC": return "Richmond";
                case "AMH": return "Amherst";
                case "FCX": return "Falls Church";
                case "LUN": return "Lunenburg";
                case "RIX": return "Richmond";
                case "APP": return "Appomattox";
                case "FAU": return "Fauquier";
                case "LYX": return "Lynchburg";
                case "ROA": return "Roanoke";
                case "ARL": return "Arlington";
                case "FLO": return "Floyd";
                case "MAD": return "Madison";
                case "ROX": return "Roanoke";
                case "AUG": return "Augusta";
                case "FLU": return "Fluvanna";
                case "MAT": return "Mathews";
                case "RBR": return "Rockbridge";
                case "BAT": return "Bath";
                case "FRA": return "Franklin";
                case "MAX": return "Manassas";
                case "RHM": return "Rockingham";
                case "BED": return "Bedford";
                case "FRX": return "Franklin";
                case "MPX": return "Manassas Park";
                case "RUS": return "Russell";
                case "BLA": return "Bland";
                case "FRE": return "Frederick";
                case "MVX": return "Martinsville";
                case "SAX": return "Salem";
                case "BOT": return "Botetourt";
                case "FBX": return "Fredericksburg";
                case "MEC": return "Mecklenburg";
                case "SCO": return "Scott";
                case "BRX": return "Bristol";
                case "GAX": return "Galax";
                case "MID": return "Middlesex";
                case "SHE": return "Shenandoah";
                case "BRU": return "Brunswick";
                case "GIL": return "Giles";
                case "MON": return "Montgomery";
                case "SMY": return "Smyth";
                case "BCH": return "Buchanan";
                case "GLO": return "Gloucester";
                case "NEL": return "Nelson";
                case "SHA": return "Southampton";
                case "BHM": return "Buckingham";
                case "GOO": return "Goochland";
                case "NEW": return "New Kent";
                case "SPO": return "Spotsylvania";
                case "BVX": return "Buena Vista";
                case "GRA": return "Grayson";
                case "NEWS": return "Newport";
                case "STA": return "Stafford";
                case "CAM": return "Campbell";
                case "GRN": return "Greene";
                case "NFX": return "Norfolk";
                case "STX": return "Staunton";
                case "CLN": return "Caroline";
                case "GVL": return "Greensville";
                case "NHA": return "Northampton";
                case "SUX": return "Suffolk";
                case "CRL": return "Carroll";
                case "HAL": return "Halifax";
                case "NUM": return "Northumberland";
                case "SUR": return "Surry";
                case "CCY": return "Charles City";
                case "HAX": return "Hampton";
                case "NRX": return "Norton";
                case "SUS": return "Sussex";
                case "CHA": return "Charlotte";
                case "HAN": return "Hanover";
                case "NOT": return "Nottoway";
                case "TAZ": return "Tazewell";
                case "CHX": return "Charlottesville";
                case "HCO": return "Henrico";
                case "ORG": return "Orange";
                case "VBX": return "Virginia Beach";
                case "CPX": return "Chesapeake";
                case "HBX": return "Harrisonburg";
                case "PAG": return "Page";
                case "WAR": return "Warren";
                case "CHE": return "Chesterfield";
                case "HRY": return "Henry";
                case "PAT": return "Patrick";
                case "WAS": return "Washington";
                case "CLA": return "Clarke";
                case "HIG": return "Highland";
                case "PBX": return "Petersburg";
                case "WAX": return "Waynesboro";
                case "COX": return "Colonial Heights";
                case "HOX": return "Hopewell";
                case "PIT": return "Pittsylvania";
                case "WES": return "Westmoreland";
                case "CVX": return "Covington";
                case "IOW": return "Isle of Wight";
                case "PQX": return "Poquoson";
                case "WMX": return "Williamsburg";
                case "CRA": return "Craig";
                case "JAM": return "James City";
                case "POX": return "Portsmouth";
                case "WIX": return "Winchester";
                case "CUL": return "Culpeper";
                case "KQN": return "King & Queen";
                case "POW": return "Powhatan";
                case "WIS": return "Wise";
                case "CUM": return "Cumberland";
                case "KGE": return "King George";
                case "PRE": return "Prince Edward";
                case "WYT": return "Wythe";
                case "DAX": return "Danville";
                case "KWM": return "King William";
                case "PRG": return "Prince George";
                case "YOR": return "York";
                case "DIC": return "Dickenson";
                default: return String.Empty;
            }
        }
    }
}

