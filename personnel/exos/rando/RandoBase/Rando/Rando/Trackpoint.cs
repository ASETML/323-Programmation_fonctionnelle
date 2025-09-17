using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rando
{
    class Trackpoint
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double elevation { get; set; }

        public Trackpoint(double latitude, double longitude, double elevation)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.elevation = elevation;
        }

        public override string ToString()
        {
            return $"lat: {this.latitude} lon: {this.longitude} ele: {this.elevation}";
        }
    }
}
