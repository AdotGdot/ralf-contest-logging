using Ralf.ContestLogging.Common.Enumerations;
using System;

namespace Ralf.ContestLogging.Common.Types
{
    public class Qso
    {
        public Qso()
        {
            DateTime = DateTime.UtcNow;
            Id = Guid.NewGuid();
            Amplifier = String.Empty;
            Antenna = String.Empty;
            ArrlSection = String.Empty;
            Callsign = String.Empty;
            CanadianProvince = String.Empty;
            City = String.Empty;
            Comments = String.Empty;
            ContestName = String.Empty;
            Continent = String.Empty;
            County = String.Empty;
            DxccName = String.Empty;
            ExchangeRcvd = String.Empty;
            ExchangeSent = String.Empty;
            GridSquare = String.Empty;
            Multiplier = String.Empty;
            Name = String.Empty;
            Power = String.Empty;
            Prefix = String.Empty;
            Receiver = String.Empty;
            ReportRcvd = String.Empty;
            ReportSent = String.Empty;
            Transmitter = String.Empty;
            USState = String.Empty;
            RacSectionAbbr = String.Empty;
            UsCountyAbbr = String.Empty;
            LoggedViaWebService = false;
            MexicanStateAbbr = String.Empty;
        }
        public int AdifId { get; set; }
        public string Amplifier { get; set; }
        public string Antenna { get; set; }
        public string ArrlSection { get; set; }
        public Band Band { get { return getBand(); } }
        public int BandAsInt { get { return (int)Band; } }
        public string BandAsString { get { return Band.AsString(); } }
        public string Callsign { get; set; }
        public string CanadianProvince { get; set; }
        public string City { get; set; }
        public string Comments { get; set; }
        public string ContestName { get; set; }
        public string Continent { get; set; }
        public string County { get; set; }
        public int CqZone { get; set; }
        public DateTime DateTime { get; set; }
        public double DistanceInKilometers { get; set; }
        public string DxccName { get; set; }
        public string ExchangeRcvd { get; set; }
        public string ExchangeSent { get; set; }
        public double Frequency { get; set; }
        public string FormattedDate { get { return this.DateTime.Date.ToString("dd-MMM-yyyy"); } }
        public string FormattedFrequency { get { return getFormattedFrequency(); } }
        public string FormattedTime { get { return this.DateTime.ToString("HH:mm:ss"); } }
        public string GridSquare { get; set; }
        public Guid Id { get; set; }
        public int ItuZone { get; set; }
        public bool MarkAsDupe { get; set; }
        public Mode Mode { get; set; }
        public string Multiplier { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Power { get; set; }
        public string Prefix { get; set; }
        public string Receiver { get; set; }
        public string ReportRcvd { get; set; }
        public string ReportSent { get; set; }
        public int SerialNumberRcvd { get; set; }
        public int SerialNumberSent { get; set; }
        public int TenTenNumber { get; set; }
        public string Transmitter { get; set; }
        public string USState { get; set; }
        public string RacSectionAbbr { get; set; }
        public string UsCountyAbbr { get; set; }
        public bool LoggedViaWebService { get; set; }
        public string MexicanStateAbbr { get; set; }
        private Band getBand()
        {
            if (Frequency >= 1800.0 && Frequency <= 2000.0)
                return Band.OneSixty;
            if (Frequency >= 3500.0 && Frequency <= 4000.0)
                return Band.Eighty;
            if (Frequency >= 7000.0 && Frequency <= 7300.0)
                return Band.Forty;
            if (Frequency >= 14000.0 && Frequency <= 14350.0)
                return Band.Twenty;
            if (Frequency >= 21000.0 && Frequency <= 21450.0)
                return Band.Fifteen;
            if (Frequency >= 28000.0 && Frequency <= 29700.0)
                return Band.Ten;
            if (Frequency >= 50000.0 && Frequency <= 54000.0)
                return Band.Six;
            if (Frequency >= 144000.0 && Frequency <= 148000.0)
                return Band.Two;
            if (Frequency >= 220000.0 && Frequency <= 225000.0)
                return Band.TwoTwentyTwo;
            if (Frequency >= 420000.0 && Frequency <= 450000.0)
                return Band.SeventyCm;
            if (Frequency >= 902000.0 && Frequency <= 926000.0)
                return Band.ThirtyThreeCm;
            if (Frequency >= 1240000.0 && Frequency <= 1300000.0)
                return Band.TwentyThreeCm;
            if (Frequency >= 2300000.0)
                return Band.Over2dot3GHz;
            return Band.Other;
        }

        private string getFormattedFrequency()
        {
            string[] parts = Frequency.ToString().Split('.');
            string intValue = parts[0];
            string decValue = parts.Length == 2 ? parts[1].PadRight(2, '0') : "00";
            return String.Format("{0}.{1}", intValue, decValue);
        }
    }
}
