using Prism.Commands;
using Ralf.ContestLogging.Common.Interfaces;
using Ralf.ContestLogging.Common.Messaging;
using Ralf.ContestLogging.Common.Models;
using Ralf.ContestLogging.Common.Types;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ralf.ContestLogging.Common.ViewModels
{
    public class DxccSelectionViewModel : IDxccSelectionViewModel
    {
        protected IDxccSelectionBehaviorService dxccBehavior;
        public DxccSelectionViewModel(IDxccSelectionBehaviorService dxccBehavior)
        {
            this.dxccBehavior = dxccBehavior;
            MessageSink.MessageBus.GetEvent<CallsignChangedNotification>().Subscribe(partialCall => onCallsignChangedNotification(partialCall));
            DxccSelected_Command = new DelegateCommand<object>(dx => onDxccSelection(dx));
        }

        protected void onDxccSelection(object dx)
        {
            MessageSink.MessageBus.GetEvent<GeographicAreaSelectionNotification>().Publish(dx);
        }

        protected virtual void onCallsignChangedNotification(string partialCall)
        {
            // get dx entities
            dxccEntities = dxccBehavior.Resolve(partialCall);
            if (dxccEntities.Count == 1)
                onDxccSelection(dxccEntities[0]);
            NotifyPropertyChanged("DxccEntities");
        }

        protected IList<DxccEntitySelection> dxccEntities;
        public IList<DxccEntitySelection> DxccEntities
        {
            get { return dxccEntities; }
        }
        public DelegateCommand<object> DxccSelected_Command { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName]string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}