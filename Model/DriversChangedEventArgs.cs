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
        public DriversChangedEventArgs(Track Track)
        {
            track = Track;
        }
    }
}
