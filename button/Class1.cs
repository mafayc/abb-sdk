using System;
using ABB.Robotics.RobotStudio;
using ABB.Robotics.RobotStudio.Environment;
namespace RobotStudioEmptyAddin2
{
    public class Class1
    {
        // This is the entry point which will be called when the Add-in is loaded
        public static void AddinMain()
        {
            //Begin UndoStep
            Project.UndoContext.BeginUndoStep("RobotStudioEmptyAddin");

            try
            {
                //创建菜单
                RibbonTab ribbonTab = new RibbonTab("ribbonTab", "自定义菜单");
                //将创建的菜单添加到RobotStudio软件的菜单栏中
                UIEnvironment.RibbonTabs.Add(ribbonTab);
                //将菜单设为激活
                UIEnvironment.ActiveRibbonTab = ribbonTab;

                //创建功能区1与功能区2
                RibbonGroup ribbonGroup1 = new RibbonGroup("ribbonGroup1", "功能区1");
                RibbonGroup ribbonGroup2 = new RibbonGroup("ribbonGroup2", "功能区2");
                //功能区添加到菜单下
                ribbonTab.Groups.Add(ribbonGroup1);
                ribbonTab.Groups.Add(ribbonGroup2);

                //在功能区1创建按钮1
                CommandBarButton commandBarButton1 = new CommandBarButton("commandBarButton1", "按钮1");
                commandBarButton1.HelpText = "按钮1帮助说明";
                //设置按钮1图标
                //commandBarButton1.Image = Image.FromFile("E:\\ABB C\\RobotStudioEmptyAddin2\\RobotStudioEmptyAddin2\\Image\\RobotStudioSampleAddin1.Button1.Large.png");
                commandBarButton1.DefaultEnabled = true;
                //按钮1添加到功能区1
                ribbonGroup1.Controls.Add(commandBarButton1);

                //功能区1按钮之间创建分隔符
                CommandBarSeparator commandBarSeparator = new CommandBarSeparator();
                ribbonGroup1.Controls.Add(commandBarSeparator);

                //在功能区1创建按钮2
                CommandBarButton commandBarButton2 = new CommandBarButton("commandBarButton2", "按钮2");
                commandBarButton2.HelpText = "按钮2帮助说明";
                //设置按钮2图标
                //commandBarButton2.Image = Image.FromFile("E:\\ABB C\\RobotStudioEmptyAddin2\\RobotStudioEmptyAddin2\\Image\\RobotStudioSampleAddin1.Button2.Large.png");
                commandBarButton2.DefaultEnabled = true;
                //按钮2添加到功能区1
                ribbonGroup1.Controls.Add(commandBarButton2);

                //在功能区2创建按钮3
                CommandBarButton commandBarButton3 = new CommandBarButton("commandBarButton3", "按钮3");
                commandBarButton3.HelpText = "按钮3帮助说明";
                //设置按钮3图标
                //commandBarButton3.Image = Image.FromFile("E:\\ABB C\\RobotStudioEmptyAddin2\\RobotStudioEmptyAddin2\\Image\\RobotStudioSampleAddin1.CloseButton.Large.png");
                commandBarButton3.DefaultEnabled = true;
                //按钮3添加到功能区2
                ribbonGroup2.Controls.Add(commandBarButton3);

                //设置按钮大小，按钮1设置为小按钮，按钮2设置为大按钮，按钮3为小按钮
                RibbonControlLayout[] ribbonControlLayout = { RibbonControlLayout.Small, RibbonControlLayout.Large, RibbonControlLayout.Small };
                ribbonGroup1.SetControlLayout(commandBarButton1, ribbonControlLayout[0]);
                ribbonGroup1.SetControlLayout(commandBarButton2, ribbonControlLayout[1]);
                ribbonGroup2.SetControlLayout(commandBarButton3, ribbonControlLayout[2]);

                //添加按钮1的UI刷新处理程序
                commandBarButton1.UpdateCommandUI += new UpdateCommandUIEventHandler(button1_UpdateCommandUI);
                //添加按钮1的响应事件处理程序
                commandBarButton1.ExecuteCommand += new ExecuteCommandEventHandler(button1_ExecuteCommand);

                commandBarButton2.UpdateCommandUI += new UpdateCommandUIEventHandler(button2_UpdateCommandUI);
                commandBarButton2.ExecuteCommand += new ExecuteCommandEventHandler(button2_ExecuteCommand);

                commandBarButton3.UpdateCommandUI += new UpdateCommandUIEventHandler(button3_UpdateCommandUI);
                commandBarButton3.ExecuteCommand += new ExecuteCommandEventHandler(button3_ExecuteCommand);
            }
            catch (Exception ex)
            {
                Project.UndoContext.CancelUndoStep(CancelUndoStepType.Rollback);
                Logger.AddMessage(new LogMessage(ex.Message.ToString()));
            }
            finally
            {
                Project.UndoContext.EndUndoStep();
            }
        }
        static void button1_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            //按钮1被激活，用来取代程序语句button1.Enabled = true
            e.Enabled = true;
        }
        static void button1_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            //按钮1被按下输出信息提示
            Logger.AddMessage(new LogMessage("按下按钮1。"));
        }
        static void button2_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            e.Enabled = true;
        }
        static void button2_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            Logger.AddMessage(new LogMessage("按下按钮2。"));
        }
        static void button3_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            e.Enabled = true;
        }

        static void button3_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            Logger.AddMessage(new LogMessage("按下按钮3。"));
        }
    }
}