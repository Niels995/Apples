using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using static System.Collections.Specialized.BitVector32;

namespace ControllerTest
{
    [TestFixture]
    internal class Model_Competition_NextTrackShould
    {
        private Competition _competition;
        private Car _car;
        private Race _race;
        private IEquipment _equipment;
        private Queue<Track> Tracks { get; set; }





        [SetUp]
        public void SetUp()
        {
            SectionTypes[] _sections1 = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish,
            SectionTypes.RightCorner, SectionTypes.RightCorner,SectionTypes.Straight,SectionTypes.Straight,
            SectionTypes.Straight,SectionTypes.RightCorner,SectionTypes.RightCorner};
            Track _trackTest1 = new Track("Track 2", _sections1);
            Tracks = new Queue<Track>();
            Tracks.Enqueue(new Track("Track 1"));
            Tracks.Enqueue(_trackTest1);
            List<IParticipant> participant = new List<IParticipant>();
            _competition = new Competition(participant, Tracks);
            _race = new Race(Tracks.Dequeue(), participant);
            _car = new Car();
        }
        [Test]
        public void NextTrack_EmptyQueue_returnNull()
        {
            var result = _competition.NextTrack();
            Assert.AreEqual(result.Name, "Track 2");
        }
        [Test]
        public void TrackSectionAdd() {
            Track t1 = _competition.NextTrack();
            var result = t1.SectionList(SectionTypes.Straight, 2, 2, 0);
            Assert.AreEqual(result.Count(), t1.Sections.Count());
            //LinkedList < Section > SectionList(SectionTypes sections, int x, int y, int compass)
        }

    }
}
