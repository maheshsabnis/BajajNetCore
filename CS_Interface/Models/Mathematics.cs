using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface.Models
{
    /// <summary>
    /// Class MUST implement all methods of the interface
    /// THe following class is implementing interace
    /// "Implicitly"
    /// </summary>
    public class Mathematics : IMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }
    }

    /// <summary>
    /// Explit IMplementation
    /// </summary>
    public class NewMath : IMath,INewMath
    {
        int IMath.Add(int x, int y)
        {
            return x + y;
        }

        int INewMath.Add(int x, int y)
        {
            return (x * x) + (y * y);
        }

        int IMath.Sub(int x, int y) 
        {
            return x - y;
        }

        int INewMath.Sub(int x, int y)
        {
            return (x * x) - (y * y);
        }
    }
}
