using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace ControllerTest
{
    [TestFixture]
    internal class Model_Competition_NextTrackShould
    {
        private Competition _competition;
        private Car _car;
        private Race _race;
        private IEquipment _equipment;
        private  Queue<Track> Tracks { get; set; }

        [SetUp]
        public void SetUp() {
            Tracks = new Queue<Track>();
            Tracks.Enqueue(new Track("Track 1"));
            List<IParticipant> participant = new List<IParticipant>();
            _competition = new Competition(participant, Tracks);
            _race = new Race(Tracks.Dequeue(), participant);
            _car = new Car();
        }
        [Test]
        public void NextTrack_EmptyQueue_returnNull() {
            var result = _competition.NextTrack();
            Assert.AreEqual(result.Name,"Track 1");
        }
        
    }
}
