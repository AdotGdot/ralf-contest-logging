namespace Ralf.ContestLogging.Common.Types
{
    public class DxccEntitySelection
    {
        public int AdifId { get; set; }
        public string Continent { get; set; }
        public int CqZone { get; set; }
        public int ItuZone { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }

        public override bool Equals(object obj)
        {
            DxccEntitySelection des = obj as DxccEntitySelection;
            return (AdifId == des.AdifId) &&
                (Continent.Equals(des.Continent)) &&
                (CqZone == des.CqZone) &&
                (ItuZone == des.ItuZone) &&
                (Name.Equals(des.Name)) &&
                (Prefix.Equals(des.Prefix));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
