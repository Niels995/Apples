using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Collections.Specialized.BitVector32;
using Section = Model.Section;
using DriversChangedEventArgs = Model.DriversChangedEventArgs;
using Timer = System.Timers.Timer;

namespace Controller
{
    public class Race
    {
        public IEquipment Equipment { get; set; }
        public Track Track { get; set; }
        public List<IParticipant> Participants { get; set; }
        public DateTime StartTime { get; set; }
        private int x { get; set; } = 0;
        private int y { get; set; } = 0;

        private static Timer Timer;
        private Random _random;
        private Dictionary<Section, SectionData> _positions;

        public event EventHandler<RaceEventArgs> RaceDraw;
        public event EventHandler<DriversChangedEventArgs> DriversChanged;

        public int RaceLength { get; set; } = 2;
        //Word niet gebruikt
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
            _random = new Random();
            Track = track;
            Participants = participant;
            RandomizeEquipment();
            _positions = new Dictionary<Section, SectionData>();
            Console.ForegroundColor = ConsoleColor.White;
            setParticipants(track);
            MakeTimer();
        }
        public void MakeTimer() {
            Start();
            Timer.Start();
            Console.ReadLine();
            Timer.Stop();
        }
        private void Start()
        {
            // Create a timer with a two second interval.
            Timer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer. 
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        public void RandomizeEquipment()
        {
            foreach (IParticipant part in Participants)
            {
                part.Quality = _random.Next(1, 11);
                part.Performance = _random.Next(1, 100);
                part.Speed = _random.Next(1, 11);
                part.Finished = 0;
            }
        }
        public string StartRace(int xStart, int yStart, Track track) {
            x = xStart;
            y = yStart;
            Graphics.Visualise(xStart,yStart,track);
            Console.ForegroundColor = ConsoleColor.Green;
            return Participants.First().Name;
        }
        public Track setParticipants(Track track) {
            int thissection = -100;
            int i = 0;
            foreach (Section section in track.Sections)
            {
                if (section.SectionType == SectionTypes.Finish)
                {
                    thissection = i - 1;
                    if (thissection == -1)
                    {
                        thissection = track.Sections.Count;
                    }
                }
                i++;
            }
            i = i + track.Sections.Count;
            foreach (IParticipant participant in Participants) {
                foreach (Section section in track.Sections){
                    i++;
                    if (i >= track.Sections.Count) {
                        i = 0; 
                    }
                    if (i == thissection)
                    {
                        if (section.SectionData.Right is null && section.SectionData.Left is not null)
                        {
                            section.SectionData.Right = participant;
                            participant.CurrentSection = i;
                            thissection = i - 1;
                            if (thissection == -1)
                            {
                                thissection = track.Sections.Count;
                            }
                        }
                        if (section.SectionData.Left is null)
                        {
                            section.SectionData.Left = participant;
                            participant.CurrentSection = i;
                        } 
                    }
                }
            }
            return track;
        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e) {
            if (Track != null)
            {
                MoveTrack(Track);
                StartRace(x, y, Track);
            }
            //DriversChanged?.Invoke(this, new DriversChangedEventArgs(Track));
            //RaceDraw?.Invoke(this, new RaceEventArgs(Track));
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        }
        IParticipant _participantL = null;
        IParticipant _participantR = null;

        int Finished = 0;
        public void MoveTrack(Track track)
        {
            foreach (IParticipant part in Participants)
            {
                int RandomInt = _random.Next(1, 10);
                if (RandomInt <= 3)
                {
                    switch (RandomInt) {
                        case 1:
                            part.Quality = _random.Next(1, 11);
                            break;
                        case 2:
                            part.Performance = _random.Next(1, 100);
                            break;
                        case 3:
                            part.Speed = _random.Next(1, 11);
                            break;
                    }
                    part.IsBroken = true;
                } else
                {
                    part.IsBroken = false;
                }
                Track = Move(track, part);
            }
            if (Finished == Participants.Count() * RaceLength)
            {
                foreach (IParticipant part in Participants)
                {
                    part.Finished = 0;
                    Finished = 0;
                    Track = null;
                    Timer.Stop();
                }
                DriversChanged = null;
                Console.Clear();
                Graphics.reset();
                Track = Data.NextRace();
            }
        }
        public Track Move(Track track ,IParticipant part) {
            int L = 0;
            bool Moved = false;
            //  int secnumberL = -5;
            //  int secnumberR = -5;
            if (part.Name.Equals("Henk")) {
                part.Speed = 3;
                part.Performance = 34;
            }
            if (!part.IsBroken)
            {
                foreach (Section sec in track.Sections)
                {
                    bool FinishCheck = false;
                    if (track.Sections.Count() <= L)
                    {
                        L = 1;
                    }
                    //if (track.Sections.Count() <= R)
                    //{
                    //    R = 1;
                    //}

                    if (sec.SectionData.Left != null && part.Finished != RaceLength)
                    {
                        Console.SetCursorPosition(80, 15 + part.Name.Length);
                        Console.WriteLine($"{sec.SectionData.DistanceLeft} {part.Name} {part.Speed} {part.Performance} ");
                        if (sec.SectionData.Left.Name == part.Name)
                        {
                            if (sec.SectionData.DistanceLeft >= 100 || part.Performance * part.Speed >= 100)
                            {
                                //    // Move 1
                                _participantL = part;
                                //   secnumberL = L;


                                int NextNumberL = part.CurrentSection + 1;
                                if (NextNumberL == track.Sections.Count()) { NextNumberL = 0; }
                                Section NextSectionL = track.Sections.ElementAt(NextNumberL);
                                Section CurrentSectionL = track.Sections.ElementAt(part.CurrentSection);
                                // Check if finish
                                if (NextSectionL.SectionData.Left == null && !Moved)
                                {
                                    sec.SectionData.Left = null;
                                    part.CurrentSection = NextNumberL;
                                    NextSectionL.SectionData.Left = _participantL;
                                    Moved = true;
                                    FinishCheck = true;
                                }
                                else if (NextSectionL.SectionData.Right == null && !Moved)
                                {
                                    sec.SectionData.Left = null;
                                    part.CurrentSection = NextNumberL;
                                    NextSectionL.SectionData.Right = _participantL;
                                    Moved = true;
                                    FinishCheck = true;
                                }
                                else
                                {
                                    sec.SectionData.DistanceLeft = 0;
                                }
                                // Volgende spot vrij heeft gemoved huidige spot is finish
                                if (FinishCheck && CurrentSectionL.SectionType == SectionTypes.Finish && Moved) //&& NextSectionL.SectionData.Left == null)// || CurrentSectionL.SectionType == SectionTypes.Finish && Moved)
                                {
                                    Finished++;
                                    part.Finished++;
                                    if (part.Finished == RaceLength)
                                    {
                                        sec.SectionData.Left = null;
                                        NextSectionL.SectionData.Left = null;
                                    }
                                    FinishCheck = false;
                                }
                            }
                            else
                            {
                                sec.SectionData.DistanceLeft += part.Performance * part.Speed;
                            }
                        }
                    }else if (sec.SectionData.Right != null && part.Finished != RaceLength)
                    {
                        if (sec.SectionData.Right.Name == part.Name)
                        {
                            if (sec.SectionData.DistanceRight >= 100 || part.Performance * part.Speed >= 100)
                            {
                                //    // Move 1
                                _participantR = part;
                                //   secnumberL = L;


                                int NextNumberR = part.CurrentSection + 1;
                                if (NextNumberR == track.Sections.Count()) { NextNumberR = 0; }
                                Section NextSectionR = track.Sections.ElementAt(NextNumberR);
                                Section CurrentSectionR = track.Sections.ElementAt(part.CurrentSection);
                                // Check if finish
                                if (NextSectionR.SectionData.Left == null && !Moved)
                                {
                                    sec.SectionData.Right = null;
                                    part.CurrentSection = NextNumberR;
                                    NextSectionR.SectionData.Left = _participantR;
                                    Moved = true;
                                    FinishCheck = true;

                                } else if (NextSectionR.SectionData.Right == null && !Moved)
                                {
                                    sec.SectionData.Right = null;
                                    part.CurrentSection = NextNumberR;
                                    NextSectionR.SectionData.Right = _participantR;
                                    Moved = true;
                                    FinishCheck = true;
                                }
                                else
                                {
                                    sec.SectionData.DistanceRight = 0;
                                }
                                // Volgende spot vrij heeft gemoved huidige spot is finish
                                if (FinishCheck && CurrentSectionR.SectionType == SectionTypes.Finish && Moved) //&& NextSectionL.SectionData.Left == null)// || CurrentSectionL.SectionType == SectionTypes.Finish && Moved)
                                {
                                    Finished++;
                                    part.Finished++;
                                    if (part.Finished == RaceLength)
                                    {
                                        sec.SectionData.Right = null;
                                        NextSectionR.SectionData.Right = null;
                                    }
                                    FinishCheck = false;
                                }
                            }
                            else
                            {
                                sec.SectionData.DistanceRight += part.Performance * part.Speed;
                            }
                        }
                    }
                    //if (sec.SectionData.Right != null && part.Finished != 2)
                    //{
                    //    Console.WriteLine(sec.SectionData.DistanceRight + "  " + part.Name);
                    //    if (sec.SectionData.Right.Name == part.Name)
                    //    {
                    //        if (sec.SectionData.DistanceRight >= 100 || sec.SectionData.DistanceRight + part.Performance * part.Speed >= 100)
                    //        {
                    //            // Set participant
                    //            _participantR = part;
                    //            // Get next section data
                    //            int NextNumberR = part.CurrentSection + 1;
                    //            if (NextNumberR == track.Sections.Count()) { NextNumberR = 0; }
                    //            Section NextSectionR = track.Sections.ElementAt(NextNumberR);
                    //            Section CurrentSectionR = track.Sections.ElementAt(part.CurrentSection);
                    //            // Check if finish
                    //            if (CurrentSectionR.SectionType == SectionTypes.Finish && NextSectionR.SectionData.Right == null && part.CurrentSection == L)
                    //            {
                    //                Finished++;
                    //                part.Finished++;
                    //                if (part.Finished == 2)
                    //                {
                    //                    NextSectionR.SectionData.Right = null;
                    //                    sec.SectionData.Left = null;
                    //                }
                    //            }
                    //            // Check if data right is null
                    //            if (NextSectionR.SectionData.Right == null && !Moved)
                    //            {
                    //                // Move 1
                    //                sec.SectionData.Right = null;
                    //                part.CurrentSection = NextNumberR;
                    //                NextSectionR.SectionData.Right = _participantR;
                    //                Moved = true;
                    //            }
                    //            else {
                    //                sec.SectionData.DistanceRight = 0;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            sec.SectionData.DistanceRight += part.Performance * part.Speed;
                    //        }
                    //    }
                    //}
                    L++;
                }
            }
            return track;
        }
    }
}
