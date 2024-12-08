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
            Bitmap modifiedImage = new Bitmap(originalImage.Width, originalImage.Height);
            float[] coefsR = FindCoefs(kr);
            float[] coefsG = FindCoefs(kg);
            float[] coefsB = FindCoefs(kb);

            int[,,] errors = new int[originalImage.Width, originalImage.Height, 3];
            int[,,] colors = new int[originalImage.Width, originalImage.Height, 3];

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    int redComponent = GetClosestColor(originalColor.R, coefsR);
                    int greenComponent = GetClosestColor(originalColor.G, coefsG);
                    int blueComponent = GetClosestColor(originalColor.B, coefsB);

                    errors[x, y, 0] = originalColor.R - redComponent;
                    errors[x, y, 1] = originalColor.G - greenComponent;
                    errors[x, y, 2] = originalColor.B - blueComponent;

                    colors[x, y, 0] += redComponent;
                    colors[x, y, 1] += greenComponent;
                    colors[x, y, 2] += blueComponent;

                    ApplyFilter(x, y, originalImage.Width, originalImage.Height, errors, colors);
                }
            }

            for (int x = 0; x < modifiedImage.Width; x++)
            {
                for (int y = 0; y < modifiedImage.Height; y++)
                {
                    Color modifiedColor = Color.FromArgb(Clip(colors[x, y, 0], 0, 255), 
                        Clip(colors[x, y, 1], 0, 255), 
                        Clip(colors[x, y, 2], 0, 255));
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }

        private void ApplyFilter(int x, int y, int width, int height, int[,,] errors, int[,,] colors)
        {
            int fx = filter.GetLength(0) / 2;
            int fy = filter.GetLength(1) / 2;

            for (int i = -fx; i <= fx; i++)
            {
                for (int j = -fy; j <= fy; j++)
                {
                    if (x + i < 0 || y + j < 0 || x + i >= width || y + j >= height)
                        continue;

                    colors[x + i, y + j, 0] += (int)(errors[x, y, 0] * filter[i + fx, j + fy]);
                    colors[x + i, y + j, 1] += (int)(errors[x, y, 1] * filter[i + fx, j + fy]);
                    colors[x + i, y + j, 2] += (int)(errors[x, y, 2] * filter[i + fx, j + fy]);
                }
            }
        }

        private int Clip(int value, int lowerBound, int upperBound)
        {
            return Math.Max(Math.Min(value, upperBound), lowerBound);
        }
    }
}
