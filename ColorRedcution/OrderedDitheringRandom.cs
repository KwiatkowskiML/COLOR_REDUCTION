using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ColorRedcution
{
    public class OrderedDitheringRandom : OrderedDithering, IColorReducer
    {
        public Bitmap GetReducedBitmap(Bitmap originalImage, int kr, int kg, int kb)
        {
            int nr = FindSmallestN(kr);
            int ng = FindSmallestN(kg);
            int nb = FindSmallestN(kb);

            int[,] bayerR = GetBayersMatrix(nr);
            int[,] bayerG = GetBayersMatrix(ng);
            int[,] bayerB = GetBayersMatrix(nb);

            Bitmap modifiedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    byte redComponent = (byte)GetColorRandom(originalColor.R, kr, nr, bayerR);
                    byte greenComponent = (byte)GetColorRandom(originalColor.G, kg, ng, bayerG);
                    byte blueComponent = (byte)GetColorRandom(originalColor.B, kb, nb, bayerB);

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }
    }
}
