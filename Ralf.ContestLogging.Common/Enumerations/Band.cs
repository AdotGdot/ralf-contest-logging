namespace Ralf.ContestLogging.Common.Enumerations
{
    public enum Band
    {
        Other = 0,
        Two = 2,
        Six = 6,
        Ten = 10,
        Twelve = 12,
        Fifteen = 15,
        Seventeen = 17,
        Twenty = 20,
        Thirty = 30,
        Forty = 40,
        Sixty = 60,
        Eighty = 80,
        OneSixty = 160,
        TwoTwentyTwo = 222,
        SeventyCm = 420,
        ThirtyThreeCm = 902,
        TwentyThreeCm = 1240,
        Over2dot3GHz = 2300
    }

    public static class BandExtensions
    {
        public static string AsString(this Band band)
        {
            switch (band)
            {
                case Band.Over2dot3GHz: return "2.3+ GHz";
                case Band.Eighty: return "80M";
                case Band.Fifteen: return "15M";
                case Band.Forty: return "40M";
                case Band.OneSixty: return "160M";
                default:
                case Band.Other: return "other";
                case Band.Seventeen: return "17M";
                case Band.SeventyCm: return "70cm";
                case Band.Six: return "6M";
                case Band.Sixty: return "60M";
                case Band.Ten: return "10M";
                case Band.Thirty: return "30M";
                case Band.ThirtyThreeCm: return "33cm";
                case Band.Twelve: return "12M";
                case Band.Twenty: return "20M";
                case Band.TwentyThreeCm: return "23cm";
                case Band.Two: return "2M";
                case Band.TwoTwentyTwo: return "1.25M";
            }
        }

        public static Band ToBand(this string bandName)
        {
            switch (bandName)
            {
                case "80M": return Band.Eighty;
                case "15M": return Band.Fifteen;
                case "40M": return Band.Forty;
                case "160M": return Band.OneSixty;
                default:
                case "other": return Band.Other;
                case "17M": return Band.Seventeen;
                case "70cm": return Band.SeventyCm;
                case "6M": return Band.Six;
                case "60M": return Band.Sixty;
                case "10M": return Band.Ten;
                case "30M": return Band.Thirty;
                case "33cm": return Band.ThirtyThreeCm;
                case "12M": return Band.Twelve;
                case "20M": return Band.Twenty;
                case "23cm": return Band.TwentyThreeCm;
                case "2M": return Band.Two;
                case "1.25M": return Band.TwoTwentyTwo;
                case "2.3+ GHz": return Band.Over2dot3GHz;
            }
        }

        public static Band GetBand(this double frequency)
        {
            if (frequency >= 1800.00 && frequency <= 2000.00)
            {
                return Band.OneSixty;
            }
            else if (frequency >= 3500.00 && frequency <= 4000.00)
            {
                return Band.Eighty;
            }
            else if (frequency == 5330.5 || frequency == 5346.5 || frequency == 5371.5 || frequency == 5403.5)
            {
                return Band.Sixty;
            }
            else if (frequency >= 7000.00 && frequency <= 7300.00)
            {
                return Band.Forty;
            }
            else if (frequency >= 10100.00 && frequency <= 10150.00)
            {
                return Band.Thirty;
            }
            else if (frequency >= 14000.00 && frequency <= 14350.00)
            {
                return Band.Twenty;
            }
            else if (frequency >= 18068.00 && frequency <= 18168.00)
            {
                return Band.Seventeen;
            }
            else if (frequency >= 21000.00 && frequency <= 21450.00)
            {
                return Band.Fifteen;
            }
            else if (frequency >= 24890.00 && frequency <= 24990.00)
            {
                return Band.Twelve;
            }
            else if (frequency >= 28000.00 && frequency <= 29700.00)
            {
                return Band.Ten;
            }
            else if (frequency >= 50000.00 && frequency <= 54000.00)
            {
                return Band.Six;
            }
            else if (frequency >= 144000.00 && frequency <= 148000.00)
            {
                return Band.Two;
            }
            else if ((frequency >= 219000.00 && frequency <= 220000.00) || (frequency >= 222000.00 && frequency <= 225000.00))
            {
                return Band.TwoTwentyTwo;
            }
            else if (frequency >= 420000.00 && frequency <= 450000.00)
            {
                return Band.SeventyCm;
            }
            else if (frequency >= 905000.00 && frequency <= 928000.00)
            {
                return Band.ThirtyThreeCm;
            }
            else if (frequency >= 1240000.00 && frequency <= 1300000.00)
            {
                return Band.TwentyThreeCm;
            }
            return Band.Other;
        }
    }
}