using Ralf.DxResolutionRepository.Afreet.Constants;
using Ralf.DxResolutionRepository.Afreet.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ralf.DxResolutionRepository.Afreet.Types
{
    internal class PrefixEntryArray : List<PrefixEntry> { }

    internal class PrefixList
    {
        public int HiChar = AfreetConstants.Chars.Length;
        private string prefixFileName;
        internal List<PrefixEntry> Entries = new List<PrefixEntry>();
        internal PrefixEntryArray[,] Index;

        public PrefixList(string prefixFileName)
        {
            this.prefixFileName = prefixFileName;
            List<string> lines = loadFromFile();
            loadFromStrings(lines);
            buildIndex();
        }

        private void buildIndex()
        {
            // build Index
            Index = new PrefixEntryArray[HiChar, HiChar];
            for (int x = 0; x < HiChar; x++)
            {
                for (int y = 0; y < HiChar; y++)
                {
                    Index[x, y] = new PrefixEntryArray();
                }
            }
            // iterate through DXCC entries
            for (int PrefixNo = 0; PrefixNo < Entries.Count; PrefixNo++)
            {
                if (!(new ArrayList(new PrefixKind[] { PrefixKind.DXCC, PrefixKind.NonDXCC }).Contains(Entries[PrefixNo].Kind)))
                {
                    continue;
                }
                // iterate through masks of the entry                
                string[] MaskList = Entries[PrefixNo].Mask.Split(',');

                for (int MaskNo = 0; MaskNo < MaskList.Count(); MaskNo++)
                {
                    // expand mask
                    string Mask = MaskList[MaskNo];
                    string L1 = Chop(ref Mask);
                    string L2;
                    if (Mask == "")
                    {
                        L2 = AfreetConstants.Chars;
                    }
                    else
                    {
                        L2 = Chop(ref Mask);
                    }
                    // add to index
                    for (int p1 = 0; p1 < L1.Length; p1++)
                    {
                        for (int p2 = 0; p2 < L2.Length; p2++)
                        {
                            AddToIndex(L1[p1], L2[p2], Entries[PrefixNo]);
                        }
                    }
                }
            }
        }

        // expand the 1-st symbol of the mask
        public string Chop(ref string str)
        {
            string s = str;
            string result;
            switch (str[0])
            {
                case '#':
                    result = AfreetConstants.Digits;
                    break;
                case '@':
                    result = AfreetConstants.Letters;
                    break;
                case '?':
                    result = AfreetConstants.Chars;
                    break;
                case '[':
                    // extract [..]
                    int closeBracketPosition = str.IndexOf(']');
                    result = str.Substring(2 - 1, closeBracketPosition - 1);
                    str = str.Remove(1, closeBracketPosition);
                    // expand ranges
                    int dashIndex;
                    while ((dashIndex = result.IndexOf('-')) != -1)
                    {
                        char before = result[dashIndex - 1];
                        char after = result[dashIndex + 1];
                        result = result.Remove(dashIndex, 1);
                        int b = (int)before;
                        int a = (int)after;
                        string addition = String.Empty;
                        for (int ch = b + 1; ch < a; ch++)
                        {
                            addition += (char)ch;
                        }
                        result = result.Insert(dashIndex, addition);
                    }
                    break;
                default:
                    result = str[0].ToString();
                    break;
            }
            str = str.Substring(1);

            return result;
        }

        private void AddToIndex(char char1, char char2, PrefixEntry entry)
        {
            int p1 = AfreetConstants.Chars.IndexOf(char1);
            int p2 = AfreetConstants.Chars.IndexOf(char2);
            p1 = p1 >= 0 ? p1 : 0;
            p2 = p2 >= 0 ? p2 : 0;

            int Len = Index[p1, p2].Count;
            // no dupes
            for (int i = 0; i < Len; i++)
            {
                if (Index[p1, p2][i] == entry)
                {
                    return;
                }
            }
            // add
            Index[p1, p2].Add(entry);
        }

        private void loadFromStrings(List<string> lines)
        {

            for (int line = 0; line < lines.Count; line++)
            {
                if (!lines[line].StartsWith("#"))
                {
                    string[] parts = lines[line].Split('|');
                    List<string> tokens = new List<string>();
                    tokens.AddRange(parts);
                    if (tokens.Count < 4)
                    {
                        continue;
                    }
                    if (tokens[0].Length > 0 && (tokens[0].StartsWith("L") || tokens[0].StartsWith("M") || tokens[0].StartsWith("-")))
                    {
                        tokens[0] = tokens[0].Substring(1);
                    }
                    PrefixKind entryKind = (PrefixKind)Convert.ToInt32(tokens[0].Substring(0, 2));
                    if (!entryKind.Equals(PrefixKind.DXCC))
                    {
                        continue;
                    }
                    // populate new entry
                    PrefixEntry entry = new PrefixEntry();

                    entry.Id = Entries.Count;
                    entry.Kind = entryKind;
                    // level
                    string level = tokens[0].Substring(2);
                    entry.Level = String.IsNullOrEmpty(level) ? 0 : Convert.ToInt32(level);
                    // location
                    entry.Data.Location.X = String.IsNullOrEmpty(tokens[1]) ? 0 : Convert.ToInt32(tokens[1]);
                    entry.Data.Location.Y = String.IsNullOrEmpty(tokens[2]) ? 0 : Convert.ToInt32(tokens[2]);
                    // rest
                    entry.Data.Territory = tokens[3];
                    entry.Data.Prefix = tokens[4];
                    entry.Data.CQ = tokens[5];
                    entry.Data.ITU = tokens[6];
                    entry.Data.Continent = tokens[7];
                    entry.Data.TZ = tokens[8];
                    entry.Data.ADIF = tokens[9];
                    entry.Data.ProvinceCode = tokens[10];
                    entry.Mask = tokens[13];
                    Entries.Add(entry);
                }
            }
        }

        private List<string> loadFromFile()
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(prefixFileName))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}