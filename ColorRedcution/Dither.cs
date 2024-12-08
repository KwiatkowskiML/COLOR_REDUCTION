using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRedcution
{
    public class Dither
    {
        protected int GetClosestColor(int color, float[] coefs)
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

        protected float[] FindCoefs(int k)
        {
            float[] coefs = new float[k];
            float delta = 1.0f / (k - 1);

            for (int i = 0; i < k; i++)
                coefs[i] = delta * i;

            return coefs;
        }
    }
}
