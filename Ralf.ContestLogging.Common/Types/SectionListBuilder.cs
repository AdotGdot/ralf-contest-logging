using System.Linq;

namespace Ralf.ContestLogging.Common.Types
{
    public static class SectionListBuilder
    {
        private static SectionList arrlSections = null;
        private static SectionList racSections = null;
        private static SectionList allSections = null;

        private static string[] arrlAbbr = new string[]{
            "CT", "EMA", "ME", "NH", "RI",
            "VT", "WMA", "ENY", "NLI", "NNJ",
            "NNY", "SNJ", "WNY", "DE", "EPA",
            "MDC", "WPA", "AL", "GA", "KY",
            "NC", "NFL", "SC", "SFL", "WCF",
            "TN", "VA", "PR", "VI", "AR",
            "LA", "MS", "NM", "NTX", "OK",
            "STX", "WTX", "EB", "LAX", "ORG",
            "SB", "SCV", "SDG", "SF", "SJV",
            "SV", "PAC", "AZ", "EWA", "ID",
            "MT", "NV", "OR", "UT", "WWA",
            "WY", "AK", "MI", "OH", "WV",
            "IL", "IN", "WI", "CO", "IA",
            "KS", "MN", "MO", "NE", "ND",
            "SD"
        };

        private static string[] racAbbr = new string[]{
            "MAR", "NL", "QC", "ONE", "ONN",
            "ONS", "GTA", "MB", "SK", "AB",
            "BC", "NWT", "YT", "NU"
        };

        public static bool isValidSection(string section)
        {
            return racAbbr.Contains(section) || arrlAbbr.Contains(section);
        }

        public static string getCanadianProvince(string section)
        {
            switch (section)
            {
                case "MAR": return "Maritime";
                case "NL": return "Newfoundland/Labrador";
                case "QC": return "Quebec";
                case "ONE": return "Ontario East";
                case "ONN": return "Ontario North";
                case "ONS": return "Ontario South";
                case "GTA": return "Greater Toronto Area";
                case "MB": return "Manitoba";
                case "SK": return "Saskatchewan";
                case "AB": return "Alberta";
                case "BC": return "British Columbia";
                case "NWT": return "Northwest Territories";
                case "YT": return "Yukon Territories";
                case "NU": return "Nunavut";
                default: return section;
            }
        }
        public static string getUSState(string section)
        {
            switch (section)
            {
                case "EMA":
                case "WMA": return "MA";
                case "ENY":
                case "NLI":
                case "NNY":
                case "WNY": return "NY";
                case "NNJ":
                case "SNJ": return "NJ";
                case "EPA":
                case "WPA": return "PA";
                case "NFL":
                case "SFL":
                case "WCF": return "FL";
                case "NTX":
                case "STX":
                case "WTX": return "TX";
                case "EB":
                case "LAX":
                case "ORG":
                case "SB":
                case "SCV":
                case "SDG":
                case "SF":
                case "SJV":
                case "SV": return "CA";
                case "EWA":
                case "WWA": return "WA";
                case "MDC": return "MD";
                default: return section;
            }
        }
        public static SectionList getAllSections()
        {
            if (allSections == null)
            {
                buildAllSections();
            }
            return allSections;
        }

        private static void buildAllSections()
        {
            if (arrlSections == null)
            {
                buildArrlSectionList();
            }
            if (racSections == null)
            {
                buildRacSectionList();
            }
            allSections = new SectionList();
            foreach (Section section in arrlSections)
            {
                allSections.Add(section);
            }
            foreach (Section section in racSections)
            {
                allSections.Add(section);
            }
        }
        public static SectionList getArrlSections()
        {
            if (arrlSections == null)
            {
                buildArrlSectionList();
            }
            return arrlSections;
        }

        private static void buildArrlSectionList()
        {
            arrlSections = new SectionList();
            arrlAbbr = arrlAbbr.OrderBy(x => x).ToArray();
            foreach (string section in arrlAbbr)
            {
                Section s = new Section() { Abbr = section };
                arrlSections.Add(s);
            }
        }

        public static SectionList getRacSections()
        {
            if (racSections == null)
            {
                buildRacSectionList();
            }
            return racSections;
        }

        private static void buildRacSectionList()
        {
            racSections = new SectionList();
            racAbbr = racAbbr.OrderBy(x => x).ToArray();
            foreach (string section in racAbbr)
            {
                Section s = new Section() { Abbr = section };
                racSections.Add(s);
            }
        }
    }
}
