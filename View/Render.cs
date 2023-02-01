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
        public static BitmapSource DrawTrack(Track track)
        {
            Bitmap bm = Pictures.GenerateBitmap(2, 2);
            return Pictures.CreateBitmapSourceFromGdiBitmap(bm);
        }
    }
}
