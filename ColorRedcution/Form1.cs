using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ColorRedcution
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap modifiedImage;

        public Form1()
        {
            InitializeComponent();
            originalImage = new Bitmap(Properties.Resources.dog1);
            modifiedImage = new Bitmap(originalImage.Width, originalImage.Height);
            modifiedImagePictureBox.Image = modifiedImage;
            originalImagePictureBox.Image = originalImage;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            int kr = (int)numKr.Value;
            int kg = (int)numKg.Value;
            int kb = (int)numKb.Value;
            int k = (int)numK.Value;

            if (radioPopularityAlgorithm.Checked)
            {
                modifiedImage = PopularityAlgorithm.QuantizeColors(originalImage, k);
                modifiedImagePictureBox.Image = modifiedImage;
                return;
            }

            IColorReducer reducer;

            if (radioAverageDithering.Checked)
                reducer = new AverageDithering();
            else if (radioOrderedDitheringRelative.Checked)
                reducer = new OrderedDitheringRelative();
            else if (radioOrderedDitheringRandom.Checked)
                reducer = new OrderedDitheringRandom();
            else if (radioErrorDiffusionDithering.Checked)
                reducer = new ErrorDifussionDithering();
            else
                reducer = new AverageDithering();

            modifiedImage = reducer.GetReducedBitmap(originalImage, kr, kg, kb);
            modifiedImagePictureBox.Image = modifiedImage;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PNG file|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    originalImage = new Bitmap(filePath);
                    originalImagePictureBox.Image = originalImage;
                }
            }    
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG file|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        modifiedImage.Save(fs, ImageFormat.Jpeg);
                        break;

                    case 2:
                        modifiedImage.Save(fs, ImageFormat.Bmp);
                        break;

                    case 3:
                        modifiedImage.Save(fs, ImageFormat.Png);
                        break;
                }

                fs.Close();
            }
        }

        private Bitmap GenerateBitmap(int numberOfStripes)
        {
            Bitmap bmp = new Bitmap(originalImage.Width, originalImage.Height);

            int stripeWidth = bmp.Width / 8;
            int stripeStart = 0;
            for (int stripe = 0; stripe < numberOfStripes; stripe++)
            {
                for (int i = stripeStart; i < stripeWidth + stripeStart; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
                stripeStart += stripeWidth;
                for (int i = stripeStart; i < stripeStart + stripeWidth; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        bmp.SetPixel(i, j, Color.White);
                    }
                }
                stripeStart += stripeWidth;
                stripeWidth /= 2;
            }

            int hslWidth = bmp.Width - stripeStart;
            int hslStart = stripeStart;

            for (int i = 0; i < hslWidth; i++)
            {
                double hue = ((double)i / (double)hslWidth) * 360.0;
                for (int j = 0; j < bmp.Height; j++)
                {
                    double sat = 1 - ((double)j / (double)bmp.Height);
                    Color col = ColorFromHSV(hue, sat, 1);
                    bmp.SetPixel(i + hslStart, j, col);
                }
            }

            return bmp;
        }

        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            originalImage = GenerateBitmap(10);
            originalImagePictureBox.Image = originalImage;
        }
    }
}
