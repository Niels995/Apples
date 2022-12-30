using Model;
using System.Collections.Generic;

namespace Controller
{
    public static class Data
    {
        private static Track _trackTest;
        private static Track _trackTest1;
        public static Competition Comp { get; set; }
        public static List<IParticipant> Participants { get; set; } = new List<IParticipant>();
        public static Queue<Track> Tracks { get; set; }
        public static Race CurrentRace { get; set; }
        public static void Initialize()
        {
            SectionTypes[] _sections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.LeftCorner, SectionTypes.Vertical,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.RightCorner,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Vertical, SectionTypes.RightCorner};
            _trackTest = new Track("Race1", _sections);
            SectionTypes[] _sections1 = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.LeftCorner, SectionTypes.Vertical,
                SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
                SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.Vertical,SectionTypes.RightCorner, SectionTypes.Straight,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight,
                SectionTypes.RightCorner, SectionTypes.Vertical, SectionTypes.RightCorner};
            _trackTest1 = new Track("Race2", _sections1);
            //Graphics.printall();
            Participants.Add(AddParticipants("Henk"));
            Participants.Add(AddParticipants("Klaas"));
            Participants.Add(AddParticipants("Pieter"));
            AddTrack(_trackTest);
            AddTrack(_trackTest1);
            Comp = new Competition(Participants, Tracks);
            Race race = new Race(Comp.NextTrack(), Participants);
        }

        public static IParticipant AddParticipants(string naam) {
            return(new Driver(naam, 0, Car.Equipment, TeamColors.Red));
        }
        public static void AddTrack(Track track) {
            if (Tracks == null)
            {
                Tracks = new Queue<Track>();
            }
            Tracks.Enqueue(track);
        }
        public static void AddTrack() {
            if (Tracks == null) { 
                Tracks = new Queue<Track>();
            }
            Tracks.Enqueue(new Track("Track 1"));
            Tracks.Enqueue(new Track("Track 2"));
        }
        public static void NextRace() {
            Track track = Comp.NextTrack();
            if (track is not null)
            {
                Graphics.Visualise(5, 5, track);
                CurrentRace = new Race(track, Participants);
            }
        }

    }
}
