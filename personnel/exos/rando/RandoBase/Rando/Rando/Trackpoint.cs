using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rando
{
    class Trackpoint
    {
        private double _latitude;
        private double _longitude;
        private double _elevation;

        public Trackpoint(double latitude, double longitude, double elevation)
        {
            _latitude = latitude;
            _longitude = longitude;
            _elevation = elevation;
        }

        public override string ToString()
        {
            return $"lat: {this._latitude} lon: {this._longitude} ele: {this._elevation}";
        }
    }
}
