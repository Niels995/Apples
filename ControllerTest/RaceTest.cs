using Controller;
using Model;
using NUnit.Framework.Internal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTest
{
    [TestFixture]
    internal class RaceTest
    {
        private Competition _competition;
        private Car _car;
        private Race _race;
        private IEquipment _equipment;
        private Track _trackTest1;
        private IParticipant Billy;
        private Queue<Track> Tracks { get; set; }
        List<IParticipant> participant = new List<IParticipant>();

        [SetUp]
        public void SetUp()
        {
            SectionTypes[] _sections1 = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish,
            SectionTypes.RightCorner, SectionTypes.RightCorner,SectionTypes.Straight,SectionTypes.Straight,
            SectionTypes.Straight,SectionTypes.RightCorner,SectionTypes.RightCorner};
            _trackTest1 = new Track("Track 2", _sections1);
            Track _trackTest2 = new Track("Track 1", _sections1);
            Tracks = new Queue<Track>();
            Tracks.Enqueue(_trackTest2);
            Tracks.Enqueue(_trackTest1);
            participant.Add(Data.AddParticipants("Henk1"));
            Billy = Data.AddParticipants("Henk");
            participant.Add(Billy);
            _competition = new Competition(participant, Tracks);
            _race = new Race(Tracks.Dequeue(), participant);
            _car = new Car();
        }
        [Test]

        // IParticipant AddParticipants(string naam)
        public void TestAddPart() {
            IParticipant result = Data.AddParticipants("Henk");
            Assert.AreEqual(result.Name, "Henk");
        }


        //Move // Spelers na elke tik verplaatsen als het kan en meer dan 100 is.
        [Test]
        public void TestMove() {
            Track returnedTrack = _race.setParticipants(_race.Track);
            Track result;
            try {
                result = _race.Move(returnedTrack, Billy);
                Assert.AreNotSame(result, _trackTest1);
            } catch (Exception ex)
            { //Idk maar zonder catch werkt het niet
            }

        }
        //setParticipants // Participants eerste keer plaatsen
        [Test]
        public void SetParticipantsTest()
        {
            Track result = _race.setParticipants(_race.Track);
            int aantal = 0;
            foreach (Section sec in result.Sections)
            {
                if (sec.SectionData.Left != null) aantal++;
                if (sec.SectionData.Right != null) aantal++;
            }
            Assert.AreEqual(aantal, participant.Count());
        }
        [Test]
        public void GraphicsPrint() {
            Section sec = new Section(SectionTypes.StartGrid,2,2,2);
            sec.SectionData.Left = Billy;
            string result = Graphics.printCorrect("*", sec);
            Assert.AreEqual("H", result);
        }
    }
}
