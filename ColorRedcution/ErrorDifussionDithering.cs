using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRedcution
{
    public class ErrorDifussionDithering : Dither, IColorReducer
    {
        private float[,] filter = {
            { 0.0f, 0.0f, 0.0f },
            { 0.0f, 0.0f, 7.0f / 16.0f },
            { 3.0f / 16.0f, 5.0f / 16.0f, 1.0f / 16.0f}
        };

        public Bitmap GetReducedBitmap(Bitmap originalImage, int kr, int kg, int kb)
        {
            Bitmap modifiedImage = new Bitmap(originalImage);
            float[] coefsR = FindCoefs(kr);
            float[] coefsG = FindCoefs(kg);
            float[] coefsB = FindCoefs(kb);

            int fx = filter.GetLength(0) / 2;
            int fy = filter.GetLength(1) / 2;

            for (int x = 0; x < modifiedImage.Width; x++)
            {
                for (int y = 0; y < modifiedImage.Height; y++)
                {
                    Color originalColor = modifiedImage.GetPixel(x, y);

                    int redComponent = GetClosestColor(originalColor.R, coefsR);
                    int greenComponent = GetClosestColor(originalColor.G, coefsG);
                    int blueComponent = GetClosestColor(originalColor.B, coefsB);

                    int errorR = originalColor.R - redComponent;
                    int errorG = originalColor.G - greenComponent;
                    int errorB = originalColor.B - blueComponent;

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);

                    for (int i = -fx; i <= fx; i++)
                    {
                        for (int j = -fy; j <= fy; j++)
                        {
                            if (x + i < 0 || y + j < 0 || x + i >= modifiedImage.Width || y + j >= modifiedImage.Height)
                                continue;

                            if (filter[i + fx, j + fy] == 0)
                                continue;

                            Color color = modifiedImage.GetPixel(x + i, y + j);

                            int red = color.R + (int)(errorR * filter[i + fx, j + fy]);
                            int green = color.G + (int)(errorG * filter[i + fx, j + fy]);
                            int blue = color.B + (int)(errorB * filter[i + fx, j + fy]);

                            Color newColor = Color.FromArgb(Clip(red, 0, 255), Clip(green, 0, 255), Clip(blue, 0, 255));
                            modifiedImage.SetPixel(x + i, y + j, newColor);
                        }
                    }
                }
            }

            return modifiedImage;
        }

        private int Clip(int value, int lowerBound, int upperBound)
        {
            return Math.Max(Math.Min(value, upperBound), lowerBound);
        }
    }
}
