namespace Ralf.ContestLogging.Common.Types
{
    public class ZoneDetail
    {
        public string Name { get; set; }
        public int ZoneNumber { get; set; }
        public int AdifId { get; set; }
    }

    public class CqZoneDetail : ZoneDetail { }
    public class ItuZoneDetail : ZoneDetail { }
}
