using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tobii.EyeX.Client;
using Tobii.EyeX.Framework;
using EyeXFramework;
using System.Timers;

namespace tobii_camera
{

    public partial class Tobii : Form
    {
        private static Tobii _instance;

        private System.Timers.Timer timer_back;
        private System.Windows.Forms.Timer timer_form;

        EyeXHost eyexhost = new EyeXHost();
        GazePointDataStream lightlyFilteredGazeDataStream;
        EyePositionDataStream PosDataStream;
        

        // 眼球位置_X
        List<int[]> POS_L=new List<int[]>();//平均化のためlist型(xy座標のみ
        List<int[]> POS_R=new List<int[]>();
        int l_counter,r_counter;//ノイズ除去のためのカウンタ

        //視点座標
        List<int[]> POINT=new List<int[]>();

        public static bool 目がない = false;
        public static string debug = "";
        public static int[] 視点座標;
        public static int[]  眼球位置_L=new int[2];
        public static int[] 眼球位置_R = new int[2];
        public static int pos_max = 1000;
        public Tobii()
        {
            InitializeComponent();
            eyexhost.Start();
            lightlyFilteredGazeDataStream = eyexhost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            lightlyFilteredGazeDataStream.Next += (s, e) => 視点情報格納(s, e);
            PosDataStream=eyexhost.CreateEyePositionDataStream();
            PosDataStream.Next += (s, e) =>  眼球位置_XY情報格納(s, e);


            タイマー開始();
            //System.Diagnostics.Debug.WriteLine(gaze_data.ToString()); 
        }
        public static Tobii Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new Tobii();
                return _instance;
            }
        }
        void 視点情報格納(object s, GazePointEventArgs e)
        {
            POINT.Add(new int[]{(int)e.X,(int)e.Y});

        }
        void  眼球位置_XY情報格納(object s, EyePositionEventArgs e)
        {
            //double[] left = { e.LeftEyeNormalized.X, e.LeftEyeNormalized.Y, e.LeftEyeNormalized.Z};
            //double[] right = { e.RightEyeNormalized.X, e.RightEyeNormalized.Y, e.RightEyeNormalized.Z };
            const int limit = 3;
            if (e.LeftEyeNormalized.X == 0)
            {
                l_counter++;
                if (l_counter > limit) POS_L.Add(new int[]{0,0});//limit回連続で0が来たら
            }
            else
            {
                POS_L.Add(new int[] { (int)(pos_max - e.LeftEyeNormalized.X * pos_max), (int)(pos_max - e.LeftEyeNormalized.Y * pos_max) });//x座標だけでいい気がしてきた
                l_counter = 0;
            }
            if (e.RightEyeNormalized.X == 0)
            {
                r_counter++;
                if (r_counter > limit) POS_R.Add(new int[] { pos_max, pos_max });
            }
            else
            {
                POS_R.Add(new int[]{(int)(pos_max - e.RightEyeNormalized.X * pos_max),(int)(pos_max - e.RightEyeNormalized.Y * pos_max)});
                r_counter = 0;
            }
        }
        private void form_ctrl(object sender, EventArgs e)//タイマ割り込みで行う処理
        {
            if (視点座標 != null)//こうしておかないと失敗すること多い
            {
                if (!目がない && checkBox_mouse.Checked) System.Windows.Forms.Cursor.Position = new System.Drawing.Point(視点座標[0], 視点座標[1]);

                label_point.Text = "Point=(" + 視点座標[0] + "," + 視点座標[1] + ")";
                label_L.Text = "L=" + 眼球位置_L[0] + "," + 眼球位置_L[1];
                label_R.Text = "R=" + 眼球位置_R[0] + "," + 眼球位置_R[1];
            }
        }
        void back_ctrl(object sender, ElapsedEventArgs e)
        {
            眼球位置_L = 平均計算(POS_L);//何故かAverage()が使えない
            眼球位置_R = 平均計算(POS_R);
            視点座標 = 平均計算(POINT);

            if (眼球位置_L[0] == 0 && 眼球位置_R[1] == 0) 目がない = true;
            else 目がない = false;

            debug =     "count(pos,point)=(" + POS_R.Count + "," + POINT.Count + ")" + "\n" +
                        "Position=" + ((眼球位置_L[0] + 眼球位置_R[0]) / 2 - pos_max / 2) + "\n" +
                        "diff=" + (眼球位置_L[0] - 眼球位置_R[0]) + "\n" +
                        "Point=(" + 視点座標[0] + "," + 視点座標[1] + ")";

            POS_L.Clear();
            POS_R.Clear();
            POINT.Clear();
        }
        private void Click_start(object sender, EventArgs e)
        {
            タイマー開始();
        }

        private void Click_stop(object sender, EventArgs e)
        {
            タイマー停止();
        }
        int[] 平均計算(List<int[]> data)
        {
            int[] ave={0,0};
            if (data.Count != 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 0; j < ave.Length; j++) ave[j] += data[i][j];
                }
                for (int i = 0; i < ave.Length; i++) ave[i] /= data.Count;
            }
            return ave;
        }


        void タイマー開始()
        {
            if(timer_form!=null)timer_form.Dispose();
            timer_form = new System.Windows.Forms.Timer();
            timer_form.Tick += new EventHandler(form_ctrl);
            timer_form.Interval = int.Parse(textBox_描画周期.Text);
            timer_form.Start();

            if (timer_back != null) timer_back.Dispose();
            timer_back = new System.Timers.Timer();
            timer_back.Elapsed += new ElapsedEventHandler(back_ctrl);
            timer_back.Interval = int.Parse(textBox_計算周期.Text);
            timer_back.Start();
        }
        void タイマー停止()
        {
            timer_form.Stop();
            timer_form.Dispose();

            timer_back.Stop();
            timer_back.Dispose();
        }

        private void Tobii_FormClosing(object sender, FormClosingEventArgs e)
        {
            タイマー停止();
        }
    }
}
