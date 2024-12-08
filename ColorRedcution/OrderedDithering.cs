using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRedcution
{
    public class OrderedDithering
    {
        protected int FindSmallestN(int k)
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

        protected int[,] GetBayersMatrix(int n)
        {
            int[,] bayerMatrix = new int[n, n];

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

            int[,] smallerMatrix = GetBayersMatrix(n / 2);

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    bayerMatrix[i, j] = 4 * smallerMatrix[i, j];
                }
            }

            for (int i = n / 2; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    bayerMatrix[i, j] = (4 * smallerMatrix[i - n / 2, j] + 2);
                }
            }

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = n / 2; j < n; j++)
                {
                    bayerMatrix[i, j] = (4 * smallerMatrix[i, j - n / 2] + 3);
                }
            }

            for (int i = n / 2; i < n; i++)
            {
                for (int j = n / 2; j < n; j++)
                {
                    bayerMatrix[i, j] = (4 * smallerMatrix[i - n / 2, j - n / 2] + 1);
                }
            }

            return bayerMatrix;
        }
        protected int GetColorRelative(int component, int k, int n, int x, int y, int[,] bayersMatrix)
        {
            int step = 255 / (k - 1);
            int level = 255 / k;
            int val = bayersMatrix[x % n, y % n];
            int newColor = ((component + val) / level) * step;
            return newColor;
        }

        protected int GetColorRandom(int component, int k, int n, int[,] bayersMatrix)
        {
            Random random = new Random();

            int step = 255 / (k - 1);
            int level = 255 / k;
            int val = bayersMatrix[random.Next(n), random.Next(n)];
            int newColor = ((component + val) / level) * step;
            return newColor;
        }
    }
}
