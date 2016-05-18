//
// GeolocatorStatus.cs
//
// Author:
//    Gabor Nemeth (gabor.nemeth.dev@gmail.com)
//
//    Copyright (C) 2015, Gabor Nemeth
//
        
using System;

namespace XDotNet.Geolocation
{
    public class GeolocatorStatus
    {
        /// <summary>
        /// WGS-84 position
        /// </summary>
        public GeoPosition Position { get; set; }
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the current speed in m/s
        /// </summary>
        /// <value>The speed in m/s</value>
        public double Speed { get; set; }
    }
}
