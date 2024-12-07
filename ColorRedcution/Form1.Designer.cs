namespace ColorRedcution
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            popularityAlgorithmParams = new GroupBox();
            numK = new NumericUpDown();
            label4 = new Label();
            ditheringParamsGroupBox = new GroupBox();
            numKb = new NumericUpDown();
            numKg = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            numKr = new NumericUpDown();
            algorithmsGroupBox = new GroupBox();
            refreshButton = new Button();
            radioPopularityAlgorithm = new RadioButton();
            radioOrderedDitheringRelative = new RadioButton();
            radioOrderedDitheringRandom = new RadioButton();
            radioErrorDiffusionDithering = new RadioButton();
            radioAverageDithering = new RadioButton();
            menuLabel = new Label();
            originalImageLabel = new Label();
            modifiedImageLabel = new Label();
            originalImagePictureBox = new PictureBox();
            modifiedImagePictureBox = new PictureBox();
            popularityAlgorithmParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numK).BeginInit();
            ditheringParamsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKr).BeginInit();
            algorithmsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)originalImagePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)modifiedImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // popularityAlgorithmParams
            // 
            popularityAlgorithmParams.Controls.Add(numK);
            popularityAlgorithmParams.Controls.Add(label4);
            popularityAlgorithmParams.Location = new Point(12, 326);
            popularityAlgorithmParams.Name = "popularityAlgorithmParams";
            popularityAlgorithmParams.Size = new Size(192, 66);
            popularityAlgorithmParams.TabIndex = 3;
            popularityAlgorithmParams.TabStop = false;
            popularityAlgorithmParams.Text = "Popularity algorithm params";
            // 
            // numK
            // 
            numK.Location = new Point(37, 28);
            numK.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numK.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numK.Name = "numK";
            numK.Size = new Size(120, 23);
            numK.TabIndex = 1;
            numK.Value = new decimal(new int[] { 1015, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 30);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 0;
            label4.Text = "K";
            // 
            // ditheringParamsGroupBox
            // 
            ditheringParamsGroupBox.Controls.Add(numKb);
            ditheringParamsGroupBox.Controls.Add(numKg);
            ditheringParamsGroupBox.Controls.Add(label3);
            ditheringParamsGroupBox.Controls.Add(label2);
            ditheringParamsGroupBox.Controls.Add(label1);
            ditheringParamsGroupBox.Controls.Add(numKr);
            ditheringParamsGroupBox.Location = new Point(12, 211);
            ditheringParamsGroupBox.Name = "ditheringParamsGroupBox";
            ditheringParamsGroupBox.Size = new Size(192, 109);
            ditheringParamsGroupBox.TabIndex = 2;
            ditheringParamsGroupBox.TabStop = false;
            ditheringParamsGroupBox.Text = "Dithering params";
            // 
            // numKb
            // 
            numKb.Location = new Point(37, 78);
            numKb.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numKb.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numKb.Name = "numKb";
            numKb.Size = new Size(120, 23);
            numKb.TabIndex = 5;
            numKb.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numKg
            // 
            numKg.Location = new Point(37, 51);
            numKg.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numKg.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numKg.Name = "numKg";
            numKg.Size = new Size(120, 23);
            numKg.TabIndex = 4;
            numKg.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 3;
            label3.Text = "Kb";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 51);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 2;
            label2.Text = "Kg";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 1;
            label1.Text = "Kr";
            label1.Click += label1_Click;
            // 
            // numKr
            // 
            numKr.Location = new Point(37, 23);
            numKr.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numKr.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numKr.Name = "numKr";
            numKr.Size = new Size(120, 23);
            numKr.TabIndex = 0;
            numKr.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // algorithmsGroupBox
            // 
            algorithmsGroupBox.Controls.Add(refreshButton);
            algorithmsGroupBox.Controls.Add(radioPopularityAlgorithm);
            algorithmsGroupBox.Controls.Add(radioOrderedDitheringRelative);
            algorithmsGroupBox.Controls.Add(radioOrderedDitheringRandom);
            algorithmsGroupBox.Controls.Add(radioErrorDiffusionDithering);
            algorithmsGroupBox.Controls.Add(radioAverageDithering);
            algorithmsGroupBox.Location = new Point(12, 27);
            algorithmsGroupBox.Name = "algorithmsGroupBox";
            algorithmsGroupBox.Size = new Size(192, 178);
            algorithmsGroupBox.TabIndex = 1;
            algorithmsGroupBox.TabStop = false;
            algorithmsGroupBox.Text = "Algorithms";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(6, 147);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(180, 23);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // radioPopularityAlgorithm
            // 
            radioPopularityAlgorithm.AutoSize = true;
            radioPopularityAlgorithm.Location = new Point(6, 122);
            radioPopularityAlgorithm.Name = "radioPopularityAlgorithm";
            radioPopularityAlgorithm.Size = new Size(134, 19);
            radioPopularityAlgorithm.TabIndex = 4;
            radioPopularityAlgorithm.TabStop = true;
            radioPopularityAlgorithm.Text = "Popularity algorithm";
            radioPopularityAlgorithm.UseVisualStyleBackColor = true;
            // 
            // radioOrderedDitheringRelative
            // 
            radioOrderedDitheringRelative.AutoSize = true;
            radioOrderedDitheringRelative.Location = new Point(6, 97);
            radioOrderedDitheringRelative.Name = "radioOrderedDitheringRelative";
            radioOrderedDitheringRelative.Size = new Size(160, 19);
            radioOrderedDitheringRelative.TabIndex = 3;
            radioOrderedDitheringRelative.TabStop = true;
            radioOrderedDitheringRelative.Text = "Ordered dithering relative";
            radioOrderedDitheringRelative.UseVisualStyleBackColor = true;
            // 
            // radioOrderedDitheringRandom
            // 
            radioOrderedDitheringRandom.AutoSize = true;
            radioOrderedDitheringRandom.Location = new Point(6, 72);
            radioOrderedDitheringRandom.Name = "radioOrderedDitheringRandom";
            radioOrderedDitheringRandom.Size = new Size(164, 19);
            radioOrderedDitheringRandom.TabIndex = 2;
            radioOrderedDitheringRandom.TabStop = true;
            radioOrderedDitheringRandom.Text = "Ordered dithering random";
            radioOrderedDitheringRandom.UseVisualStyleBackColor = true;
            // 
            // radioErrorDiffusionDithering
            // 
            radioErrorDiffusionDithering.AutoSize = true;
            radioErrorDiffusionDithering.Location = new Point(6, 47);
            radioErrorDiffusionDithering.Name = "radioErrorDiffusionDithering";
            radioErrorDiffusionDithering.Size = new Size(151, 19);
            radioErrorDiffusionDithering.TabIndex = 1;
            radioErrorDiffusionDithering.TabStop = true;
            radioErrorDiffusionDithering.Text = "Error diffusion dithering";
            radioErrorDiffusionDithering.UseVisualStyleBackColor = true;
            // 
            // radioAverageDithering
            // 
            radioAverageDithering.AutoSize = true;
            radioAverageDithering.Location = new Point(6, 22);
            radioAverageDithering.Name = "radioAverageDithering";
            radioAverageDithering.Size = new Size(119, 19);
            radioAverageDithering.TabIndex = 0;
            radioAverageDithering.TabStop = true;
            radioAverageDithering.Text = "Average dithering";
            radioAverageDithering.UseVisualStyleBackColor = true;
            // 
            // menuLabel
            // 
            menuLabel.AutoSize = true;
            menuLabel.Location = new Point(12, 9);
            menuLabel.Name = "menuLabel";
            menuLabel.Size = new Size(41, 15);
            menuLabel.TabIndex = 0;
            menuLabel.Text = "MENU";
            // 
            // originalImageLabel
            // 
            originalImageLabel.AutoSize = true;
            originalImageLabel.Location = new Point(224, 9);
            originalImageLabel.Name = "originalImageLabel";
            originalImageLabel.Size = new Size(85, 15);
            originalImageLabel.TabIndex = 4;
            originalImageLabel.Text = "Original Image";
            // 
            // modifiedImageLabel
            // 
            modifiedImageLabel.AutoSize = true;
            modifiedImageLabel.Location = new Point(620, 9);
            modifiedImageLabel.Name = "modifiedImageLabel";
            modifiedImageLabel.Size = new Size(91, 15);
            modifiedImageLabel.TabIndex = 5;
            modifiedImageLabel.Text = "Modified Image";
            // 
            // originalImagePictureBox
            // 
            originalImagePictureBox.Location = new Point(224, 27);
            originalImagePictureBox.Name = "originalImagePictureBox";
            originalImagePictureBox.Size = new Size(375, 398);
            originalImagePictureBox.TabIndex = 6;
            originalImagePictureBox.TabStop = false;
            // 
            // modifiedImagePictureBox
            // 
            modifiedImagePictureBox.Location = new Point(605, 27);
            modifiedImagePictureBox.Name = "modifiedImagePictureBox";
            modifiedImagePictureBox.Size = new Size(428, 398);
            modifiedImagePictureBox.TabIndex = 7;
            modifiedImagePictureBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1084, 461);
            Controls.Add(modifiedImagePictureBox);
            Controls.Add(originalImagePictureBox);
            Controls.Add(modifiedImageLabel);
            Controls.Add(originalImageLabel);
            Controls.Add(menuLabel);
            Controls.Add(popularityAlgorithmParams);
            Controls.Add(ditheringParamsGroupBox);
            Controls.Add(algorithmsGroupBox);
            MaximumSize = new Size(1100, 500);
            MinimumSize = new Size(1100, 500);
            Name = "Form1";
            Text = "Form1";
            popularityAlgorithmParams.ResumeLayout(false);
            popularityAlgorithmParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numK).EndInit();
            ditheringParamsGroupBox.ResumeLayout(false);
            ditheringParamsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numKb).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKr).EndInit();
            algorithmsGroupBox.ResumeLayout(false);
            algorithmsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)originalImagePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)modifiedImagePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label menuLabel;
        private GroupBox algorithmsGroupBox;
        private GroupBox popularityAlgorithmParams;
        private GroupBox ditheringParamsGroupBox;
        private Label originalImageLabel;
        private Label modifiedImageLabel;
        private PictureBox originalImagePictureBox;
        private PictureBox modifiedImagePictureBox;
        private RadioButton radioPopularityAlgorithm;
        private RadioButton radioOrderedDitheringRelative;
        private RadioButton radioOrderedDitheringRandom;
        private RadioButton radioErrorDiffusionDithering;
        private RadioButton radioAverageDithering;
        private Button refreshButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown numKr;
        private NumericUpDown numKb;
        private NumericUpDown numKg;
        private NumericUpDown numK;
    }
}
