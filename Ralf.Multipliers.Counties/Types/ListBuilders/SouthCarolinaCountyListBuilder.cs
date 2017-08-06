using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class SouthCarolinaCountyListBuilder : CountyListBuilder
    {
        public SouthCarolinaCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "SC";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "ABBE","AIKE","ALLE","ANDE","BAMB",
                "BARN","BEAU","BERK","CHOU","CHAR",
                "CKEE","CHES","CHFD","CLRN","COLL",
                "DARL","DILL","DORC","EDGE","FAIR",
                "FLOR","GEOR","GVIL","GRWD","HAMP",
                "HORR","JASP","KERS","LNCS","LAUR",
                "LEE","LEXI","MARI","MARL","MCOR",
                "NEWB","OCON","ORNG","PICK","RICH",
                "SALU","SPAR","SUMT","UNIO","WILL",
                "YORK" };
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "ABBE": return "Abbeville";
                case "AIKE": return "Aiken";
                case "ALLE": return "Allendale";
                case "ANDE": return "Anderson";
                case "BAMB": return "Bamberg";
                case "BARN": return "Barnwell";
                case "BEAU": return "Beaufort";
                case "BERK": return "Berkeley";
                case "CHOU": return "Calhoun";
                case "CHAR": return "Charleston";
                case "CKEE": return "Cherokee";
                case "CHES": return "Chester";
                case "CHFD": return "Chesterfield";
                case "CLRN": return "Clarendon";
                case "COLL": return "Colleton";
                case "DARL": return "Darlington";
                case "DILL": return "Dillon";
                case "DORC": return "Dorchester";
                case "EDGE": return "Edgefield";
                case "FAIR": return "Fairfield";
                case "FLOR": return "Florence";
                case "GEOR": return "Georgetown";
                case "GVIL": return "Greenville";
                case "GRWD": return "Greenwood";
                case "HAMP": return "Hampton";
                case "HORR": return "Horry";
                case "JASP": return "Jasper";
                case "KERS": return "Kershaw";
                case "LNCS": return "Lancaster";
                case "LAUR": return "Laurens";
                case "LEE": return "Lee";
                case "LEXI": return "Lexington";
                case "MARI": return "Marion";
                case "MARL": return "Marlboro";
                case "MCOR": return "Mccormick";
                case "NEWB": return "Newberry";
                case "OCON": return "Oconee";
                case "ORNG": return "Orangeburg";
                case "PICK": return "Pickens";
                case "RICH": return "Richland";
                case "SALU": return "Saluda";
                case "SPAR": return "Spartanburg";
                case "SUMT": return "Sumter";
                case "UNIO": return "Union";
                case "WILL": return "Williamsburg";
                case "YORK": return "York";
                default: return String.Empty;
            }
        }
    }
}
