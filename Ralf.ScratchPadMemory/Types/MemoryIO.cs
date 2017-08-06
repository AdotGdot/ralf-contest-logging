using Ralf.ScratchPadMemory.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace Ralf.ScratchPadMemory.Types
{
    public class MemoryIO: IMemoryIO
    {
        private string pathAndFileName;
        public MemoryIO(string pathAndFileName)
        {
            this.pathAndFileName = pathAndFileName;
        }

        public MemoryList GetMemoryList()
        {
            return getMemoryList();
        }

        private MemoryList getMemoryList()
        {
            MemoryList memories;
            if (File.Exists(pathAndFileName))
            {
                using (TextReader r = new StreamReader(pathAndFileName))
                {
                    try
                    {
                        XmlSerializer s = new XmlSerializer(typeof(MemoryList));
                        memories = (MemoryList)s.Deserialize(r);
                    }
                    finally
                    {
                        r.Close();
                    }
                }
            }
            else
            {
                memories = new MemoryList();
                setMemoryList(memories);
            }
            return memories;
        }

        private void setMemoryList(MemoryList memories)
        {
            using (TextWriter w = new StreamWriter(pathAndFileName))
            {
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(MemoryList));
                    s.Serialize(w, memories);
                }
                finally
                {
                    w.Close();
                }
            }
        }

        public void SetMemoryList(MemoryList memories)
        {
            setMemoryList(memories);
        }
    }
}
