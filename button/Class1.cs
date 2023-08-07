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
                //�����˵�
                RibbonTab ribbonTab = new RibbonTab("ribbonTab", "�Զ���˵�");
                //�������Ĳ˵���ӵ�RobotStudio����Ĳ˵�����
                UIEnvironment.RibbonTabs.Add(ribbonTab);
                //���˵���Ϊ����
                UIEnvironment.ActiveRibbonTab = ribbonTab;

                //����������1�빦����2
                RibbonGroup ribbonGroup1 = new RibbonGroup("ribbonGroup1", "������1");
                RibbonGroup ribbonGroup2 = new RibbonGroup("ribbonGroup2", "������2");
                //��������ӵ��˵���
                ribbonTab.Groups.Add(ribbonGroup1);
                ribbonTab.Groups.Add(ribbonGroup2);

                //�ڹ�����1������ť1
                CommandBarButton commandBarButton1 = new CommandBarButton("commandBarButton1", "��ť1");
                commandBarButton1.HelpText = "��ť1����˵��";
                //���ð�ť1ͼ��
                //commandBarButton1.Image = Image.FromFile("E:\\ABB C\\RobotStudioEmptyAddin2\\RobotStudioEmptyAddin2\\Image\\RobotStudioSampleAddin1.Button1.Large.png");
                commandBarButton1.DefaultEnabled = true;
                //��ť1��ӵ�������1
                ribbonGroup1.Controls.Add(commandBarButton1);

                //������1��ť֮�䴴���ָ���
                CommandBarSeparator commandBarSeparator = new CommandBarSeparator();
                ribbonGroup1.Controls.Add(commandBarSeparator);

                //�ڹ�����1������ť2
                CommandBarButton commandBarButton2 = new CommandBarButton("commandBarButton2", "��ť2");
                commandBarButton2.HelpText = "��ť2����˵��";
                //���ð�ť2ͼ��
                //commandBarButton2.Image = Image.FromFile("E:\\ABB C\\RobotStudioEmptyAddin2\\RobotStudioEmptyAddin2\\Image\\RobotStudioSampleAddin1.Button2.Large.png");
                commandBarButton2.DefaultEnabled = true;
                //��ť2��ӵ�������1
                ribbonGroup1.Controls.Add(commandBarButton2);

                //�ڹ�����2������ť3
                CommandBarButton commandBarButton3 = new CommandBarButton("commandBarButton3", "��ť3");
                commandBarButton3.HelpText = "��ť3����˵��";
                //���ð�ť3ͼ��
                //commandBarButton3.Image = Image.FromFile("E:\\ABB C\\RobotStudioEmptyAddin2\\RobotStudioEmptyAddin2\\Image\\RobotStudioSampleAddin1.CloseButton.Large.png");
                commandBarButton3.DefaultEnabled = true;
                //��ť3��ӵ�������2
                ribbonGroup2.Controls.Add(commandBarButton3);

                //���ð�ť��С����ť1����ΪС��ť����ť2����Ϊ��ť����ť3ΪС��ť
                RibbonControlLayout[] ribbonControlLayout = { RibbonControlLayout.Small, RibbonControlLayout.Large, RibbonControlLayout.Small };
                ribbonGroup1.SetControlLayout(commandBarButton1, ribbonControlLayout[0]);
                ribbonGroup1.SetControlLayout(commandBarButton2, ribbonControlLayout[1]);
                ribbonGroup2.SetControlLayout(commandBarButton3, ribbonControlLayout[2]);

                //��Ӱ�ť1��UIˢ�´������
                commandBarButton1.UpdateCommandUI += new UpdateCommandUIEventHandler(button1_UpdateCommandUI);
                //��Ӱ�ť1����Ӧ�¼��������
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
            //��ť1���������ȡ���������button1.Enabled = true
            e.Enabled = true;
        }
        static void button1_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            //��ť1�����������Ϣ��ʾ
            Logger.AddMessage(new LogMessage("���°�ť1��"));
        }
        static void button2_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            e.Enabled = true;
        }
        static void button2_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            Logger.AddMessage(new LogMessage("���°�ť2��"));
        }
        static void button3_UpdateCommandUI(object sender, UpdateCommandUIEventArgs e)
        {
            e.Enabled = true;
        }

        static void button3_ExecuteCommand(object sender, ExecuteCommandEventArgs e)
        {
            Logger.AddMessage(new LogMessage("���°�ť3��"));
        }
    }
}