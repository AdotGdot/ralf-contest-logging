using System;
using System.Text.RegularExpressions;

namespace Ralf.PrefixParsing
{
    public static class PrefixParser
    {
        private static Regex regex = new Regex("[0-9]");

        public static string parseForPrefix(string callsign)
        {
            if (callsign.Contains("/"))
            {
                return prefixFromPortableCallsign(callsign);
            }

            int n;
            int dummy;
            for (n = callsign.Length - 1; n >= 0; n--)
            {
                string x = callsign[n].ToString();
                if (Int32.TryParse(x, out dummy))
                {
                    break;
                }
            }

            string prefix = callsign.Substring(0, n + 1);
            Match match = regex.Match(prefix);
            if (!match.Success)
            {
                prefix = callsign.Substring(0, 2) + "0";
            }
            return prefix;
        }

        private static string prefixFromPortableCallsign(string callsign)
        {
            string[] parts = callsign.Split('/');
            string prefix = parts[0].Length > parts[1].Length ? parts[1] : parts[0];
            if (prefix.Equals("MM"))
            {
                return String.Empty;
            }
            Match match = regex.Match(prefix);
            if (!match.Success)
            {
                prefix = callsign.Substring(0, 2) + "0";
            }
            return prefix;
        }
    }
}
