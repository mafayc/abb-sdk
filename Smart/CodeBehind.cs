using ABB.Robotics.Math;
using ABB.Robotics.RobotStudio;
using ABB.Robotics.RobotStudio.Stations;
using System;
using System.Collections.Generic;
using System.Text;



namespace Smart
{

    /// <summary>
    /// Code-behind class for the Smart Smart Component.
    /// </summary>
    /// <remarks>
    /// The code-behind class should be seen as a service provider used by the 
    /// Smart Component runtime. Only one instance of the code-behind class
    /// is created, regardless of how many instances there are of the associated
    /// Smart Component.
    /// Therefore, the code-behind class should not store any state information.
    /// Instead, use the SmartComponent.StateCache collection.
    /// </remarks>
    public class CodeBehind : SmartComponentCodeBehind
    {
        private double a, b, c = 1, d = 1, o = 0;

        /// <summary>
        /// Called when the value of a dynamic property value has changed.
        /// </summary>
        /// <param name="component"> Component that owns the changed property. </param>
        /// <param name="changedProperty"> Changed property. </param>
        /// <param name="oldValue"> Previous value of the changed property. </param>
        public override void OnPropertyValueChanged(SmartComponent component, DynamicProperty changedProperty, Object oldValue)
        {
            if (changedProperty.Name == "IA")
            {
                a = (double)changedProperty.Value; Logger.AddMessage(new LogMessage("a="+a.ToString()));
            }
            else if (changedProperty.Name == "IB")
            {
                b = (double)changedProperty.Value; Logger.AddMessage(new LogMessage("b=" + b.ToString()));
            }
            else if (changedProperty.Name == "IC")
            {
                c = (double)changedProperty.Value; Logger.AddMessage(new LogMessage("c=" + c.ToString()));
            }
            else if (changedProperty.Name == "ID")
            {
                d = (double)changedProperty.Value; Logger.AddMessage(new LogMessage("d=" + d.ToString()));
            }




        }


        public override void OnIOSignalValueChanged(SmartComponent component, IOSignal changedSignal)
        {

                o = (a+b)*c/d;
                component.Properties["OUT"].Value = o;
                Logger.AddMessage(new LogMessage("("+a+ "+"+b+ ")*"+c+ "/" + d+"=" + o));


        }

        public override void OnSimulationStep(SmartComponent component, double simulationTime, double previousTime)
        {
        }
    }
}
