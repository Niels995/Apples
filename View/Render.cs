using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Controller;
using Model;

namespace WPFAppels
{
    internal static class Render
    {
        //public static BitmapSource DrawTrack(Track track)
        //{
        //    Bitmap bm = Pictures.GenerateBitmap(2, 2);
        //    return Pictures.CreateBitmapSourceFromGdiBitmap(bm);
        //}

        private static int _direction;

        private const int TileSize = 70;
        private const int CarSize = 7;

        #region ImagesLoad
        public const string Horizontal = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\Horizontaal.png";
        public const string Vertical = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\Verticaal.png";
        public const string StartGrid = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\Start.png";
        public const string Finish = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\Finish.png";
        public const string Left = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\RechtsHAVA.png";
        public const string Right = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\RechtsHV.png";

        public const string Red = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\HRed.png";
        public const string Green = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\HGreen.png";
        public const string Blue = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\HBlue.png";
        public const string Yellow = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\HYellow.png";
        public const string Grey = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\HGrey.png";

        public const string Pech = "C:\\Users\\niels\\source\\repos\\Apples\\View\\Images\\Pech.png";
        #endregion
        //#region Graphics

        //private const string TrackStraight = @".\Graphics\Scaled\Track\track_straight.png";
        //private const string TrackStart = @".\Graphics\Scaled\Track\track_start.png";
        //private const string TrackFinish = @".\Graphics\Scaled\Track\track_finish.png";
        //private const string TrackCornerLeft = @".\Graphics\Scaled\Track\track_corner_left.png";
        //private const string TrackCornerRight = @".\Graphics\Scaled\Track\track_corner_right.png";

        //#endregion

        public static BitmapSource DrawTrack(Track track)
        {
            // init the bitmap
            int[] sectionGrid = new int[128]; //TrackSimulator.SimulateTrack(track);

            int width = TileSize * sectionGrid[0];
            int height = TileSize * sectionGrid[1];

            Bitmap? bmp = Pictures.GenerateBitmap(2, 2);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bmp!);

            // start position to render from
            int x = sectionGrid[2] + 2;
            int y = sectionGrid[3] + 2;

            // draw track sections
            foreach (Section section in track.Sections)
            {
                _direction = section.Compass;
                string imageUrl;
                switch (section.SectionType)
                {
                    case SectionTypes.StartGrid:
                        imageUrl = StartGrid;
                        break;
                    case SectionTypes.Finish:
                        imageUrl = Finish;
                        break;
                    case SectionTypes.Straight:
                        imageUrl = Horizontal;
                        break;
                    case SectionTypes.LeftCorner:
                        imageUrl = Left;
                        break;
                    case SectionTypes.RightCorner:
                        imageUrl = Right;
                        break;
                    case SectionTypes.Vertical:
                        imageUrl = Vertical;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Bitmap? trackImage = Pictures.AddImage(imageUrl);
                System.Drawing.Graphics trackGraphics = System.Drawing.Graphics.FromImage(trackImage!);

                // get section data for current section
                SectionData sectionData = Data.CurrentRace.GetSectionData(section);

                // draw the players, if any
                if (sectionData.Left != null)
                {
                    IParticipant player = sectionData.Left;
                    Bitmap? playerImage = Pictures.GetPlayer(player.Teamcolors, section.SectionType);

                    if (player.Equipment.IsBroken)
                    {
                        playerImage = Pictures.GetBrokenPlayer(section.SectionType);
                    }

                    if (section.SectionType == SectionTypes.LeftCorner)
                    {
                        playerImage?.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }

                    switch (section.SectionType)
                    {
                        case SectionTypes.LeftCorner:
                            trackGraphics.DrawImage(playerImage!, 0, 0, CarSize, CarSize);
                            break;
                        case SectionTypes.RightCorner:
                            trackGraphics.DrawImage(playerImage!, CarSize / 2, CarSize / 2, CarSize, CarSize);
                            break;
                        case SectionTypes.Straight:
                        case SectionTypes.StartGrid:
                        case SectionTypes.Finish:
                        default:
                            trackGraphics.DrawImage(playerImage!, CarSize / 2, 0, CarSize, CarSize);
                            break;
                    }
                }

                if (sectionData.Right != null)
                {
                    IParticipant player = sectionData.Right;
                    Bitmap? playerImage = Pictures.GetPlayer(player.Teamcolors, section.SectionType);

                    if (player.Equipment.IsBroken)
                    {
                        playerImage = Pictures.GetBrokenPlayer(section.SectionType);
                    }

                    switch (section.SectionType)
                    {
                        case SectionTypes.LeftCorner:
                            playerImage?.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            trackGraphics.DrawImage(playerImage!, CarSize / 2, CarSize / 2, CarSize, CarSize);
                            break;
                        case SectionTypes.RightCorner:
                            trackGraphics.DrawImage(playerImage!, 0, CarSize, CarSize, CarSize);
                            break;
                        case SectionTypes.Straight:
                        case SectionTypes.StartGrid:
                        case SectionTypes.Finish:
                        default:
                            trackGraphics.DrawImage(playerImage!, CarSize / 2, CarSize, CarSize, CarSize);
                            break;
                    }
                }

                switch (_direction)
                {
                    case 0:
                        trackImage?.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case 3:
                        trackImage?.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 2:
                        trackImage?.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 1:
                        trackImage?.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                graphics.DrawImage(trackImage!, 2 * TileSize, 2 * TileSize, TileSize, TileSize);

                // set direction for next track piece
                //_direction = TrackSimulator.SimulateSection(section, _direction);

                // adjust the x & y coordinates
                switch (_direction)
                {
                    case 0:
                        y--;
                        break;
                    case 3:
                        x--;
                        break;
                    case 2:
                        y++;
                        break;
                    case 1:
                        x++;
                        break;
                }
            }

            // return full track
            return Pictures.CreateBitmapSourceFromGdiBitmap(bmp!);
        }
    }
}
