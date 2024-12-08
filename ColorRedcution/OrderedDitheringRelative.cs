using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ColorRedcution
{
    public class OrderedDitheringRelative : IColorReducer
    {
        public Bitmap GetReducedBitmap(Bitmap originalImage, int kr, int kg, int kb)
        {
            int nr = FindSmallestN(kr);
            int ng = FindSmallestN(kg);
            int nb = FindSmallestN(kb);

            float[,] bayerR = GetBayersMatrix(nr);
            float[,] bayerG = GetBayersMatrix(ng);
            float[,] bayerB = GetBayersMatrix(nb);

            Bitmap modifiedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    byte redComponent = (byte)GetColor2(originalColor.R, kr, nr, x, y, bayerR);
                    byte greenComponent = (byte)GetColor2(originalColor.G, kg, ng, x, y, bayerG);
                    byte blueComponent = (byte)GetColor2(originalColor.B, kb, nb, x, y, bayerB);

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }

        int GetColor1(int component, int n, int x, int y, float[,] bayersMatrix)
        {
            int col = component / (n * n);
            int re = component % (n * n);
            int i = x % n;
            int j = y % n;
            if (re > bayersMatrix[i, j])
                col++;

            return col;
        }

        private int GetColor2(int component, int k, int n, int x, int y, float[,] bayersMatrix)
        {
            int step = 255 / (k - 1);
            int level = 255 / k;
            int newColor = (component / level) * step;

            float matrixValue = bayersMatrix[x % n, y % n];
            if (component > newColor * matrixValue)
                newColor = (byte)(newColor + 1);

            return newColor;
        }

        private int FindSmallestN(int k)
        {
            int[] possibleValues = { 2, 3, 4, 6, 8, 12, 16 };
            double threshold = 256.0 / (k - 1);

            for (int i = 0; i < possibleValues.Length; i++)
            {
                if (Math.Pow(possibleValues[i], 2) >= threshold)
                {
                    return possibleValues[i];
                }
            }

            return -1;
        }

        private float[,] GetBayersMatrix(int n)
        {
            float[,] bayerMatrix = new float[n, n];

            if (n == 2)
            {
                bayerMatrix[0, 0] = 0;
                bayerMatrix[0, 1] = 2;
                bayerMatrix[1, 0] = 3;
                bayerMatrix[1, 1] = 1;
                return bayerMatrix;
            }

            if (n == 3)
            {
                bayerMatrix[0, 0] = 6;
                bayerMatrix[0, 1] = 8;
                bayerMatrix[0, 2] = 4;
                bayerMatrix[1, 0] = 1;
                bayerMatrix[1, 1] = 0;
                bayerMatrix[1, 2] = 3;
                bayerMatrix[2, 0] = 5;
                bayerMatrix[2, 1] = 2;
                bayerMatrix[2, 2] = 7;
                return bayerMatrix;
            }

            float[,] smallerMatrix = GetBayersMatrix(n/2);

            for (int i = 0; i < n/2; i++)
            {
                for (int j = 0; j < n/2; j++)
                {
                    bayerMatrix[i, j] = 4 * smallerMatrix[i, j] / (n * n);
                }
            }

            for (int i = n/2; i < n; i++)
            {
                for (int j = 0; j < n/2; j++)
                {
                    bayerMatrix[i, j] = (4 * smallerMatrix[i - n/2, j] + 2) / (n * n);
                }
            }

            for (int i = 0; i < n/2; i++)
            {
                for (int j = n/2; j < n; j++)
                {
                    bayerMatrix[i, j] = (4 * smallerMatrix[i, j - n/2] + 3) / (n * n);
                }
            }

            for (int i = n/2; i < n; i++)
            {
                for (int j = n/2; j < n; j++)
                {
                    bayerMatrix[i, j] = (4 * smallerMatrix[i - n / 2, j - n / 2] + 1) / (n * n);
                }
            }

            return bayerMatrix;
        }
    }
}
