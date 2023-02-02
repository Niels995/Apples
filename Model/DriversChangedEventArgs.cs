using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DriversChangedEventArgs : EventArgs
    {
        public Track track { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public DriversChangedEventArgs()
        {
            //int x, int y, Track Track
            //this.x = x;
            //this.y = y;
            //track = Track;
        }
    }
}
