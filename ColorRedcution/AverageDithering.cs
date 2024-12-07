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
            // Create a new bitmap to store the modified image
            Bitmap modifiedImage = new Bitmap(image.Width, image.Height);

            // Iterate through each pixel in the image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Get the original pixel color
                    Color originalColor = image.GetPixel(x, y);

                    // Apply average dithering to each color component
                    byte redComponent = (byte)AverageDitherComponent(originalColor.R, kr);
                    byte greenComponent = (byte)AverageDitherComponent(originalColor.G, kg);
                    byte blueComponent = (byte)AverageDitherComponent(originalColor.B, kb);

                    // Create the modified pixel color
                    Color modifiedColor = Color.FromArgb(originalColor.A, redComponent, greenComponent, blueComponent);

                    // Set the modified pixel in the new bitmap
                    modifiedImage.SetPixel(x, y, modifiedColor);
                }
            }

            return modifiedImage;
        }

        private int AverageDitherComponent(int component, int k)
        {
            // Calculate the number of discrete levels for the color component
            int levels = 256 / k;

            // Calculate the average dithered value for the component
            return (component / levels) * levels + levels / 2;
        }
    }
}
