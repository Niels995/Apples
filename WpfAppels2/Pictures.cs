using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing.Bitmap;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;

namespace WPFAppels
{
    internal static class Pictures
    {
        private static Dictionary<string, Bitmap> Images = new Dictionary<string, Bitmap>();

        public static Bitmap AddImage(string namefile) {
            if (Images.ContainsKey(namefile))
            {
                return Images[namefile];
            }
            else {
                Bitmap newBitmap = new Bitmap(namefile);
                Images.Add(namefile, newBitmap);
                return newBitmap;
            }
        }
        public static void ClearImages() {
            Images.Clear();
        }

        public static Bitmap setBitmap(int x, int y) {
            return new Bitmap(x, y);
        }

        public static Bitmap GenerateBitmap(int width, int height)
        {
            if (!Images.ContainsKey("empty"))
            {
                Bitmap bmp = new Bitmap(width, height);
                Images.Add("empty", bmp);
            }

            return (Bitmap) Images["empty"].Clone();
        }

        public static BitmapSource CreateBitmapSourceFromGdiBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        //public static Bitmap GetPlayer(TeamColors tc, SectionTypes st)
        //{
        //    if (st == SectionTypes.LeftCorner || st == SectionTypes.RightCorner)
        //    {
        //        return GetImageBitmap(@$".\Graphics\Scaled\Cars\Corner\car_{tc.ToString().ToLower()}.png");
        //    }

        //    return GetImageBitmap(@$".\Graphics\Scaled\Cars\Straight\car_{tc.ToString().ToLower()}.png");
        //}

        //public static Bitmap GetBrokenPlayer(SectionTypes st)
        //{
        //    if (st == SectionTypes.LeftCorner || st == SectionTypes.RightCorner)
        //    {
        //        return GetImageBitmap(@".\Graphics\Scaled\Cars\Corner\car_broken.png");
        //    }

        //    return GetImageBitmap(@".\Graphics\Scaled\Cars\Straight\car_broken.png");
        //}
    }
}
