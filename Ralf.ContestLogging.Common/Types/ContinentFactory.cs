using System;
using System.Collections.Generic;
using System.Linq;

namespace Ralf.ContestLogging.Common.Types
{
    public static class ContinentFactory
    {
        private static IList<ContinentDetail> continents = null;
        public static IList<ContinentDetail> GetContinentList()
        {
            if(continents == null)
            {
                continents = new List<ContinentDetail>();
                continents.Add(new ContinentDetail() { Name = "Other", Abbreviation = String.Empty });
                continents.Add(new ContinentDetail() { Name = "North America", Abbreviation = "NA" });
                continents.Add(new ContinentDetail() { Name = "South America", Abbreviation = "SA" });
                continents.Add(new ContinentDetail() { Name = "Africa", Abbreviation = "AF" });
                continents.Add(new ContinentDetail() { Name = "Oceania", Abbreviation = "OC" });
                continents.Add(new ContinentDetail() { Name = "Asia", Abbreviation = "AS" });
                continents.Add(new ContinentDetail() { Name = "Europe", Abbreviation = "EU" });
                continents.Add(new ContinentDetail() { Name = "Africa", Abbreviation = "AF" });
                continents.Add(new ContinentDetail() { Name = "Antartica", Abbreviation = "AN" });
            }
            return continents;
        }
        public static ContinentDetail GetContinent( this string abbreviation)
        {
            return (from continent in GetContinentList()
                    where continent.Abbreviation.Equals(abbreviation)
                    select continent).FirstOrDefault();
        }
    }
}
