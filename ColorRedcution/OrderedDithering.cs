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

        protected float[] FindCoefs(int k)
        {
            float[] coefs = new float[k];
            float delta = 1.0f / (k - 1);

            for (int i = 0; i < k; i++)
                coefs[i] = delta * i;

            return coefs;
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
        protected int GetClostestColor(int color, float[] coefs)
        {
            if (color >= 255)
                return 255;
            if (color <= 0)
                return 0;

            float finalColor;
            float coef = color / 255.0f;

            int i = 0;
            while (i < coefs.Length - 1 && coef > coefs[i + 1])
            {
                i++;
            }

            finalColor = (Math.Abs(coefs[i] - coef) <= Math.Abs(coefs[i + 1] - coef)) ? coefs[i] : coefs[i + 1];

            return (int)(finalColor * 255);
        }
    }
}
