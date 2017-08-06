using Ralf.ContestLogging.Common.Interfaces;
using System;

namespace Ralf.Multipliers.Counties.Types.ListBuilders
{
    public class NewMexicoCountyListBuilder : CountyListBuilder
    {
        public NewMexicoCountyListBuilder(ILogService service) : base(service)
        {
            stateAbbr = "NM";
            buildCountyAbbrArray();
        }

        private void buildCountyAbbrArray()
        {
            countyAbbreviations = new string[] {
                "BER","CAT","CHA","CIB","COL",
                "CUR","DEB","ANA","EDD","GRA",
                "GUA","HAR","HID","LEA","LIN",
                "LOS","LUN","MCK","MOR","OTE",
                "QUA","RIO","ROO","SJU","SMI",
                "SAN","SFE","SIE","SOC","TAO",
                "TOR","UNI","VAL"};
        }

        public override string getCountyFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "BER": return "Bernalillo";
                case "CAT": return "Catron";
                case "CHA": return "Chaves";
                case "CIB": return "Cibola";
                case "COL": return "Colfax";
                case "CUR": return "Curry";
                case "DEB": return "De Baca";
                case "ANA": return "Dona";
                case "EDD": return "Eddy";
                case "GRA": return "Grant";
                case "GUA": return "Guadalupe";
                case "HAR": return "Harding";
                case "HID": return "Hidalgo";
                case "LEA": return "Lea";
                case "LIN": return "Lincoln";
                case "LOS": return "Los Alamos";
                case "LUN": return "Luna";
                case "MCK": return "Mckinley";
                case "MOR": return "Mora";
                case "OTE": return "Otero";
                case "QUA": return "Quay";
                case "RIO": return "Rio Arriba";
                case "ROO": return "Roosevelt";
                case "SJU": return "San Juan";
                case "SMI": return "San Miguel";
                case "SAN": return "Sandoval";
                case "SFE": return "Santa Fe";
                case "SIE": return "Sierra";
                case "SOC": return "Socorro";
                case "TAO": return "Taos";
                case "TOR": return "Torrance";
                case "UNI": return "Union";
                case "VAL": return "Valencia";
                default: return String.Empty;
            }
        }
    }
}
