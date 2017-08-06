using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ralf.MaidenheadCalculator
{
    public static class LocatorConverter
    {
        private static string letters = "ABCDEFGHIJKLMNOPQRSTUVWX";
        private static string expression = "[A-R][A-R][0-9][0-9]";
        public static bool isValidGridSquare(string gridSquare)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(gridSquare))
            {
                result = Regex.IsMatch(gridSquare, expression) && gridSquare.Length == 4;
            }
            return result;
        }
        public static double DistanceInKilometers(
            string gridSquare1,
            string gridSquare2,
            int precision)
        {
            Coordinate coordinate1 = GridSquareToCoordinate(gridSquare1);
            Coordinate coordinate2 = GridSquareToCoordinate(gridSquare2);

            return calculateDistance(coordinate1, coordinate2, UnitOfMeasure.Kilometers, precision);
        }

        public static double DistanceInMiles(
            string gridSquare1,
            string gridSquare2,
            int precision)
        {
            Coordinate coordinate1 = GridSquareToCoordinate(gridSquare1);
            Coordinate coordinate2 = GridSquareToCoordinate(gridSquare2);

            return calculateDistance(coordinate1, coordinate2, UnitOfMeasure.Miles, precision);
        }

        public static double DistanceInNauticalMiles(
            string gridSquare1,
            string gridSquare2,
            int precision)
        {
            Coordinate coordinate1 = GridSquareToCoordinate(gridSquare1);
            Coordinate coordinate2 = GridSquareToCoordinate(gridSquare2);

            return calculateDistance(coordinate1, coordinate2, UnitOfMeasure.NauticalMiles, precision);
        }

        public static double DistanceInKilometers(
            Coordinate coordinate1,
            Coordinate coordinate2,
            int precision)
        {
            return calculateDistance(coordinate1, coordinate2, UnitOfMeasure.Kilometers, precision);
        }

        public static double DistanceInMiles(
            Coordinate coordinate1,
            Coordinate coordinate2,
            int precision)
        {
            return calculateDistance(coordinate1, coordinate2, UnitOfMeasure.Miles, precision);
        }

        public static double DistanceInNauticalMiles(
            Coordinate coordinate1,
            Coordinate coordinate2,
            int precision)
        {
            return calculateDistance(coordinate1, coordinate2, UnitOfMeasure.NauticalMiles, precision);
        }

        public static Coordinate GridSquareToCoordinate(string gridSquare)
        {
            Coordinate coordinate = new Coordinate();
            gridSquare = gridSquare.ToUpper();
            if (gridSquare.Length == 4)
            {
                gridSquare += "LM";
            }
            else if (gridSquare.Length != 6)
            {
                throw new Exception("The locator must have 4 chars i.e. JN68 or jn59 or 6 chars i.e. JN68RN or jn59eg");
            }

            char[] gs = gridSquare.ToUpper().ToArray();

            int x_l = letters.IndexOf(gs[0]);
            int x_m = Convert.ToInt32(gs[2].ToString());
            int x_r = letters.IndexOf(gs[4]);

            int y_l = letters.IndexOf(gs[1]);
            int y_m = Convert.ToInt32(gs[3].ToString());
            int y_r = letters.IndexOf(gs[5]);

            double x = x_l * 10 + x_m + (x_r + 0.5) / 24;
            x *= 2;
            x -= 180;

            coordinate.Longitude = Math.Ceiling(x * 100) / 100;

            double y = y_l * 10 + y_m + (y_r + 0.5) / 24;
            y -= 90;
            coordinate.Latitude = Math.Ceiling(y * 100) / 100;

            return coordinate;
        }

        private static double calculateDistance(
            Coordinate coordinate1,
            Coordinate coordinate2,
            UnitOfMeasure unitOfMeasure,
            int precision)
        {
            double theta = coordinate1.Longitude - coordinate2.Longitude;
            double dist = Math.Sin(deg2rad(coordinate1.Latitude)) * Math.Sin(deg2rad(coordinate2.Latitude)) +
                          Math.Cos(deg2rad(coordinate1.Latitude)) * Math.Cos(deg2rad(coordinate2.Latitude)) *
                          Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unitOfMeasure == UnitOfMeasure.Kilometers)
            {
                dist = dist * 1.609344;
            }
            else if (unitOfMeasure == UnitOfMeasure.NauticalMiles)
            {
                dist = dist * 0.8684;
            }
            return Math.Round(dist, precision);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
