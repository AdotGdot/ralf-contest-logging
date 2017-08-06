using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class AlabamaCountyListBuilder : CountyListBuilder
    {
        public AlabamaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "AL";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "AUTA","BALD","BARB","BIBB","BLOU",
                "BULL","BUTL","CHOU","CHMB","CKEE",
                "CHIL","CHOC","CLRK","CLAY","CLEB",
                "COFF","COLB","CONE","COOS","COVI",
                "CREN","CULM","DALE","DLLS","DKLB",
                "ELMO","ESCA","ETOW","FAYE","FRNK",
                "GENE","GREE","HALE","HNRY","HOUS",
                "JKSN","JEFF","LAMA","LAUD","LAWR",
                "LEE","LIME","LOWN","MACO","MDSN",
                "MRGO","MARI","MRSH","MOBI","MNRO",
                "MGMY","MORG","PERR","PICK","PIKE",
                "RAND","RSSL","SHEL","SCLR","SUMT",
                "TDEG","TPOO","TUSC","WLKR","WASH",
                "WLCX","WINS"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "AUTA": return "Autauga";
                case "BALD": return "Baldwin";
                case "BARB": return "Barbour";
                case "BIBB": return "Bibb";
                case "BLOU": return "Blount";
                case "BULL": return "Bullock";
                case "BUTL": return "Butler";
                case "CHOU": return "Calhoun";
                case "CHMB": return "Chambers";
                case "CKEE": return "Cherokee";
                case "CHIL": return "Chilton";
                case "CHOC": return "Choctaw";
                case "CLRK": return "Clarke";
                case "CLAY": return "Clay";
                case "CLEB": return "Cleburne";
                case "COFF": return "Coffee";
                case "COLB": return "Colbert";
                case "CONE": return "Conecuh";
                case "COOS": return "Coosa";
                case "COVI": return "Covington";
                case "CREN": return "Crenshaw";
                case "CULM": return "Cullman";
                case "DALE": return "Dale";
                case "DLLS": return "Dallas";
                case "DKLB": return "Dekalb";
                case "ELMO": return "Elmore";
                case "ESCA": return "Escambia";
                case "ETOW": return "Etowah";
                case "FAYE": return "Fayette";
                case "FRNK": return "Franklin";
                case "GENE": return "Geneva";
                case "GREE": return "Greene";
                case "HALE": return "Hale";
                case "HNRY": return "Henry";
                case "HOUS": return "Houston";
                case "JKSN": return "Jackson";
                case "JEFF": return "Jefferson";
                case "LAMA": return "Lamar";
                case "LAUD": return "Lauderdale";
                case "LAWR": return "Lawrence";
                case "LEE": return "Lee";
                case "LIME": return "Limestone";
                case "LOWN": return "Lowndes";
                case "MACO": return "Macon";
                case "MDSN": return "Madison";
                case "MRGO": return "Marengo";
                case "MARI": return "Marion";
                case "MRSH": return "Marshall";
                case "MOBI": return "Mobile";
                case "MNRO": return "Monroe";
                case "MGMY": return "Montgomery";
                case "MORG": return "Morgan";
                case "PERR": return "Perry";
                case "PICK": return "Pickens";
                case "PIKE": return "Pike";
                case "RAND": return "Randolph";
                case "RSSL": return "Russell";
                case "SHEL": return "Shelby";
                case "SCLR": return "St. Clair";
                case "SUMT": return "Sumter";
                case "TDEG": return "Talladega";
                case "TPOO": return "Tallapoosa";
                case "TUSC": return "Tuscaloosa";
                case "WLKR": return "Walker";
                case "WASH": return "Washington";
                case "WLCX": return "Wilcox";
                case "WINS": return "Winston";
                default: return String.Empty;
            }
        }
    }
}
