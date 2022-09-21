using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }

        private Random _random;
        private Dictionary<Section, SectionData> _positions;

        public SectionData GetSectionData(Section section)
        {
            if (_positions.ContainsKey(section))
            {
                return _positions[section];
            }
            _positions.Add(section, new SectionData());
            return _positions[section];
        }
        public Race(Track track, List<IParticipant> participant) {
            _random = new Random(DateTime.Now.Millisecond);
            Track = track;
            Participants = participant;
            _positions = new Dictionary<Section, SectionData>();
        }
        public void RandomizeEquipment() { 
        }
    }
}
