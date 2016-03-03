namespace tobii_camera
{
    partial class メイン画面
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Camera = new System.Windows.Forms.Button();
            this.button_Tobii = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.label_debug = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_描画周期 = new System.Windows.Forms.TextBox();
            this.textBox_window_y = new System.Windows.Forms.TextBox();
            this.textBox_window_x = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_average = new System.Windows.Forms.TextBox();
            this.textBox_radius = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_計算周期 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_circle = new System.Windows.Forms.CheckBox();
            this.checkBox_green = new System.Windows.Forms.CheckBox();
            this.checkBox_point = new System.Windows.Forms.CheckBox();
            this.button_arduino = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Camera
            // 
            this.button_Camera.Location = new System.Drawing.Point(12, 12);
            this.button_Camera.Name = "button_Camera";
            this.button_Camera.Size = new System.Drawing.Size(75, 23);
            this.button_Camera.TabIndex = 0;
            this.button_Camera.Text = "Camera";
            this.button_Camera.UseVisualStyleBackColor = true;
            this.button_Camera.Click += new System.EventHandler(this.Click_Camera);
            // 
            // button_Tobii
            // 
            this.button_Tobii.Location = new System.Drawing.Point(12, 41);
            this.button_Tobii.Name = "button_Tobii";
            this.button_Tobii.Size = new System.Drawing.Size(75, 23);
            this.button_Tobii.TabIndex = 1;
            this.button_Tobii.Text = "Tobii";
            this.button_Tobii.UseVisualStyleBackColor = true;
            this.button_Tobii.Click += new System.EventHandler(this.Click_Tobii);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 379);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Click_start);
            // 
            // label_debug
            // 
            this.label_debug.AutoSize = true;
            this.label_debug.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_debug.Location = new System.Drawing.Point(93, 12);
            this.label_debug.Name = "label_debug";
            this.label_debug.Size = new System.Drawing.Size(78, 27);
            this.label_debug.TabIndex = 3;
            this.label_debug.Text = "debug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "描画周期(ms)";
            // 
            // textBox_描画周期
            // 
            this.textBox_描画周期.Location = new System.Drawing.Point(62, 150);
            this.textBox_描画周期.Name = "textBox_描画周期";
            this.textBox_描画周期.Size = new System.Drawing.Size(25, 19);
            this.textBox_描画周期.TabIndex = 5;
            this.textBox_描画周期.Text = "50";
            // 
            // textBox_window_y
            // 
            this.textBox_window_y.Location = new System.Drawing.Point(58, 237);
            this.textBox_window_y.Name = "textBox_window_y";
            this.textBox_window_y.Size = new System.Drawing.Size(25, 19);
            this.textBox_window_y.TabIndex = 6;
            this.textBox_window_y.Text = "240";
            // 
            // textBox_window_x
            // 
            this.textBox_window_x.Location = new System.Drawing.Point(27, 237);
            this.textBox_window_x.Name = "textBox_window_x";
            this.textBox_window_x.Size = new System.Drawing.Size(25, 19);
            this.textBox_window_x.TabIndex = 7;
            this.textBox_window_x.Text = "320";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "window";
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(12, 109);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 9;
            this.button_back.Text = "background";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.Click_back);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "移動平均";
            // 
            // textBox_average
            // 
            this.textBox_average.Location = new System.Drawing.Point(62, 262);
            this.textBox_average.Name = "textBox_average";
            this.textBox_average.Size = new System.Drawing.Size(25, 19);
            this.textBox_average.TabIndex = 11;
            this.textBox_average.Text = "1";
            // 
            // textBox_radius
            // 
            this.textBox_radius.Location = new System.Drawing.Point(62, 281);
            this.textBox_radius.Name = "textBox_radius";
            this.textBox_radius.Size = new System.Drawing.Size(25, 19);
            this.textBox_radius.TabIndex = 13;
            this.textBox_radius.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "許容半径";
            // 
            // textBox_計算周期
            // 
            this.textBox_計算周期.Location = new System.Drawing.Point(62, 187);
            this.textBox_計算周期.Name = "textBox_計算周期";
            this.textBox_計算周期.Size = new System.Drawing.Size(25, 19);
            this.textBox_計算周期.TabIndex = 15;
            this.textBox_計算周期.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "計算周期(ms)";
            // 
            // checkBox_circle
            // 
            this.checkBox_circle.AutoSize = true;
            this.checkBox_circle.Checked = true;
            this.checkBox_circle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_circle.Location = new System.Drawing.Point(12, 305);
            this.checkBox_circle.Name = "checkBox_circle";
            this.checkBox_circle.Size = new System.Drawing.Size(69, 16);
            this.checkBox_circle.TabIndex = 16;
            this.checkBox_circle.Text = "円を表示";
            this.checkBox_circle.UseVisualStyleBackColor = true;
            // 
            // checkBox_green
            // 
            this.checkBox_green.AutoSize = true;
            this.checkBox_green.Checked = true;
            this.checkBox_green.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_green.Location = new System.Drawing.Point(12, 327);
            this.checkBox_green.Name = "checkBox_green";
            this.checkBox_green.Size = new System.Drawing.Size(72, 16);
            this.checkBox_green.TabIndex = 17;
            this.checkBox_green.Text = "緑線表示";
            this.checkBox_green.UseVisualStyleBackColor = true;
            // 
            // checkBox_point
            // 
            this.checkBox_point.AutoSize = true;
            this.checkBox_point.Checked = true;
            this.checkBox_point.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_point.Location = new System.Drawing.Point(12, 349);
            this.checkBox_point.Name = "checkBox_point";
            this.checkBox_point.Size = new System.Drawing.Size(72, 16);
            this.checkBox_point.TabIndex = 18;
            this.checkBox_point.Text = "視点表示";
            this.checkBox_point.UseVisualStyleBackColor = true;
            // 
            // button_arduino
            // 
            this.button_arduino.Location = new System.Drawing.Point(12, 70);
            this.button_arduino.Name = "button_arduino";
            this.button_arduino.Size = new System.Drawing.Size(75, 23);
            this.button_arduino.TabIndex = 19;
            this.button_arduino.Text = "Arduino";
            this.button_arduino.UseVisualStyleBackColor = true;
            this.button_arduino.Click += new System.EventHandler(this.Click_Arduino);
            // 
            // メイン画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(370, 453);
            this.Controls.Add(this.button_arduino);
            this.Controls.Add(this.checkBox_point);
            this.Controls.Add(this.checkBox_green);
            this.Controls.Add(this.checkBox_circle);
            this.Controls.Add(this.textBox_計算周期);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_radius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_average);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_window_x);
            this.Controls.Add(this.textBox_window_y);
            this.Controls.Add(this.textBox_描画周期);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_debug);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_Tobii);
            this.Controls.Add(this.button_Camera);
            this.Name = "メイン画面";
            this.Text = "main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.メイン画面_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Camera;
        private System.Windows.Forms.Button button_Tobii;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_描画周期;
        private System.Windows.Forms.Label label_debug;
        private System.Windows.Forms.TextBox textBox_window_y;
        private System.Windows.Forms.TextBox textBox_window_x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_average;
        private System.Windows.Forms.TextBox textBox_radius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_計算周期;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_circle;
        private System.Windows.Forms.CheckBox checkBox_green;
        private System.Windows.Forms.CheckBox checkBox_point;
        private System.Windows.Forms.Button button_arduino;
    }
}

