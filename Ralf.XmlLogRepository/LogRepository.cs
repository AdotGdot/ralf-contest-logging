using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;

namespace Ralf.XmlLogRepository
{
    public class LogRepository : ILogRepository
    {
        private static Mutex mutex = new Mutex();
        private List<Qso> qsos;
        private string pathAndFileName;
        private int backupDepth = -1;

        public LogRepository(string pathAndFileName) : this(pathAndFileName, 2) { }
        public LogRepository(string pathAndFileName, int backupDepth)
        {
            this.pathAndFileName = pathAndFileName;
            this.backupDepth = backupDepth;
            loadLog();
        }

        #region
        private void loadLog()
        {
            if (File.Exists(pathAndFileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Qso>));
                TextReader r = new StreamReader(pathAndFileName);
                qsos = (List<Qso>)s.Deserialize(r);
                r.Close();
            }
            else
            {
                qsos = new List<Qso>();
                saveLog();
            }
        }

        private void saveLog()
        {
            saveBackup();
            XmlSerializer s = new XmlSerializer(typeof(List<Qso>));
            TextWriter w = new StreamWriter(pathAndFileName);
            s.Serialize(w, qsos);
            w.Close();
            loadLog();
        }

        private void saveBackup()
        {
            string path = String.Format("{0}\\bak", Path.GetDirectoryName(pathAndFileName));
            string fileName = Path.GetFileNameWithoutExtension(pathAndFileName);
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            enforceBackupDepth();
            DateTime now = DateTime.UtcNow;
            path = String.Format("{0}\\{1}_{2}_{3}_{4}_{5}_{6}_{7}.xml", path, now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, fileName);

            XmlSerializer s = new XmlSerializer(typeof(List<Qso>));
            TextWriter w = new StreamWriter(path);
            s.Serialize(w, qsos);
            w.Close();
        }

        private void enforceBackupDepth()
        {
            if (backupDepth > 0)
            {
                string path = String.Format("{0}\\bak", Path.GetDirectoryName(pathAndFileName));
                DirectoryInfo folder = new DirectoryInfo(path);

                IOrderedEnumerable<FileInfo> files = folder.GetFiles().OrderByDescending(f => f.LastWriteTimeUtc);

                for (int i = files.Count() - 1; i >= backupDepth; i--)
                {
                    FileInfo fi = files.ElementAt(i);
                    File.Delete(fi.FullName);
                }
            }
        }
        #endregion

        public void Add(Qso qso)
        {
            mutex.WaitOne();
            try
            {
                qsos.Add(qso);
                saveLog();
            }
            catch
            {
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public IEnumerable<Qso> FindAll()
        {
            IList<Qso> result;
            mutex.WaitOne();
            try
            {
                result = qsos.ToArray<Qso>().ToList<Qso>();
            }
            catch
            {
                result = new List<Qso>();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            return result;
        }

        public Qso FindBy(Guid guid)
        {
            Qso result;
            mutex.WaitOne();
            try
            {
                result = qsos.Where(q => q.Id == guid).OrderByDescending(qso => qso.DateTime).First<Qso>() as Qso;
            }
            catch
            {
                result = null;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
            return result;
        }

        public void Remove(Qso qso)
        {
            mutex.WaitOne();
            try
            {
                int i = qsos.FindIndex(x => x.Id == qso.Id);
                qsos.RemoveAt(i);
                saveLog();
            }
            catch
            {
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public void Update(Qso qso)
        {
            mutex.WaitOne();
            try
            {
                int i = qsos.FindIndex(x => x.Id == qso.Id);
                qsos.RemoveAt(i);
                qsos.Insert(i, qso);
                saveLog();
            }
            catch
            {
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}