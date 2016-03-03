namespace tobii_camera
{
    partial class Camera
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_resX = new System.Windows.Forms.TextBox();
            this.textBox_resY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_描画周期 = new System.Windows.Forms.TextBox();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_計算周期 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_映像確認 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Click_Start);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Click_Stop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "解像度(USBカメラ)";
            // 
            // textBox_resX
            // 
            this.textBox_resX.Location = new System.Drawing.Point(14, 131);
            this.textBox_resX.Name = "textBox_resX";
            this.textBox_resX.Size = new System.Drawing.Size(39, 19);
            this.textBox_resX.TabIndex = 5;
            this.textBox_resX.Text = "640";
            // 
            // textBox_resY
            // 
            this.textBox_resY.Location = new System.Drawing.Point(59, 131);
            this.textBox_resY.Name = "textBox_resY";
            this.textBox_resY.Size = new System.Drawing.Size(39, 19);
            this.textBox_resY.TabIndex = 6;
            this.textBox_resY.Text = "480";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "描画周期(ms)";
            // 
            // textBox_描画周期
            // 
            this.textBox_描画周期.Location = new System.Drawing.Point(12, 179);
            this.textBox_描画周期.Name = "textBox_描画周期";
            this.textBox_描画周期.Size = new System.Drawing.Size(39, 19);
            this.textBox_描画周期.TabIndex = 8;
            this.textBox_描画周期.Text = "200";
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(107, 12);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(566, 429);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 9;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Start(IP)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Click_IP);
            // 
            // textBox_計算周期
            // 
            this.textBox_計算周期.Location = new System.Drawing.Point(12, 220);
            this.textBox_計算周期.Name = "textBox_計算周期";
            this.textBox_計算周期.Size = new System.Drawing.Size(39, 19);
            this.textBox_計算周期.TabIndex = 12;
            this.textBox_計算周期.Text = "200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "計算周期(ms)";
            // 
            // checkBox_映像確認
            // 
            this.checkBox_映像確認.AutoSize = true;
            this.checkBox_映像確認.Checked = true;
            this.checkBox_映像確認.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_映像確認.Location = new System.Drawing.Point(12, 246);
            this.checkBox_映像確認.Name = "checkBox_映像確認";
            this.checkBox_映像確認.Size = new System.Drawing.Size(72, 16);
            this.checkBox_映像確認.TabIndex = 13;
            this.checkBox_映像確認.Text = "映像確認";
            this.checkBox_映像確認.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(388, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(8, 8);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(685, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox_映像確認);
            this.Controls.Add(this.textBox_計算周期);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Controls.Add(this.textBox_描画周期);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_resY);
            this.Controls.Add(this.textBox_resX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Camera";
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camera_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_resX;
        private System.Windows.Forms.TextBox textBox_resY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_描画周期;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_計算周期;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_映像確認;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}