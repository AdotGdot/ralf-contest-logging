using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.Interfaces
{
    public interface ILogService
    {
        void AddQso(Qso qso);
        IList<Qso> GetDupes(string partialCallsign);
        IList<Qso> GetDupes(string partialCallsign, Band band);
        IList<Qso> GetDupes(string partialCallsign, Mode mode);
        IList<Qso> GetDupes(string partialCallsign, Band band, Mode mode);
        IList<Qso> GetLog();
        IList<Qso> GetLog(Band band);
        IList<Qso> GetLog(Mode mode);
        IList<Qso> GetLog(Band band, Mode mode);
        IList<Qso> GetLog(int index, int count);
        IList<Qso> GetLog(Band band, int index, int count);
        IList<Qso> GetLog(Mode mode, int index, int count);
        IList<Qso> GetLog(Band band, Mode mode, int index, int count);
        Qso GetQsoBy(Guid id);
        bool IsDupe(string callsign);
        bool IsDupe(string callsign, Band band);
        bool IsDupe(string callsign, Mode mode);
        //int getQsoCount(object oneSixty);
        int getQsoCount(Band band);
        bool IsDupe(string callsign, Band band, Mode mode);
        int QsoCount { get; }
        void Remove(Qso qso);
        void UpdateQso(Qso qso);
    }
}
