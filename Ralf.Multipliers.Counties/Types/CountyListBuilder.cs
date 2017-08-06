using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using Ralf.Multipliers.Counties.Interfaces;
using System;
using System.Linq;

namespace Ralf.Multipliers.Counties.Types
{
    public abstract class CountyListBuilder : ICountyListBuilder
    {
        protected CountyList countyList = null;
        protected string[] countyAbbreviations;
        protected string stateAbbr;
        protected ILogService service;
        public CountyListBuilder(ILogService service)
        {
            this.service = service;

        }
        public abstract string getCountyFromAbbr(string abbr);

        public CountyList getCountyList()
        {
            if (countyList == null)
            {
                buildCountyList();
            }
            CountyList result = markWorkedCounties();
            return result;
        }
        public bool isValidCountyAbbr(string abbr)
        {
            return countyAbbreviations.Contains(abbr);
        }
        private CountyList markWorkedCounties()
        {
            CountyList result = new CountyList();
            string[] workedCounties = getWorkedCountiesArray();
            foreach (County county in countyList)
            {
                county.Worked = workedCounties.Contains(county.Abbr);
                result.Add(county);
            }
            return result;
        }

        protected virtual string[] getWorkedCountiesArray()
        {
            string[] workedCounties = (from Qso qso in service.GetLog()
                                       where !String.IsNullOrEmpty(qso.Multiplier)
                                       && qso.USState.Equals(stateAbbr)
                                       select qso.Multiplier).Distinct().ToArray();
            return workedCounties;
        }

        protected void buildCountyList()
        {
            countyList = new CountyList();
            countyAbbreviations = countyAbbreviations.OrderBy(x => x).ToArray();
            foreach (string abbr in countyAbbreviations)
            {
                County county = new County() { Abbr = abbr, Worked = false, State = stateAbbr, Name = getCountyFromAbbr(abbr) };
                countyList.Add(county);
            }
        }
    }
}
