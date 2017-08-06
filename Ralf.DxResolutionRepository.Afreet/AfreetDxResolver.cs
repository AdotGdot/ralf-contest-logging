using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using Ralf.DxResolutionRepository.Afreet.Constants;
using Ralf.DxResolutionRepository.Afreet.Enums;
using Ralf.DxResolutionRepository.Afreet.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ralf.DxResolutionRepository.Afreet
{
    public class AfreetDxResolver : IDxResolutionRepository
    {
        private const string ADIF_MARKER = "ADIF";
        // EndingPreserve = ':R:P:M:';
        private const string EndingPreserve = ":R:P:M:";
        //EndingIgnore = ':AM:MM:QRP:A:B:BCN:LH:';
        private const string EndingIgnore = ":AM:MM:QRP:A:B:BCN:LH:";
        //Digits = ['0'..'9'];
        //Letters = ['A'..'Z'];
        //AllowedChars = Digits + Letters + ['/'];
        private const string AllowedChars = AfreetConstants.Chars + "/";
        //SafeOneCharPrefixes = ['U','G','F','I','K','N','W'];
        private char[] SafeOneCharPrefixes = new char[] { 'U', 'G', 'F', 'I', 'K', 'N', 'W' };
        //OneCharPrefixes = SafeOneCharPrefixes + ['R','B','M'];  
        private char[] OneCharPrefixes = new char[] { 'U', 'G', 'F', 'I', 'K', 'N', 'W', 'R', 'B', 'M' };
        // 
        private char[] UsItalyPrefixes = new char[] { 'I', 'K', 'N', 'W', 'R' };
        private PrefixKind[] AllowedForTop = new PrefixKind[] { PrefixKind.DXCC, PrefixKind.NonDXCC, PrefixKind.Province, PrefixKind.Station, PrefixKind.City };
        private PrefixKind[] AllowedForSub = new PrefixKind[] { PrefixKind.Province, PrefixKind.Station, PrefixKind.City };
        private bool[,] ResultForTop = { { false, false, false, false }, { true, true, true, true }, { false, false, false, true } };
        private bool[,] ResultForChild = { { false, false, false, false }, { false, false, false, false }, { false, false, false, true } };

        private PrefixList prefixList;
        private Dictionary<string, string> callList = new Dictionary<string, string>();
        private List<PrefixEntry> hitTree;
        private List<PrefixData> hitList;

        public AfreetDxResolver(string prefixFileName)
        {
            prefixList = new PrefixList(prefixFileName);
        }

        public AfreetDxResolver(string prefixFileName, string callFileName)
        {
            prefixList = new PrefixList(prefixFileName);
            loadCallList(callFileName);
        }

        public IList<DxccEntity> Resolve(string callsign)
        {
            hitList = new List<PrefixData>();
            hitTree = new List<PrefixEntry>();
            if (formatCallsign(ref callsign))
            {
                resolveCallsign(callsign);
            }
            IList<DxccEntity> entities = new List<DxccEntity>();
            foreach (PrefixData prefixData in hitList)
            {
                DxccEntity entity = new DxccEntity();
                entity.AdifId = String.IsNullOrEmpty(prefixData.ADIF) ? 0 : Convert.ToInt32(prefixData.ADIF);
                entity.Name = prefixData.Territory;
                entity.Continents = buildContinentList(prefixData.Continent);
                entity.CqZones = buildCqZoneList(prefixData.CQ);
                entity.ItuZones = buildItuZonesList(prefixData.ITU);
                entity.Prefix = prefixData.Prefix;
                entities.Add(entity);
            }
            return entities;
        }
        public DxccEntity Resolve(int adifId)
        {
            string adif = String.Format("{0}{1}", ADIF_MARKER, adifId);
            return Resolve(adif).FirstOrDefault();
        }

        public IList<ContinentDetail> ResolveContinentDetail(string callsign)
        {
            IList<DxccEntity> entities = Resolve(callsign);
            IList<ContinentDetail> details = new List<ContinentDetail>();

            int adif;
            string name;
            foreach (DxccEntity entity in entities)
            {
                adif = entity.AdifId;
                name = entity.Name;
                foreach (string continent in entity.Continents)
                {
                    ContinentDetail detail = new ContinentDetail() { AdifId = adif, Abbreviation = continent, Name = name };
                    details.Add(detail);
                }
            }
            return details;
        }

        public IList<ItuZoneDetail> ResolveItuZoneDetail(string callsign)
        {
            IList<DxccEntity> entities = Resolve(callsign);
            IList<ItuZoneDetail> details = new List<ItuZoneDetail>();

            int adif;
            string name;
            foreach (DxccEntity entity in entities)
            {
                adif = entity.AdifId;
                name = entity.Name;
                foreach (int zone in entity.ItuZones)
                {
                    ItuZoneDetail detail = new ItuZoneDetail() { AdifId = adif, ZoneNumber = zone, Name = name };
                    details.Add(detail);
                }
            }
            return details;
        }

        public IList<CqZoneDetail> ResolveCqZoneDetail(string callsign)
        {
            IList<DxccEntity> entities = Resolve(callsign);
            IList<CqZoneDetail> details = new List<CqZoneDetail>();

            int adif;
            string name;
            foreach (DxccEntity entity in entities)
            {
                adif = entity.AdifId;
                name = entity.Name;
                foreach (int zone in entity.CqZones)
                {
                    CqZoneDetail detail = new CqZoneDetail() { AdifId = adif, ZoneNumber = zone, Name = name };
                    details.Add(detail);
                }
            }
            return details;
        }

        private List<int> buildItuZonesList(string zones)
        {
            return getZoneIds(zones);
        }

        private List<int> buildCqZoneList(string zones)
        {
            return getZoneIds(zones);
        }


        private List<int> getZoneIds(string zones)
        {
            List<int> ids = new List<int>();
            // 16-19;23
            // first split byte semi-colon
            string[] parts = zones.Split(';');
            foreach (string part in parts)
            {
                if (part.Contains('-'))
                {
                    string[] hilo = part.Split('-');
                    int lo = Convert.ToInt32(hilo[0]);
                    int hi = Convert.ToInt32(hilo[1]);
                    for (int i = lo; i <= hi; i++)
                    {
                        ids.Add(i);
                    }
                }
                else
                {
                    ids.Add(Convert.ToInt32(part));
                }
            }
            return ids;
        }
        private List<string> buildContinentList(string continents)
        {
            // EU;AF
            List<string> continentList = new List<string>();
            string[] parts = continents.Split(';');
            foreach (string part in parts)
                continentList.Add(part);
            return continentList;
        }

        internal bool IsValidCall(string callsign)
        {
            bool result;
            int adif;
            if (Int32.TryParse(callsign, out adif))
            {
                result = false;
            }
            else
            {
                result = formatCallsign(ref callsign);
            }
            return result;
        }

        internal List<string> GetAdifList()
        {
            List<string> result = new List<string>();
            foreach (PrefixEntry entry in prefixList.Entries)
            {
                if (entry.Kind.Equals(PrefixKind.DXCC))
                {
                    string line = String.Format("{0}{1}\t{2}",
                        entry.Data.ADIF.ToString().PadLeft(4, ' ').PadRight(6, ' '),
                        entry.Data.Prefix.PadLeft(5, ' ').PadRight(7, ' '),
                        entry.Data.Territory);
                    result.Add(line);
                }
            }
            return result;
        }

        internal List<PrefixData> GetAdminItem(int adif, string admin)
        {
            List<PrefixData> result = new List<PrefixData>();
            foreach (PrefixEntry entry in prefixList.Entries)
            {
                if (entry.Kind.Equals(PrefixKind.City) || entry.Kind.Equals(PrefixKind.Province))
                {
                    if (entry.Data.ProvinceCode.Equals(admin))
                    {
                        int parent = entry.Parent;
                        while (parent > -1)
                        {
                            ////get missing fields from the parent
                            if (String.IsNullOrEmpty(entry.Data.ADIF)) { entry.Data.ADIF = prefixList.Entries[parent].Data.ADIF; }
                            if (String.IsNullOrEmpty(entry.Data.CQ)) { entry.Data.CQ = prefixList.Entries[parent].Data.CQ; }
                            if (String.IsNullOrEmpty(entry.Data.ITU)) { entry.Data.ITU = prefixList.Entries[parent].Data.ITU; }
                            if (String.IsNullOrEmpty(entry.Data.Continent)) { entry.Data.Continent = prefixList.Entries[parent].Data.Continent; }
                            if (String.IsNullOrEmpty(entry.Data.TZ)) { entry.Data.TZ = prefixList.Entries[parent].Data.TZ; }
                            if (String.IsNullOrEmpty(entry.Data.Province)) { entry.Data.Province = prefixList.Entries[parent].Data.Province; }
                            if (String.IsNullOrEmpty(entry.Data.ProvinceCode)) { entry.Data.ProvinceCode = prefixList.Entries[parent].Data.ProvinceCode; }
                            if (String.IsNullOrEmpty(entry.Data.City)) { entry.Data.City = prefixList.Entries[parent].Data.City; }
                            if (String.IsNullOrEmpty(entry.Data.Territory)) { entry.Data.Territory = prefixList.Entries[parent].Data.Territory; }

                            ////if parent is pfDxcc, done
                            int parentAdif;
                            if (Int32.TryParse(entry.Data.ADIF, out parentAdif))
                            {
                                if (entry.Kind.Equals(PrefixKind.DXCC) && parentAdif.Equals(adif))
                                {
                                    result.Add(entry.Data);
                                }
                            }
                            ////upper parent
                            parent = entry.Parent;
                        }
                    }
                }
            }
            return result;
        }

        #region private methods
        private void loadCallList(string callFileName)
        {
            using (StreamReader sr = new StreamReader(callFileName))
            {
                String line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2 && !callList.ContainsKey(parts[0]))
                    {
                        callList.Add(parts[0], parts[1]);
                    }
                }
            }
        }

        private bool formatCallsign(ref string callsign)
        {
            string call = callsign.Trim().ToUpper().Replace(" ", "");
            //see if mapping available
            if (callIsMapped(ref call))
            {
                callsign = call;
                return true;
            }
            // /MM does not count for DXCC
            if (call.EndsWith("/MM")) { return false; }
            // /ANT is Antarctica
            if (call.EndsWith("/ANT"))
            {
                callsign = "ADIF013";
                return true;
            }
            //check length and '/'
            if (call.Length < 2 || call[0].Equals('/')) { return false; }
            if (call.Contains("//")) { return false; }
            if (call.EndsWith("/")) { call = call.Substring(0, call.Length - 1); }
            foreach (char ch in call)
            {
                if (!AllowedChars.Contains(ch)) { return false; }
            }
            //split call at '/' into S1, S2, S3
            string[] callParts = call.Split('/');
            //remove endings
            call = String.Empty;
            // here rebuild call 
            for (int i = callParts.Length - 1; i >= 0; i--)
            {
                string potentialEnding = String.Format(":{0}:", callParts[i]);
                if (EndingIgnore.Contains(potentialEnding))
                {
                    callParts[i] = String.Empty;
                }
                else
                {
                    call = String.Format("{0}/{1}", callParts[i], call);
                }
            }
            // resplit and check array size
            callParts = call.Split('/');
            if (callParts.Length < 1 || callParts.Length > 3)
            {
                return false;
            }

            string s1 = callParts[0];
            string s2 = (callParts.Length > 1) ? callParts[1] : String.Empty;
            string s3 = (callParts.Length > 2) ? callParts[2] : String.Empty;
            // verify
            if (s3.Length > 1) { return false; }
            // exceptions
            if ((s1.StartsWith("HK") && s2.Equals("0M")) || (s1.StartsWith("FR") && s2.Equals("G")))
            {
                //because 0M is invalid prefix
                //because G is 1-char prefix
                callsign = String.Format("{0}/{1}", s1, s2);
                return true;
            }

            // call area digit
            if (s2.Length.Equals(1) && AfreetConstants.Digits.Contains(s2))
            {
                //cannot have 2 digital endings, e.g. J49AA/5/9
                if (!String.IsNullOrEmpty(s3) && AfreetConstants.Digits.Contains(s3[0])) { return false; }
                //1-char prefix: I4AA/5 (only for Italy and USA)
                //U,{R},B,G,M,F - digit is not a call area, or call area sub-divisions exist
                if (s1.Length > 1 && AfreetConstants.Digits.Contains(s1[1]) && UsItalyPrefixes.Contains(s1[0]))
                {
                    s1 = s1[0].ToString();
                }
                //2-char prefix: J49AA/5,3A2AA/5, UA3AA/5
                else if (s1.Length > 2 && AfreetConstants.Digits.Contains(s1[2]))
                {
                    s1 = s1.Substring(0, 2);
                }
                //3-char prefix: 3DA0AA/5
                else if (s1.Length > 3 && AfreetConstants.Digits.Contains(s1[3]))
                {
                    s1 = s1.Substring(0, 3);
                }
                //no call area digit to replace
                else { return false; }
                // replace call area
                s1 += s2;
                s2 = String.Empty;
            }
            //WPX rule for 1-char prefixes
            if (s1.Length.Equals(1) && OneCharPrefixes.Contains(s1[0]))
            {
                s1 += "0";
            }
            else if (s2.Length.Equals(1) && s3.Length.Equals(1) && OneCharPrefixes.Contains(s1[0]))
            {
                s2 += "0";
            }
            //1 char prefixes that do not conflict with endings /P, /B, /R, /M
            else if (s2.Length.Equals(1) && SafeOneCharPrefixes.Contains(s2[0]))
            {
                s2 += "0";
            }
            // find body
            string body = (s2.Length > 1 && s2.Length < s1.Length) ? body = s2 : body = s1;
            if (body.Length < 2) { return false; }
            // find ending
            string ending;
            if (s2.Length.Equals(1))
            {
                if (!String.IsNullOrEmpty(s3))
                {
                    return false;
                }
                else
                {
                    ending = s2;
                }
            }
            else
            {
                ending = s3;
            }
            // merge body and ending
            callsign = !String.IsNullOrEmpty(ending) ? String.Format("{0}/{1}", body, ending) : body;

            return true;
        }

        private bool callIsMapped(ref string call)
        {
            string callListValue;
            if (callList.ContainsKey(call))
            {
                if (callList.TryGetValue(call, out callListValue))
                {
                    call = callListValue;
                    int adif;
                    if (Int32.TryParse(callListValue, out adif))
                    {
                        call = String.Format("{0}{1}", ADIF_MARKER, adif);
                    }
                    return true;
                }
            }
            return false;
        }

        private void resolveCallsign(string callsign)
        {
            if (callsign.StartsWith(ADIF_MARKER))
            {
                int adif = Convert.ToInt32(callsign.Substring(ADIF_MARKER.Length));
                if (adif > 0)
                {
                    PrefixData prefixData = getAdifItem(adif);
                    if (prefixData != null)
                    {
                        hitList.Add(prefixData);
                    }
                }
            }
            else
            {
                int x = AfreetConstants.Chars.IndexOf(callsign[0]);
                int y = AfreetConstants.Chars.IndexOf(callsign[1]);
                List<PrefixEntry> arr = prefixList.Index[x, y];

                for (int i = 0; i < arr.Count; i++)
                {
                    try
                    {
                        if (tryMask(arr[i], true, callsign))
                        {
                            PrefixEntry hitEntry = addHit(arr[i], -1);
                            addSubHits(arr[i], hitEntry.Id, callsign);
                        }
                    }
                    catch
                    {

                    }
                }
                packHits();
            }

            // order hist list by prefix
            hitList = hitList.OrderBy(e => e.Prefix).ToList<PrefixData>();
        }

        private void packHits()
        {
            for (int i = hitTree.Count - 1; i >= 0; i--)
            {
                if (hitTree[i].Data.Location.X == Int32.MaxValue)
                {
                    ////mark as used
                    hitTree[i].Id = -1;
                    if (hitTree[i].Parent >= 0)
                    {
                        ////add attribute to parent
                        hitTree[hitTree[i].Parent].Data.Attributes.Add(hitTree[i].Data.Territory);
                    }
                    //end;
                }
            }
            ////add to output
            for (int i = hitTree.Count - 1; i >= 0; i--)
            {
                if (hitTree[i].Id > -1)
                {

                    PrefixData hit = new PrefixData();
                    hit.Location.X = Int32.MaxValue;
                    hit.Location.Y = Int32.MaxValue;
                    hit = mergePrefixData(hit, hitTree[i]);
                    hitList.Add(hit);
                }
            }
            hitTree = null;
        }

        private PrefixData mergePrefixData(PrefixData destination, PrefixEntry source)
        {
            source.Id = -1;
            switch (source.Kind)
            {
                case PrefixKind.DXCC:
                    {
                        destination.Territory = source.Data.Territory;
                        break;
                    }
                case PrefixKind.Province:
                    {
                        destination.Province = (String.IsNullOrEmpty(destination.Province)) ?
                            source.Data.Territory :
                            String.Format("{0}, {1}", source.Data.Territory, destination.Province);
                        break;
                    }
                case PrefixKind.City:
                    {
                        destination.City = source.Data.Territory;
                        break;
                    }
                case PrefixKind.Station:
                    {
                        if (source.Data.Location.X != Int32.MaxValue)
                        {
                            destination.City = source.Data.Territory;
                        }
                        break;
                    }
            }
            ////set location if it was not set by the child
            if (destination.Location.X == Int32.MaxValue) { destination.Location = source.Data.Location; }
            ////copy fields from Src to Dst
            if (source.Data.Location.X != Int32.MaxValue)
            {
                if (String.IsNullOrEmpty(destination.Prefix)) { destination.Prefix = source.Data.Prefix; }
                if (String.IsNullOrEmpty(destination.CQ)) { destination.CQ = source.Data.CQ; }
                if (String.IsNullOrEmpty(destination.ITU)) { destination.ITU = source.Data.ITU; }
                if (String.IsNullOrEmpty(destination.Continent)) { destination.Continent = source.Data.Continent; }
                if (String.IsNullOrEmpty(destination.TZ)) { destination.TZ = source.Data.TZ; }
                if (String.IsNullOrEmpty(destination.ADIF)) { destination.ADIF = source.Data.ADIF; }
                if (String.IsNullOrEmpty(destination.ProvinceCode)) { destination.ProvinceCode = source.Data.ProvinceCode; }
            }
            ////copy attributes
            destination.Attributes.AddRange(source.Data.Attributes);
            ////add missing data from Src's parents
            if (source.Parent > -1) { mergePrefixData(destination, hitTree[source.Parent]); }
            return destination;
        }

        private void addSubHits(PrefixEntry prefixEntry, int parentId, string callsign)
        {

            for (int i = 0; i < prefixEntry.Children.Count; i++)
            {
                PrefixEntry child = prefixList.Entries[prefixEntry.Children[i]];
                if (tryMask(child, false, callsign))
                {
                    PrefixEntry hit = addHit(child, parentId);
                    addSubHits(child, parentId, callsign);
                }
            }
        }

        private PrefixEntry addHit(PrefixEntry prefixEntry, int parentId)
        {
            PrefixEntry hitEntry = new PrefixEntry();
            hitEntry.Data = prefixEntry.Data;
            hitEntry.Kind = prefixEntry.Kind;
            ////ordinal number of the hit
            hitEntry.Id = hitTree.Count;
            ////remember your parent
            hitEntry.Parent = parentId;
            hitTree.Add(hitEntry);
            ////tell the parent about its child
            if (parentId > 0)
            {
                PrefixEntry parent = hitTree[parentId];
                parent.Children.Add(hitEntry.Id);
            }
            return hitEntry;
        }

        private int[] usPossesions = new int[] { 166, 103, 123, 174, 97, 134, 138, 9, 297, 105, 182, 285, 43, 6, 110 };
        private bool tryMask(PrefixEntry entry, bool topLevel, string callsign)
        {
            bool result = false;
            if (usPossesions.Contains(Convert.ToInt32(entry.Data.ADIF)) & topLevel == true)
            {
                result = true;
            }
            //check entry kind
            else if (topLevel)
            {
                if (!AllowedForTop.Contains(entry.Kind)) { return result; }
            }
            else
            {
                if (!AllowedForSub.Contains(entry.Kind)) { return result; }
            }
            // mobile, portable, beacon, rover
            if (callsign.EndsWith("/M") || callsign.EndsWith("/P") || callsign.EndsWith("/B") || callsign.EndsWith("/R"))
            {
                callsign = callsign.Substring(0, callsign.Length - 2);
            }
            string[] maskParts = entry.Mask.Split(',');
            for (int i = 0; i < maskParts.Length; i++)
            {
                PrefixMatch prefixMatch = comparePrefix(maskParts[i], callsign);
                EndingMatch endingMatch = compareEnding(maskParts[i], callsign);
                if (topLevel)
                {
                    result = ResultForTop[(int)prefixMatch, (int)endingMatch];
                }
                else
                {
                    result = ResultForChild[(int)prefixMatch, (int)endingMatch];
                }
                if (result)
                {
                    break;
                }
            }
            return result;
        }

        private EndingMatch compareEnding(string mask, string callsign)
        {
            int callPos = callsign.IndexOf('/');
            int maskPos = mask.IndexOf('/');
            EndingMatch result;
            ////in mask only
            if (callPos < 0 && maskPos >= 0)
            {
                result = EndingMatch.edM;
            }
            ////in prefix only
            else if (callPos >= 0 && maskPos < 0)
            {
                //ignore common endings - mobile,portable,rover,beacon
                if (callPos.Equals(callsign.Length - 1) && (new ArrayList(new char[] { 'M', 'P', 'R', 'B' }).Contains(callsign[callPos + 1])))
                {
                    result = EndingMatch.edEQ;
                }
                else
                {
                    result = EndingMatch.edP;
                }
            }
            ////none
            else if (callPos < 0 && maskPos < 0)
            {
                result = EndingMatch.edEQ;
            }
            ////both
            else if (callsign.Substring(callPos).Equals(mask.Substring(maskPos)))
            {
                result = EndingMatch.edEQ;
            }
            else
            {
                result = EndingMatch.edNE;
            }

            return result;
        }

        private PrefixMatch comparePrefix(string mask, string callsign)
        {
            int posCall = callsign.IndexOf('/');
            int posMask = mask.IndexOf('/');
            if (posCall > 0)
            {
                callsign = callsign.Substring(0, posCall - 1);
            }
            if (posMask > 0)
            {
                mask = mask.Substring(0, posMask - 1);
            }
            if (String.IsNullOrEmpty(mask) || String.IsNullOrEmpty(callsign))
            {
                return PrefixMatch.pfNE;
            }

            for (int i = 0; i < callsign.Length; i++)
            {
                ////end of mask
                if (String.IsNullOrEmpty(mask))
                {
                    return PrefixMatch.pfGE;
                }
                ////non-matching char
                string chopResult = prefixList.Chop(ref mask);
                if (!chopResult.Contains(callsign[i]))
                {
                    return PrefixMatch.pfNE;
                }
            }

            if (String.IsNullOrEmpty(mask) || mask.Equals("."))
            {
                return PrefixMatch.pfGE;
            }

            ////if ".", require exact length or just prefix with no suffix
            char lastCallChar = callsign[callsign.Length - 1];
            char lastMaskChar = mask[mask.Length - 1];
            if (lastMaskChar.Equals('.') && !AfreetConstants.Digits.Contains(lastCallChar))
            {
                return PrefixMatch.pfNE;
            }
            return PrefixMatch.pfLT;
        }

        private PrefixData getAdifItem(int adif)
        {
            PrefixData result = null;
            for (int i = 0; i < prefixList.Entries.Count; i++)
            {
                if (prefixList.Entries[i].Kind.Equals(PrefixKind.DXCC) && prefixList.Entries[i].Data.ADIF.Equals(adif.ToString()))
                {
                    result = prefixList.Entries[i].Data;
                    break;
                }
            }
            return result;
        }
        #endregion
    }
}