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

        public event EventHandler<DriversChangedEventArgs> DriversChanged;
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
            Console.ForegroundColor = ConsoleColor.White;
            setParticipants(track);
            MakeTimer();
        }
        private void MakeTimer() {
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

        public IEquipment RandomizeEquipment()
        {
            Car.Equipment.Quality = _random.Next(1000);
            Car.Equipment.Performance = _random.Next(1000);
            Car.Equipment.Speed = _random.Next(1000);
            return Car.Equipment;
        }
        public string StartRace(int xStart, int yStart, Track track) {
            x = xStart;
            y = yStart;
            Visual.Visualise(xStart,yStart,track);
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
                            thissection = i - 1;
                            if (thissection == -1)
                            {
                                thissection = track.Sections.Count;
                            }
                        }
                        if (section.SectionData.Left is null)
                        {
                            section.SectionData.Left = participant;
                        } 
                    }
                }
            }
            return track;
        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e) {
            DriversChanged?.Invoke(this, new DriversChangedEventArgs(Track));
            DriversChangedt(Track);
            StartRace(x, y, Track);
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
        }
        IParticipant _participantL = null;
        IParticipant _participantR = null;

        int Finished = 0;
        public void DriversChangedt(Track track)
        {
            foreach (IParticipant part in Participants)
            {
                Track = Move(track, part);
            }
            if (Finished == Participants.Count() * 2) { 
                
            }
        }
        public Track Move(Track track ,IParticipant part) {
            int L = 0;
            int R = 0;
            int secnumberL = -5;
            int secnumberR = -5;
            foreach (Section sec in track.Sections)
                {
                    if (track.Sections.Count() == L)
                    {
                        L = 0;
                    }
                    if (track.Sections.Count() == R)
                    {
                        R = 0;
                    }
                if (sec.SectionData.Left != null)
                {
                    if (sec.SectionData.Left.Name == part.Name)
                    {
                        // Move 1
                        _participantL = part;
                        secnumberL = L;
                        if (sec.SectionType == SectionTypes.Finish) {
                            Finished++;
                        }
                        if (secnumberL == track.Sections.Count - 1)
                        {
                            bool first = true;
                            foreach (Section sect in track.Sections)
                            {
                                if (first)
                                {
                                    sect.SectionData.Left = _participantL;
                                    first = false;
                                }
                            }
                            secnumberL = -5;
                        }
                        // Clear space
                        sec.SectionData.Left = null;
                    }
                }
                if (L == secnumberL + 1)
                {
                    sec.SectionData.Left = _participantL;
                }


                if (sec.SectionData.Right != null)
                    {
                        if (sec.SectionData.Right.Name == part.Name)
                        {
                            // Move 1
                            _participantR = part;
                            secnumberR = R;
                        if (sec.SectionType == SectionTypes.Finish)
                        {
                            Finished++;
                        }
                        if (secnumberR == track.Sections.Count - 1)
                            {
                                bool first = true;
                                foreach (Section sect in track.Sections) {
                                    if (first) {
                                        sect.SectionData.Right = _participantR;
                                        first = false;
                                    }
                                }
                                secnumberR = -5;
                            }
                            // Clear space
                            sec.SectionData.Right = null;
                        }
                    }
                    if (R == secnumberR + 1)
                    {
                        sec.SectionData.Right = _participantR;
                    }
                    L++;
                    R++;
                }
            return track;
        }
    }
}
