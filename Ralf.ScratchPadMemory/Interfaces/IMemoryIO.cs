using Ralf.ScratchPadMemory.Types;

namespace Ralf.ScratchPadMemory.Interfaces
{
    public interface IMemoryIO
    {
        MemoryList GetMemoryList();
        void SetMemoryList(MemoryList memories);
    }
}
