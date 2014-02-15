using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Test
{
    internal class Program
    {
        private const int SpiSetdeskwallpaper = 20;
        private const int SpifUpdateinifile = 0x01;
        private const int SpiGetdeskwallpaper = 0x73;
        private const int MaxPath = 260;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);


        private static void Main(string[] args)
        {
            Size sr = Screen.PrimaryScreen.WorkingArea.Size;
            string path = GetCurrentDesktopWallpaper();
            var bmp = new Bitmap(path);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                var stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near; // Not necessary here
                var font2 = new Font(new FontFamily("Agency FB"), 20, FontStyle.Bold);
//                var font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point);
                g.DrawString("hôm nay phải nghiên cứu entiy farm word", font2, Brushes.White,
                    new RectangleF(bmp.Width/2 - sr.Width/2, bmp.Height/2 - sr.Height/2, sr.Width, sr.Height),
                    stringFormat);
            }
            bmp.Save("D:/test.bmp", ImageFormat.Bmp);
            SystemParametersInfo(
                SpiSetdeskwallpaper,
                0,
                "D:/test.bmp",
                SpifUpdateinifile
                );
            Console.WriteLine("Done !. Press any key to continute... ");
            Console.ReadKey();
        }

        public static string GetCurrentDesktopWallpaper()
        {
            var currentWallpaper = new string('\0', MaxPath);
            SystemParametersInfo(SpiGetdeskwallpaper, currentWallpaper.Length, currentWallpaper, 0);
            return currentWallpaper.Substring(0, currentWallpaper.IndexOf('\0'));
        }
    }
}