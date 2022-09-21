using Model;
using System.Collections.Generic;

namespace Controller
{
    public static class Data
    {
        public static Competition Comp { get; set; }
        public static List<IParticipant> Participants { get; set; }
        public static Queue<Track> Tracks { get; set; }
        public static void Initialize() {
            AddParticipants();
            AddParticipants();
            AddParticipants();
            AddTrack();
            Comp = new Competition(Participants, Tracks);
        }

        public static void AddParticipants() {
            if (Participants == null)
            {
                Participants = new List<IParticipant>();
            }
            Participants.Add(new Driver("Henk", 0, Car.Equipment, TeamColors.Red));
        }
        public static void AddTrack() {
            if (Tracks == null) { 
                Tracks = new Queue<Track>();
            }
            Tracks.Enqueue(new Track("Track 1"));
            Tracks.Enqueue(new Track("Track 2"));
        }

    }
}
