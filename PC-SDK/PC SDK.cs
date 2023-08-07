﻿//-------------------------------------------------引用库文件-------------------------------------------------       
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.EventLogDomain;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using System;
using System.Windows.Forms;
using ABB.Robotics.Controllers.IOSystemDomain;

/*备用的常用库文件
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Text;
using RobotStudio.Services.RobApi;
using System.Net.Sockets;
using System.Linq.Expressions;
*/
//.................................................引用库文件.................................................
namespace 教程
{
    
    public partial class Form1 : Form                                           //public 关键字是类型和类型成员的访问修饰符。 公共访问是允许的最高访问级别。 对访问公共成员没有限制
    {
        public int x = 0, Y = 1;                                                      //设置私有成员变量x，控制time1工作状态。c#中无全局变量？
        double x0 = 0, y0 = 0, z0 = 0, vp = 0, x1 = 0, y1 = 0, z1 = 0, va = 0;
        double j11 = 0, j12 = 0, j13 = 0, j14 = 0, j15 = 0, j16 = 0, j21 = 0, j22 = 0, j23 = 0, j24 = 0, j25 = 0, j26, j1, j2, j3, j4, j5, j6;

        void svp()
        {
            x0 = x1;
            y0 = y1;
            z0 = z1;
            x1 = double.Parse(txt_x.Text);
            y1 = double.Parse(txt_y.Text);
            z1 = double.Parse(txt_z.Text);
            va = Math.Pow((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0) + (z1 - z0) * (z1 - z0), 1.0 / (3)) * 2;
            this.txtvp.Text = "轨迹平均矢量速度大小：" + va.ToString() + "mm/s";
        }
        void sap()
        {
            double va0 = va, vb;
            svp();
            vb = (va - va0) * 2;
            this.txtvp.Text = this.txtvp.Text+ "轨迹平均矢量加速度大小：" + vb.ToString() + "mm/s";
        }
        void sjvp()
        {
            j11 = j21;
            j12 = j22;
            j13 = j23;
            j14 = j24;
            j15 = j25;
            j16 = j26;
            j21 = double.Parse(txt_x.Text);
            j22 = double.Parse(txt_y.Text);
            j23 = double.Parse(txt_z.Text);
            j24 = double.Parse(txt_rx.Text);
            j25 = double.Parse(txt_ry.Text);
            j26 = double.Parse(txt_rz.Text);
            j1 = (j21 - j11) * 2;
            j2 = (j22 - j12) * 2;
            j3 = (j23 - j13) * 2;
            j4 = (j24 - j14) * 2;
            j5 = (j25 - j15) * 2;
            j6 = (j26 - j16) * 2;
            this.txtvp.Text = "6轴平均角速度大小：\r\n" + "j1:" + j1 + "r/s\r\n" + "j2:" + j2 + "r/s\r\n" + "j3:" + j3 + "r/s\r\n" + "j4:" + j4 + "r/s\r\n" + "j5:" + j5 + "r/s\r\n" + "j6:" + j6 + "r/s\r\n";
        }
        void sjap()
        {
            double i1, i2, i3, i4, i5, i6, k1, k2, k3, k4, k5, k6;
            i1 = j1; i2 = j2; i3 = j3; i4 = j4; i5 = j5; i6 = j6;
            sjvp();
            k1 = (j1 - i1) * 2;
            k2 = (j2 - i3) * 2;
            k3 = (j3 - i3) * 2;
            k4 = (j4 - i4) * 2;
            k5 = (j5 - i5) * 2;
            k6 = (j6 - i6) * 2;
            this.txtvp.Text = this.txtvp.Text + "6轴平均角加速度大小：\r\n" + "aj1:" + k1 + "r/s2\r\n" + "aj2:" + k2 + "r/s2\r\n" + "aj3:" + k3 + "r/s2\r\n" + "aj4:" + k4 + "r/s2\r\n" + "aj5:" + k5 + "r/s2\r\n" + "aj6:" + k6 + "r/s2\r\n";
        }

        void power()
        {

            Signal pw = controllers.IOSystem.GetSignal("smb");
            DigitalSignal ipw = (DigitalSignal)pw;
            if (ipw.Value.ToString() == "0")
            {
                this.txtp.Text = "当前电池电量：高\r\n此电池数据每10小时更新一次";
            }
            else {
                this.txtp.Text = "当前电池电量：低\r\n此电池数据每10小时更新一次";
            }
        }
        void smc()
        {

            Signal jt = controllers.IOSystem.GetSignal("smc");
            DigitalSignal ijt = (DigitalSignal)jt;
            if (ijt.Value.ToString() == "0")
            {
                this.txtsmc.Text = "急停状态：否";
            }
            else {
                this.txtsmc.Text = "急停状态：是";
            }
        }
        void smd()
        {

            Signal mn = controllers.IOSystem.GetSignal("smd");
            DigitalSignal imn = (DigitalSignal)mn;
            if (imn.Value.ToString() == "0")
            {
                this.txtsmd.Text = "示教器模拟输出：否";
            }
            else
            {
                this.txtsmd.Text = "示教器模拟输出：是";
            }
        }
        void smfxt() 
        { 
        Signal xt = controllers.IOSystem.GetSignal("smf");
        DigitalSignal ixt = (DigitalSignal)xt;
            this.smf.Text = ixt.Value.ToString();
        }


        void sub()
        {
            controllers.StateChanged += new EventHandler<StateChangedEventArgs>(c_sc);//添加对控制器的订阅
            controllers.Rapid.ExecutionStatusChanged += new EventHandler<ExecutionStatusChangedEventArgs>(exe_sc);//运行模式
            controllers.OperatingModeChanged += new EventHandler<OperatingModeChangeEventArgs>(op_sc);//操作模式
           
        }

        private void exe_sc(object sender, ExecutionStatusChangedEventArgs e)
        {            this.Invoke(new EventHandler(UpdateGUIse), sender,e);//采用委托方式，防止界面进程与主线程冲突
        }
        private void op_sc(object sender, OperatingModeChangeEventArgs e)
        {            this.Invoke(new EventHandler(UpdateGUIop), sender, e);        }
        private void c_sc(object sender, StateChangedEventArgs e)
        {            this.Invoke(new EventHandler(UpdateGUIcsc), sender, e);        }


        private void UpdateGUIse(object sender, System.EventArgs e)
        {            this.txt_yx.Text = "运行模式：" + controllers.Rapid.ExecutionStatus.ToString();        }
        private void UpdateGUIop(object sender, System.EventArgs e)
        {            this.txt_cz.Text = "操作模式：" + controllers.OperatingMode.ToString();        }
        private void UpdateGUIcsc(object sender, System.EventArgs e)
        {            this.txt_kz.Text = "控制器状态：" + controllers.State.ToString();        }




        //-------------------------------------------------通信初始化-------------------------------------------------
        private NetworkScanner scanner = null;                                  //创建机器人网络扫描器NetworkScanner类的实例化对象scanner//private 关键字是一个成员访问修饰符。
        private ABB.Robotics.Controllers.Controller controllers = null;         //创建机器人控制器Controller类的实例化对象controllers
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks = null;       //创建控制器与rapid连接
        private NetworkWatcher networkwatcher = null;                           //创建网络监视
        //.................................................通信初始化.................................................




        //-------------------------------------------------通信扫描-------------------------------------------------
        private void button4_Click(object sender, EventArgs e)                  //刷新按钮子程序
        {
            timer1.Enabled = false;                                             //关闭计时器timer1
          //if (scanner == null)                                                //确定扫描仪已经创建，没用
          //{
                scanner = new NetworkScanner();                                 //打开扫描器
          //}
            scanner.Scan();                                                     //扫描网络
            this.listView1.Items.Clear();                                       //清空listView1中内容
            ControllerInfoCollection controls = scanner.Controllers;            //将网络上所有机器人的信息返回给ControllerInfoCollection类型的数据controls
            foreach (ControllerInfo info in controls)                           //foreach循环
            {
                ListViewItem item = new ListViewItem(info.SystemName);          //对所有机器人的信息进行遍历
                item.SubItems.Add(info.IPAddress.ToString());                   //系统名称(第一列，此后列依次排序)
                item.SubItems.Add(info.Version.ToString());                     //系统ip
                item.SubItems.Add(info.IsVirtual.ToString());                   //版本
                item.SubItems.Add(info.ControllerName.ToString());              //是否虚拟
                item.Tag = info;                                                //获得系统名称
                this.listView1.Items.Add(item);                                 //输出控制器名称                
            }
        }
        //.................................................通信扫描.................................................



        //-------------------------------------------------通信登录-------------------------------------------------
        private void listView1_DoubleClick(object sender, EventArgs e)          //机器人信息窗口listView1子程序
        {
                ListViewItem item = this.listView1.SelectedItems[0];            //初始化
                    ControllerInfo info = (ControllerInfo)item.Tag;             //获得控制器信息信息
                    if (info.Availability==Availability.Available)              //当信息可用时
                    {
                        if (controllers!=null)
                        {
                            controllers.Logoff();                               //注销该控制器的登录
                            controllers.Dispose();                              //登出Dispose
                            controllers = null;                                 //控制器设置为null
                        }
                        controllers = ControllerFactory.CreateFrom(info);       //将控制器确定为所选择中的控制器信息
                        controllers.Logon(UserInfo.DefaultUser);                //使用默认用户名登录
                        MessageBox.Show("已登录控制器" + info.SystemName);      //弹窗提醒
                        x = 1; timer1.Enabled = true ;                          //在以上登录完成之后，计时器标志x打开，打开计时器time1
                //获取速度
                RapidData ai = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "a");
                texta.Text = Convert.ToString(ai.ToString() + "：" + ai.Value.ToString() + "\r\n");
                RapidData vi = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "v");
                textv.Text = Convert.ToString(vi.ToString() + "：" + vi.Value.ToString() + "\r\n");
                vp = Convert.ToInt32(vi.Value.ToString());
                //获取程序
                tasks = controllers.Rapid.GetTasks();
                ABB.Robotics.Controllers.RapidDomain.Module mod = tasks[0].GetModule("Mod1");

                Routine[] r = mod.GetRoutines();                //获取mod1下的所有routine
                comboBox1.Items.Clear();                //清屏
                for (int i = 0; i < r.Length; i++)
                {
                    //this.txt_main.Text = this.txt_main.Text + r[i].Name.ToString() + "\r\n";
                    comboBox1.Items.Add(r[i].Name.ToString());//输出到box1的item
                }
                comboBox1.Text = r[0].Name.ToString();
            }
 //               }
 //           }
        }
        //.................................................通信登录.................................................







        //-------------------------------------------------定时信息获取-------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)                                                                                                            //时间函数time1子程序
        {
                double rx;                                                                                                                                              //定义double类型局部变量rx
                double ry;                                                                                                                                              //定义double类型局部变量ry
                double rz;

            if (txt_x.Text == "302.00" && txt_y.Text == "0.00" && txt_z.Text == "521.00")
            {
                ooo.Text = "机器人当前点位：原点";
            }
            else { ooo.Text = "机器人当前点位：非原点"; }//定义double类型局部变量rz
            if (x == 0)                                                                                                                                                 //PCsdk 未连接到机器人时。
            {
                ooo.Text = "机器人当前点位：未获取";                                                                                                                                                       //不执行任何获取信息的程序
            }
            else if (x == 1)                                                                                                                                            //按钮处于直角坐标状态
            {
                
                ABB.Robotics.Controllers.RapidDomain.RobTarget aRobTarget = controllers.MotionSystem.ActiveMechanicalUnit.GetPosition(CoordinateSystemType.World);      //通过controllers.MotionSystem.ActiveMechanicalUnit.GetPosition（）；函数获得world型数据，赋值给aRobTarget
                txt_x.Text = aRobTarget.Trans.X.ToString(format: "#0.00");                                                                                              //在aRobTarget里获得x坐标。保留到小数后两位。幅值给文本txt_x
                txt_y.Text = aRobTarget.Trans.Y.ToString(format: "#0.00");                                                                                              //在aRobTarget里获得x坐标。保留到小数后两位。幅值给文本txt_x
                txt_z.Text = aRobTarget.Trans.Z.ToString(format: "#0.00");                                                                                              //在aRobTarget里获得x坐标。保留到小数后两位。幅值给文本txt_x
                aRobTarget.Rot.ToEulerAngles(out rx, out ry, out rz);                                                                                                   //通过aRobTarget.Rot.ToEulerAngles();函数获得欧拉角数据，赋值给out rx, out ry, out rz。
                txt_rx.Text = rx.ToString(format: "#0.00");
                txt_ry.Text = ry.ToString(format: "#0.00");
                txt_rz.Text = rz.ToString(format: "#0.00");
                txt_v.Text = "当前设置的运行速度：" + controllers.MotionSystem.SpeedRatio.ToString() + " %";                                                            //通过controllers.MotionSystem.SpeedRatio.ToString()函数获得文本型Text数据，赋值给txt_v.    
                sub(); 
                if (Y == 1) { svp(); }
                if (Y == 2) { sap(); }
            }
            else if (x == 2)                                                                                                                                            //按钮处于6轴状态
            {
                JointTarget aJointTarget = controllers.MotionSystem.ActiveMechanicalUnit.GetPosition();                                                                 //通过controllers.MotionSystem.ActiveMechanicalUnit.GetPosition();函数获得机器人6轴信息，赋值给aJointTarget
                txt_x.Text = aJointTarget.RobAx.Rax_1.ToString(format: "#0.00");                                                                                        //在aJointTarget里获得轴1坐标。保留到小数后两位。幅值给文本txt_x
                txt_y.Text = aJointTarget.RobAx.Rax_2.ToString(format: "#0.00");                                                                                        //在aJointTarget里获得轴1坐标。保留到小数后两位。幅值给文本txt_x
                txt_z.Text = aJointTarget.RobAx.Rax_3.ToString(format: "#0.00");                                                                                        //在aJointTarget里获得轴1坐标。保留到小数后两位。幅值给文本txt_x
                txt_rx.Text = aJointTarget.RobAx.Rax_4.ToString(format: "#0.00");                                                                                       //在aJointTarget里获得轴1坐标。保留到小数后两位。幅值给文本txt_x
                txt_ry.Text = aJointTarget.RobAx.Rax_5.ToString(format: "#0.00");                                                                                       //在aJointTarget里获得轴1坐标。保留到小数后两位。幅值给文本txt_x
                txt_rz.Text = aJointTarget.RobAx.Rax_6.ToString(format: "#0.00");
                txt_v.Text = "当前设置的运行速度：" + controllers.MotionSystem.SpeedRatio.ToString() + " %";                                                            //通过controllers.MotionSystem.SpeedRatio.ToString()函数获得文本型Text数据，赋值给txt_v.
                smfxt();
                if (Y == 1) { sjvp(); }
                if (Y == 2) { sjap(); }
            }

        }
        //.................................................定时信息获取.................................................


        //-------------------------------------------------机器人控制-------------------------------------------------
        private void abbon_Click(object sender, EventArgs e)                        //上电按钮子程序
        {
            try                                                                     //try-catch异常监测函数，发生错误时候保持程序可以继续运行
            {
                if (controllers.OperatingMode == ControllerOperatingMode.Auto)      //判断机器人当前模式，为自动时   
                {
                    controllers.State = ControllerState.MotorsOn;                   //机器人上电函数
                    MessageBox.Show("已执行上电");                                  //弹窗提醒“已执行上电”
                }
                else                                                                //机器人当前模式，手动时  
                {
                    MessageBox.Show("请切换到自动模式");                            //弹窗提醒“请切换到自动模电” 
                }
            }
            catch(System.Exception ex){MessageBox.Show("error" + ex.Message);}      //try-catch异常监测函数，发生错误时候保持程序可以继续运行
        }



        private void abboff_Click(object sender, EventArgs e)                       //下电按钮子程序
        {
            try                                                                     //try-catch异常监测函数，发生错误时候保持程序可以继续运行
            {
                if (controllers.OperatingMode == ControllerOperatingMode.Auto)      //判断机器人当前模式，为自动时      
                {
                    controllers.State = ControllerState.MotorsOff;                  //机器人下电函数
                    MessageBox.Show("已执行下电");                                  //弹窗提醒“已执行下电”
                }
                else                                                                //机器人当前模式，手动时  
                {
                    MessageBox.Show("请切换到自动模式");                            //弹窗提醒“请切换到自动模电” 
                }
            }
            catch (System.Exception ex) { MessageBox.Show("error" + ex.Message); }  //try-catch异常监测函数，发生错误时候保持程序可以继续运行
        }

        private void button5_Click(object sender, EventArgs e)                      //重新启动按钮子程序
        {
            try                                                                     //try-catch异常监测函数，发生错误时候保持程序可以继续运行
            {
                using (Mastership m = Mastership.Request(controllers.Rapid))        //using 指令允许使用在命名空间中定义的类型，而无需指定该类型的完全限定命名空间。 using 指令以基本形式从单个命名空间导入所有类型
                {
                    StartResult result = controllers.Rapid.Start();                 //控制器中当前rapid的程序，运行
                    MessageBox.Show("已执行重新启动");                              //弹窗提示“已执行重新启动”
                }
            }
             catch(Exception ex){ MessageBox.Show("error" + ex.Message); }          //try-catch异常监测函数，发生错误时候保持程序可以继续运行
        }

        private void button6_Click(object sender, EventArgs e)                      //停止按钮子程序
        {
            try                                                                     //try-catch异常监测函数，发生错误时候保持程序可以继续运行
            {
                using (Mastership m = Mastership.Request(controllers.Rapid))        //using 指令允许使用在命名空间中定义的类型，而无需指定该类型的完全限定命名空间。 using 指令以基本形式从单个命名空间导入所有类型
                {
                    controllers.Rapid.Stop(StopMode.Immediate);                     //控制器中当前rapid的程序，停止
                    MessageBox.Show("已执行停止");                                  //弹窗提示“已执行停止”
                }
            }
            catch (Exception ex) { MessageBox.Show("error" + ex.Message); }         //try-catch异常监测函数，发生错误时候保持程序可以继续运行
        }
        //.................................................机器人控制.................................................










        //-------------------------------------------------日志输出-------------------------------------------------
        private void button7_Click(object sender, EventArgs e)                     //获取日志按钮子程序
        { 
            this.txtrz.Text = "日志信息如下：" + "\r\n";                           //更改字符信息为“日志信息如下”
            ABB.Robotics.Controllers.EventLogDomain.EventLog log = controllers.EventLog;
                                                                                   //将机器人的日志读入
            EventLogCategory cat;                                                  //定义事件格式变量cat
            cat = log.GetCategory(0);                                              //GetCategory函数为读取日志。0表示获取所有事件日志.1表示获取最近20条
            {
                MessageBox.Show("日志正在输出，请等待");                           //弹窗提醒“日志正在输出，请等待”
                foreach (ABB.Robotics.Controllers.EventLogDomain.EventLogMessage emsg in cat.Messages)
                {                                                                  //循环，次数为cat日志个数
                    int AlarmNo;                                                   //遍历所有日志
                    AlarmNo = emsg.CategoryId * 10000 + emsg.Number;               //将日志的类别和错误符号合并，生成完整的警报代码//CategoryId、Number为int类型
                    this.txtrz.Text = this.txtrz.Text + emsg.Timestamp + "     " + AlarmNo.ToString() + "     " + emsg.Title + "     " + "\r\n"; 
                                                                                   //文本输出，格式，参数
                }
                MessageBox.Show("日志输出完毕");                                  ////弹窗提醒“日志输出完毕”
            }
        }
        //.................................................日志输出.................................................






        //------------------------改变输出的机器人信息类型------------------------
        private void radioButton1_CheckedChanged(object sender, EventArgs e)       //直角坐标系按钮子程序
        {
            x = 1;                                                                 //当直角坐标系按钮按下时候，将x设置为1，计时器time1以1状态程序运行
            if (radioButton1.Checked)                                              //判断直角坐标系按钮按下时执行。
            {
                label_x.Text = "X";                                                //将表示文本更新为X
                label_y.Text = "Y";                                                //将表示文本更新为Y
                label_z.Text = "Z";                                                //将表示文本更新为Z
                label_rx.Text = "RX";                                              //将表示文本更新为RX
                label_ry.Text = "RY";                                              //将表示文本更新为RY
                label_rz.Text = "RZ";                                              //将表示文本更新为RZ
            }
            else                                                                   //判断直角坐标系未按钮按下时执行。
            { 
                x = 2;
                label_x.Text = "J1";                                               //将表示文本更新为J1
                label_y.Text = "J2";                                               //将表示文本更新为J2
                label_z.Text = "J3";                                               //将表示文本更新为J3
                label_rx.Text = "J4";                                              //将表示文本更新为J4
                label_ry.Text = "J5";                                              //将表示文本更新为J5
                label_rz.Text = "J6";                                              //将表示文本更新为J6
            }
        }
        //........................改变输出的机器人信息类型........................






        

        


        //-------------------------------------------------读取io-------------------------------------------------
        private void kong_Click(object sender, EventArgs e)
        {   listView3.Items.Clear();                                                  //清屏
            try { 
            SignalCollection sig = controllers.IOSystem.GetSignals(IOFilterTypes.Unit,"d652");
            foreach (Signal signal in sig )
            {
                ListViewItem item = new ListViewItem(signal.Name);
                item.SubItems.Add(signal.Type.ToString());
                item.SubItems.Add(signal.Value.ToString());
                item.SubItems.Add(signal.Unit.ToString());
                listView3.Items.Add(item);
            }
            }
            catch (Exception ex) { MessageBox.Show("错误：未连接到控制器。" + ex.Message); }
        }
        //.................................................读取io.................................................



        private void button8_Click_1(object sender, EventArgs e)
        {
            Signal idoxp = controllers.IOSystem.GetSignal("DOxp");
            DigitalSignal didoxp = (DigitalSignal)idoxp;
            if (txt_doxp.Text == "1") { didoxp.Set(); }
            else { didoxp.Reset(); }
            MessageBox.Show("写入完毕");
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Signal ido_h_5 = controllers.IOSystem.GetSignal("do_h_5");
            DigitalSignal dido_h_5 = (DigitalSignal)ido_h_5;
            if (do_h_5.Text == "1") { dido_h_5.Set(); }
            else { dido_h_5.Reset(); }
            MessageBox.Show("写入完毕");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Signal iDOgongju = controllers.IOSystem.GetSignal("DOgongju");
            DigitalSignal diDOgongju = (DigitalSignal)iDOgongju;
            if (do_h_4.Text == "1") { diDOgongju.Set(); }
            else { diDOgongju.Reset(); }
            MessageBox.Show("写入完毕");
        }


//---------------------------------------------控制器机器人运到到制定坐标————————————————————————————————————
        private void xmru_Click(object sender, EventArgs e)
        {
            using (Mastership.Request(controllers.Rapid))
                {
                    RapidData rd = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "O");
                //RobTarget zb = (RobTarget)rd.Value;//将rd强制转换为num型数据

                ABB.Robotics.Controllers.RapidDomain.RobTarget zb = (ABB.Robotics.Controllers.RapidDomain.RobTarget)rd.Value;//将rd强制转换为num型数据
                    zb.Trans.X = Convert.ToSingle(xmrux.Text);
                    zb.Trans.Y = Convert.ToSingle(xmruy.Text);
                    zb.Trans.Z = Convert.ToSingle(xmruz.Text);
                    rd.Value = zb;
                    MessageBox.Show("已修改为" + zb.ToString());
                }
        }
        //.................................................控制器机器人运到到制定坐标.................................................




        //---------------------------------------------机器人设置信息、时间信息————————————————————————————————————
        private void button11_Click(object sender, EventArgs e)//设置信息
        {
            this.abbsys.Text = " ";
            this.abbsys.Text = "系统名称：" + controllers.RobotWare.Name.ToString() + "\r\n"; 
            this.abbsys.Text = this.abbsys.Text + "RW版本：" + controllers.RobotWare.Version.ToString() + "\r\n";
            RobotWareOptionCollection sys = controllers.RobotWare.Options;
            foreach (RobotWareOption op in sys)
            {
                this.abbsys.Text = this.abbsys.Text + "系统设置信息：" + op.ToString() + "\r\n";//遍历所有信息显示
            }
            this.abbsys.Text = this.abbsys.Text + "机器人信息（Mac地址）：" + controllers.MacAddress.ToString() + "\r\n";
            this.abbsys.Text = this.abbsys.Text + "机器人信息（Mac地址长度）：" + controllers.MacAddress.Length.ToString() + "\r\n";
            this.abbsys.Text = this.abbsys.Text + "机器人信息（系统序列ID）:" + controllers.SystemId.ToString() + "\r\n";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            MechanicalUnitServiceInfo m0 = controllers.MotionSystem.ActiveMechanicalUnit.ServiceInfo;//创建当前机械单元serviceinfo实例
            this.abbrun.Text = " ";
            this.abbrun.Text = "生产总时间：" + m0.ElapsedProductionTime.TotalHours.ToString() + "\r\n";
            this.abbrun.Text = this.abbrun.Text + "自上次服务后的生产总时间：" + m0.ElapsedCalenderTimeSinceLastService.TotalHours.ToString() + "\r\n";
            this.abbrun.Text = this.abbrun.Text + "上次开机时间：" + m0.LastStart.ToString() + "\r\n";
            MainComputerServiceInfo m1 = controllers.MainComputerServiceInfo;

            this.abbrun.Text = this.abbrun.Text + "主机CPU信息：" + m1.CpuInfo.ToString() + "\r\n";
            this.abbrun.Text = this.abbrun.Text + "主机CPU温度：" + m1.Temperature.ToString() + "摄氏度\r\n";
            this.abbrun.Text = this.abbrun.Text + "主机存储信息：" + m1.RamSize.ToString() + "\r\n";
            
            
        }
        //.................................................机器人设置信息、时间信息.................................................



        //---------------------------------------------rapid程序选择————————————————————————————————————
        private void button13_Click(object sender, EventArgs e)
        {
            string s1 = ""; 
            s1 = comboBox1.SelectedItem.ToString(); 
            try
            {
                using (Mastership m= Mastership.Request(controllers.Rapid))
                {
                    tasks[0].SetProgramPointer("Mod1", s1);//指针移动到选择的程序
                    MessageBox.Show("程序已更改为：" + s1);

                }

            }
            catch (System.Exception ex) { MessageBox.Show("程序更改失败" + ex.Message); }
            tasks = controllers.Rapid.GetTasks();
            ABB.Robotics.Controllers.RapidDomain.Module mod = tasks[0].GetModule("Mod1");
        }
        //.................................................rapid程序选择.................................................


        //---------------------------------------------获取工具、工具坐标系、坐标————————————————————————————————————
        private void button15_Click(object sender, EventArgs e)
        {
            power();smc(); smd();
            Tool t = controllers.MotionSystem.ActiveMechanicalUnit.Tool;
            //获取当前工具
            WorkObject w = controllers.MotionSystem.ActiveMechanicalUnit.WorkObject;
            //获取当前工件坐标系
            string k = controllers.MotionSystem.ActiveMechanicalUnit.Name;
            ToolData t1 = (ToolData)t.Data;
            //转化为ToolData
            WobjData w1 = (WobjData)w.Data;
            //转化为WobjData
            this.gj.Text = "当前工具：" + t.Name;
            //s1 = gj + t1.Tframe.ToString() + " ";
            this.gjzbx.Text = "工件坐标系：" + w.Name + "    坐标："+ w1.Uframe.ToString();
            this.yhzbx.Text =  "用户坐标系："  + k;
            sub(); 
        }
        //.................................................获取工具、工具坐标系、坐标.................................................


        private void button16_Click(object sender, EventArgs e)
        {
            RapidData j1 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "Y");
            textB.Text = Convert.ToString(j1.ToString() + "：" + j1.Value.ToString() + "\r\n");
        }
        private void button17_Click(object sender, EventArgs e)
        {
            using (Mastership.Request(controllers.Rapid))
            {
                RapidData y = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "Y");
                Num z = (Num)y.Value;

                    //this..Text = "寄存器读取变量Y读取测试"+ y.ToString() + "：" + y.Value.ToString() + "\r\n";//遍历所有信息显示

                z.FillFromString2(this.textB.Text);
                y.Value = z;
                y.Value = z;

                //MessageBox.Show("已修改为" + rd2.ToString());
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            RapidData j1 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "j1");
            this.text6B.Text = j1.ToString() + "：" + j1.Value.ToString() + "\r\n";
            RapidData j2 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "j2");
            this.text6B.Text = this.text6B.Text + j2.ToString() + "：" + j1.Value.ToString() + "\r\n";
            RapidData j3 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "j3");
            this.text6B.Text = this.text6B.Text + j3.ToString() + "：" + j1.Value.ToString() + "\r\n";
            RapidData j4 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "j4");
            this.text6B.Text = this.text6B.Text + j4.ToString() + "：" + j1.Value.ToString() + "\r\n";
            RapidData j5 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "j5");
            this.text6B.Text = this.text6B.Text + j5.ToString() + "：" + j1.Value.ToString() + "\r\n";
            RapidData j6 = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "j6");
            this.text6B.Text = this.text6B.Text + j6.ToString() + "：" + j1.Value.ToString() + "\r\n";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            using (Mastership.Request(controllers.Rapid))
            {
                RapidData v = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "v");
                Num v0 = (Num)v.Value;
                v0.FillFromString2(this.textv.Text);
                v.Value = v0;
                MessageBox.Show("运行速度已修改为" + v0);
                RapidData vi = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "v");
                textv.Text = Convert.ToString(v.ToString() + "：" + v.Value.ToString() + "\r\n");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            using (Mastership.Request(controllers.Rapid))
            {
                RapidData a = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "a");
                Num a0 = (Num)a.Value;
                a0.FillFromString2(this.texta.Text);
                a.Value = a0;
                MessageBox.Show("加速度已修改为" + a0);
                RapidData ai = controllers.Rapid.GetRapidData("T_ROB1", "Mod1", "a");
                texta.Text = Convert.ToString(ai.ToString() + "：" + ai.Value.ToString() + "\r\n");
            }
        }

        private void textv_TextChanged(object sender, EventArgs e)        {        }
        private void button14_Click(object sender, EventArgs e)        { Y = 2;       }
        private void authenticationExceptionBindingSource_CurrentChanged(object sender, EventArgs e) { }
        public Form1() { InitializeComponent(); }                       //未使用
        private void listView1_(object sender, EventArgs e) { }          //未使用
        private void label3_Click(object sender, EventArgs e) { }                //未使用
        private void txt_x_TextChanged(object sender, EventArgs e) { }                      //未使用
        private void label4_Click(object sender, EventArgs e) { }                           //未使用。txt_x子程序
        private void listView2_SelectedIndexChanged(object sender, EventArgs e) { }    //未使用。istView2子程序
        private void button8_Click(object sender, EventArgs e) { }                 //上电按钮子程序
        private void label5_Click(object sender, EventArgs e) { }
        private void txt_v_TextChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void abbrunbgm_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtcs_Click(object sender, EventArgs e) { }
    }
    }