//-------------------------------------------------引用库文件-------------------------------------------------       
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.EventLogDomain;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using System;
using System.Windows.Forms;
using ABB.Robotics.Controllers.IOSystemDomain;
/*备用的常用库文件
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
        public int x = 0;                                                      //设置公共访问变量x，控制time1工作状态。c#中无全局变量？

   



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








        //------------------------小试牛刀------------------------
        private void button1_Click(object sender, EventArgs e)                  //运算按钮子程序
        {
            string i1 = textBox1.Text;                                          //输入第一个数字到i1
            string i2 = textBox2.Text;                                          //输入第二个数字到i2
            float fi1 = Convert.ToSingle(i1);                                   //在C#编程过程中，可以使用Convert.ToSingle方法将字符串或者其他可转换为数字的对象变量转换为数字（float）类型，Convert.ToSingle方法有多个重载方法，最常使用的一个方法将字符串转换为float类型，方法签名为：static float ToSingle(string value)。当Convert.ToSingle无法转换时，将会引发程序异常，如果无法确定是否一定可转换，建议使用float.TryParse等方法。
            float fi2 = Convert.ToSingle(i2);
            float sum = fi1 + fi2;                                              //进行加和
            textBox3.Text = Convert.ToString(sum);                              //数字转化为文本输出到text格式的textBox3
        }
        //........................小试牛刀........................






       //------------------------弹窗------------------------
        private void button3_Click(object sender, EventArgs e)                  //弹窗按钮子程序
        {
            Form1 form = new Form1();                                           //按钮触发的新窗口为form1本身。非模式窗体
            form.Show();                                                        //Show（）；函数的调用会立即返回，新窗体显示的同时Show方法调用语句后面的代码会得到执行，没有在当前活动窗体和新窗体间建立任何关系.独立的窗口
        }
        //........................弹窗........................







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
//            if (this.listView1.Items.Count > 0){                                 //判断输出窗口格式，屁用没有？??????????????????????????????????????????????????????
            
                ListViewItem item = this.listView1.SelectedItems[0];            //初始化
//                if (item.Tag!=null){                                             //判断输出内容，屁用没有？??????????????????????????????????????????????????????????
                
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
        {   this.txtrz.Text = "日志信息如下：" + "\r\n";                           //更改字符信息为“日志信息如下”
            ABB.Robotics.Controllers.EventLogDomain.EventLog log = controllers.EventLog;
                                                                                   //将机器人的日志读入
            EventLogCategory cat;                                                  //定义事件格式变量cat
            cat = log.GetCategory(1);                                              //GetCategory函数为读取日志。0表示获取所有事件日志.1表示获取最近20条
            {
                MessageBox.Show("日志正在输出，请等待");                           //弹窗提醒“日志正在输出，请等待”
                foreach (ABB.Robotics.Controllers.EventLogDomain.EventLogMessage emsg in cat.Messages)
                {                                                                  //循环，次数为cat日志个数
                    int AlarmNo;                                                   //遍历所有日志
                    AlarmNo = emsg.CategoryId * 10000 + emsg.Number;               //将日志的类别和错误符号合并，生成完整的警报代码//CategoryId、Number为int类型
                    this.txtrz.Text = this.txtrz.Text + emsg.Timestamp + "     " + AlarmNo.ToString() + "     " + emsg.Title + "     " + "\r\n"; 
                                                                                   //文本输出，格式，参数
                }
                MessageBox.Show("日志输出完毕");                                   ////弹窗提醒“日志输出完毕”
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


//---------------------------------------------控制器机器人运到到制定坐标（还没做好）————————————————————————————————————
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

/*
            JointTarget aJointTarget = controllers.MotionSystem.ActiveMechanicalUnit.GetPosition();
            aJointTarget.RobAx.Rax_1=  Convert.ToSingle(xmrux.Text);
            aJointTarget.RobAx.Rax_2 = Convert.ToSingle(xmruy.Text);
            aJointTarget.RobAx.Rax_3 = Convert.ToSingle(xmruz.Text);
            
            aJointTarget.RobAx.Rax_1 = Convert.ToSingle(xmrux.Text);
            aJointTarget.RobAx.Rax_1 = Convert.ToSingle(xmrux.Text);
            aJointTarget.RobAx.Rax_1 = Convert.ToSingle(xmrux.Text);
            */


        }
        //.................................................控制器机器人运到到制定坐标（还没做好）.................................................





        //---------------------------------------------机器人设置信息、时间信息————————————————————————————————————
        private void button11_Click(object sender, EventArgs e)//设置信息
        {
            //abbsys.AppendText("");
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

        }


        private void button14_Click(object sender, EventArgs e)
        {

            tasks = controllers.Rapid.GetTasks();
            ABB.Robotics.Controllers.RapidDomain.Module mod = tasks[0].GetModule("Mod1");

            Routine[] r = mod.GetRoutines();
            //获取mod1下的所有routine
            comboBox1.Items.Clear();
            //清屏
            for (int i = 0; i < r.Length; i++)
            {
                //this.txt_main.Text = this.txt_main.Text + r[i].Name.ToString() + "\r\n";
                comboBox1.Items.Add(r[i].Name.ToString());//输出到box1的item
            }
            comboBox1.Text = r[0].Name.ToString();
        }
        //.................................................rapid程序选择.................................................


        //---------------------------------------------获取工具、工具坐标系、坐标————————————————————————————————————
        private void button15_Click(object sender, EventArgs e)
        {
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


        private void authenticationExceptionBindingSource_CurrentChanged(object sender, EventArgs e)        {        }
        public Form1() { InitializeComponent(); }                       //未使用
        private void listView1_(object sender, EventArgs e) { }          //未使用
        private void label3_Click(object sender, EventArgs e) { }                //未使用
        private void txt_x_TextChanged(object sender, EventArgs e) { }                      //未使用
        private void label4_Click(object sender, EventArgs e) { }                           //未使用。txt_x子程序
        private void listView2_SelectedIndexChanged(object sender, EventArgs e) { }    //未使用。istView2子程序
        private void button8_Click(object sender, EventArgs e) { }                 //上电按钮子程序
        private void label5_Click(object sender, EventArgs e) { }
        private void txt_v_TextChanged(object sender, EventArgs e){}
        private void radioButton2_CheckedChanged(object sender, EventArgs e){}
        private void label10_Click(object sender, EventArgs e){}
        private void Form1_Load(object sender, EventArgs e)                            {        }
        private void abbrunbgm_SelectedIndexChanged(object sender, EventArgs e)        {        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)        {        }

        private void button16_Click(object sender, EventArgs e)
        {/*
            //bool i=false;
            string k = controllers..ToString();
            //this.txtcs.Text = ":"+k;            
            foreach (int p in k)
            {
                this.txtcs.Text = this.txtcs.Text + p.ToString() ;//遍历所有信息显示+ "\r\n结束"
            }*/

        }
















    }
}

    

