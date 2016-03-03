namespace tobii_camera
{
    partial class 描画画面
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
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.pictureBoxIpl2 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIpl1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(220, 174);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // pictureBoxIpl2
            // 
            this.pictureBoxIpl2.Location = new System.Drawing.Point(68, 59);
            this.pictureBoxIpl2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxIpl2.Name = "pictureBoxIpl2";
            this.pictureBoxIpl2.Size = new System.Drawing.Size(127, 96);
            this.pictureBoxIpl2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl2.TabIndex = 1;
            this.pictureBoxIpl2.TabStop = false;
            // 
            // 描画画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pictureBoxIpl2);
            this.Controls.Add(this.pictureBoxIpl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "描画画面";
            this.Text = "描画画面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.描画画面_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl2;
    }
}