using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// Same as the name of tyhe Project
/// Nemspace can contain multiple classes
namespace CS_SimpleOOPs
{
    /// <summary>
    /// Data Memebers
    /// Member Functions aka Methods
    /// </summary>
    public class ClsMath
    {
        // DEfining Data Members
        // DEfault access specifier for all members of class
        // is private
        int x,y;

        // COnstrctur: Method with same name as the class name
        // but no return type 
        public ClsMath() 
        {
            Console.WriteLine("The defaule contructor is called");
        }
        /// <summary>
        /// Parameterized COnstructor
        /// USed to initialize Private members of the class
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public ClsMath(int a, int b)
        {
            Console.WriteLine("Patraeterized Constructor is called");
            x = a;
            y = b;
        }
        /// <summary>
        /// A method w/o any input and output parameters
        /// ONe-Way methodor void method
        /// </summary>
        public void PrintMemeberValues()
        {
            Console.WriteLine($"x = {x} and y = {y}");
        }
        /// <summary>
        /// Method with output parameter define as
        /// 'int' return type
        /// Two-Way method
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            int z = x + y;
            // return value using 'return' keyword
            return z;
        }
        /// <summary>
        /// Method with input and output parameter 
        /// </summary>
        /// <param name="opType"></param>
        /// <returns></returns>
        public int ProcessValues(string opType)
        {
            int result = 0;
            switch (opType)
            {
                case "Mul":
                    result = x * y;
                    break;
                case "Div":
                    result = x / y; 
                    break;
                case "Square":
                    result = (x * x) + 2 * x * y + (y * y);
                    break;
                case "XSquare":
                    result = x * x;
                    break;
                case "YSquare":
                    result = y * y; 
                    break;
                case "XCube":
                    result = x * x * x;
                    break;
                case "YCube":
                    result = y * y * y;
                    break;
            }
            return result;
        }

    }
}
