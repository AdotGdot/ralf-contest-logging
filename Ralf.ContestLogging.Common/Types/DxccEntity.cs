using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Types
{
    public class DxccEntity
    {
        public int AdifId { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public List<string> Continents { get; set; }
        public List<int> CqZones { get; set; }
        public List<int> ItuZones { get; set; }
    }
}
