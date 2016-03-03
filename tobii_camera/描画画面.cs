using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.Timers;
using System.Diagnostics;

namespace tobii_camera
{
    public partial class 描画画面 : Form
    {
        private static 描画画面 _instance;
        IplImage background;
        IplImage frame;
        IplImage frame2;
        List<CvPoint> stack_points=new List<CvPoint>();
        CvSize window_size;
        CvPoint point_old;
        Point location_ipl2;
        int 許容半径;

        int dis_height;//ディスプレイの高さ
        int dis_width;//ディスプレイの幅
        int pos_max;// 眼球位置_Xx座標の最大値
        int diff_in;//初期の左右 眼球位置_Xの差
        int posY_in;//初期の目の高さ

        private System.Timers.Timer timer_back;
        private System.Windows.Forms.Timer timer_form;
        
        int vertical_line;//顔の向きを表している　|　の表示座標
        int vertical_counter;
        int horizontal_line;
        int horizontal_counter;

        PerformanceCounter[] PC;
        public 描画画面()
        {

            InitializeComponent();
            Console.WriteLine("byouga_0");
            //スクリーンの大きさをピクセルで取得
            dis_height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            dis_width=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            pos_max = Tobii.pos_max;
            while (Tobii. 眼球位置_L[0] == 0 || Tobii. 眼球位置_R[0] == 100) { }//両目とれるまでここにとどまる
            diff_in = Tobii. 眼球位置_R[0]-Tobii. 眼球位置_L[0];
            posY_in = (Tobii.眼球位置_L[1] + Tobii.眼球位置_R[1] )/ 2;
            Console.WriteLine("byouga_1");

            pictureBoxIpl1.Width = dis_width;
            pictureBoxIpl1.Height = dis_height;
            frame = Cv.CreateImage(new CvSize(dis_width, dis_height), BitDepth.U8, 3);
            background = Cv.CreateImage(new CvSize(dis_width, dis_height), BitDepth.U8, 3);
            background=メイン画面.background;
            pictureBoxIpl1.ImageIpl = background;
            window_size = new CvSize(メイン画面.window[0], メイン画面.window[1]);
            point_old = new CvPoint(window_size.Width / 2, window_size.Height / 2);
            許容半径 = メイン画面.radius;
            Console.WriteLine("byouga_2");


            frame2 = Cv.CreateImage(new CvSize(メイン画面.window[0], メイン画面.window[1]), BitDepth.U8, 3);
            frame2.Zero();
            pictureBoxIpl2.ImageIpl = frame2;

            PC=new System.Diagnostics.PerformanceCounter[3];


            タイマー開始();
        }

        public static 描画画面 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new 描画画面();
                return _instance;
            }
        }
        private void form_ctrl(object sender, EventArgs e)//タイマ割り込みで行う処理
        {
            //pictureBoxIpl1.RefreshIplImage(frame);
            
            pictureBoxIpl1.RefreshIplImage(frame);
            pictureBoxIpl2.RefreshIplImage(frame2);
            pictureBoxIpl2.Location = location_ipl2;

        }

        void back_ctrl(object sender, ElapsedEventArgs e)
        {
            var sample = background.Clone();
            if (Camera.camera != null)
            {
                Camera.camera.Resize(sample);

                Camera.camera.Resize(frame2);
            }
            if (Tobii.眼球位置_L[0] == 0 && Tobii.眼球位置_R[0] == pos_max)
            {
                //両目検出できなかった時の処理
            }
            else
            {
                stack_CvPoint(ref stack_points);
                視点描画(ref sample);
               // 顔の向き描画(ref sample);
                debug描画(ref sample);
            }
            frame = sample.Clone();
            sample.Dispose();

            frame.Zero();//背景ゼロ
            カメラ画像の表示位置計算();
        }
        void  カメラ画像の表示位置計算()
        {
            var point = ave_CvPoints(stack_points);//枠の中心座標
            point.X -= frame2.Width / 2;
            point.Y -= frame2.Height / 2;
            if (point.X < 0) point.X = 0;
            if (point.Y < 0) point.Y = 0;
            if (point.X > dis_width - frame2.Width) point.X = dis_width - frame2.Width;
            if (point.Y > dis_height - frame2.Height) point.Y = dis_height - frame2.Height;

            location_ipl2.X = point.X;
            location_ipl2.Y = point.Y;
            //Console.WriteLine("{0},{1}", location_ipl2.X, location_ipl2.Y);
        }

        void 視点描画(ref IplImage src)
        {
            //視点位置と□
            var point = ave_CvPoints(stack_points);//枠の中心座標
            if(メイン画面.視点を表示)Cv.Circle(src, point, 3, new CvScalar(255, 255, 255));
            枠の中心座標計算(ref point, 許容半径);
            if(メイン画面.円を表示)Cv.Circle(src, point, 許容半径, new CvScalar(255, 255, 255));
           // 首の動きで座標操作(ref point);

            枠外を塗りつぶす(ref src, new CvRect(new CvPoint(point.X-window_size.Width/2,point.Y-window_size.Height/2), window_size));

            point_old = point;
        }
        void 首の動きで座標操作(ref CvPoint point)
        {
            //垂直線
            if (vertical_line < dis_width / 8 || vertical_line > dis_width * 7 / 8)
            {
                vertical_counter++;
                if (vertical_counter > 5)
                {
                    if (vertical_line < dis_width / 2) point.X = window_size.Width / 2;
                    else point.X = dis_width - window_size.Width / 2;
                }
            }
            else vertical_counter = 0;

            //水平線
            if (horizontal_line < dis_height / 8 || horizontal_line > dis_height * 7 / 8)
            {
                horizontal_counter++;
                if (horizontal_counter > 5)
                {
                    if (horizontal_line < dis_height / 2) point.Y = window_size.Height / 2;
                    else point.Y = dis_height - window_size.Height / 2;
                }
            }
            else horizontal_counter = 0;
        }
        void 枠の中心座標計算(ref CvPoint point,int r)
        {
            double distance=Math.Sqrt(Math.Pow(point.X - point_old.X, 2) + Math.Pow(point.Y - point_old.Y, 2));

            if (Math.Abs(point.X - point_old.X) > window_size.Width / 2 || Math.Abs(point.Y - point_old.Y) > window_size.Height / 2)
            {//枠外だったらスキップ 
            }
            else if (distance > r)
            {
                double ratio = r / distance;
                point.X += (int)((point_old.X - point.X) * ratio);
                point.Y += (int)((point_old.Y - point.Y) * ratio);
            }
            else point = point_old;

            if (point.X < window_size.Width / 2) point.X = window_size.Width / 2;
            if (point.Y < window_size.Height / 2) point.Y = window_size.Height / 2;
            if (point.X > dis_width - window_size.Width / 2) point.X = dis_width - window_size.Width / 2;
            if (point.Y > dis_height - window_size.Height) point.Y = dis_height - window_size.Height / 2;
 
        }
        void 枠外を塗りつぶす(ref IplImage src,CvRect rect)
        {
            var mask = src.Clone();
            mask.Zero();
            Cv.Rectangle(mask, rect, new CvScalar(255, 255, 255), -1);
            mask.Not(mask);
            src.Not(src);//枠外を黒くしたいので
            Cv.Add(src, mask, src);
            src.Not(src);
            Cv.Rectangle(src, rect, new CvScalar(255, 255, 255), 1);//枠を表示
            mask.Dispose();
        }
        void stack_CvPoint(ref List<CvPoint> points)
        {
            if (points.Count < メイン画面.average_num) stack_points.Add(new CvPoint(Tobii.視点座標[0], Tobii.視点座標[1]));//最終項に追加される
            else
            {
                points.RemoveAt(0);//先頭を削除
                points.Add(new CvPoint(Tobii.視点座標[0], Tobii.視点座標[1]));
            }
        }
        CvPoint ave_CvPoints(List<CvPoint> points)
        {
            CvPoint ave=new CvPoint(0,0);
            for (int i = 0; i < points.Count; i++)
            {
                ave.X += points[i].X;
                ave.Y += points[i].Y;
            }
            ave.X /= points.Count;
            ave.Y /= points.Count;

            return ave;
        }
        void 顔の向き描画(ref IplImage src)
        {
            垂直線描画(ref src);
            水平線描画(ref src);
        }
        void 水平線描画(ref IplImage src)
        {
            int[] eyes = new int[] { Tobii.眼球位置_L[1], Tobii.眼球位置_R[1] };
            int line_pos = dis_height / 2;
            int diff = posY_in-(eyes[0] + eyes[1]) / 2;
            if (eyes[0] == 0) diff = posY_in- eyes[1] ;
            if (eyes[1] == pos_max) diff = posY_in-eyes[0];

            line_pos = dis_height/2+dis_height/2*diff / 20;
            if (line_pos > dis_height) line_pos = dis_height;
            if (line_pos < 0) line_pos = 0;
            if(メイン画面.緑線を表示)Cv.Line(src, new CvPoint(0, line_pos), new CvPoint(dis_width, line_pos), new CvScalar(0, 255, 0), 5);
            horizontal_line = line_pos;
        }
        void 垂直線描画(ref IplImage src)
        {
            // | の表示
            int[] eyes = new int[] { Tobii.眼球位置_L[0], Tobii.眼球位置_R[0] };
            int line_pos = dis_width / 2;

            //2つの眼球距離から推定．最初の姿勢から前後に身体を揺らすとダメ
            if (eyes[0] != 0 && eyes[1] != pos_max)//両目の位置が検出できている時
            {
                const double min_ratio = 0.906;//sin50°/(2sin25°) 眼球間角度は50°,片目が中心に来る時を最大と過程
                double ratio = (double)(Tobii.眼球位置_R[0] - Tobii.眼球位置_L[0]) / (double)diff_in;
                double POS_Ratio = (1 - ratio) / (1 - min_ratio);
                if (POS_Ratio > 1) POS_Ratio = 1;

                if ((eyes[1] + eyes[0]) / 2 > pos_max / 2)//右を向いている
                {
                    line_pos += (int)(POS_Ratio * (double)dis_width / 2);
                }
                else//左を向いている 
                {
                    line_pos -= (int)(POS_Ratio * (double)dis_width / 2);
                }

                if (POS_Ratio < 0.2) line_pos = dis_width / 2;
            }
            else
            {
                if (eyes[0] == 0) line_pos = 0;
                else line_pos = dis_width;
            }

            vertical_line = line_pos;
            if (メイン画面.緑線を表示) Cv.Line(src, new CvPoint(line_pos, 0), new CvPoint(line_pos, dis_height), new CvScalar(0, 255, 0), 5);
        }
        void debug描画(ref IplImage src)
        {
            string[] debug = Tobii.debug.Split('\n');
            CvFont フォント = new CvFont(FontFace.HersheyComplex, 0.5, 0.5);
            Cv.PutText(src, debug[0], new CvPoint(10, 20), フォント, new CvColor(255, 255, 255));
            Cv.PutText(src, debug[1], new CvPoint(10, 40), フォント, new CvColor(255, 255, 255));
            Cv.PutText(src, debug[2], new CvPoint(10, 60), フォント, new CvColor(255, 255, 255));

        }
        void タイマー開始()
        {
            if (timer_form != null) timer_form.Dispose();
            timer_form = new System.Windows.Forms.Timer();
            timer_form.Tick += new EventHandler(form_ctrl);
            timer_form.Interval = メイン画面.描画周期;
            timer_form.Start();

            if(timer_back!=null)timer_back.Dispose();
            timer_back = new System.Timers.Timer();
            timer_back.Elapsed += new ElapsedEventHandler(back_ctrl);
            timer_back.Interval = メイン画面.計算周期;
            timer_back.Start();
        }
        void タイマー停止()
        {
            timer_back.Stop();
            timer_back.Dispose();

            timer_form.Stop();
            timer_form.Dispose();
        }

        private void 描画画面_FormClosing(object sender, FormClosingEventArgs e)
        {
            タイマー停止();
        }

    }
}
