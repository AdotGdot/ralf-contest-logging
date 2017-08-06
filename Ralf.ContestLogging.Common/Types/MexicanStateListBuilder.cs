using System.Linq;

namespace Ralf.ContestLogging.Common.Types
{
    public static class MexicanStateListBuilder
    {
        private static MexicanStateList list = null;

        private static string[] mexStates = new string[]
        {
            "Aguascalientes (AGS)",
            "Baja California (BAC)",
            "Baja California Sur (BCS)",
            "Campeche (CAM)",
            "Chiapas (CHI)",
            "Chihuahua (CHH)",
            "Ciudad de Mexico (CMX)",
            "Coahuila (COA)",
            "Colima (COL)",
            "Durango (DGO)",
            "Estado de Mexico (EMX)",
            "Guanajuato (GTO)",
            "Guerrero (GRO)",
            "Hidalgo (HGO)",
            "Jalisco (JAL)",
            "Michoacán (MIC)",
            "Morelos (MOR)",
            "Nayarit (NAY)",
            "Nuevo León (NLE)",
            "Oaxaca (OAX)",
            "Puebla (PUE)",
            "Queretaro (QRO)",
            "Quintana Roo (QUI)",
            "San Luis Potosí (SLP)",
            "Sinaloa (SIN)",
            "Sonora (SON)",
            "Tabasco (TAB)",
            "Tamaulipas (TAM)",
            "Tlaxcala (TLX)",
            "Veracruz (VER)",
            "Yucatan (YUC)",
            "Zacatecas (ZAC)"
        };

        public static bool isValidState(string stateAbbr)
        {
            MexicanStateList list = MexicanStateListBuilder.getMexicanStateList();
            return (from MexicanState state in list
                    where state.Abbr == stateAbbr
                    select state).Count() == 1;
        }

        public static MexicanStateList getMexicanStateList()
        {
            if (list == null)
            {
                buildMexicanStateList();
            }
            return list;
        }

        private static void buildMexicanStateList()
        {
            list = new MexicanStateList();
            MexicanState mexicanState;
            foreach (string s in mexStates)
            {
                string[] parts = s.Split('(');
                string name = parts[0].Trim();
                string abbr = parts[1].Substring(0, 3);
                mexicanState = new MexicanState() { Abbr = abbr, Name = name };
                list.Add(mexicanState);
            }
        }
    }
}
