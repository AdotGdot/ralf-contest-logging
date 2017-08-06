using System.Collections.Generic;
using System.Windows;

namespace Ralf.DxResolutionRepository.Afreet.Types
{
    internal class PrefixData
    {
        // from file
        public Point Location;
        public string Territory;
        public string Prefix;
        public string CQ;
        public string ITU;
        public string Continent;
        public string TZ;
        public string ADIF;
        public string ProvinceCode;
        // inferred
        public string Province;
        public string City;
        public List<string> Attributes = new List<string>();
    }
}
