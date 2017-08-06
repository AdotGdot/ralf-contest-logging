using System.Linq;

namespace Ralf.Multipliers.CanadianProvinces.Types
{
    public static class CanadianProvinceListBuilder
    {
        private static CanadianProvinceList list = null;

        private static string[] abbrs = new string[]
        {
            "NS",
            "QC",
            "ON",
            "MB",
            "SK",
            "AB",
            "BC",
            "NT",
            "NB",
            "NL",
            "NU",
            "YT",
            "PE"
        };
        private static string[] names = new string[]
        {
            "Nova Scotia",
            "Quebec",
            "Ontario",
            "Manitoba",
            "Saskatchewan",
            "Alberta",
            "British Columbia",
            "Northwest Territories",
            "New Brunswick",
            "Newfoundland and Labrador",
            "Nunavut",
            "Yukon",
            "Prince Edward Island"
        };

        public static bool isValidProvince(string abbr)
        {
            return abbrs.Contains(abbr);
        }

        public static CanadianProvinceList getCanadianProvinceList()
        {
            if (list == null)
            {
                buildCanadianProvinceList();
            }
            return list;
        }
        public static string getProvinceFromAbbr(string abbr)
        {
            switch (abbr)
            {
                case "NS": return "Nova Scotia";
                case "QC": return "Quebec";
                case "ON": return "Ontario";
                case "MB": return "Manitoba";
                case "SK": return "Saskatchewan";
                case "AB": return "Alberta";
                case "BC": return "British Columbia";
                case "NT": return "Northwest Territories";
                case "NB": return "New Brunswick";
                case "NL": return "Newfoundland and Labrador";
                case "NU": return "Nunavut";
                case "YT": return "Yukon";
                case "PE": return "Prince Edward Island";
                default: return string.Empty;
            }
        }
        private static void buildCanadianProvinceList()
        {
            list = new CanadianProvinceList();
            CanadianProvince province;
            abbrs = abbrs.OrderBy(x => x).ToArray();
            for (int i = 0; i < abbrs.Length; i++)
            {
                province = new CanadianProvince() { Abbr = abbrs[i], Name = names[i], Worked = false };
                list.Add(province);
            }
        }
    }
}
