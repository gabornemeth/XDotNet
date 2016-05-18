
using System;
using Newtonsoft.Json;

namespace XDotNet.Geolocation
{
    /// <summary>
    /// Geographic position in WGS84
    /// </summary>
    public struct GeoPosition
    {
        /// <summary>
        /// Longitude in degrees
        /// </summary>
        public float Longitude { get; set; }
        /// <summary>
        /// Latitude in degrees
        /// </summary>
        public float Latitude { get; set; }
        /// <summary>
        /// Altitude in meters
        /// </summary>
        public float Altitude { get; set; }

        [JsonIgnore]
        public bool IsEmpty
        {
            get
            {
                return Longitude.Equals(0) && Latitude.Equals(0) && Altitude.Equals(0);
            }
        }

        private static GeoPosition empty = new GeoPosition();

        public static GeoPosition Empty
        {
            get
            {
                return empty;
            }
        }

        /// <summary>
        /// Initializes a new instance of <c>GeoPosition</c>
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        public GeoPosition(float longitude, float latitude, float altitude = 0)
            : this()
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }

        public override string ToString()
        {
            return string.Format("Lon={0} Lat={1} Alt={2}", Longitude, Latitude, Altitude);
        }

        public bool Equals(GeoPosition pos)
        {
            return Longitude.Equals(pos.Longitude) && Latitude.Equals(pos.Latitude) && Altitude.Equals(pos.Altitude);
        }

        /// <summary>
        /// Distance from a position in degrees
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public GeoPosition DistanceFrom(GeoPosition pos)
        {
            return new GeoPosition(System.Math.Abs(pos.Longitude - Longitude), System.Math.Abs(pos.Latitude - Latitude));
        }
    }
}
