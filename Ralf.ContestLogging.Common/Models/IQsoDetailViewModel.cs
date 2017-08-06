using Prism.Commands;
using Ralf.ContestLogging.Common.Enumerations;
using Ralf.ContestLogging.Common.Types;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Ralf.ContestLogging.Common.Models
{
    public interface IQsoDetailViewModel : IBaseViewModel
    {
        void OnKeyDown(object sender, KeyEventArgs e);
        Visibility KeyerVisibility { get; set; }
        void SetQsoId(Guid qsoId);
        DelegateCommand<object> EntryCompleted_Command { get; set; }
        DelegateCommand<object> EntryCanceled_Command { get; set; }
        int AdifId { get; set; }
        string Antenna { get; set; }
        string ArrlSection { get; set; }
        Band Band { get; }
        int BandAsInt { get; }
        string BandAsString { get; }
        string Callsign { get; set; }
        string CanadianProvince { get; set; }
        string City { get; set; }
        string Comments { get; set; }
        string ContestName { get; set; }
        string Continent { get; set; }
        string County { get; set; }
        int CqZone { get; set; }
        DateTime DateTime { get; set; }
        double DistanceInKilometers { get; set; }
        string DxccName { get; set; }
        string ExchangeRcvd { get; set; }
        string ExchangeSent { get; set; }
        double Frequency { get; set; }
        string FormattedDate { get; }
        string FormattedFrequency { get; }
        string FormattedTime { get; }
        string GridSquare { get; set; }
        Guid Id { get; set; }
        int ItuZone { get; set; }
        bool MarkAsDupe { get; set; }
        Mode Mode { get; set; }
        string Multiplier { get; set; }
        string Name { get; set; }
        int Points { get; set; }
        string Power { get; set; }
        string Prefix { get; set; }
        string ReportRcvd { get; set; }
        string ReportSent { get; set; }
        int SerialNumberRcvd { get; set; }
        int SerialNumberSent { get; set; }
        int TenTenNumber { get; set; }
        string USState { get; set; }
        DelegateCommand<object> KeyUp_Command { get; set; }

        IList<Qso> DupeList { get; set; }

        string ErrorMessage { get; set; }
        Visibility ErrorVisibility { get; set; }
    }
}
