using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using Section = Model.Section;

namespace Controller
{
    public static class Visual
    {
        private static Track _trackTest;
        private static Track _trackTest1;
        private static int Compass = 1;
        private static int HeightInts = 0;
        private static int WidthInts = 0;

        private static int SmallestHeightInts = 0;
        private static int SmallestWidthInts = 0;

        private static int HeighestHeightInts = 0;
        private static int HeighestWidthInts = 0;

        private static int[,] TrackPrint;
        public static void Initialize() {
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
            Console.BackgroundColor = ConsoleColor.Black;
            List<IParticipant> participants = new List<IParticipant>();
            participants.Add(AddParticipants("Pieter"));
            participants.Add(AddParticipants("Henk"));
            //participants.Add(AddParticipants("Klaas"));
            Race race1 = new Race(_trackTest, participants);
            race1.StartRace(-HeighestWidthInts + 1, -SmallestHeightInts, _trackTest);
        }
        public static int Visualise(int xStart, int yStart, Track track) {
            Console.SetCursorPosition(xStart + 15, yStart + 8 + 3);
            foreach (Section s in track.Sections) {
                int _currentsection = Convert.ToInt32(s.SectionType);
            }
            int[] ints = new int[track.Sections.Count() + 1];
            int a = 0;
            foreach (var section in track.Sections)
            {
                a++;
                ints[a] = Convert.ToInt32(section.SectionType);
            }
            checkPathVisual(track);
            TrackPrint = new int[50, 60];
            checkPathVisual(track);
            return 0;
        }
        public static IParticipant AddParticipants(string naam)
        {
            return (new Driver(naam, 0, Car.Equipment, TeamColors.Red));
        }
        public static void checkPathVisual(Track track1) {
            SectionTypes[] sections = { SectionTypes.StartGrid };
            Track _trackFinal = new Track("TestDing idk", sections);
            if (TrackPrint is not null)
            {
                WidthInts = -HeighestWidthInts;
                HeightInts = -SmallestHeightInts;
            }
            foreach (Section sec in track1.Sections) {
                int check = Convert.ToInt32(sec.SectionType);
                if (TrackPrint is not null) { 
                }
                switch (check)
                {
                    case 2: case 4: case 5:
                        if (Compass == 1) { 
                            WidthInts++;
                            if (HeighestWidthInts > WidthInts)
                            {
                                HeighestWidthInts = WidthInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        } if (Compass == 3) { 
                            WidthInts--;
                            if (SmallestWidthInts < WidthInts) { 
                                SmallestWidthInts = WidthInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        break;
                    case 3:
                        if (Compass == 0)
                        {
                            HeightInts--;
                            if (SmallestHeightInts > HeightInts)
                            {
                                SmallestHeightInts = HeightInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        if (Compass == 2)
                        {
                            HeightInts++;
                            if (HeighestHeightInts < HeightInts)
                            {
                                HeighestHeightInts = HeightInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        break;
                    case 6: case 8:
                        if (Compass == 0)
                        {
                            HeightInts--;
                            if (SmallestHeightInts > HeightInts)
                            {
                                SmallestHeightInts = HeightInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        if (Compass == 2)
                        {
                            HeightInts++;
                            if (HeighestHeightInts < HeightInts)
                            {
                                HeighestHeightInts = HeightInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        if (Compass == 1)
                        {
                            WidthInts++;
                            if (HeighestWidthInts > WidthInts)
                            {
                                HeighestWidthInts = WidthInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        if (Compass == 3)
                        {
                            WidthInts--;
                            if (SmallestWidthInts < WidthInts)
                            {
                                SmallestWidthInts = WidthInts;
                            }
                            if (TrackPrint is not null)
                            {
                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
                                TrackPrint[HeightInts, WidthInts] = check;
                            }
                        }
                        if (check == 8) {
                            Compass++;
                            if (Compass == 4) { Compass = 0; }
                        }
                        if (check == 6) {
                            Compass--;
                            if (Compass == -1) { Compass = 3; }
                        }
                        break;

                }
            }
        }
    }
}

