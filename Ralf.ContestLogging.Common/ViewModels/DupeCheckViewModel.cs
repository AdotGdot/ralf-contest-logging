using Prism.Commands;
using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public class DupeCheckViewModel : BaseViewModel, IDupeCheckViewModel
    {
        public event ResetDupeEventHandler onResetDupeView;

        protected Band band;
        protected Mode mode;
        protected TransceiverMode xcvrMode;
        protected IDupeBehaviorsService dupeBehaviors;
        private bool transceiverInitialized = false;
        public DupeCheckViewModel(ILogService service, 
            IDupeBehaviorsService dupeBehaviors)
            : base(service)
        {
            MessageSink.MessageBus.GetEvent<DataDictionaryRequest>().Subscribe(details => onNewEntryDataDictionaryRequest(details));
            MessageSink.MessageBus.GetEvent<BandChangedNotification>().Subscribe(details => onBandChangedNotification(details));
            MessageSink.MessageBus.GetEvent<ModeChangedNotification>().Subscribe(details => onModeChangedNotification(details));
            MessageSink.MessageBus.GetEvent<EntryCompleteNotification>().Subscribe(details => onEntryCompleteNotification(details));
            MessageSink.MessageBus.GetEvent<TransceiverStateResponse>().Subscribe(details => onTransceiverStateResponse(details));
            MessageSink.MessageBus.GetEvent<DupeCallsignRequest>().Subscribe(details => onDupeCallsignRequest(details));
            MessageSink.MessageBus.GetEvent<EntryCompleteNotification>().Subscribe(details => onEntryCompletedNotification(details));
            this.dupeBehaviors = dupeBehaviors;

            Reset_Command = new DelegateCommand<object>(onReset_Command);
            KeyUp_Command = new DelegateCommand<object>(onKeyUp_Command);
            EditQso_Command = new DelegateCommand<object>(onEditQso_Command);
        }

        public virtual void onDupeCallsignRequest(object details)
        {
            string callsign = details.ToString().Trim();
            if (!String.IsNullOrEmpty(callsign))
            {
                Callsign = callsign;
                onKeyUp_Command(callsign);
                NotifyPropertyChanged("Callsign");
            }
        }

        private void onTransceiverStateResponse(TransceiverState details)
        {
            transceiverInitialized = true;
            band = details.Band;
            xcvrMode = details.Mode;
            mode = xcvrMode.ToMode();
        }

        public DelegateCommand<object> EditQso_Command { get; set; }
        private void onEditQso_Command(object commandParameter)
        {
            Qso qso = commandParameter as Qso;
            if (qso != null)
            {
                MessageSink.MessageBus.GetEvent<EditEntryNotification>().Publish(qso.Id);
            }
        }

        private void onEntryCompleteNotification(object details)
        {
            resetView();
        }

        private void onBandChangedNotification(Band details)
        {
            band = details;
            resetView();
        }

        private void onModeChangedNotification(Mode details)
        {
            if (mode != details)
            {
                mode = details;
                xcvrMode = mode.ToTransceiverMode();
                resetView();
            }
        }

        protected virtual void resetView()
        {
            DupeList = null;
            Callsign = String.Empty;
            partialCall = String.Empty;
            NotifyPropertyChanged("Callsign");
            MessageSink.MessageBus.GetEvent<DupeResetNotification>().Publish(new object());
            if (onResetDupeView != null)
            {
                onResetDupeView();
            }
        }

        public DelegateCommand<object> Reset_Command { get; set; }
        private void onReset_Command(object commandParameter)
        {
            resetView();
        }

        private IList<Qso> dupeList;
        public IList<Qso> DupeList
        {
            get { return dupeList; }
            set
            {
                if (dupeList != value)
                {
                    dupeList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected string partialCall = String.Empty;
        public string Callsign { get; set; }

        public DelegateCommand<object> KeyUp_Command { get; set; }
        private void onKeyUp_Command(object commandParameter)
        {
            if (!transceiverInitialized)
            {
                MessageSink.MessageBus.GetEvent<TransceiverStateRequest>().Publish(new object());
            }
            partialCall = commandParameter.ToString();
            if (partialCall.Length > 1)
                DupeList = getDupeList();
            else
                DupeList = new List<Qso>();
        }

        ///////////////////
        protected void onEntryCompletedNotification(object details)
        {
            resetView();
        }

        protected void onNewEntryDataDictionaryRequest(object details)
        {
            DataDictionary nedd = new DataDictionary();
            if (!String.IsNullOrEmpty(partialCall))
            {
                nedd.Add("Callsign", partialCall);
            }
            MessageSink.MessageBus.GetEvent<DataDictionaryResponse>().Publish(nedd);
        }
        protected IList<Qso> getDupeList()
        {
            return dupeBehaviors.getDupes(partialCall, band, mode);
        }
    }
}