using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using System.Timers;

namespace tobii_camera
{
    public partial class メイン画面 : Form
    {
        //private System.Timers.Timer timer_back;
        private System.Windows.Forms.Timer timer_form;
        
        public static int[] window=new int[2];
        public static int 描画周期;
        public static int 計算周期;
        public static IplImage background;
        public static int average_num;
        public static int radius;
        public static bool 円を表示 = true;
        public static bool 緑線を表示 = true;
        public static bool 視点を表示 = true;


        public メイン画面()
        {
            InitializeComponent();

            background = Cv.CreateImage(new CvSize(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height), BitDepth.U8, 3);
            background.Zero();

            window[0] = int.Parse(textBox_window_x.Text);
            window[1] = int.Parse(textBox_window_y.Text);
            
            //Camera.Instance.Show();
            Tobii.Instance.Show();
            タイマー開始();
            
        }

        private void Click_Camera(object sender, EventArgs e)
        {
            Camera.Instance.Show();
        }

        private void Click_Tobii(object sender, EventArgs e)
        {
            Tobii.Instance.Show();
        }

        private void timer_Tick(object sender, EventArgs e)//タイマ割り込みで行う処理
        {            
            label_debug.Text = Tobii.debug;
        }
        private void Click_Arduino(object sender, EventArgs e)
        {
            Arduino.Instance.Show();
        }

        private void Click_start(object sender, EventArgs e)
        {
            //描画に使うデータ格納
            window[0] = int.Parse(textBox_window_x.Text);
            window[1] = int.Parse(textBox_window_y.Text);
            描画周期 = int.Parse(textBox_描画周期.Text);
            計算周期 = int.Parse(textBox_計算周期.Text);
            average_num = int.Parse(textBox_average.Text);
            radius = int.Parse(textBox_radius.Text);
            //boll型で表示の有無を決定
            円を表示 = checkBox_circle.Checked;
            緑線を表示 = checkBox_green.Checked;
            視点を表示 = checkBox_point.Checked;
            
            描画画面.Instance.Show();
        }


        private void Click_back(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ファイル名をタイトルバーに設定
                this.Text = dialog.SafeFileName;
                //OpenCV処理
                background.Zero();
                var buff = new IplImage(dialog.FileName, LoadMode.Color);
                buff.Resize(background);
                buff.Dispose();
            }
        }


        void タイマー開始()
        {
            if (timer_form != null) timer_form.Dispose();
            timer_form = new System.Windows.Forms.Timer();
            timer_form.Tick += new EventHandler(timer_Tick);
            timer_form.Interval = int.Parse(textBox_描画周期.Text);
            timer_form.Start();
        }
        void タイマー停止()
        {
            timer_form.Stop();
            timer_form.Dispose();
        }

        private void メイン画面_FormClosing(object sender, FormClosingEventArgs e)
        {
            タイマー停止();
        }


    }
}
