using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;

namespace tobii_camera
{
    public partial class Arduino : Form
    {
        public static bool Serial_state = false;
        private static Arduino _instance;
        private SerialPort mySerialPort = new SerialPort("COM4");
        private System.Timers.Timer timer_back;
        private System.Windows.Forms.Timer timer_form;
        public static int[] 送信座標 = new int[2];
        public static int[] 受信座標 = new int[2];
        public static int[] old_送信座標 = new int[2];
        int dis_height;//ディスプレイの高さ
        int dis_width;//ディスプレイの幅
        int pot_center = 512;//ポテンショの真ん中の値
        static int[]可動範囲 = new int[2];//degで角度を入れてポテンショの大きさに直してある


        public Arduino()
        {
            InitializeComponent();

            //スクリーンの大きさ(中心)をピクセルで取得
            dis_width   = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            dis_height  = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            送信座標[0] = dis_width / 2;
            送信座標[1] = dis_height / 2;
            
            //1023/360=2.842 角度(deg)をポテンショの大きさの角度に直す
            可動範囲[0] = (int)(2.842 * int.Parse(textBox_range_x.Text));
            可動範囲[1] = (int)(2.842 * int.Parse(textBox_range_y.Text));
            Console.WriteLine("{0},{1}", Tobii.眼球位置_L[0], Tobii.眼球位置_L[1]);  
        }

        public static Arduino Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new Arduino();
                return _instance;
            }
        }

        private void form_ctrl(object sender, EventArgs e)//タイマ割り込みで行う処理
        {
            label_debug_send_x.Text = "送信x座標:" + 送信座標[0].ToString();
            label_debug_send_y.Text = "送信y座標:" + 送信座標[1].ToString();
            label_debug_recieve_x.Text = "受信x座標:" + 受信座標[0].ToString();
            label_debug_recieve_y.Text = "受信y座標:" + 受信座標[1].ToString();
        }

        void back_ctrl(object sender, ElapsedEventArgs e)
        {
            眼球位置送信();
            ロボット位置受信();
        }

        void タイマー開始()
        {
            if (timer_form != null) timer_form.Dispose();
            timer_form = new System.Windows.Forms.Timer();
            timer_form.Tick += new EventHandler(form_ctrl);
            timer_form.Interval = int.Parse(textBox_form.Text);
            timer_form.Start();

            if (timer_back != null) timer_back.Dispose();
            timer_back = new System.Timers.Timer();
            timer_back.Elapsed += new ElapsedEventHandler(back_ctrl);
            timer_back.Interval = int.Parse(textBox_back.Text);
            timer_back.Start();
        }

        void タイマー停止()
        {
            timer_form.Stop();
            timer_form.Dispose();

            timer_back.Stop();
            timer_back.Dispose();
        }

 /*       private void Serial_comm(object sender, EventArgs e)
        {
            Console.WriteLine("Serial_comm");
        }
  */      
        private void 通信状況_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox 通信状況 = (CheckBox)sender;

            if (通信状況.Checked)
            {
                Serial_state = true;
                通信状況.Text = "通信中";
                //Console.WriteLine("通信中");
                if (mySerialPort.IsOpen == false)
                {
                    mySerialPort.BaudRate = 9600;
                    mySerialPort.Open();
                }
                
                タイマー開始();

            }
            else
            {
                Serial_state = false;
                通信状況.Text = "通信開始";
                //Console.WriteLine("通信開始");
                if (mySerialPort.IsOpen == true)
                {
                    mySerialPort.Close();
                }
                タイマー停止();
            }

            //1023/360=2.842 角度(deg)をポテンショの大きさの角度に直す
            可動範囲[0] = (int)(2.842 * int.Parse(textBox_range_x.Text));
            可動範囲[1] = (int)(2.842 * int.Parse(textBox_range_y.Text));

        }

        //眼球の位置を送り続ける
        public void 眼球位置送信()
        {
           if (Serial_state == true) 
            {
                byte[] bytes = new byte[4];

               //両目の眼球位置送るように送信座標は配列にしている
                送信座標[0] = Tobii.視点座標[0];
                送信座標[1] = Tobii.視点座標[1];

               //もし眼球運動が取得できなかったら以前の値を送る
                if (送信座標[0] == 0 || 送信座標[1] == 0)
                {
                    送信座標[0] = old_送信座標[0];
                    送信座標[1] = old_送信座標[1];
                }

               //winowのサイズより端によせない
                if (送信座標[0] < メイン画面.window[0] / 2) { 送信座標[0] = メイン画面.window[0] / 2; }
                if (送信座標[0] > dis_width - メイン画面.window[0] / 2) { 送信座標[0] = dis_width - メイン画面.window[0] / 2; }
                if (送信座標[1] < メイン画面.window[1] / 2) { 送信座標[1] = メイン画面.window[0] / 2; }
                if (送信座標[1] > dis_height - メイン画面.window[1] / 2) { 送信座標[1] = dis_height - メイン画面.window[0] / 2; }

                //可動範囲に合わせてArduinoに送る用の値に変換する
                送信座標[0] = Map(送信座標[0], メイン画面.window[0] / 2, dis_width - メイン画面.window[0] / 2,
                                 pot_center - (可動範囲[0] / 2), pot_center + (可動範囲[0] / 2));
                送信座標[1] = Map(送信座標[1], メイン画面.window[1] / 2, dis_height - メイン画面.window[1] / 2,
                  pot_center - (可動範囲[1] / 2), (pot_center + 可動範囲[1] / 2));


                Console.WriteLine("{0},{1}", pot_center - (可動範囲[1] / 2), pot_center + (可動範囲[1] / 2));

                bytes[0] = (byte)(送信座標[0] / 256);
                bytes[1] = (byte)(送信座標[0] % 256);
                bytes[2] = (byte)(送信座標[1] / 256);
                bytes[3] = (byte)(送信座標[1] % 256);


                mySerialPort.Write(new byte[] { bytes[0] }, 0, 1);
                mySerialPort.Write(new byte[] { bytes[1] }, 0, 1);
                mySerialPort.Write(new byte[] { bytes[2] }, 0, 1);
                mySerialPort.Write(new byte[] { bytes[3] }, 0, 1);

               //更新
                old_送信座標[0] = 送信座標[0];
                old_送信座標[1] = 送信座標[1];

            }
        }

        public void ロボット位置受信()
        {
            if (mySerialPort.IsOpen == true && mySerialPort.ReadBufferSize > 3)
            {
                int[] 受信データ = new int[4];
                受信データ[0] = mySerialPort.ReadByte();
                受信データ[1] = mySerialPort.ReadByte();
                受信データ[2] = mySerialPort.ReadByte();
                受信データ[3] = mySerialPort.ReadByte();

                受信座標[0] = 受信データ[0] * 256 + 受信データ[1];
                受信座標[1] = 受信データ[2] * 256 + 受信データ[3];
            }
 
        }

        public int Map(int val, int start1, int end1, int start2, int end2)
        {
        //ある範囲（start1-end1）に存在する値（val）を別の範囲(start2-end2)に比例変換する
            float r_val = (float)((val - start1)) /(float)((end1 - start1)) * (float)((end2 - start2)) + start2; 
            return (int)r_val;
        }

    }
}
