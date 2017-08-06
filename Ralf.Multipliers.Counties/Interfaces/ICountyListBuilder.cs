using Ralf.Multipliers.Counties.Types;

namespace Ralf.Multipliers.Counties.Interfaces
{
    public interface ICountyListBuilder
    {
        bool isValidCountyAbbr(string abbr);
        CountyList getCountyList();
        string getCountyFromAbbr(string abbr);
    }
}
