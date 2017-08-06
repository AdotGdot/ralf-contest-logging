namespace Ralf.ContestLogging.Common.Types
{
    public static class ZoneListBuilder
    {
        public static ZoneList getCqZoneList()
        {
            ZoneList list = new ZoneList();
            Zone zone;
            for (int i = 0; i < 40; i++)
            {
                zone = new Zone() { ZoneNumber = (i + 1) };
                list.Add(zone);
            }
            return list;
        }
        public static ZoneList getItuZoneList()
        {
            ZoneList list = new ZoneList();
            Zone zone;
            for (int i = 0; i < 75; i++)
            {
                zone = new Zone() { ZoneNumber = (i + 1) };
                list.Add(zone);
            }
            return list;
        }
        public static bool IsValidItuZone(int ituZone)
        {
            return ituZone > 0 && ituZone < 77;
        }
        public static bool IsValidCqZone(int cqZone)
        {
            return cqZone > 0 && cqZone < 41;
        }
    }
}
