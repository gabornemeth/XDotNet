using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDotNet.Geolocation
{
    public class GeoLocatorStatusChangedEventArgs : EventArgs
    {
        public GeolocatorStatus Status { get; protected set; }

        public GeoLocatorStatusChangedEventArgs(GeolocatorStatus status)
        {
            Status = status;
        }
    }

    /// <summary>
    /// Geolocator interface
    /// </summary>
    public interface IGeolocator
    {
        /// <summary>
        /// Last valid status
        /// </summary>
        GeolocatorStatus Status { get;  }
        event EventHandler<GeoLocatorStatusChangedEventArgs> StatusChanged;
        Task ConnectAsync();
        void Disconnect();
        void SetMaxAgeLimit(int maxAgeSeconds);
    }
}
