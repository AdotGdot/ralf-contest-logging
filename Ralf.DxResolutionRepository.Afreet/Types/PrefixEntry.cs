using Ralf.DxResolutionRepository.Afreet.Enums;
using System.Collections.Generic;

namespace Ralf.DxResolutionRepository.Afreet.Types
{
    internal class PrefixEntry
    {
        public PrefixData Data = new PrefixData();
        public int Id;
        public PrefixKind Kind;
        public int Level;
        public string Mask;
        public int Parent;
        public List<int> Children = new List<int>();
    }
}
