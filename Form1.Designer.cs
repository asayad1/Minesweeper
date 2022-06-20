namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mediumButton = new System.Windows.Forms.PictureBox();
            this.easyButton = new System.Windows.Forms.PictureBox();
            this.hardButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flagLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mediumButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(960, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 950);
            this.panel1.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // mediumButton
            // 
            this.mediumButton.Image = global::Minesweeper.Properties.Resources.medium;
            this.mediumButton.Location = new System.Drawing.Point(963, 746);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(95, 92);
            this.mediumButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mediumButton.TabIndex = 15;
            this.mediumButton.TabStop = false;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            // 
            // easyButton
            // 
            this.easyButton.Image = global::Minesweeper.Properties.Resources.easy2;
            this.easyButton.Location = new System.Drawing.Point(960, 658);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(98, 92);
            this.easyButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.easyButton.TabIndex = 14;
            this.easyButton.TabStop = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.Image = global::Minesweeper.Properties.Resources.hard2;
            this.hardButton.Location = new System.Drawing.Point(968, 837);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(90, 88);
            this.hardButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hardButton.TabIndex = 13;
            this.hardButton.TabStop = false;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.5F);
            this.label1.Location = new System.Drawing.Point(987, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 495);
            this.label1.TabIndex = 16;
            this.label1.Text = "M\r\n I\r\nN\r\nE\r\nS\r\nW\r\nE\r\nE\r\nP\r\nE\r\nR\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Minesweeper.Properties.Resources.flag;
            this.pictureBox1.Location = new System.Drawing.Point(968, 509);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(966, 650);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 10);
            this.panel2.TabIndex = 2;
            // 
            // flagLabel
            // 
            this.flagLabel.AutoSize = true;
            this.flagLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagLabel.Location = new System.Drawing.Point(971, 604);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.Size = new System.Drawing.Size(85, 43);
            this.flagLabel.TabIndex = 18;
            this.flagLabel.Text = "000";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(960, 509);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(108, 10);
            this.panel3.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1052, 924);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper - Ahmad Sayad";
            ((System.ComponentModel.ISupportInitialize)(this.mediumButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox hardButton;
        private System.Windows.Forms.PictureBox easyButton;
        private System.Windows.Forms.PictureBox mediumButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label flagLabel;
        private System.Windows.Forms.Panel panel3;
    }
}

