using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RaceEventArgs : EventArgs
    {
        public Color color { get; private set; }
        public string Title { get; private set; }

        public RaceEventArgs(Track track) {
            Title = track.Name;
        }
    }
}
