using Prism.Commands;
using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public abstract class QsoDetailViewModel : BaseViewModel, IQsoDetailViewModel
    {
        protected IDupeBehaviorsService dupeBehaviors;
        protected Band[] contestBands = new Band[] { };
        protected Mode[] contestModes = new Mode[] { };
        protected string adif;
        protected string geographicArea;
        protected string continent;
        protected string stationPower;
        protected Visibility keyerVisibility;
        protected Window window;
        protected string contestName;
        protected Qso qso = new Qso();
        protected QsoType qsoType;
        private ILogWebService webService;
        protected string transmitter;
        protected string receiver;
        public DelegateCommand<object> EntryCompleted_Command { get; set; }
        public DelegateCommand<object> EntryCanceled_Command { get; set; }
        public QsoDetailViewModel(
            ILogService service,
            IDupeBehaviorsService dupeBehaviors,
            ILogWebService webService,
            string adif,
            string geographicArea,
            string continent,
            string stationPower,
            string modes,
            string bands,
            string transmitter,
            string receiver)
            : base(service)
        {
            this.webService = webService;
            qsoType = QsoType.NewQso;
            KeyUp_Command = new DelegateCommand<object>(onKeyUp_Command);
            this.adif = adif;
            this.geographicArea = geographicArea;
            this.continent = continent;
            this.stationPower = stationPower;
            this.dupeBehaviors = dupeBehaviors;
            this.transmitter = transmitter;
            this.receiver = receiver;
            try
            {
                contestName = ConfigurationManager.AppSettings["contestName"];
            }
            catch
            {
                contestName = String.Empty;
            }
            loadContestModes(modes);
            loadContestBands(bands);

            EntryCompleted_Command = new DelegateCommand<object>(on_EntryCompleted_Command);
            EntryCanceled_Command = new DelegateCommand<object>(on_EntryCanceled_Command);

            MessageSink.MessageBus.GetEvent<DataDictionaryResponse>().Subscribe(details => onNewEntryDataDictionaryResponse(details));
            MessageSink.MessageBus.GetEvent<TransceiverStateResponse>().Subscribe(details => onTransceiverStateResponse(details));
            MessageSink.MessageBus.GetEvent<GeographicAreaSelectionNotification>().Subscribe(details => onGeographicAreaSelectionNotification(details));
        }

        private void loadContestBands(string bands)
        {
            List<Band> bandList = new List<Band>();
            string[] bandArray = bands.ToUpper().Split(',');
            if (bandArray.Contains("160"))
            {
                bandList.Add(Band.OneSixty);
            }
            if (bandArray.Contains("80"))
            {
                bandList.Add(Band.Eighty);
            }
            if (bandArray.Contains("40"))
            {
                bandList.Add(Band.Forty);
            }
            if (bandArray.Contains("20"))
            {
                bandList.Add(Band.Twenty);
            }
            if (bandArray.Contains("15"))
            {
                bandList.Add(Band.Fifteen);
            }
            if (bandArray.Contains("10"))
            {
                bandList.Add(Band.Ten);
            }
            if (bandArray.Contains("6"))
            {
                bandList.Add(Band.Six);
            }
            if (bandArray.Contains("222"))
            {
                bandList.Add(Band.TwoTwentyTwo);
            }
            if (bandArray.Contains("2"))
            {
                bandList.Add(Band.Two);
            }
            if (bandArray.Contains("70"))
            {
                bandList.Add(Band.SeventyCm);
            }
            if (bandArray.Contains("33"))
            {
                bandList.Add(Band.ThirtyThreeCm);
            }
            if (bandArray.Contains("23"))
            {
                bandList.Add(Band.TwentyThreeCm);
            }
            if (bandArray.Contains("13"))
            {
                bandList.Add(Band.Over2dot3GHz);
            }
            contestBands = bandList.ToArray<Band>();
        }

        private void loadContestModes(string modes)
        {
            List<Mode> modeList = new List<Mode>();
            string[] modeArray = modes.ToUpper().Split(',');
            if (modeArray.Contains("SSB"))
            {
                modeList.Add(Mode.SSB);
            }
            if (modeArray.Contains("CW"))
            {
                modeList.Add(Mode.CW);
            }
            if (modeArray.Contains("FM"))
            {
                modeList.Add(Mode.FM);
            }
            contestModes = modeList.ToArray<Mode>();
        }

        protected virtual void onGeographicAreaSelectionNotification(object details)
        {
            DxccEntitySelection des = details as DxccEntitySelection;
            if (des != null)
            {
                AdifId = des.AdifId;
                Continent = des.Continent;
                DxccName = des.Name;
                if (des.ItuZone != 0)
                {
                    ItuZone = des.ItuZone;
                }
                if (des.CqZone != 0)
                {
                    CqZone = des.CqZone;
                }
            }
        }

        private void on_EntryCompleted_Command(object obj)
        {
            window = obj as Window;
            if (qsoType == QsoType.NewQso)
            {
                insertQso();
            }
            else
            {
                updateQso();
            }
        }

        private void updateQso()
        {
            string msg;
            if (!qsoIsValid(out msg))
            {
                ErrorMessage = msg;
                ErrorVisibility = Visibility.Visible;
            }
            else
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(updateWorker_DoWorkAsync);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }

        }

        private void updateWorker_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            bool result;
            if (qso.LoggedViaWebService)
            {
                result = webService.Update(qso).Result;
            }
            else
            {
                result = webService.Insert(qso).Result;
            }
            qso.LoggedViaWebService = result;
            service.UpdateQso(qso);
            return;
        }

        private void insertQso()
        {
            string msg;
            if (!qsoIsValid(out msg))
            {
                ErrorMessage = msg;
                ErrorVisibility = Visibility.Visible;
            }
            else
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(insertWorker_DoWork);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageSink.MessageBus.GetEvent<EntryCompleteNotification>().Publish(new object());
            MessageSink.MessageBus.GetEvent<LogChangedNotification>().Publish(new object());
            window.Close();
        }

        private void insertWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool result = webService.Insert(qso).Result;
            qso.LoggedViaWebService = result;
            service.AddQso(qso);
        }

        protected void on_EntryCanceled_Command(object obj)
        {
            window = obj as Window;
            window.Close();
            qso = new Qso();
            MessageSink.MessageBus.GetEvent<EntryCompleteNotification>().Publish(new object());
        }

        public DelegateCommand<object> KeyUp_Command { get; set; }

        #region new
        private void onTransceiverStateResponse(TransceiverState details)
        {
            Frequency = details.Frequency;
            Mode = details.Mode.ToMode();
            onKeyUp_Command(Callsign);
            KeyerVisibility = Mode == Mode.CW ? Visibility.Visible : Visibility.Collapsed;
        }

        protected virtual void onNewEntryNotification()
        {
            qsoType = QsoType.NewQso;
            notifyAllPropertiesChanged();
            NotifyPropertyChanged("text");
            qso = new Qso();
            DateTime = DateTime.UtcNow;
            qso.Transmitter = transmitter;
            qso.Receiver = receiver;
            // check dupe view for callsign
            MessageSink.MessageBus.GetEvent<DataDictionaryRequest>().Publish(new object());
            // get rig state
            MessageSink.MessageBus.GetEvent<TransceiverStateRequest>().Publish(new object());
            //
            ErrorMessage = String.Empty;
            notifyAllPropertiesChanged();
            onKeyUp_Command(Callsign);

        }

        protected virtual void onNewEntryDataDictionaryResponse(DataDictionary details)
        {
            string callsign;
            if (details.TryGetValue("Callsign", out callsign))
            {
                Callsign = callsign.ToString();
            }
            onKeyUp_Command(Callsign);
        }

        #endregion
        public void SetQsoId(Guid qsoId)
        {
            if (qsoId == Guid.Empty)
            {
                onNewEntryNotification();
            }
            else
            {
                onEditEntryNotification(qsoId);
            }
        }
        #region edit

        protected virtual void onEditEntryNotification(Guid details)
        {
            qsoType = QsoType.ExistingQso;
            NotifyPropertyChanged("text");
            qso = service.GetQsoBy(details);

            string msg;
            ErrorMessage = String.Empty;
            if (!qsoIsValid(out msg))
            {
                ErrorMessage = msg;
            }
            notifyAllPropertiesChanged();
            onKeyUp_Command(Callsign);
        }

        #endregion
        protected virtual void onKeyUp_Command(object commandParameter)
        {
            string partialCall = commandParameter != null ? commandParameter.ToString() : String.Empty;
            if (partialCall.Length > 1)
            {
                DupeList = getDupeList(partialCall);
            }
            else
            {
                DupeList = new List<Qso>();
            }
            MessageSink.MessageBus.GetEvent<CallsignChangedNotification>().Publish(partialCall);
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Mode == Mode.CW)
            {
                if (e.Key == Key.Escape)
                {
                    // cancel new/edit entry
                    MessageSink.MessageBus.GetEvent<EntryCompleteNotification>().Publish(null);
                }
                else if (e.Key == Key.F4) { MessageSink.MessageBus.GetEvent<CancelMessageNotification>().Publish(null); }
                else if (e.Key == Key.F5) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(0); }
                else if (e.Key == Key.F6) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(1); }
                else if (e.Key == Key.F7) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(2); }
                else if (e.Key == Key.F8) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(3); }
                else if (e.Key == Key.F9) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(4); }
                //else if (e.Key == Key.F10)
                else if (e.Key == Key.System)
                {
                    MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(5);
                }
                else if (e.Key == Key.F11) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(6); }
                else if (e.Key == Key.F12) { MessageSink.MessageBus.GetEvent<SendMessageNotification>().Publish(7); }
                else if (e.Key == Key.F1) { MessageSink.MessageBus.GetEvent<SetFocusToFreeFormEntryNotification>().Publish(null); }
            }
        }
        protected IList<Qso> getDupeList(string partialCall)
        {
            return service.GetDupes(partialCall, Band);
        }

        protected virtual bool qsoIsValid(out string msg)
        {
            qso.ContestName = contestName;
            StringBuilder sb = new StringBuilder();
            // check callsign
            if (String.IsNullOrEmpty(Callsign) || Callsign.Length < 3)
            {
                sb.AppendLine("A callsign must have a minimum length of three. ");
            }
            // check for dupe
            if (qsoType == QsoType.NewQso && isDupe())
            {
                sb.AppendLine("Duplicate QSO. ");
            }
            // must have continent and dxcc
            if (AdifId == 0)
            {
                sb.AppendLine("A Dxcc entity must be selected. ");
            }
            // check band
            if (!contestBands.Contains(qso.Band))
            {
                sb.AppendLine("QSO on non-contest band. ");
            }
            // check mode
            if (!contestModes.Contains(qso.Mode))
            {
                sb.AppendLine("QSO using non-contest mode. ");
            }
            // assign state for AK and HI
            if (AdifId == 6)
            {
                USState = "AK";
                CanadianProvince = String.Empty;
            }
            else if (qso.AdifId == 110)
            {
                USState = "HI";
                CanadianProvince = String.Empty;
            }
            // assign power
            Power = stationPower;
            msg = sb.ToString().Trim();
            return msg.Length == 0;
        }

        protected virtual bool isDupe()
        {
            bool result = false;
            if (qsoType == QsoType.NewQso)
            {
                result = dupeBehaviors.isDupe(qso.Callsign, qso.Band, qso.Mode);
            }
            else
            {
                IList<Qso> qsos = dupeBehaviors.getDupes(qso.Callsign, qso.Band, qso.Mode);
                if ((qsos.Count > 1) || (qsos.Count == 1 && qsos[0].Id != qso.Id))
                {
                    return true;
                }
            }
            return result;
        }

        private IList<Qso> dupeList = new List<Qso>();
        public IList<Qso> DupeList
        {
            get { return dupeList; }
            set
            {
                if (dupeList != value)
                {
                    IList<Qso> dupes = filterDupes(value);
                    dupeList = (value == null) ? new List<Qso>() : value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected virtual IList<Qso> filterDupes(IList<Qso> dupes)
        {
            return dupes;
        }

        private string errorMessage = String.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = String.IsNullOrEmpty(value) ? String.Empty : value;
                    NotifyPropertyChanged();
                    ErrorVisibility = String.IsNullOrEmpty(errorMessage) ? Visibility.Collapsed : Visibility.Visible;
                }
            }
        }

        private Visibility errorVisibility;
        public Visibility ErrorVisibility
        {
            get { return errorVisibility; }
            set
            {
                if (errorVisibility != value)
                {
                    errorVisibility = value;
                    NotifyPropertyChanged("ErrorVisibility");
                }
            }
        }

        protected virtual void notifyAllPropertiesChanged()
        {
            NotifyPropertyChanged("AdifId");
            NotifyPropertyChanged("ArrlSection");
            NotifyPropertyChanged("NotifyPropertyChanged");
            NotifyPropertyChanged("BandAsInt");
            NotifyPropertyChanged("Band");
            NotifyPropertyChanged("BandAsString");
            NotifyPropertyChanged("Callsign");
            NotifyPropertyChanged("CanadianProvince");
            NotifyPropertyChanged("Continent");
            NotifyPropertyChanged("County");
            NotifyPropertyChanged("CqZone");
            NotifyPropertyChanged("DateTime");
            NotifyPropertyChanged("DistanceInKilometers");
            NotifyPropertyChanged("DxccName");
            NotifyPropertyChanged("ExchangeRcvd");
            NotifyPropertyChanged("ExchangeSent");
            NotifyPropertyChanged("Frequency");
            NotifyPropertyChanged("FormattedDate");
            NotifyPropertyChanged("FormattedFrequency");
            NotifyPropertyChanged("FormattedTime");
            NotifyPropertyChanged("GridSquare");
            NotifyPropertyChanged("Id");
            NotifyPropertyChanged("ItuZone");
            NotifyPropertyChanged("Mode");
            NotifyPropertyChanged("Multiplier");
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Points");
            NotifyPropertyChanged("Power");
            NotifyPropertyChanged("Prefix");
            NotifyPropertyChanged("SerialNumberRcvd");
            NotifyPropertyChanged("SerialNumberSent");
            NotifyPropertyChanged("TenTenNumber");
            NotifyPropertyChanged("USState");

            NotifyPropertyChanged("ErrorMessage");
            NotifyPropertyChanged("ErrorVisibility");
            NotifyPropertyChanged("DupeList");
            NotifyPropertyChanged("DxccEntities");

            NotifyPropertyChanged("Antenna");
            NotifyPropertyChanged("City");
            NotifyPropertyChanged("Comments");
            NotifyPropertyChanged("ContestName");
            NotifyPropertyChanged("MarkAsDupe");
            NotifyPropertyChanged("ReportRcvd");
            NotifyPropertyChanged("ReportSent");

            NotifyPropertyChanged("KeyerVisibility");
        }

        public Visibility KeyerVisibility
        {
            get { return keyerVisibility; }
            set
            {
                if (keyerVisibility != value)
                {
                    keyerVisibility = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int AdifId
        {
            get { return qso.AdifId; }
            set
            {
                if (qso.AdifId != value)
                {
                    qso.AdifId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ArrlSection
        {
            get { return qso.ArrlSection; }
            set
            {
                if (qso.ArrlSection != value)
                {
                    qso.ArrlSection = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Band Band { get { return qso.Band; } }

        public int BandAsInt { get { return qso.BandAsInt; } }
        public string BandAsString { get { return qso.BandAsString; } }

        public string Callsign
        {
            get { return qso.Callsign; }
            set
            {
                if (qso.Callsign != value)
                {
                    qso.Callsign = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CanadianProvince
        {
            get { return qso.CanadianProvince; }
            set
            {
                if (qso.CanadianProvince != value)
                {
                    qso.CanadianProvince = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Continent
        {
            get { return qso.Continent; }
            set
            {
                if (qso.Continent != value)
                {
                    qso.Continent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string County
        {
            get { return qso.County; }
            set
            {
                if (qso.County != value)
                {
                    qso.County = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int CqZone
        {
            get { return qso.CqZone; }
            set
            {
                if (qso.CqZone != value)
                {
                    qso.CqZone = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime DateTime
        {
            get { return qso.DateTime; }
            set
            {
                if (qso.DateTime != value)
                {
                    qso.DateTime = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("FormattedDate");
                    NotifyPropertyChanged("FormattedTime");
                }
            }
        }

        public double DistanceInKilometers
        {
            get { return qso.DistanceInKilometers; }
            set
            {
                if (qso.DistanceInKilometers != value)
                {
                    qso.DistanceInKilometers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string DxccName
        {
            get { return qso.DxccName; }
            set
            {
                if (qso.DxccName != value)
                {
                    qso.DxccName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ExchangeRcvd
        {
            get { return qso.ExchangeRcvd; }
            set
            {
                if (qso.ExchangeRcvd != value)
                {
                    qso.ExchangeRcvd = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ExchangeSent
        {
            get { return qso.ExchangeSent; }
            set
            {
                if (qso.ExchangeSent != value)
                {
                    qso.ExchangeSent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double Frequency
        {
            get { return qso.Frequency; }
            set
            {
                if (qso.Frequency != value)
                {
                    qso.Frequency = value;
                    NotifyPropertyChanged("FormattedFrequency");
                    NotifyPropertyChanged();
                }
            }
        }

        public string FormattedDate { get { return qso.FormattedDate; } }

        public string FormattedFrequency { get { return qso.FormattedFrequency; } }

        public string FormattedTime { get { return qso.FormattedTime; } }

        public string GridSquare
        {
            get { return qso.GridSquare; }
            set
            {
                if (qso.GridSquare != value)
                {
                    qso.GridSquare = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Guid Id
        {
            get { return qso.Id; }
            set
            {
                if (qso.Id != value)
                {
                    qso.Id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int ItuZone
        {
            get { return qso.ItuZone; }
            set
            {
                if (qso.ItuZone != value)
                {
                    qso.ItuZone = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Mode Mode
        {
            get { return qso.Mode; }
            set
            {
                if (qso.Mode != value)
                {
                    qso.Mode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Multiplier
        {
            get { return qso.Multiplier; }
            set
            {
                if (qso.Multiplier != value)
                {
                    qso.Multiplier = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return qso.Name; }
            set
            {
                if (qso.Name != value)
                {
                    qso.Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int Points
        {
            get { return qso.Points; }
            set
            {
                if (qso.Points != value)
                {
                    qso.Points = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Power
        {
            get { return qso.Power; }
            set
            {
                if (qso.Power != value)
                {
                    qso.Power = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Prefix
        {
            get { return qso.Prefix; }
            set
            {
                if (qso.Prefix != value)
                {
                    qso.Prefix = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int SerialNumberRcvd
        {
            get { return qso.SerialNumberRcvd; }
            set
            {
                if (qso.SerialNumberRcvd != value)
                {
                    qso.SerialNumberRcvd = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int SerialNumberSent
        {
            get { return qso.SerialNumberSent; }
            set
            {
                if (qso.SerialNumberSent != value)
                {
                    qso.SerialNumberSent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TenTenNumber
        {
            get { return qso.TenTenNumber; }
            set
            {
                if (qso.TenTenNumber != value)
                {
                    qso.TenTenNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string USState
        {
            get { return qso.USState; }
            set
            {
                if (qso.USState != value)
                {
                    qso.USState = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string Antenna
        {
            get { return qso.Antenna; }
            set
            {
                if (qso.Antenna != value)
                {
                    qso.Antenna = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string City
        {
            get { return qso.City; }
            set
            {
                if (qso.City != value)
                {
                    qso.City = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Comments
        {
            get { return qso.Comments; }
            set
            {
                if (qso.Comments != value)
                {
                    qso.Comments = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ContestName
        {
            get { return qso.ContestName; }
            set
            {
                if (qso.ContestName != value)
                {
                    qso.ContestName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool MarkAsDupe
        {
            get { return qso.MarkAsDupe; }
            set
            {
                if (qso.MarkAsDupe != value)
                {
                    qso.MarkAsDupe = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Receiver
        {
            get { return qso.Receiver; }
            set
            {
                if (qso.Receiver != value)
                {
                    qso.Receiver = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ReportRcvd
        {
            get { return qso.ReportRcvd; }
            set
            {
                if (qso.ReportRcvd != value)
                {
                    qso.ReportRcvd = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ReportSent
        {
            get { return qso.ReportSent; }
            set
            {
                if (qso.ReportSent != value)
                {
                    qso.ReportSent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Transmitter
        {
            get { return qso.Transmitter; }
            set
            {
                if (qso.Transmitter != value)
                {
                    qso.Transmitter = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
