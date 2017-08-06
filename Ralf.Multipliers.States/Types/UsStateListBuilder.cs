using System.Linq;

namespace Ralf.Multipliers.States.Types
{
    public static class UsStateListBuilder
    {
        private static string[] usStateData = "AL,AK,AZ,AR,CA,CO,CT,DE,FL,GA,HI,ID,IL,IN,IA,KS,KY,LA,ME,MD,MA,MI,MN,MS,MO,MT,NE,NV,NH,NJ,NM,NY,NC,ND,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VT,VA,WA,WV,WI,WY".Split(',');
        private static UsStateList list;
        public static UsStateList getUsStateList()
        {
            if (list == null)
            {
                list = new UsStateList();
                UsState s;
                foreach (string data in usStateData.OrderBy(x => x))
                {
                    s = new UsState() { Abbr = data };
                    list.Add(s);
                }
            }
            return list;
        }
        public static bool isValidState(string abbr)
        {
            if (list == null)
            {
                getUsStateList();
            }
            return (from UsState s in list
                    where s.Abbr.Equals(abbr)
                    select s).Count() > 0;
        }
    }
}
