using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ABstract_Polymorphism.ModelClasses
{
    public class LandReporter
    {
        public double PrintArea(Shape shape)
        {
            return shape.GetArea();
        }
    }
}
