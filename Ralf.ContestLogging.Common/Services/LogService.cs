using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ralf.ContestLogging.Common.Services
{
    public class LogService : ILogService
    {
        private ILogRepository repository;

        public LogService(ILogRepository repository)
        {
            this.repository = repository;
        }

        public int getQsoCount(Band band)
        {
            return repository.FindAll().Where(q => q.Band == band).Count();
        }
        public void AddQso(Qso qso)
        {
            repository.Add(qso);
        }

        public void UpdateQso(Qso qso)
        {
            repository.Update(qso);
        }

        public void Remove(Qso qso)
        {
            repository.Remove(qso);
        }

        public Qso GetQsoBy(Guid id)
        {
            return repository.FindBy(id);
        }

        public bool IsDupe(string callsign)
        {
            return repository.FindAll().Where(q => q.Callsign.Equals(callsign)).Count() != 0;
        }

        public bool IsDupe(string callsign, Band band)
        {
            return repository.FindAll().Where(q => q.Callsign.Equals(callsign) && q.Band == band).Count() != 0;
        }

        public bool IsDupe(string callsign, Mode mode)
        {
            return repository.FindAll().Where(q => q.Callsign.Equals(callsign) && q.Mode == mode).Count() != 0;
        }
        public bool IsDupe(string callsign, Band band, Mode mode)
        {
            return repository.FindAll().Where(q => q.Callsign.Equals(callsign) && q.Mode == mode && q.Band == band).Count() != 0;
        }
        public IList<Qso> GetDupes(string partialCallsign)
        {
            return repository.FindAll().Where(q => q.Callsign.StartsWith(partialCallsign)).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetDupes(string partialCallsign, Band band)
        {
            return repository.FindAll().Where(q => q.Callsign.StartsWith(partialCallsign) && q.Band == band).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetDupes(string partialCallsign, Mode mode)
        {
            return repository.FindAll().Where(q => q.Callsign.StartsWith(partialCallsign) && q.Mode == mode).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetDupes(string partialCallsign, Band band, Mode mode)
        {
            return repository.FindAll().Where(q => q.Callsign.StartsWith(partialCallsign) && q.Band == band && q.Mode == mode).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetLog()
        {
            return repository.FindAll().OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetLog(Band band)
        {
            return repository.FindAll().Where(q => q.Band == band).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetLog(Mode mode)
        {
            return repository.FindAll().Where(q => q.Mode == mode).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetLog(Band band, Mode mode)
        {
            return repository.FindAll().Where(q => q.Band == band && q.Mode == mode).OrderByDescending(qso => qso.DateTime).ToList<Qso>();
        }

        public IList<Qso> GetLog(int index, int count)
        {
            return repository.FindAll().OrderByDescending(qso => qso.DateTime).Skip(index).Take(count).ToList<Qso>();
        }

        public IList<Qso> GetLog(Band band, int index, int count)
        {
            return repository.FindAll().Where(q => q.Band == band).OrderByDescending(qso => qso.DateTime).Skip(index).Take(count).ToList<Qso>();
        }

        public IList<Qso> GetLog(Mode mode, int index, int count)
        {
            return repository.FindAll().Where(q => q.Mode == mode).OrderByDescending(qso => qso.DateTime).Skip(index).Take(count).ToList<Qso>();
        }

        public IList<Qso> GetLog(Band band, Mode mode, int index, int count)
        {
            return repository.FindAll().Where(q => q.Band == band && q.Mode == mode).OrderByDescending(qso => qso.DateTime).Skip(index).Take(count).ToList<Qso>();
        }

        public int QsoCount { get { return repository.FindAll().Count(); } }
    }
}