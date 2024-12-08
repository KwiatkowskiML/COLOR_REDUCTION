using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRedcution
{
    public class AverageDithering : Dither, IColorReducer
    {
        public Bitmap GetReducedBitmap(Bitmap image, int kr, int kg, int kb)
        {
            Bitmap modifiedImage = new Bitmap(image.Width, image.Height);
            float[] coefsR = FindCoefs(kr);
            float[] coefsG = FindCoefs(kg);
            float[] coefsB = FindCoefs(kb);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    byte redComponent = (byte)GetClosestColor(originalColor.R, coefsR);
                    byte greenComponent = (byte)GetClosestColor(originalColor.G, coefsG);
                    byte blueComponent = (byte)GetClosestColor(originalColor.B, coefsB);

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }
    }
}
