using Falcon_Flight_Planner.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDatabase.GeoLib
{
    /// <summary>
    ///  Represents a 3D Point on a Map
    /// </summary>
    public class GeoPoint
    {
        #region Properties
        /// <summary>
        /// The String Representation of the Lattitude (N/S) of this <see cref="GeoPoint"/> in Degress Minutes Seconds (DMS) Notation.
        /// </summary>
        public string Latitude
        { get { return _Latitude.ToString(); } }
        /// <summary>
        /// The String Representation of the Longitude (E/W) of this <see cref="GeoPoint"/> in Degress Minutes Seconds (DMS) Notation.
        /// </summary>
        public string Longitude
        { get { return _Longitude.ToString(); } }
        /// <summary>
        /// <para>The X Value of this <see cref="GeoPoint"/>.</para> 
        /// <para>The X Value is associated with Longitude. Negative Values indicate West Longitude Values.</para>
        /// </summary>
        public double X
        {
            get { return _Longitude.ToDouble(); }
            set { _Longitude = new Coordinate(value, value < 0 ? CardinalDirection.W : CardinalDirection.E); }
        }
        /// <summary>
        /// <para>The Y Value of this <see cref="GeoPoint"/>.</para> 
        /// <para>The Y Value is associated with Latitude. Negative Values indicate South Latitude Values.</para>
        /// </summary>
        public double Y
        {
            get { return _Latitude.ToDouble(); }
            set { _Latitude = new Coordinate(value, value < 0 ? CardinalDirection.S : CardinalDirection.N); }
        }
        /// <summary>
        /// The Elevation Component of this <see cref="GeoPoint"/>.
        /// </summary>
        public double Elevation
        {
            get { return _Elevation; }
            set { _Elevation = value; }
        }


        #endregion Properties

        #region Fields
        private Coordinate _Latitude = new Coordinate();
        private Coordinate _Longitude = new Coordinate();
        private double _Elevation = 0;
        #endregion Fields

        #region Functional Methods
        /// <summary>
        /// Set the Latitude Component using Degrees, Minutes, and Seconds with a Cardinal Direction
        /// </summary>
        /// <param name="degree">The Degree Value of the Coordinate.</param>
        /// <param name="minutes">The Minute Value of the Coordinate.</param>
        /// <param name="seconds">The Second Component of the Coordinate.</param>
        /// <param name="direction">The Cardinal Direction (E/W)</param>
        public void SetLatitude(double degree, double minutes, double seconds, CardinalDirection direction)
        {
            _Latitude = new Coordinate(degree, minutes, seconds, direction);
            if (_Latitude.ToDouble() < 0)
                if (_Latitude.Position == CardinalDirection.E)
                    _Latitude.Position = CardinalDirection.W;
                else if (_Latitude.Position == CardinalDirection.W)
                    _Latitude.Position = CardinalDirection.E;
        }
        /// <summary>
        /// Set the Latitude Component using Degrees, Minutes, and Seconds with a Cardinal Direction
        /// </summary>
        /// <param name="degree">The Degree Value of the Coordinate.</param>
        /// <param name="minutes">The Minute Value of the Coordinate.</param>
        /// <param name="seconds">The Second Component of the Coordinate.</param>
        /// <param name="direction">The Cardinal Direction (N/S)</param>
        public void SetLongitude(double degrees, double minutes, double seconds, CardinalDirection direction)
        {
            _Longitude = new Coordinate(degrees, minutes, seconds, direction);
            if (_Longitude.ToDouble() < 0)
                if (_Longitude.Position == CardinalDirection.E)
                    _Longitude.Position = CardinalDirection.W;
                else if (_Longitude.Position == CardinalDirection.W)
                    _Longitude.Position = CardinalDirection.E;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Latitude.ToString() + ", " + Longitude.ToString() + " Elevation: " + Elevation);
            return sb.ToString();
        }
        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Initializes a default instance of the <see cref="GeoPoint"/> object.
        /// </summary>
        public GeoPoint()
        {

        }
        /// <summary>
        /// Initializes an instance of the <see cref="GeoPoint"/> object with the supplied values.
        /// </summary>
        /// <param name="x">The X (Longitude) Component</param>
        /// <param name="y">The Y (Latitude) Component</param>
        public GeoPoint(double x, double y)
        {
            X = x; Y = y;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="GeoPoint"/> object with the supplied values.
        /// </summary>
        /// <param name="x">The X (Longitude) Component</param>
        /// <param name="y">The Y (Latitude) Component</param>
        /// <param name="elevation">The Elevation Component</param>
        public GeoPoint(double x, double y, double elevation)
            : this(x, y)
        {
            _Elevation = elevation;
        }
        /// <summary>
        /// Initializes a copy of the supplied <see cref="GeoPoint"/> object.
        /// </summary>
        /// <param name="geopoint">The <see cref="GeoPoint"/> object with the values to copy.</param>
        public GeoPoint(GeoPoint geopoint)
        {
            _Latitude = geopoint._Latitude;
            _Longitude = geopoint._Longitude;
            _Elevation = geopoint._Elevation;
        }
        /// <summary>
        /// Initializes a new <see cref="GeoPoint"/> object with the supplied values.
        /// </summary>
        /// <param name="x">The X (Longitude) Component</param>
        /// <param name="y">The Y (Latitude) Component</param>
        /// <param name="elevation">The Elevation Component</param>
        public GeoPoint(Coordinate x, Coordinate y, double elevation)
        {
            _Latitude = y;
            _Longitude = x;
            _Elevation = elevation;
        }
        #endregion Constructors
    }
}
