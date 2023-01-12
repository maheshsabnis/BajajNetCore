using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Derivation.ModelClasses
{
    /// <summary>
    /// Shape always have dimesions and has the area calcultion
    /// </summary>
    public class Shape
    {
        //Data Members
        private double xDimension;
        private double yDimension;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="xDimension"></param>
        /// <param name="yDimension"></param>
        public Shape(double xDimension, double yDimension)
        {
            // Local members of class are accessed within class using 'this.MEMBER_NAME'
            this.xDimension = xDimension;
            this.yDimension = yDimension;
        }

        public double GetArea()
        {
            return xDimension * yDimension;
        }
    }

    /// <summary>
    /// Rectangle is derived from 'Shape'
    /// THis means that 'Rectangle is-a Shape'
    /// </summary>
    public class Rectangle : Shape
    {
        private double height = 0;
        private double width = 0;
        /// <summary>
        /// ACcess the BAse class ctor and pass parameters
        /// to it using 'base()'
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Rectangle(double height, double width):base(height, width) 
        {
            this.height = height;
            this.width = width;
        }

        public double GetRectArea()
        {
            return height* width;
        }
    }

    public class Circle : Shape
    {
        private double radius = 0;

        public Circle(double radius):base(radius,radius)
        {
            this.radius = radius;
        }

        public double GetCircleArea()
        { 
            return Math.PI* (radius*radius);
        }
    }
}
