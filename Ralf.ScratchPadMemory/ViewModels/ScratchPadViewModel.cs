using Prism.Commands;
using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Types;
using Ralf.ScratchPadMemory.Interfaces;
using Ralf.ScratchPadMemory.Models;
using Ralf.ScratchPadMemory.Types;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Ralf.ScratchPadMemory.ViewModels
{
    public class ScratchPadViewModel : IScratchPadViewModel, INotifyPropertyChanged
    {
        private Window window = null;
        private IMemoryIO memoryIO;
        private double frequency;
        private Mode mode;
        private string errorMessage;
        private MemoryList memories;
        private string callsign;
  
        public string Callsign
        {
            get { return callsign; }
            set
            {
                callsign = value;
                NotifyPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public MemoryList Memories
        {
            get { return memories; }
            set
            {
                memories = value;
                NotifyPropertyChanged();
            }
        }
        public DelegateCommand<object> MemorySelected_Command { get; set; }
        public DelegateCommand<object> AddMemory_Command { get; set; }
        public DelegateCommand<object> DeleteMemory_Command { get; set; }
        public DelegateCommand<object> ViewVisible_Command { get; set; }
        public DelegateCommand<object> ClearMemory_Command { get; set; }
        public DelegateCommand<object> CloseView_Command { get; set; }

        public ScratchPadViewModel(IMemoryIO memoryIO)
        {
            this.memoryIO = memoryIO;
            loadMemoryList();
            MessageSink.MessageBus.GetEvent<TransceiverStateResponse>().Subscribe(onTransceiverStateResponse);
            MessageSink.MessageBus.GetEvent<DataDictionaryResponse>().Subscribe(details => onCallsignResponse(details));
            MemorySelected_Command = new DelegateCommand<object>(onMemorySelected);
            AddMemory_Command = new DelegateCommand<object>(onAddMemory);
            DeleteMemory_Command = new DelegateCommand<object>(onDeleteMemory);
            ViewVisible_Command = new DelegateCommand<object>(onViewVisible);
            ClearMemory_Command = new DelegateCommand<object>(onClearMemory);
            CloseView_Command = new DelegateCommand<object>(onCloseView);

            MessageSink.MessageBus.GetEvent<TransceiverStateRequest>().Publish(new object());
            MessageSink.MessageBus.GetEvent<DataDictionaryRequest>().Publish(new object());
        }

        private void onCloseView(object obj)
        {
            closeWindow();
        }

        private void onCallsignResponse(DataDictionary details)
        {
            string callsign;
            if (details.TryGetValue("Callsign", out callsign))
            {
                Callsign = callsign.ToString();
            }
        }

        private void onClearMemory(object obj)
        {
            Memories.Clear();
            saveMemoryList();
            ErrorMessage = String.Empty;
        }

        private void onTransceiverStateResponse(TransceiverState obj)
        {
            mode = obj.Mode.ToMode();
            frequency = obj.Frequency;
        }

        protected void NotifyPropertyChanged([CallerMemberName]string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        private void loadMemoryList()
        {
            Memories = memoryIO.GetMemoryList();
        }

        private void saveMemoryList()
        {
            memoryIO.SetMemoryList(Memories);
        }

        #region DelegateCommand handlers

        private void onViewVisible(object obj)
        {
            window = obj as Window;
        }

        private void onDeleteMemory(object obj)
        {
            Memory memory = obj as Memory;
            if (memory != null)
            {
                Memories.Remove(memory);
                saveMemoryList();
            }
        }

        private void onMemorySelected(object obj)
        {
            Memory memory = obj as Memory;
            if (memory != null)
            {
                MessageSink.MessageBus.GetEvent<TransceiverSetFrequencyRequest>().Publish(memory.Frequency);
                MessageSink.MessageBus.GetEvent<TransceiverSetModeRequest>().Publish(memory.Mode);
                MessageSink.MessageBus.GetEvent<DupeCallsignRequest>().Publish(memory.Callsign);
                closeWindow();
            }
        }

        private void closeWindow()
        {
            if (window != null)
            {
                window.Close();
            }
        }

        private void onAddMemory(object obj)
        {
            if (obj != null)
            {
                if (!String.IsNullOrEmpty(obj.ToString()))
                {
                    string callsign = obj.ToString();
                    if (!isDupe(callsign))
                    {
                        Memory memory = new Memory();
                        DateTime dt = DateTime.UtcNow;
                        memory.Callsign = callsign;
                        memory.Date = dt.Date.ToString("dd-MMM-yyyy");
                        memory.Time = dt.ToString("HH:mm:ss");
                        memory.Frequency = frequency;
                        memory.Mode = mode;
                        Memories.Add(memory);
                        saveMemoryList();
                        closeWindow();
                    }
                    else
                    {
                        ErrorMessage = "Callsign and frequency already in list.";
                    }
                }
            }
        }

        private bool isDupe(string callsign)
        {
            var memory = (from Memory m in Memories
                          where m.Callsign.Equals(callsign)
                          && m.Frequency.Equals(frequency)
                          select m).FirstOrDefault();
            return memory != null;
        }

        public void callsignTextBox_KeyUp(object sender, KeyEventArgs e)
        {
           if(e.Key == Key.Return)
            {
                onAddMemory(Callsign);
            }
        }

        #endregion
    }
}
