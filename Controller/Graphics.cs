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
    internal class Graphics
    {
        enum dir
        {
            north,
            east,
            south,
            west,
            crash
        }

        enum graphic { 
            
        }

        public static int[] track1;
        public static int[,] TrackPrint;
        public static void Direction(int getal,int x, int y, Section section) {
            for (int i = 0; i < 8; i++) {
                Console.SetCursorPosition(y * 14, x * 7 + i);
                switch (getal) {
                    case 0:
                        Console.Write(printCorrect(Blank[i], section));
                        break;
                    case 1:
                        Console.Write(printCorrect(Rechts[i], section));
                        break;
                    case 2:
                        Console.Write(printCorrect(Horizontaal[i], section));
                        break;
                    case 3:
                        Console.Write(printCorrect(Verticaal[i], section));
                        break;
                    case 4:
                        Console.Write(printCorrect(Start[i], section));
                        break;
                    case 5:
                        Console.Write(printCorrect(Finish[i], section));
                        break;
                    case 6:
                        Console.Write(printCorrect(Links[i], section));
                        break;
                    case 7:
                        Console.Write(printCorrect(LinksV[i], section));
                        break;
                    case 8:
                        Console.Write(printCorrect(RechtsV[i], section));
                        break;
                    case 9:
                        Console.Write(printCorrect(LinksA[i], section));
                        break;
                    case 10:
                        Console.Write(printCorrect(LinksVA[i], section));
                        break;
                    case 11:
                        Console.Write(printCorrect(RechtsA[i], section));
                        break;
                    case 12:
                        Console.Write(printCorrect(RechtsVA[i], section));
                        break;
                    case 13:
                        Console.Write(printCorrect(HorizontaalA[i], section));
                        break;
                    case 14:
                        Console.Write(printCorrect(VerticaalA[i], section));
                        break;
                }
            }
        }
        public static void printall(int sec, int x, int y, int comp, Section section) {
            Corner(sec, x , y, comp, section);
        }

        private static string printCorrect(string print, Section section) {
            string Name;
            string changed = print;
            if (section.SectionData.Left is not null)
            {
                Name = section.SectionData.Left.Name;
                changed = print.Replace("*", Name.Remove(1));
            }
            if (section.SectionData.Right is not null) {
                Name = section.SectionData.Right.Name;
                changed = changed.Replace("+", Name.Remove(1));
            }
            changed = changed.Replace("+", " ");
            changed = changed.Replace("*", " ");
            return changed;
        }


        public static void Corner(int sec, int x, int y, int compass, Section section) {
            if (sec == 6 || sec == 8)
            {
                if (compass == 0 && sec == 8)
                {
                    Direction(1, x, y, section);
                }
                if (compass == 1 && sec == 8)
                {
                    Direction(8, x, y, section);
                }
                if (compass == 2 && sec == 8)
                {
                    Direction(9, x, y, section);
                }
                if (compass == 3 && sec == 8)
                {
                    Direction(10, x, y, section);
                }
                if (compass == 0 && sec == 6)
                {
                    Direction(12, x, y, section);
                }
                if (compass == 1 && sec == 6)
                {
                    Direction(6, x, y, section);
                }
                if (compass == 2 && sec == 6)
                {
                    Direction(7, x, y, section);
                }
                if (compass == 3 && sec == 6)
                {
                    Direction(11, x, y, section);
                }
            }
            else if (sec == 2 || sec == 3) {
                if (compass == 1 && sec == 2) {
                    Direction(2, x, y, section);
                }
                if (compass == 3 && sec == 2)
                {
                    Direction(13, x, y, section);
                }
                if (compass == 0 && sec == 3)
                {
                    Direction(3, x, y, section);
                }
                if (compass == 2 && sec == 3)
                {
                    Direction(14, x, y, section);
                }
            }
            else
            {
                Direction(sec, x, y, section);
            }
        }

        //public static void checkCorner(int h, int w)
        //{
        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6)
        //    {
        //        if (w >= 1) {
        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
        //            {
        //                Graphics.Direction(8);
        //            }
        //        }
        //    }
        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8)
        //    {
        //        if (w >= 1)
        //        {
        //            if (!(new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
        //            {
        //                Graphics.Direction(1);
        //            }
        //        } else { Graphics.Direction(1); }
        //    }
        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8)
        //    {
        //        if (w >= 1) {
        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
        //            { 
        //                Graphics.Direction(8);
        //            } 
        //        }
        //    }
        //    if (new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6)
        //    {
        //        if (w >= 1)
        //        {
        //            if (!(new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
        //            {
        //                Graphics.Direction(1);
        //            }
        //        }else { Graphics.Direction(1); }
        //    }
        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6))
        //    {
        //        if (w >= 1)
        //        {
        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
        //            {
        //                Graphics.Direction(6);
        //            }
        //        }
        //    }
        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8))
        //    {
        //        if (w >= 1)
        //        {
        //            if ((!new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
        //            {
        //                Graphics.Direction(7);
        //            }
        //        }
        //        else { Graphics.Direction(7); }
        //    }
        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 8))
        //    {
        //        if (w >= 1)
        //        {
        //            if (new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1]))
        //            {
        //                Graphics.Direction(6);
        //            }
        //        }
        //    }
        //    if ((!new[] { 3, 6, 8 }.Contains(TrackPrint[h + 1, w]) && TrackPrint[h, w] == 6))
        //    {
        //        if (w >= 1)
        //        {
        //            if ((!new[] { 2, 4, 5, 6, 8 }.Contains(TrackPrint[h, w - 1])))
        //            {
        //                Graphics.Direction(7);
        //            }
        //        }
        //        else { Graphics.Direction(7); }
        //    }
        //}

        public static string[] Blank =
        {
            
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              ",
                "              "
            
        };

        public static string[] Links = 
        {
                 " |          | ",
                 "-/          | ",
                 "  *         | ",
                 "            | ",
                 "            / ",
                 "          +/  ",
                 "----------/   ",
                 "              "
            
        };
        public static string[] LinksV =
{
                 " |          | ",
                 " |          \\-",
                 " |         *  ",
                 " |            ",
                 " |            ",
                 " \\+           ",
                 "  \\-----------",
                 "              "

        };
        public static string[] RechtsV =
        {
               "              ",
                "----------\\   ",
                "          *\\  ",
                "            \\ ",
                "            | ",
                "            | ",
                "-\\+         | ",
                " |          | "
            
        };
        public static string[] Rechts =
{
                "              ",
                "   /----------",
                "  /*          ",
                " /            ",
                " |            ",
                " |        +   ",
                " |          /-",
                " |          | "

        };
        public static string[] LinksA =
{
                 " |          | ",
                 "-/          | ",
                 "  +         | ",
                 "            | ",
                 "            / ",
                 "          */  ",
                 "----------/   ",
                 "              "

        };
        public static string[] LinksVA =
{
                 " |          | ",
                 " |          \\-",
                 " |         +  ",
                 " |            ",
                 " |            ",
                 " \\*           ",
                 "  \\-----------",
                 "              "

        };
        public static string[] RechtsVA =
        {
               "              ",
                "----------\\   ",
                "          +\\  ",
                "            \\ ",
                "            | ",
                "            | ",
                "-\\*         | ",
                " |          | "

        };
        public static string[] RechtsA =
{
                "              ",
                "   /----------",
                "  /+          ",
                " /            ",
                " |            ",
                " |        *   ",
                " |          /-",
                " |          | "

        };
        public static string[] Horizontaal =
        {
                "              ",
                "--------------",
                "      *       ",
                "              ",
                "              ",
                "      +       ",
                "--------------",
                "              "
            
        };
        public static string[] Verticaal =
        {
                " |          | ",
                " |          | ",
                " |          | ",
                " |*        +| ",
                " |          | ",
                " |          | ",
                " |          | ",
                " |          | "
            
        };
        public static string[] HorizontaalA =
{
                "              ",
                "--------------",
                "      +       ",
                "              ",
                "              ",
                "      *       ",
                "--------------",
                "              "

        };
        public static string[] VerticaalA =
        {
                " |          | ",
                " |          | ",
                " |          | ",
                " |+        *| ",
                " |          | ",
                " |          | ",
                " |          | ",
                " |          | "

        };
        public static string[] Start =
        {
                "              ",
                "--------------",
                "       *      ",
                "              ",
                "              ",
                "       +      ",
                "--------------",
                "              "
            
        };
        public static string[] Finish =
        {
                "              ",
                "----------#---",
                "       *  #   ",
                "          #   ",
                "          #   ",
                "       +  #   ",
                "----------#---",
                "              "
            
        };
    }
}
