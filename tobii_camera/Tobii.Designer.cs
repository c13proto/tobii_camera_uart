namespace tobii_camera
{
    partial class Tobii
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
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.label_point = new System.Windows.Forms.Label();
            this.textBox_描画周期 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_L = new System.Windows.Forms.Label();
            this.label_R = new System.Windows.Forms.Label();
            this.checkBox_mouse = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_計算周期 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(13, 13);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(138, 42);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Click_start);
            // 
            // button_stop
            // 
            this.button_stop.Font = new System.Drawing.Font("MS UI Gothic", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_stop.Location = new System.Drawing.Point(12, 108);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(733, 435);
            this.button_stop.TabIndex = 1;
            this.button_stop.Text = "stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.Click_stop);
            // 
            // label_point
            // 
            this.label_point.AutoSize = true;
            this.label_point.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_point.Location = new System.Drawing.Point(304, 55);
            this.label_point.Name = "label_point";
            this.label_point.Size = new System.Drawing.Size(128, 27);
            this.label_point.TabIndex = 2;
            this.label_point.Text = "point=(x,y)";
            // 
            // textBox_描画周期
            // 
            this.textBox_描画周期.Location = new System.Drawing.Point(269, 6);
            this.textBox_描画周期.Name = "textBox_描画周期";
            this.textBox_描画周期.Size = new System.Drawing.Size(28, 19);
            this.textBox_描画周期.TabIndex = 3;
            this.textBox_描画周期.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "描画周期(ms)";
            // 
            // label_L
            // 
            this.label_L.AutoSize = true;
            this.label_L.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_L.Location = new System.Drawing.Point(437, 9);
            this.label_L.Name = "label_L";
            this.label_L.Size = new System.Drawing.Size(41, 27);
            this.label_L.TabIndex = 5;
            this.label_L.Text = "L=";
            // 
            // label_R
            // 
            this.label_R.AutoSize = true;
            this.label_R.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_R.Location = new System.Drawing.Point(573, 9);
            this.label_R.Name = "label_R";
            this.label_R.Size = new System.Drawing.Size(43, 27);
            this.label_R.TabIndex = 6;
            this.label_R.Text = "R=";
            // 
            // checkBox_mouse
            // 
            this.checkBox_mouse.AutoSize = true;
            this.checkBox_mouse.Location = new System.Drawing.Point(170, 55);
            this.checkBox_mouse.Name = "checkBox_mouse";
            this.checkBox_mouse.Size = new System.Drawing.Size(88, 16);
            this.checkBox_mouse.TabIndex = 8;
            this.checkBox_mouse.Text = "mouse_move";
            this.checkBox_mouse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "計算周期(ms)";
            // 
            // textBox_計算周期
            // 
            this.textBox_計算周期.Location = new System.Drawing.Point(269, 25);
            this.textBox_計算周期.Name = "textBox_計算周期";
            this.textBox_計算周期.Size = new System.Drawing.Size(28, 19);
            this.textBox_計算周期.TabIndex = 9;
            this.textBox_計算周期.Text = "50";
            // 
            // Tobii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 556);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_計算周期);
            this.Controls.Add(this.checkBox_mouse);
            this.Controls.Add(this.label_R);
            this.Controls.Add(this.label_L);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_描画周期);
            this.Controls.Add(this.label_point);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.KeyPreview = true;
            this.Name = "Tobii";
            this.Text = "Tobii";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tobii_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label_point;
        private System.Windows.Forms.TextBox textBox_描画周期;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_L;
        private System.Windows.Forms.Label label_R;
        private System.Windows.Forms.CheckBox checkBox_mouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_計算周期;

    }
}