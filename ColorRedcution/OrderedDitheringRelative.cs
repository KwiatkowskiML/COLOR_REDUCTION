using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ColorRedcution
{
    public class OrderedDitheringRelative : OrderedDithering, IColorReducer
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

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    byte redComponent = (byte)GetColorRelative2(int.Min(originalColor.R + bayerR[x % nr, y % nr], 255), coefsR);
                    byte greenComponent = (byte)GetColorRelative2(int.Min(originalColor.G + bayerG[x % ng, y % ng], 255), coefsG);
                    byte blueComponent = (byte)GetColorRelative2(int.Min(originalColor.B + bayerB[x % nb, y % nb], 255), coefsB);

                    Color modifiedColor = Color.FromArgb(redComponent, greenComponent, blueComponent);
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }    

        protected int GetColorRelative2(int color, float[] coefs)
        {
            if (color >= 255)
                return 255;
            if (color <= 0)
                return 0;

            float finalColor;
            float coef = color / 255.0f;

            int left = 0;
            int right = coefs.Length - 1;

            if (coef <= coefs[0])
            {
                return (int)(coefs[0] * 255);
            }

            if (coef >= coefs[right])
            {
                return (int)(coefs[right] * 255);
            }

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (coefs[mid] == coef)
                {
                    return (int)(coefs[mid] * 255);
                }

                if (coef < coefs[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            finalColor = (Math.Abs(coefs[left] - coef) <= Math.Abs(coefs[left - 1] - coef)) ? coefs[left] : coefs[left - 1];

            return (int)(finalColor * 255);
        }
    }
}
