using Falcon_Flight_Planner.Enums;
using System;

namespace FalconDatabase.GeoLib
{
    /// <summary>
    /// Represents a 1-D Coordinate Component on a Map
    /// </summary>
    public class Coordinate
    {

        #region Properties
        /// <summary>
        /// Degrees Component of a Lattitude or Longitude Coordinate
        /// </summary>
        public double Degrees { get; set; } = 0;
        /// <summary>
        /// Minutes Component of a Lattitude or Longitude Coordinate
        /// </summary>
        public double Minutes { get; set; } = 0;
        /// <summary>
        /// Seconds Component of a Lattitude or Longitude Coordinate
        /// </summary>
        public double Seconds { get; set; } = 0;
        /// <summary>
        /// Global Hemisphere of the coordinate
        /// </summary>
        public CardinalDirection Position { get; set; } = CardinalDirection.N;
        #endregion Properties // Checked

        #region Functional Methods
        /// <summary>
        /// Convert the coordinate into a Double Value
        /// </summary>
        /// <returns></returns>
        public double ToDouble()
        {
            var result = Degrees + Minutes / 60 + Seconds / 3600;
            return Position == CardinalDirection.W || Position == CardinalDirection.S ? -result : result;
        }
        /// <summary>
        /// Get the <see cref="string"/> representation of the Coordinate.
        /// </summary>
        /// <returns>Coordinate in the "Degrees Minutes Seconds" format</returns>
        public override string ToString()
        {
            return Degrees + "º " + Minutes + "' " + Seconds + "'' " + Position;
        }
        #endregion Functional Methods

        #region Constructors
        public Coordinate() { }
        public Coordinate(double value, CardinalDirection position)
        {
            // Validate Cardinal Directions
            if (value < 0 && position == CardinalDirection.N)
                position = CardinalDirection.S;
            if (value < 0 && position == CardinalDirection.E)
                position = CardinalDirection.W;
            if (value > 0 && position == CardinalDirection.S)
                position = CardinalDirection.N;
            if (value > 0 && position == CardinalDirection.W)
                position = CardinalDirection.E;

            var decimalValue = Convert.ToDecimal(value);

            decimalValue = Math.Abs(decimalValue);

            var degrees = decimal.Truncate(decimalValue);
            decimalValue = (decimalValue - degrees) * 60;

            var minutes = decimal.Truncate(decimalValue);
            var seconds = (decimalValue - minutes) * 60;

            Degrees = Convert.ToDouble(degrees);
            Minutes = Convert.ToDouble(minutes);
            Seconds = Convert.ToDouble(seconds);
            Position = position;
        }
        public Coordinate(double degrees, double minutes, double seconds, CardinalDirection position)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
            Position = position;
        }
        public Coordinate(Coordinate coordinate)
        {
            Degrees = coordinate.Degrees;
            Minutes = coordinate.Minutes;
            Seconds = coordinate.Seconds;
            Position = coordinate.Position;
        }
        #endregion Constructors

    }


}
