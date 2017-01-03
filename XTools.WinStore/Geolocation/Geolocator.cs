using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace XDotNet.Geolocation
{
    /// <summary>
    /// Windows Store Geolocator
    /// </summary>
    public class Geolocator : IGeolocator
    {
        private Windows.Devices.Geolocation.Geolocator _geolocator;
        private GeolocatorStatus _status;
        private bool _isConnected;
        /// <summary>
        /// Age limit of location in seconds
        /// </summary>
        private int _locationAgeLimit = 60;
        /// <summary>
        /// Last received position
        /// </summary>
        private Geoposition _lastPosition;
        /// <summary>
        /// Timestamp of the last received position (time of receive)
        /// </summary>
        private DateTime _lastPositionTimestamp;

        public Geolocator()
        {
            _geolocator = new Windows.Devices.Geolocation.Geolocator
            {
                DesiredAccuracy = Windows.Devices.Geolocation.PositionAccuracy.High,
                DesiredAccuracyInMeters = 10,
                MovementThreshold = 1.0 // 1 meter displacement fires change in position
            };

            _status = new GeolocatorStatus();
        }

        void geolocator_PositionChanged(Windows.Devices.Geolocation.Geolocator sender, Windows.Devices.Geolocation.PositionChangedEventArgs args)
        {
            _lastPosition = args.Position;
#if WINDOWS_PHONE_APP
            _lastPositionTimestamp = _lastPosition.Coordinate.PositionSourceTimestamp.HasValue ?
                _lastPosition.Coordinate.PositionSourceTimestamp.Value.UtcDateTime :
                _lastPosition.Coordinate.Timestamp.UtcDateTime;
#else
            _lastPositionTimestamp = _lastPosition.Coordinate.Timestamp.UtcDateTime;
#endif
            UpdateStatus();
        }

        public event EventHandler<GeoLocatorStatusChangedEventArgs> StatusChanged;

        public GeolocatorStatus Status
        {
            get { return _status; }
        }

        public async Task ConnectAsync()
        {
            _geolocator.PositionChanged += geolocator_PositionChanged;
            _geolocator.StatusChanged += geolocator_StatusChanged;
            _isConnected = true;

            // initialize with the last known position
            _lastPosition = await _geolocator.GetGeopositionAsync();
            _lastPositionTimestamp = DateTime.UtcNow;
            UpdateStatus();
            Task.Run(async () =>
            {
                while (_isConnected)
                {
                    await Task.Delay(1000);
                    UpdateStatus();
                }
            });
        }

        public void Disconnect()
        {
            _geolocator.PositionChanged -= geolocator_PositionChanged;
            _geolocator.StatusChanged -= geolocator_StatusChanged;
            _isConnected = false;
        }

        private void geolocator_StatusChanged(Windows.Devices.Geolocation.Geolocator sender, StatusChangedEventArgs args)
        {
            Debug.WriteLine("Geolocator status changed to {0}.", args.Status);
        }

        private void UpdateStatus()
        {
            var geoPos = _lastPosition;
            var pos = geoPos.Coordinate.Point.Position;

            var timeDiff = DateTime.UtcNow.Subtract(_lastPositionTimestamp);
            GeoPosition newPos;
            if (timeDiff.TotalSeconds > _locationAgeLimit)
                newPos = GeoPosition.Empty; // location is too old, treat as empty
            else
            {
                newPos = new GeoPosition
                {
                    Latitude = (float)pos.Latitude,
                    Longitude = (float)pos.Longitude,
                    Altitude = (float)pos.Altitude
                };
            }
            if (newPos.Equals(_status.Position))
            {
                Diagnostics.Log.Diagnostics("Geolocator position has not been changed.");
                return;
            }

            _status.Position = newPos;
            _status.Speed = geoPos.Coordinate.Speed.GetValueOrDefault(0);
            Diagnostics.Log.Diagnostics(string.Format("Current geoposition: {0}\n\tObtained from: {1}", _status.Position, geoPos.Coordinate.PositionSource));

            if (StatusChanged != null)
            {
                var args = new GeoLocatorStatusChangedEventArgs(_status);
                StatusChanged(this, args);
            }
        }


        public void SetMaxAgeLimit(int maxAgeSeconds)
        {
            _locationAgeLimit = maxAgeSeconds;
        }
    }
}
