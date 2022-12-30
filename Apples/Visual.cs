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
            //participants.Add(AddParticipants("Pieter"));
            //participants.Add(AddParticipants("Henk"));
            //participants.Add(AddParticipants("Klaas"));
            Race race1 = new Race(_trackTest, participants);
            //race1.StartRace(-HeighestWidthInts + 1, -SmallestHeightInts, _trackTest);
        }
        public static IParticipant AddParticipants(string naam)
        {
            return (new Driver(naam, 0, Car.Equipment, TeamColors.Red));
        }

    }
}

