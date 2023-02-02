using Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Controller
{
    public static class Data
    {
        #region Console
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
            CurrentRace = new Race(Comp.NextTrack(), Participants);
            //CurrentRace.MakeTimer();
            //CurrentRace.DriversChanged += UpdateAndMoveTrack;
        }

        public static void UpdateAndMoveTrack(object sender, DriversChangedEventArgs eventArgs)
        {
            CurrentRace.MoveTrack(eventArgs.track);
        }

        public static IParticipant AddParticipants(string naam)
        {
            return (new Driver(naam, 0, Car.Equipment, TeamColors.Red));
        }
        public static void AddTrack(Track track)
        {
            if (Tracks == null)
            {
                Tracks = new Queue<Track>();
            }
            Tracks.Enqueue(track);
        }
        public static void AddTrack()
        {
            if (Tracks == null)
            {
                Tracks = new Queue<Track>();
            }
            Tracks.Enqueue(new Track("Track 1"));
            Tracks.Enqueue(new Track("Track 2"));
        }
        public static Track NextRace()
        {
            Track track = Comp.NextTrack();
            if (track != null)
            {
                //Visual.Visualise(5, 5, track);
                //CurrentRace.Track = track;
                //CurrentRace.Participants= Participants;
                CurrentRace = new Race(track, Participants);
                //foreach (IParticipant part in Participants) { 

                //    CurrentRace.FinishedPlayer(part);
                //}
            }
            return track;
        }
        #endregion
        //#region WPF

        //public static Competition Comp { get; set; }
        //public static List<IParticipant> Participants { get; set; } = new List<IParticipant>();
        //public static Race CurrentRace { get; set; }
        //public static void Initialize()
        //{
        //    //Graphics.printall();
        //    Comp = new Competition();
        //    AddParticipants();
        //    AddTracks();
        //    CurrentRace = new Race(Comp.NextTrack(), Participants);
        //    //CurrentRace.DriversChanged += UpdateAndMoveTrack;
        //}
        //private static void AddParticipants()
        //{
        //    Comp.Participants.Add(new Driver("Henk", 0, Car.Equipment, TeamColors.Red));
        //    Comp.Participants.Add(new Driver("Klaas", 0, Car.Equipment, TeamColors.Blue));
        //    Comp.Participants.Add(new Driver("Pieter", 0, Car.Equipment, TeamColors.Green));
        //    Comp.Participants.Add(new Driver("Pablo", 0, Car.Equipment, TeamColors.Yellow));
        //}
        //private static void AddTracks()
        //{
        //    SectionTypes[] _sections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.LeftCorner, SectionTypes.Vertical,
        //        SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
        //        SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.RightCorner,
        //        SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight,
        //        SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.Vertical, SectionTypes.RightCorner};
        //    SectionTypes[] _sections1 = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Finish, SectionTypes.LeftCorner, SectionTypes.Vertical,
        //        SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.RightCorner,
        //        SectionTypes.Vertical, SectionTypes.Vertical, SectionTypes.Vertical,SectionTypes.RightCorner, SectionTypes.Straight,
        //        SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight,
        //        SectionTypes.RightCorner, SectionTypes.Vertical, SectionTypes.RightCorner};
        //    Comp.Tracks.Enqueue(new Track("Race1", _sections));
        //    Comp.Tracks.Enqueue(new Track("Race2", _sections1));
        //}

        //public static void UpdateAndMoveTrack(object sender, DriversChangedEventArgs eventArgs)
        //{
        //    CurrentRace.MoveTrack(eventArgs.track);
        //}

        //public static IParticipant AddParticipants(string naam)
        //{
        //    return (new Driver(naam, 0, Car.Equipment, TeamColors.Red));
        //}
        //public static void AddTrack(Track track)
        //{
        //    //if (Tracks == null)
        //    //{
        //    //    Tracks = new Queue<Track>();
        //    //}
        //    //Tracks.Enqueue(track);
        //}
        //public static Track NextRace()
        //{
        //    Track track = Comp.NextTrack();
        //    if (track != null)
        //    {
        //        Graphics.Visualise(5, 5, track);
        //        //CurrentRace.Track = track;
        //        //CurrentRace.Participants= Participants;
        //        CurrentRace = new Race(track, Participants);
        //        //foreach (IParticipant part in Participants) { 

        //        //    CurrentRace.FinishedPlayer(part);
        //        //}
        //    }
        //    return track;
        //}
        //#endregion
    }
}
