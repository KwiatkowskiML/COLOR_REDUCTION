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

            float[] coefsR = FindCoefs(kr);
            float[] coefsG = FindCoefs(kg);
            float[] coefsB = FindCoefs(kb);

            Bitmap modifiedImage = new Bitmap(originalImage.Width, originalImage.Height);
            Random random = new Random();

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int redComponent;
                    int greenComponent;
                    int blueComponent;

                    if (kr == 2)
                    {
                        if (originalColor.R > bayerR[random.Next(nr), random.Next(nr)])
                            redComponent = 255;
                        else
                            redComponent = 0;
                    }
                    else
                        redComponent = GetClosestColor(int.Min(originalColor.R + bayerR[random.Next(nr), random.Next(nr)], 255), coefsR);

                    if (kg == 2)
                    {
                        if (originalColor.G > bayerG[random.Next(ng), random.Next(ng)])
                            greenComponent = 255;
                        else
                            greenComponent = 0;
                    }
                    else
                        greenComponent = GetClosestColor(int.Min(originalColor.G + bayerG[random.Next(ng), random.Next(ng)], 255), coefsG);

                    if (kb == 2)
                    {
                        if (originalColor.B > bayerB[random.Next(nb), random.Next(nb)])
                            blueComponent = 255;
                        else
                            blueComponent = 0;
                    }
                    else
                        blueComponent = GetClosestColor(int.Min(originalColor.B + bayerB[random.Next(nb), random.Next(nb)], 255), coefsB);

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }
    }
}
