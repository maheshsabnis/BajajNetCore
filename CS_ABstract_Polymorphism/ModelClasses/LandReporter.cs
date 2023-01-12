using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ABstract_Polymorphism.ModelClasses
{
    /// <summary>
    /// FActory that will Dynamically decide the 
    /// Type of Object to be processed
    /// "Dynamic Polymorphism"
    /// </summary>
    public class LandReporter
    {
        public double PrintArea(Shape shape)
        {
            return shape.GetArea();
        }
    }
}
