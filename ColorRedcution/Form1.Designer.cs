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
            originalImageLabel = new Label();
            modifiedImageLabel = new Label();
            modifiedImagePictureBox = new PictureBox();
            originalImagePictureBox = new PictureBox();
            loadButton = new Button();
            saveButton = new Button();
            createButton = new Button();
            popularityAlgorithmParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numK).BeginInit();
            ditheringParamsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKr).BeginInit();
            algorithmsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)modifiedImagePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)originalImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // popularityAlgorithmParams
            // 
            popularityAlgorithmParams.Controls.Add(numK);
            popularityAlgorithmParams.Controls.Add(label4);
            popularityAlgorithmParams.Location = new Point(12, 511);
            popularityAlgorithmParams.Name = "popularityAlgorithmParams";
            popularityAlgorithmParams.Size = new Size(278, 76);
            popularityAlgorithmParams.TabIndex = 3;
            popularityAlgorithmParams.TabStop = false;
            popularityAlgorithmParams.Text = "Popularity algorithm params";
            // 
            // numK
            // 
            numK.Location = new Point(37, 30);
            numK.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numK.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numK.Name = "numK";
            numK.Size = new Size(120, 31);
            numK.TabIndex = 1;
            numK.Value = new decimal(new int[] { 1015, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 30);
            label4.Name = "label4";
            label4.Size = new Size(22, 25);
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
            ditheringParamsGroupBox.Location = new Point(12, 369);
            ditheringParamsGroupBox.Name = "ditheringParamsGroupBox";
            ditheringParamsGroupBox.Size = new Size(278, 136);
            ditheringParamsGroupBox.TabIndex = 2;
            ditheringParamsGroupBox.TabStop = false;
            ditheringParamsGroupBox.Text = "Dithering params";
            // 
            // numKb
            // 
            numKb.Location = new Point(37, 93);
            numKb.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numKb.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numKb.Name = "numKb";
            numKb.Size = new Size(120, 31);
            numKb.TabIndex = 5;
            numKb.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numKg
            // 
            numKg.Location = new Point(37, 59);
            numKg.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numKg.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numKg.Name = "numKg";
            numKg.Size = new Size(120, 31);
            numKg.TabIndex = 4;
            numKg.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 95);
            label3.Name = "label3";
            label3.Size = new Size(33, 25);
            label3.TabIndex = 3;
            label3.Text = "Kb";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 59);
            label2.Name = "label2";
            label2.Size = new Size(33, 25);
            label2.TabIndex = 2;
            label2.Text = "Kg";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(28, 25);
            label1.TabIndex = 1;
            label1.Text = "Kr";
            // 
            // numKr
            // 
            numKr.Location = new Point(37, 23);
            numKr.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numKr.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numKr.Name = "numKr";
            numKr.Size = new Size(120, 31);
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
            algorithmsGroupBox.Location = new Point(12, 138);
            algorithmsGroupBox.Name = "algorithmsGroupBox";
            algorithmsGroupBox.Size = new Size(278, 236);
            algorithmsGroupBox.TabIndex = 1;
            algorithmsGroupBox.TabStop = false;
            algorithmsGroupBox.Text = "Algorithms";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(6, 186);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(180, 34);
            refreshButton.TabIndex = 5;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // radioPopularityAlgorithm
            // 
            radioPopularityAlgorithm.AutoSize = true;
            radioPopularityAlgorithm.Location = new Point(6, 142);
            radioPopularityAlgorithm.Name = "radioPopularityAlgorithm";
            radioPopularityAlgorithm.Size = new Size(198, 29);
            radioPopularityAlgorithm.TabIndex = 4;
            radioPopularityAlgorithm.TabStop = true;
            radioPopularityAlgorithm.Text = "Popularity algorithm";
            radioPopularityAlgorithm.UseVisualStyleBackColor = true;
            // 
            // radioOrderedDitheringRelative
            // 
            radioOrderedDitheringRelative.AutoSize = true;
            radioOrderedDitheringRelative.Location = new Point(6, 111);
            radioOrderedDitheringRelative.Name = "radioOrderedDitheringRelative";
            radioOrderedDitheringRelative.Size = new Size(240, 29);
            radioOrderedDitheringRelative.TabIndex = 3;
            radioOrderedDitheringRelative.TabStop = true;
            radioOrderedDitheringRelative.Text = "Ordered dithering relative";
            radioOrderedDitheringRelative.UseVisualStyleBackColor = true;
            // 
            // radioOrderedDitheringRandom
            // 
            radioOrderedDitheringRandom.AutoSize = true;
            radioOrderedDitheringRandom.Location = new Point(6, 79);
            radioOrderedDitheringRandom.Name = "radioOrderedDitheringRandom";
            radioOrderedDitheringRandom.Size = new Size(247, 29);
            radioOrderedDitheringRandom.TabIndex = 2;
            radioOrderedDitheringRandom.TabStop = true;
            radioOrderedDitheringRandom.Text = "Ordered dithering random";
            radioOrderedDitheringRandom.UseVisualStyleBackColor = true;
            // 
            // radioErrorDiffusionDithering
            // 
            radioErrorDiffusionDithering.AutoSize = true;
            radioErrorDiffusionDithering.Location = new Point(6, 51);
            radioErrorDiffusionDithering.Name = "radioErrorDiffusionDithering";
            radioErrorDiffusionDithering.Size = new Size(226, 29);
            radioErrorDiffusionDithering.TabIndex = 1;
            radioErrorDiffusionDithering.TabStop = true;
            radioErrorDiffusionDithering.Text = "Error diffusion dithering";
            radioErrorDiffusionDithering.UseVisualStyleBackColor = true;
            // 
            // radioAverageDithering
            // 
            radioAverageDithering.AutoSize = true;
            radioAverageDithering.Location = new Point(6, 24);
            radioAverageDithering.Name = "radioAverageDithering";
            radioAverageDithering.Size = new Size(178, 29);
            radioAverageDithering.TabIndex = 0;
            radioAverageDithering.TabStop = true;
            radioAverageDithering.Text = "Average dithering";
            radioAverageDithering.UseVisualStyleBackColor = true;
            // 
            // originalImageLabel
            // 
            originalImageLabel.AutoSize = true;
            originalImageLabel.Location = new Point(336, 27);
            originalImageLabel.Name = "originalImageLabel";
            originalImageLabel.Size = new Size(129, 25);
            originalImageLabel.TabIndex = 4;
            originalImageLabel.Text = "Original Image";
            // 
            // modifiedImageLabel
            // 
            modifiedImageLabel.AutoSize = true;
            modifiedImageLabel.Location = new Point(859, 27);
            modifiedImageLabel.Name = "modifiedImageLabel";
            modifiedImageLabel.Size = new Size(139, 25);
            modifiedImageLabel.TabIndex = 5;
            modifiedImageLabel.Text = "Modified Image";
            // 
            // modifiedImagePictureBox
            // 
            modifiedImagePictureBox.Location = new Point(854, 61);
            modifiedImagePictureBox.Name = "modifiedImagePictureBox";
            modifiedImagePictureBox.Size = new Size(512, 512);
            modifiedImagePictureBox.TabIndex = 7;
            modifiedImagePictureBox.TabStop = false;
            // 
            // originalImagePictureBox
            // 
            originalImagePictureBox.ErrorImage = null;
            originalImagePictureBox.InitialImage = null;
            originalImagePictureBox.Location = new Point(336, 61);
            originalImagePictureBox.Name = "originalImagePictureBox";
            originalImagePictureBox.Size = new Size(512, 512);
            originalImagePictureBox.TabIndex = 8;
            originalImagePictureBox.TabStop = false;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(12, 10);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(112, 34);
            loadButton.TabIndex = 9;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(12, 50);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // createButton
            // 
            createButton.Location = new Point(12, 90);
            createButton.Name = "createButton";
            createButton.Size = new Size(112, 34);
            createButton.TabIndex = 11;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1378, 644);
            Controls.Add(createButton);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(originalImagePictureBox);
            Controls.Add(modifiedImagePictureBox);
            Controls.Add(modifiedImageLabel);
            Controls.Add(originalImageLabel);
            Controls.Add(popularityAlgorithmParams);
            Controls.Add(ditheringParamsGroupBox);
            Controls.Add(algorithmsGroupBox);
            MaximumSize = new Size(1400, 700);
            MinimumSize = new Size(1400, 700);
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
            ((System.ComponentModel.ISupportInitialize)modifiedImagePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)originalImagePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox algorithmsGroupBox;
        private GroupBox popularityAlgorithmParams;
        private GroupBox ditheringParamsGroupBox;
        private Label originalImageLabel;
        private Label modifiedImageLabel;
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
        private PictureBox originalImagePictureBox;
        private Button loadButton;
        private Button saveButton;
        private Button createButton;
    }
}
