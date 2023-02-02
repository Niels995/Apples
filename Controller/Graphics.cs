using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Graphics
    {
//        private static Track _trackTest;
//        private static Track _trackTest1;
//        private static int Compass = 1;
//        private static int HeightInts = 0;
//        private static int WidthInts = 0;

//        private static int SmallestHeightInts = 0;
//        private static int SmallestWidthInts = 0;

//        private static int HeighestHeightInts = 0;
//        private static int HeighestWidthInts = 0;

//        public static void Visualise(int xStart, int yStart, Track track)
//        {
//            foreach (Section s in track.Sections)
//            {
//                int _currentsection = Convert.ToInt32(s.SectionType);
//            }
//            int[] ints = new int[track.Sections.Count() + 1];
//            int a = 0;
//            foreach (var section in track.Sections)
//            {
//                a++;
//                ints[a] = Convert.ToInt32(section.SectionType);
//            }
//            checkPathVisual(track);
//            //Console.SetCursorPosition(-HeighestWidthInts + 15, -SmallestHeightInts + 8 + 3);
//            TrackPrint = new int[50, 60];
//            checkPathVisual(track);
//        }
//        public static void reset() {
//            TrackPrint = null;
//            Compass = 1;
//            HeightInts = 0;
//            WidthInts = 0;

//            SmallestHeightInts = 0;
//            SmallestWidthInts = 0;

//            HeighestHeightInts = 0;
//            HeighestWidthInts = 0;
//        }

//        public static void checkPathVisual(Track track1)
//        {
//            SectionTypes[] sections = { SectionTypes.StartGrid };
//            Track _trackFinal = new Track("TestDing idk", sections);
//            if (TrackPrint is not null)
//            {
//                WidthInts = -HeighestWidthInts;
//                HeightInts = -SmallestHeightInts;
//            }
//            foreach (Section sec in track1.Sections)
//            {
//                int check = Convert.ToInt32(sec.SectionType);
//                if (TrackPrint is not null)
//                {
//                }
//                switch (check)
//                {
//                    case 2:
//                    case 4:
//                    case 5:
//                        if (Compass == 1)
//                        {
//                            WidthInts++;
//                            if (HeighestWidthInts > WidthInts)
//                            {
//                                HeighestWidthInts = WidthInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec); 
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        if (Compass == 3)
//                        {
//                            WidthInts--;
//                            if (SmallestWidthInts < WidthInts)
//                            {
//                                SmallestWidthInts = WidthInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        break;
//                    case 3:
//                        if (Compass == 0)
//                        {
//                            HeightInts--;
//                            if (SmallestHeightInts > HeightInts)
//                            {
//                                SmallestHeightInts = HeightInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        if (Compass == 2)
//                        {
//                            HeightInts++;
//                            if (HeighestHeightInts < HeightInts)
//                            {
//                                HeighestHeightInts = HeightInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        break;
//                    case 6:
//                    case 8:
//                        if (Compass == 0)
//                        {
//                            HeightInts--;
//                            if (SmallestHeightInts > HeightInts)
//                            {
//                                SmallestHeightInts = HeightInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        if (Compass == 2)
//                        {
//                            HeightInts++;
//                            if (HeighestHeightInts < HeightInts)
//                            {
//                                HeighestHeightInts = HeightInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        if (Compass == 1)
//                        {
//                            WidthInts++;
//                            if (HeighestWidthInts > WidthInts)
//                            {
//                                HeighestWidthInts = WidthInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        if (Compass == 3)
//                        {
//                            WidthInts--;
//                            if (SmallestWidthInts < WidthInts)
//                            {
//                                SmallestWidthInts = WidthInts;
//                            }
//                            if (TrackPrint is not null)
//                            {
//                                _trackFinal.SectionList(sec.SectionType, HeightInts, WidthInts, Compass);
//                                Graphics.printall(check, HeightInts, WidthInts, Compass, sec);
//                                TrackPrint[HeightInts, WidthInts] = check;
//                            }
//                        }
//                        if (check == 8)
//                        {
//                            Compass++;
//                            if (Compass == 4) { Compass = 0; }
//                        }
//                        if (check == 6)
//                        {
//                            Compass--;
//                            if (Compass == -1) { Compass = 3; }
//                        }
//                        break;
//                }
//            }
//        }

//        public static int[] track1;
//        public static int[,] TrackPrint;
//        public static void Direction(int getal,int x, int y, Section section) {
//            for (int i = 0; i < 8; i++) {
//                Console.SetCursorPosition(y * 7, x * 7 + i);
//                switch (getal) {
//                    case 0:
//                        Console.Write(printCorrect(Blank[i], section));
//                        break;
//                    case 1:
//                        Console.Write(printCorrect(Rechts[i], section));
//                        break;
//                    case 2:
//                        Console.Write(printCorrect(Horizontaal[i], section));
//                        break;
//                    case 3:
//                        Console.Write(printCorrect(Verticaal[i], section));
//                        break;
//                    case 4:
//                        Console.Write(printCorrect(Start[i], section));
//                        break;
//                    case 5:
//                        Console.Write(printCorrect(Finish[i], section));
//                        break;
//                    case 6:
//                        Console.Write(printCorrect(Links[i], section));
//                        break;
//                    case 7:
//                        Console.Write(printCorrect(LinksV[i], section));
//                        break;
//                    case 8:
//                        Console.Write(printCorrect(RechtsV[i], section));
//                        break;
//                    case 9:
//                        Console.Write(printCorrect(LinksA[i], section));
//                        break;
//                    case 10:
//                        Console.Write(printCorrect(LinksVA[i], section));
//                        break;
//                    case 11:
//                        Console.Write(printCorrect(RechtsA[i], section));
//                        break;
//                    case 12:
//                        Console.Write(printCorrect(RechtsVA[i], section));
//                        break;
//                    case 13:
//                        Console.Write(printCorrect(HorizontaalA[i], section));
//                        break;
//                    case 14:
//                        Console.Write(printCorrect(VerticaalA[i], section));
//                        break;
//                }
//            }
//        }
//        public static void printall(int sec, int x, int y, int comp, Section section) {
//            section.Y = WidthInts;
//            section.X = HeightInts;
//            section.Compass = Compass;
//            Corner(sec, x , y, comp, section);
//        }
//        //public voor tests
//        public static string printCorrect(string print, Section section) {
//            string Name;
//            string changed = print;
//            if (section.SectionData.Left is not null)
//            {
//                if (section.SectionData.Left.IsBroken)
//                {
//                    changed = print.Replace("*", "X");
//                }
//                else
//                {
//                    Name = section.SectionData.Left.Name;
//                    changed = print.Replace("*", Name.Remove(1));
//                }
//            }
//            if (section.SectionData.Right is not null) {
//                if (section.SectionData.Right.IsBroken)
//                {
//                    changed = changed.Replace("+", "X");
//                }
//                else
//                {
//                    Name = section.SectionData.Right.Name;
//                    changed = changed.Replace("+", Name.Remove(1));
//                }
//            }
//            changed = changed.Replace("+", " ");
//            changed = changed.Replace("*", " ");
//            return changed;
//        }


//        public static void Corner(int sec, int x, int y, int compass, Section section) {
//            if (sec == 6 || sec == 8)
//            {
//                if (compass == 0 && sec == 8)
//                {
//                    Direction(1, x, y, section);
//                }
//                if (compass == 1 && sec == 8)
//                {
//                    Direction(8, x, y, section);
//                }
//                if (compass == 2 && sec == 8)
//                {
//                    Direction(9, x, y, section);
//                }
//                if (compass == 3 && sec == 8)
//                {
//                    Direction(10, x, y, section);
//                }
//                if (compass == 0 && sec == 6)
//                {
//                    Direction(12, x, y, section);
//                }
//                if (compass == 1 && sec == 6)
//                {
//                    Direction(6, x, y, section);
//                }
//                if (compass == 2 && sec == 6)
//                {
//                    Direction(7, x, y, section);
//                }
//                if (compass == 3 && sec == 6)
//                {
//                    Direction(11, x, y, section);
//                }
//            }
//            else if (sec == 2 || sec == 3) {
//                if (compass == 1 && sec == 2) {
//                    Direction(2, x, y, section);
//                }
//                if (compass == 3 && sec == 2)
//                {
//                    Direction(13, x, y, section);
//                }
//                if (compass == 0 && sec == 3)
//                {
//                    Direction(3, x, y, section);
//                }
//                if (compass == 2 && sec == 3)
//                {
//                    Direction(14, x, y, section);
//                }
//            }
//            else
//            {
//                Direction(sec, x, y, section);
//            }
//        }

//        //public static void checkCorner(int h, int w)
//        //{
//        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6)
//        //    {
//        //        if (w >= 1) {
//        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
//        //            {
//        //                Graphics.Direction(8);
//        //            }
//        //        }
//        //    }
//        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8)
//        //    {
//        //        if (w >= 1)
//        //        {
//        //            if (!(new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
//        //            {
//        //                Graphics.Direction(1);
//        //            }
//        //        } else { Graphics.Direction(1); }
//        //    }
//        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8)
//        //    {
//        //        if (w >= 1) {
//        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
//        //            { 
//        //                Graphics.Direction(8);
//        //            } 
//        //        }
//        //    }
//        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6)
//        //    {
//        //        if (w >= 1)
//        //        {
//        //            if (!(new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
//        //            {
//        //                Graphics.Direction(1);
//        //            }
//        //        }else { Graphics.Direction(1); }
//        //    }
//        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6))
//        //    {
//        //        if (w >= 1)
//        //        {
//        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
//        //            {
//        //                Graphics.Direction(6);
//        //            }
//        //        }
//        //    }
//        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8))
//        //    {
//        //        if (w >= 1)
//        //        {
//        //            if ((!new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
//        //            {
//        //                Graphics.Direction(7);
//        //            }
//        //        }
//        //        else { Graphics.Direction(7); }
//        //    }
//        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8))
//        //    {
//        //        if (w >= 1)
//        //        {
//        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
//        //            {
//        //                Graphics.Direction(6);
//        //            }
//        //        }
//        //    }
//        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6))
//        //    {
//        //        if (w >= 1)
//        //        {
//        //            if ((!new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
//        //            {
//        //                Graphics.Direction(7);
//        //            }
//        //        }
//        //        else { Graphics.Direction(7); }
//        //    }
//        //}

//        public static string[] Blank =
//        {
            
//                "       ",
//                "       ",   
//                "       ",
//                "       ",
//                "       ",
//                "       ",
//                "       ",
//                "       "
//        };

//        public static string[] Links = 
//        {
//                 " |   | ",
//                 "-/   | ",
//                 "*    | ",
//                 "     | ",
//                 "     / ",
//                 "   +/  ",
//                 "---/   ",
//                 "       "
            
//        };
//        public static string[] LinksV =
//{
//                 " |   | ",
//                 " |   \\-",
//                 " |   * ",
//                 " |     ",
//                 " |     ",
//                 " \\+    ",
//                 "  \\----",
//                 "       "

//        };
//        public static string[] RechtsV =
//        {
//                "       ",
//                "---\\   ",
//                "   *\\  ",
//                "     \\ ",
//                "     | ",
//                "     | ",
//                "-\\+  | ",
//                " |   | "
            
//        };
//        public static string[] Rechts =
//{
//                "       ",
//                "   /---",
//                "  /*   ",
//                " /     ",
//                " |     ",
//                " |   + ",
//                " |   /-",
//                " |   | "

//        };
//        public static string[] LinksA =
//{
//                 " |   | ",
//                 "-/   | ",
//                 " +   | ",
//                 "     | ",
//                 "     / ",
//                 "   */  ",
//                 "---/   ",
//                 "       "

//        };
//        public static string[] LinksVA =
//{
//                 " |   | ",
//                 " |   \\-",
//                 " |  +  ",
//                 " |     ",
//                 " |     ",
//                 " \\*    ",
//                 "  \\----",
//                 "       "

//        };
//        public static string[] RechtsVA =
//        {
//                "       ",
//                "---\\   ",
//                "   +\\  ",
//                "     \\ ",
//                "     | ",
//                "     | ",
//                "-\\*  | ",
//                " |   | "

//        };
//        public static string[] RechtsA =
//{
//                "       ",
//                "   /---",
//                "  /+   ",
//                " /     ",
//                " |     ",
//                " |  *  ",
//                " |   /-",
//                " |   | "

//        };
//        public static string[] Horizontaal =
//        {
//                "       ",
//                "-------",
//                " *     ",
//                "       ",
//                "       ",
//                "  +    ",
//                "-------",
//                "       ",

//        };
//        public static string[] Verticaal =
//        {
//                " |   | ",
//                " |   | ",
//                " |   | ",
//                " |* +| ",
//                " |   | ",
//                " |   | ",
//                " |   | ",
//                " |   | "
            
//        };
//        public static string[] HorizontaalA =
//{
//                "       ",
//                "-------",
//                " +     ",
//                "       ",
//                "       ",
//                " *     ",
//                "-------",
//                "       "

//        };
//        public static string[] VerticaalA =
//        {
//                " |   | ",
//                " |   | ",
//                " |   | ",
//                " |+ *| ",
//                " |   | ",
//                " |   | ",
//                " |   | ",
//                " |   | "

//        };
//        public static string[] Start =
//        {
//                "       ",
//                "-------",
//                "  *    ",
//                "       ",
//                "       ",
//                "  +    ",
//                "-------",
//                "       "
            
//        }; 
//        public static string[] Finish =
//        {
//                "       ",
//                "----#--",
//                " *  #  ",
//                "    #  ",
//                "    #  ",
//                " +  #  ",
//                "----#--",
//                "       "
            
//        };
    }
}
