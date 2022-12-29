using Model;
using System.Collections.Generic;

namespace Controller
{
    public static class Data
    {
        public static Competition Comp { get; set; }
        public static List<IParticipant> Participants { get; set; } = new List<IParticipant>();
        public static Queue<Track> Tracks { get; set; }
        public static Race CurrentRace { get; set; }
        public static void Initialize()
        {
            //Graphics.printall();
            Participants.Add(AddParticipants("Henk"));
            Participants.Add(AddParticipants("Klaas"));
            Participants.Add(AddParticipants("Pieter"));
            AddTrack();
            Comp = new Competition(Participants, Tracks);
        }

        public static IParticipant AddParticipants(string naam) {
            return(new Driver(naam, 0, Car.Equipment, TeamColors.Red));
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
            if (track is not null) {
                CurrentRace = new Race(track, Participants);
            }
        }

    }
}
