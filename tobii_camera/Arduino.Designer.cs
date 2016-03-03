namespace tobii_camera
{
    partial class Arduino
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
            this.通信状況 = new System.Windows.Forms.CheckBox();
            this.textBox_form = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_back = new System.Windows.Forms.TextBox();
            this.label_debug_recieve_x = new System.Windows.Forms.Label();
            this.label_debug_recieve_y = new System.Windows.Forms.Label();
            this.label_debug_send_x = new System.Windows.Forms.Label();
            this.label_debug_send_y = new System.Windows.Forms.Label();
            this.textBox_range_x = new System.Windows.Forms.TextBox();
            this.textBox_range_y = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // 通信状況
            // 
            this.通信状況.Appearance = System.Windows.Forms.Appearance.Button;
            this.通信状況.Location = new System.Drawing.Point(12, 12);
            this.通信状況.Name = "通信状況";
            this.通信状況.Size = new System.Drawing.Size(75, 23);
            this.通信状況.TabIndex = 14;
            this.通信状況.Text = "通信開始";
            this.通信状況.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.通信状況.UseVisualStyleBackColor = true;
            this.通信状況.CheckedChanged += new System.EventHandler(this.通信状況_CheckedChanged);
            // 
            // textBox_form
            // 
            this.textBox_form.Location = new System.Drawing.Point(85, 41);
            this.textBox_form.Name = "textBox_form";
            this.textBox_form.Size = new System.Drawing.Size(37, 19);
            this.textBox_form.TabIndex = 15;
            this.textBox_form.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "back";
            // 
            // textBox_back
            // 
            this.textBox_back.Location = new System.Drawing.Point(85, 65);
            this.textBox_back.Name = "textBox_back";
            this.textBox_back.Size = new System.Drawing.Size(37, 19);
            this.textBox_back.TabIndex = 17;
            this.textBox_back.Text = "50";
            // 
            // label_debug_recieve_x
            // 
            this.label_debug_recieve_x.AutoSize = true;
            this.label_debug_recieve_x.Location = new System.Drawing.Point(10, 181);
            this.label_debug_recieve_x.Name = "label_debug_recieve_x";
            this.label_debug_recieve_x.Size = new System.Drawing.Size(61, 12);
            this.label_debug_recieve_x.TabIndex = 19;
            this.label_debug_recieve_x.Text = "受信x座標:";
            // 
            // label_debug_recieve_y
            // 
            this.label_debug_recieve_y.AutoSize = true;
            this.label_debug_recieve_y.Location = new System.Drawing.Point(109, 181);
            this.label_debug_recieve_y.Name = "label_debug_recieve_y";
            this.label_debug_recieve_y.Size = new System.Drawing.Size(61, 12);
            this.label_debug_recieve_y.TabIndex = 20;
            this.label_debug_recieve_y.Text = "受信y座標:";
            // 
            // label_debug_send_x
            // 
            this.label_debug_send_x.AutoSize = true;
            this.label_debug_send_x.Location = new System.Drawing.Point(10, 160);
            this.label_debug_send_x.Name = "label_debug_send_x";
            this.label_debug_send_x.Size = new System.Drawing.Size(61, 12);
            this.label_debug_send_x.TabIndex = 21;
            this.label_debug_send_x.Text = "送信x座標:";
            // 
            // label_debug_send_y
            // 
            this.label_debug_send_y.AutoSize = true;
            this.label_debug_send_y.Location = new System.Drawing.Point(109, 160);
            this.label_debug_send_y.Name = "label_debug_send_y";
            this.label_debug_send_y.Size = new System.Drawing.Size(61, 12);
            this.label_debug_send_y.TabIndex = 22;
            this.label_debug_send_y.Text = "送信y座標:";
            // 
            // textBox_range_x
            // 
            this.textBox_range_x.Location = new System.Drawing.Point(85, 90);
            this.textBox_range_x.Name = "textBox_range_x";
            this.textBox_range_x.Size = new System.Drawing.Size(37, 19);
            this.textBox_range_x.TabIndex = 23;
            this.textBox_range_x.Text = "120";
            // 
            // textBox_range_y
            // 
            this.textBox_range_y.Location = new System.Drawing.Point(85, 115);
            this.textBox_range_y.Name = "textBox_range_y";
            this.textBox_range_y.Size = new System.Drawing.Size(37, 19);
            this.textBox_range_y.TabIndex = 24;
            this.textBox_range_y.Text = "90";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "可動範囲X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "可動範囲Y";
            // 
            // Arduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_range_y);
            this.Controls.Add(this.textBox_range_x);
            this.Controls.Add(this.label_debug_send_y);
            this.Controls.Add(this.label_debug_send_x);
            this.Controls.Add(this.label_debug_recieve_y);
            this.Controls.Add(this.label_debug_recieve_x);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_form);
            this.Controls.Add(this.通信状況);
            this.Name = "Arduino";
            this.Text = "Arduino";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox 通信状況;
        private System.Windows.Forms.TextBox textBox_form;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_back;
        private System.Windows.Forms.Label label_debug_recieve_x;
        private System.Windows.Forms.Label label_debug_recieve_y;
        private System.Windows.Forms.Label label_debug_send_x;
        private System.Windows.Forms.Label label_debug_send_y;
        private System.Windows.Forms.TextBox textBox_range_x;
        private System.Windows.Forms.TextBox textBox_range_y;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}