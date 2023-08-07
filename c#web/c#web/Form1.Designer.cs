
namespace RobotWebServices
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.j6 = new System.Windows.Forms.Label();
            this.xtxx = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.io = new System.Windows.Forms.Label();
            this.djkg = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lbl_showspeed = new System.Windows.Forms.Label();
            this.hsc_speed = new System.Windows.Forms.HScrollBar();
            this.btn_J6Dec = new System.Windows.Forms.Button();
            this.btn_J5Dec = new System.Windows.Forms.Button();
            this.btn_J4Dec = new System.Windows.Forms.Button();
            this.btn_J3Dec = new System.Windows.Forms.Button();
            this.btn_J6Add = new System.Windows.Forms.Button();
            this.btn_J5Add = new System.Windows.Forms.Button();
            this.btn_J4Add = new System.Windows.Forms.Button();
            this.btn_J3Add = new System.Windows.Forms.Button();
            this.btn_J2Dec = new System.Windows.Forms.Button();
            this.btn_J2Add = new System.Windows.Forms.Button();
            this.btn_J1Dec = new System.Windows.Forms.Button();
            this.btn_J1Add = new System.Windows.Forms.Button();
            this.btn_jogAxisModeSet = new System.Windows.Forms.Button();
            this.btn_mShipGet = new System.Windows.Forms.Button();
            this.btn_localRegist = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.doxp = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.buttonzbxx = new System.Windows.Forms.Button();
            this.zbxx = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "系统信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "6轴角度";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // j6
            // 
            this.j6.AutoSize = true;
            this.j6.Location = new System.Drawing.Point(208, 60);
            this.j6.Name = "j6";
            this.j6.Size = new System.Drawing.Size(135, 15);
            this.j6.TabIndex = 3;
            this.j6.Text = "6轴角度显示区域：";
            // 
            // xtxx
            // 
            this.xtxx.AutoSize = true;
            this.xtxx.Location = new System.Drawing.Point(12, 60);
            this.xtxx.Name = "xtxx";
            this.xtxx.Size = new System.Drawing.Size(142, 15);
            this.xtxx.TabIndex = 1;
            this.xtxx.Text = "系统信息显示区域：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(406, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "获取I/O信息";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // io
            // 
            this.io.AutoSize = true;
            this.io.Location = new System.Drawing.Point(406, 59);
            this.io.Name = "io";
            this.io.Size = new System.Drawing.Size(136, 15);
            this.io.TabIndex = 5;
            this.io.Text = "I/O信息显示区域：";
            // 
            // djkg
            // 
            this.djkg.AutoSize = true;
            this.djkg.Location = new System.Drawing.Point(42, 36);
            this.djkg.Name = "djkg";
            this.djkg.Size = new System.Drawing.Size(112, 15);
            this.djkg.TabIndex = 6;
            this.djkg.Text = "电机状态：未知";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "上电";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(110, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "下电";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // lbl_showspeed
            // 
            this.lbl_showspeed.AutoSize = true;
            this.lbl_showspeed.Location = new System.Drawing.Point(624, 467);
            this.lbl_showspeed.Name = "lbl_showspeed";
            this.lbl_showspeed.Size = new System.Drawing.Size(112, 15);
            this.lbl_showspeed.TabIndex = 25;
            this.lbl_showspeed.Text = "速度（必填项）";
            // 
            // hsc_speed
            // 
            this.hsc_speed.Location = new System.Drawing.Point(611, 429);
            this.hsc_speed.Maximum = 2000;
            this.hsc_speed.Name = "hsc_speed";
            this.hsc_speed.Size = new System.Drawing.Size(144, 26);
            this.hsc_speed.TabIndex = 24;
            this.hsc_speed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsc_speed_Scroll);
            // 
            // btn_J6Dec
            // 
            this.btn_J6Dec.Location = new System.Drawing.Point(944, 513);
            this.btn_J6Dec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J6Dec.Name = "btn_J6Dec";
            this.btn_J6Dec.Size = new System.Drawing.Size(108, 42);
            this.btn_J6Dec.TabIndex = 22;
            this.btn_J6Dec.Text = "J6-";
            this.btn_J6Dec.UseVisualStyleBackColor = true;
            this.btn_J6Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J6Dec_MouseDown);
            this.btn_J6Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J6Dec_MouseUp);
            // 
            // btn_J5Dec
            // 
            this.btn_J5Dec.Location = new System.Drawing.Point(944, 455);
            this.btn_J5Dec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J5Dec.Name = "btn_J5Dec";
            this.btn_J5Dec.Size = new System.Drawing.Size(108, 42);
            this.btn_J5Dec.TabIndex = 21;
            this.btn_J5Dec.Text = "J5-";
            this.btn_J5Dec.UseVisualStyleBackColor = true;
            this.btn_J5Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J5Dec_MouseDown);
            this.btn_J5Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J5Dec_MouseUp);
            // 
            // btn_J4Dec
            // 
            this.btn_J4Dec.Location = new System.Drawing.Point(944, 398);
            this.btn_J4Dec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J4Dec.Name = "btn_J4Dec";
            this.btn_J4Dec.Size = new System.Drawing.Size(108, 42);
            this.btn_J4Dec.TabIndex = 20;
            this.btn_J4Dec.Text = "J4-";
            this.btn_J4Dec.UseVisualStyleBackColor = true;
            this.btn_J4Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J4Dec_MouseDown);
            this.btn_J4Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J4Dec_MouseUp);
            // 
            // btn_J3Dec
            // 
            this.btn_J3Dec.Location = new System.Drawing.Point(944, 342);
            this.btn_J3Dec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J3Dec.Name = "btn_J3Dec";
            this.btn_J3Dec.Size = new System.Drawing.Size(108, 42);
            this.btn_J3Dec.TabIndex = 19;
            this.btn_J3Dec.Text = "J3-";
            this.btn_J3Dec.UseVisualStyleBackColor = true;
            this.btn_J3Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J3Dec_MouseDown);
            this.btn_J3Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J3Dec_MouseUp);
            // 
            // btn_J6Add
            // 
            this.btn_J6Add.Location = new System.Drawing.Point(811, 513);
            this.btn_J6Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J6Add.Name = "btn_J6Add";
            this.btn_J6Add.Size = new System.Drawing.Size(108, 42);
            this.btn_J6Add.TabIndex = 18;
            this.btn_J6Add.Text = "J6+";
            this.btn_J6Add.UseVisualStyleBackColor = true;
            this.btn_J6Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J6Add_MouseDown);
            this.btn_J6Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J6Add_MouseUp);
            // 
            // btn_J5Add
            // 
            this.btn_J5Add.Location = new System.Drawing.Point(811, 455);
            this.btn_J5Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J5Add.Name = "btn_J5Add";
            this.btn_J5Add.Size = new System.Drawing.Size(108, 42);
            this.btn_J5Add.TabIndex = 23;
            this.btn_J5Add.Text = "J5+";
            this.btn_J5Add.UseVisualStyleBackColor = true;
            this.btn_J5Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J5Add_MouseDown);
            this.btn_J5Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J5Add_MouseUp);
            // 
            // btn_J4Add
            // 
            this.btn_J4Add.Location = new System.Drawing.Point(811, 398);
            this.btn_J4Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J4Add.Name = "btn_J4Add";
            this.btn_J4Add.Size = new System.Drawing.Size(108, 42);
            this.btn_J4Add.TabIndex = 17;
            this.btn_J4Add.Text = "J4+";
            this.btn_J4Add.UseVisualStyleBackColor = true;
            this.btn_J4Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J4Add_MouseDown);
            this.btn_J4Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J4Add_MouseUp);
            // 
            // btn_J3Add
            // 
            this.btn_J3Add.Location = new System.Drawing.Point(811, 342);
            this.btn_J3Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J3Add.Name = "btn_J3Add";
            this.btn_J3Add.Size = new System.Drawing.Size(108, 42);
            this.btn_J3Add.TabIndex = 16;
            this.btn_J3Add.Text = "J3+";
            this.btn_J3Add.UseVisualStyleBackColor = true;
            this.btn_J3Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J3Add_MouseDown);
            this.btn_J3Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J3Add_MouseUp);
            // 
            // btn_J2Dec
            // 
            this.btn_J2Dec.Location = new System.Drawing.Point(944, 286);
            this.btn_J2Dec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J2Dec.Name = "btn_J2Dec";
            this.btn_J2Dec.Size = new System.Drawing.Size(108, 42);
            this.btn_J2Dec.TabIndex = 15;
            this.btn_J2Dec.Text = "J2-";
            this.btn_J2Dec.UseVisualStyleBackColor = true;
            this.btn_J2Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J2Dec_MouseDown);
            this.btn_J2Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J2Dec_MouseUp);
            // 
            // btn_J2Add
            // 
            this.btn_J2Add.Location = new System.Drawing.Point(811, 286);
            this.btn_J2Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J2Add.Name = "btn_J2Add";
            this.btn_J2Add.Size = new System.Drawing.Size(108, 42);
            this.btn_J2Add.TabIndex = 14;
            this.btn_J2Add.Text = "J2+";
            this.btn_J2Add.UseVisualStyleBackColor = true;
            this.btn_J2Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J2Add_MouseDown);
            this.btn_J2Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J2Add_MouseUp);
            // 
            // btn_J1Dec
            // 
            this.btn_J1Dec.Location = new System.Drawing.Point(944, 231);
            this.btn_J1Dec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J1Dec.Name = "btn_J1Dec";
            this.btn_J1Dec.Size = new System.Drawing.Size(108, 39);
            this.btn_J1Dec.TabIndex = 13;
            this.btn_J1Dec.Text = "J1-";
            this.btn_J1Dec.UseVisualStyleBackColor = true;
            this.btn_J1Dec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J1Dec_MouseDown);
            this.btn_J1Dec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J1Dec_MouseUp);
            // 
            // btn_J1Add
            // 
            this.btn_J1Add.Location = new System.Drawing.Point(811, 231);
            this.btn_J1Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_J1Add.Name = "btn_J1Add";
            this.btn_J1Add.Size = new System.Drawing.Size(108, 39);
            this.btn_J1Add.TabIndex = 12;
            this.btn_J1Add.Text = "J1+";
            this.btn_J1Add.UseVisualStyleBackColor = true;
            this.btn_J1Add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_J1Add_MouseDown);
            this.btn_J1Add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_J1Add_MouseUp);
            // 
            // btn_jogAxisModeSet
            // 
            this.btn_jogAxisModeSet.Location = new System.Drawing.Point(611, 363);
            this.btn_jogAxisModeSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_jogAxisModeSet.Name = "btn_jogAxisModeSet";
            this.btn_jogAxisModeSet.Size = new System.Drawing.Size(144, 46);
            this.btn_jogAxisModeSet.TabIndex = 11;
            this.btn_jogAxisModeSet.Text = "设置单轴模式";
            this.btn_jogAxisModeSet.UseVisualStyleBackColor = true;
            this.btn_jogAxisModeSet.Click += new System.EventHandler(this.btn_jogAxisModeSet_Click);
            // 
            // btn_mShipGet
            // 
            this.btn_mShipGet.Location = new System.Drawing.Point(611, 297);
            this.btn_mShipGet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_mShipGet.Name = "btn_mShipGet";
            this.btn_mShipGet.Size = new System.Drawing.Size(143, 42);
            this.btn_mShipGet.TabIndex = 10;
            this.btn_mShipGet.Text = "请求Motion权限";
            this.btn_mShipGet.UseVisualStyleBackColor = true;
            this.btn_mShipGet.Click += new System.EventHandler(this.btn_mShipGet_Click);
            // 
            // btn_localRegist
            // 
            this.btn_localRegist.Location = new System.Drawing.Point(610, 231);
            this.btn_localRegist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_localRegist.Name = "btn_localRegist";
            this.btn_localRegist.Size = new System.Drawing.Size(144, 42);
            this.btn_localRegist.TabIndex = 9;
            this.btn_localRegist.Text = "注册本地用户";
            this.btn_localRegist.UseVisualStyleBackColor = true;
            this.btn_localRegist.Click += new System.EventHandler(this.btn_localRegist_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(589, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 365);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "机器人6轴控制";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.djkg);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Location = new System.Drawing.Point(333, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "电机控制";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.doxp);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Location = new System.Drawing.Point(83, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "I/O控制";
            // 
            // doxp
            // 
            this.doxp.AutoSize = true;
            this.doxp.Location = new System.Drawing.Point(73, 34);
            this.doxp.Name = "doxp";
            this.doxp.Size = new System.Drawing.Size(39, 15);
            this.doxp.TabIndex = 6;
            this.doxp.Text = "DOxp";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(18, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 19);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "开启";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(110, 66);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(58, 19);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "关闭";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // buttonzbxx
            // 
            this.buttonzbxx.Location = new System.Drawing.Point(627, 20);
            this.buttonzbxx.Name = "buttonzbxx";
            this.buttonzbxx.Size = new System.Drawing.Size(75, 23);
            this.buttonzbxx.TabIndex = 29;
            this.buttonzbxx.Text = "坐标信息";
            this.buttonzbxx.UseVisualStyleBackColor = true;
            this.buttonzbxx.Click += new System.EventHandler(this.buttonzbxx_Click);
            // 
            // zbxx
            // 
            this.zbxx.AutoSize = true;
            this.zbxx.Location = new System.Drawing.Point(624, 59);
            this.zbxx.Name = "zbxx";
            this.zbxx.Size = new System.Drawing.Size(142, 15);
            this.zbxx.TabIndex = 30;
            this.zbxx.Text = "坐标信息显示区域：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 607);
            this.Controls.Add(this.xtxx);
            this.Controls.Add(this.j6);
            this.Controls.Add(this.io);
            this.Controls.Add(this.zbxx);
            this.Controls.Add(this.buttonzbxx);
            this.Controls.Add(this.lbl_showspeed);
            this.Controls.Add(this.hsc_speed);
            this.Controls.Add(this.btn_J6Dec);
            this.Controls.Add(this.btn_J5Dec);
            this.Controls.Add(this.btn_J4Dec);
            this.Controls.Add(this.btn_J3Dec);
            this.Controls.Add(this.btn_J6Add);
            this.Controls.Add(this.btn_J5Add);
            this.Controls.Add(this.btn_J4Add);
            this.Controls.Add(this.btn_J3Add);
            this.Controls.Add(this.btn_J2Dec);
            this.Controls.Add(this.btn_J2Add);
            this.Controls.Add(this.btn_J1Dec);
            this.Controls.Add(this.btn_J1Add);
            this.Controls.Add(this.btn_jogAxisModeSet);
            this.Controls.Add(this.btn_mShipGet);
            this.Controls.Add(this.btn_localRegist);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label j6;
        private System.Windows.Forms.Label xtxx;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label io;
        private System.Windows.Forms.Label djkg;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label lbl_showspeed;
        private System.Windows.Forms.HScrollBar hsc_speed;
        private System.Windows.Forms.Button btn_J6Dec;
        private System.Windows.Forms.Button btn_J5Dec;
        private System.Windows.Forms.Button btn_J4Dec;
        private System.Windows.Forms.Button btn_J3Dec;
        private System.Windows.Forms.Button btn_J6Add;
        private System.Windows.Forms.Button btn_J5Add;
        private System.Windows.Forms.Button btn_J4Add;
        private System.Windows.Forms.Button btn_J3Add;
        private System.Windows.Forms.Button btn_J2Dec;
        private System.Windows.Forms.Button btn_J2Add;
        private System.Windows.Forms.Button btn_J1Dec;
        private System.Windows.Forms.Button btn_J1Add;
        private System.Windows.Forms.Button btn_jogAxisModeSet;
        private System.Windows.Forms.Button btn_mShipGet;
        private System.Windows.Forms.Button btn_localRegist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label doxp;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button buttonzbxx;
        private System.Windows.Forms.Label zbxx;
    }
}

