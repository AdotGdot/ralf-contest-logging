using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Windows;
using System.Windows.Input;


namespace Ralf.ContestLogging.Common.ViewModels
{
    public class ShellViewModel : BaseViewModel, IShellViewModel
    {
        private Visibility keyerControlVisibility;
        private IQsoDetailPopupService qsoDetailPopupService;
        private IScratchPadMemoryPopupService memoryPopupService;
        private Key lastKey;

        public ShellViewModel(
            ILogService service, 
            IQsoDetailPopupService qsoDetailPopupService,
            IScratchPadMemoryPopupService memoryPopupService)
            : base(service)
        {
            MessageSink.MessageBus.GetEvent<EditEntryNotification>().Subscribe(onEditQso);
            MessageSink.MessageBus.GetEvent<ModeChangedNotification>().Subscribe(onModeChanged);
            MessageSink.MessageBus.GetEvent<TransceiverStateResponse>().Subscribe(onTransceiverStateChanged);
            this.qsoDetailPopupService = qsoDetailPopupService;
            this.memoryPopupService = memoryPopupService;
        }

        private void onTransceiverStateChanged(TransceiverState xcvrState)
        {
            onModeChanged(xcvrState.Mode.ToMode());
        }

        private void onModeChanged(Mode mode)
        {
            KeyerControlVisibility = mode == Mode.CW ? Visibility.Visible : Visibility.Collapsed;
        }

        public Visibility KeyerControlVisibility
        {
            get { return keyerControlVisibility; }
            set
            {
                if (keyerControlVisibility != value)
                {
                    keyerControlVisibility = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void onEditQso(Guid guid)
        {
            popupQsoDetailView(guid);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((lastKey == Key.LeftCtrl || lastKey == Key.RightCtrl) && e.Key == Key.F1)
            {
                // scratchpad memory
                popupScratchPadView();
            }
            else if (e.Key == Key.F1)
            {
                // help goes here eventually
            }
            else if (e.Key == Key.F2)
            {
                // new entry
                popupQsoDetailView(Guid.Empty);
            }
            else if (e.Key == Key.Escape)
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
            lastKey = e.Key;
        }

        private void popupScratchPadView()
        {
            memoryPopupService.PopupScratchPadMemoryView();
        }


        private void popupQsoDetailView(Guid guid)
        {
            qsoDetailPopupService.PopupQsoDetailView(guid);
        }
    }
}
