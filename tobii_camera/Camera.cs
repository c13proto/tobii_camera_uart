using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using System.Net;
using System.IO;
using OpenCvSharp.Extensions;
using System.Timers;

namespace tobii_camera
{
    public partial class Camera : Form
    {
        bool IPcamera = false;

        //USBカメラ用変数
        private static Camera _instance;
        CvCapture CAPTURE;

        //IPカメラ用変数
        byte[] CAPTURE_IP;
        string URL = "http://192.168.2.1/?action=snapshot";

        private System.Timers.Timer timer_back;
        private System.Windows.Forms.Timer timer_form;
        public static IplImage camera;

        public Camera()
        {
            InitializeComponent();
        }

        public static Camera Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new Camera();
                return _instance;
            }
        }

        private void Click_Start(object sender, EventArgs e)
        {
            IPcamera = false;
            CAPTURE = Cv.CreateCameraCapture(0);
            解像度設定(int.Parse(textBox_resX.Text), int.Parse(textBox_resY.Text));
            CAPTURE.Fps = 1000/int.Parse(textBox_描画周期.Text);
            タイマー開始();
        }
        private void Click_IP(object sender, EventArgs e)
        {
            IPcamera = true;
            CAPTURE_IP = new byte[int.Parse(textBox_resX.Text) * int.Parse(textBox_resY.Text)];
            タイマー開始();
        }
        private void form_ctrl(object sender, EventArgs e)//タイマ割り込みで行う処理
        {
            if(checkBox_映像確認.Checked)pictureBoxIpl1.RefreshIplImage(camera);
        }
        void back_ctrl(object sender, ElapsedEventArgs e)
        {            
            if (!IPcamera)//usbカメラの処理
            {
                var frame = Cv.QueryFrame(CAPTURE);
                if (frame != null)
                {
                    camera = frame.Clone();
                }
                else System.Diagnostics.Debug.WriteLine("frame=null");
                Cv.ReleaseImage(frame);
            }
            else//wifiカメラの処理
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(URL);
                Bitmap bmp = new Bitmap(stream);
                stream.Close();
                camera = BitmapConverter.ToIplImage(bmp);
                bmp.Dispose();
            }
        }
        private void Click_Stop(object sender, EventArgs e)
        {
            タイマー停止();
        }
        void 解像度設定(int x,int y)
        {
            Cv.SetCaptureProperty(CAPTURE, CaptureProperty.FrameWidth, x);
            Cv.SetCaptureProperty(CAPTURE, CaptureProperty.FrameHeight,y);
        }

        void タイマー開始()
        {
            if (timer_form != null) timer_form.Dispose();
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

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            タイマー停止();
        }
    }
}
