using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace RobotWebServices
{
    public partial class Form1 : Form
    {

        private CookieContainer _cookies = new CookieContainer();
        private NetworkCredential _credential = new NetworkCredential("Default User", "robotics");
        private System.Timers.Timer timer1 = new System.Timers.Timer();
        private System.Timers.Timer timer2 = new System.Timers.Timer();
        private float J1;
        private float J2;
        private float J3;
        private float J4;
        private float J5;
        private float J6;
        private float speedRate = 1000;

        public Form1()
        {
            this.timer1.Elapsed += timer1_Tick;
            InitializeComponent();
        }


        //________________________________________________________________________________________________________________________________
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void OX00()
        {
            this.xtxx.Text = " ";
            this.j6.Text = " ";
            this.io.Text = " ";
            this.zbxx.Text = " ";

        }


            private void ioout(string data)
        {
            string url = $"http://127.0.0.1/rw/iosystem/signals/DeviceNet/d652/DOxp?action=set";
            string body = data;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Credentials = _credential;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = _cookies;

            Stream s = request.GetRequestStream();
            s.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            s.Close();


            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {

                if (data == "1")
                {
                    this.djkg.Text = "电机状态：开启";
                }
                else
                {
                    this.djkg.Text = "电机状态：关闭";
                }
            }
        }
        //function IOout(data)
        //{
        //    var rwServiceResource = new XMLHttpRequest();
        //    rwServiceResource.open("POST", "/rw/iosystem/signals/DeviceNet/d652/DOxp?action=set", true, "Default User", "robotics");
        //    rwServiceResource.timeout = 10000;
        //    rwServiceResource.setRequestHeader('content-type', 'application/x-www-form-urlencoded');
        //    rwServiceResource.send(data);
        //}






        private void dianji(string data)
        {
            string url = $"http://127.0.0.1/rw/panel/ctrlstate?action=setctrlstate";
            string body = data;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Credentials = _credential;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = _cookies;

            Stream s = request.GetRequestStream();
            s.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            s.Close();


            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {

                if (data == "1")
                {
                    this.djkg.Text = "电机状态：开启";
                }
                else {
                    this.djkg.Text = "电机状态：关闭";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OX00();
            string url = $"http://127.0.0.1/rw/system?json=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.Proxy = null;
            request.Timeout = 10000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(content);
                    var state = res._embedded._state[0];
                    if (state != null)
                    {
                        this.xtxx.Text = "系统名字："+state["name"] + "\r\n版本号：" + state["rwversion"] + "\r\n兼容版本：" + state["rwversionname"]  ;

                        for (int i = 0;  i < 9; i++)
                        {
                            var option = res._embedded._state[1].options[i];
                            this.xtxx.Text = this.xtxx.Text+ i+"\r\n选项：" + option["option"];
                        }

                    }
                }
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OX00();
            string url = $"http://127.0.0.1/rw/motionsystem/mechunits/ROB_1/jointtarget?json=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.Proxy = null;
            request.Timeout = 10000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(content);
                    var state = res._embedded._state[0];
                    if (state != null)
                    {
                        this.j6.Text = "J1：" + state["rax_1"] + "\r\nj2：" + state["rax_2"] + "\r\nj3：" + state["rax_3"] + "\r\nj4：" + state["rax_4"] + "\r\nj5：" + state["rax_5"] + "\r\nj6：" + state["rax_6"];

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OX00();
            this.io.Text = " ";
            string url = $"http://127.0.0.1/rw/iosystem/signals?json=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.Proxy = null;
            request.Timeout = 10000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(content);
                    var state = res._embedded._state[0];
                    if (state != null)
                    {
                        for (int i = 0; i < 18; i++)
                        {
                            var x = res._embedded._state[i];
                            this.io.Text = this.io.Text  + "\r\nI/O信号"+ i+"：" + x["name"]+ x["lvalue"]+ x["_type"] + x["_title"]   + x["lstate"];
                        }

                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dianji("ctrl-state=motoron");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dianji("ctrl-state=motoroff");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ioout("lvalue=1"); 
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ioout("lvalue = 0"); 
        }


        private void buttonzbxx_Click(object sender, EventArgs e)
        {

            OX00();
            string url = $"http://127.0.0.1/rw/motionsystem/mechunits/ROB_1?json=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.Proxy = null;
            request.Timeout = 10000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(content);
                    var state = res._embedded._state[0];
                    if (state != null)
                    {
                        this.zbxx.Text = this.zbxx.Text + "\r\n工具名称：" + state["name"];
                        this.zbxx.Text = this.zbxx.Text + "\r\nwobj名称：" + state["wobj-name"];
                        this.zbxx.Text = this.zbxx.Text + "\r\n运动模式：" + state["jog-mode"];
                        this.zbxx.Text = this.zbxx.Text + "\r\n机器人模式：" + state["mode"];
                        this.zbxx.Text = this.zbxx.Text + "\r\n当前任务：" + state["task"];
                        this.zbxx.Text = this.zbxx.Text + "\r\n负载模式：" + state["payload-name"];
                        this.zbxx.Text = this.zbxx.Text + "\r\n轴数量： " + state["axes"];


                    }
                }
            }
        }




















        //--------------------------------END--------------------------------\\

        private void btn_localRegist_Click(object sender, EventArgs e)
        {
            string url = $"http://127.0.0.1/users";//用户域
            string body = "username=xyz&application=RobotStudio&location=IN-BLR-XXXX&ulocale=local";//注册本地登录

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Credentials = _credential;//默认用户名密码
            request.ContentType = "application/x-www-form-urlencoded";//提交属性
            request.CookieContainer = _cookies;

            Stream s = request.GetRequestStream();
            s.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            s.Close();
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
                if (httpResponse.StatusCode == HttpStatusCode.Created)
                {
                    btn_localRegist.BackColor = Color.Green;
                    btn_localRegist.Enabled = false;
                }
            }

        }

        private void btn_mShipGet_Click(object sender, EventArgs e)
        {//请求mot权限
            string url = $"http://127.0.0.1/rw/mastership/motion?action=request";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Credentials = _credential;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = _cookies;

            Stream s = request.GetRequestStream();
            s.Close();
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
                if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    //Console.WriteLine("Created");
                    //MessageBox.Show("Motion response: NO_CONTENT");
                    btn_mShipGet.BackColor = Color.Green;
                    btn_mShipGet.Enabled = false;
                }
            }
        }

        private void btn_jogAxisModeSet_Click(object sender, EventArgs e)
        {//设为单轴模式
            string url = $"http://127.0.0.1/rw/motionsystem/mechunits/ROB_1?action=set&continue-on-en=1";
            string body = "jog-mode=AxisGroup1";
            //运动模式为单轴运动
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.ContentType = "application/x-www-form-urlencoded";

            Stream s = request.GetRequestStream();
            s.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            s.Close();
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
                if (httpResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    //Console.WriteLine("Created");
                    //MessageBox.Show("Jog Node Set Response: NO_CONTENT");
                    btn_jogAxisModeSet.BackColor = Color.Green;
                }
            }
        }

        private int getCCount()
        {//获取计数器
            string url = $"http://127.0.0.1/rw/motionsystem?resource=change-count&json=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.Proxy = null;
            request.Timeout = 10000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                    dynamic res = JsonConvert.DeserializeObject(content);
                    var state = res._embedded._state[0];
                    if (state != null)
                    {

                        //MessageBox.Show("state:" + state["change-count"]);
                        return Convert.ToInt32(state["change-count"]);
                    }
                }
            }
            //MessageBox.Show("-1");
            return -1;
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {//计时器1正转.2反转
            speedRate = hsc_speed.Value;
            timer1.Stop();
            int ccount = getCCount();
            string url = $"http://127.0.0.1/rw/motionsystem?action=jog";
            string body = "axis1=" + J1 * speedRate + "&axis2=" + J2 * speedRate + "&axis3=" + J3 * speedRate + "&axis4=" + J4 * speedRate + "&axis5=" + J5 * speedRate + "&axis6=" + J6 * speedRate + "&ccount=" + ccount + "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.ContentType = "application/x-www-form-urlencoded";

            Stream s = request.GetRequestStream();
            s.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            s.Close();
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
            }
            timer1.Start();
        }

        public void PerformJogStop()
        {

            string url = $"http://127.0.0.1/rw/motionsystem?action=jog";
            int ccount = getCCount();

            string body = "axis1=0&axis2=0&axis3=0&axis4=0&axis5=0&axis6=0&ccount=" + ccount + "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Credentials = _credential;
            request.CookieContainer = _cookies;
            request.ContentType = "application/x-www-form-urlencoded";

            Stream s = request.GetRequestStream();
            s.Write(Encoding.ASCII.GetBytes(body), 0, body.Length);
            s.Close();
            using (var httpResponse = (HttpWebResponse)request.GetResponse())
            {
            }


        }

        private void btn_MouseDown()
        {
            this.timer1.Interval = 200;
            this.timer1.Enabled = true;
        }

        private void btn_MouseUp()
        {
            J1 = 0;
            J2 = 0;
            J3 = 0;
            J4 = 0;
            J5 = 0;
            J6 = 0;
            this.timer1.Stop();
            this.PerformJogStop();
        }


        //J1
        private void btn_J1Add_MouseDown(object sender, MouseEventArgs e)
        {
            J1 = 1;
            btn_MouseDown();
        }
        private void btn_J1Add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        private void btn_J1Dec_MouseDown(object sender, MouseEventArgs e)
        {
            J1 = -1;
            btn_MouseDown();
        }
        private void btn_J1Dec_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }

        //J2
        private void btn_J2Add_MouseDown(object sender, MouseEventArgs e)
        {
            J2 = 1;
            btn_MouseDown();
        }
        private void btn_J2Add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        private void btn_J2Dec_MouseDown(object sender, MouseEventArgs e)
        {
            J2 = -1;
            btn_MouseDown();
        }
        private void btn_J2Dec_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }

        //J3
        private void btn_J3Add_MouseDown(object sender, MouseEventArgs e)
        {
            J3 = 1;
            btn_MouseDown();
        }
        private void btn_J3Add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        private void btn_J3Dec_MouseDown(object sender, MouseEventArgs e)
        {
            J3 = -1;
            btn_MouseDown();
        }
        private void btn_J3Dec_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        //J4
        private void btn_J4Add_MouseDown(object sender, MouseEventArgs e)
        {
            J4 = 1;
            btn_MouseDown();
        }
        private void btn_J4Add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        private void btn_J4Dec_MouseDown(object sender, MouseEventArgs e)
        {
            J4 = -1;
            btn_MouseDown();
        }
        private void btn_J4Dec_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }

        //J5
        private void btn_J5Add_MouseDown(object sender, MouseEventArgs e)
        {
            J5 = 1;
            btn_MouseDown();
        }
        private void btn_J5Add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        private void btn_J5Dec_MouseDown(object sender, MouseEventArgs e)
        {
            J5 = -1;
            btn_MouseDown();
        }
        private void btn_J5Dec_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }

        //J1
        private void btn_J6Add_MouseDown(object sender, MouseEventArgs e)
        {
            J6 = 1;
            btn_MouseDown();
        }
        private void btn_J6Add_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }
        private void btn_J6Dec_MouseDown(object sender, MouseEventArgs e)
        {
            J6 = -1;
            btn_MouseDown();
        }
        private void btn_J6Dec_MouseUp(object sender, MouseEventArgs e)
        {
            btn_MouseUp();
        }




        private void hsc_speed_Scroll(object sender, ScrollEventArgs e)
        {
            lbl_showspeed.Text = "速度: " + hsc_speed.Value.ToString();
        }


    }
}
