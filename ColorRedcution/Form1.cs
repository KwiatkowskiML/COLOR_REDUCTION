using System.Windows.Forms;

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
    }
}
