using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface ILogRepository
    {
        void Add(Qso qso);
        void Update(Qso qso);
        void Remove(Qso qso);
        Qso FindBy(Guid guid);
        IEnumerable<Qso> FindAll();
    }
}
