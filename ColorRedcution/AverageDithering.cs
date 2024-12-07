using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRedcution
{
    public class AverageDithering : IColorReducer
    {
        public Bitmap GetReducedBitmap(Bitmap image, int kr, int kg, int kb)
        {
            Bitmap modifiedImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    byte redComponent = (byte)AverageDitherComponent(originalColor.R, kr);
                    byte greenComponent = (byte)AverageDitherComponent(originalColor.G, kg);
                    byte blueComponent = (byte)AverageDitherComponent(originalColor.B, kb);

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }

        private int AverageDitherComponent(int component, int k)
        {
            int step = 255 / (k - 1);
            int level = 255 / k;
            return (component / level) * step;
        }
    }
}
