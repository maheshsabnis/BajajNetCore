using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface.Models
{
    /// <summary>
    /// INterface with Method Declarations
    /// </summary>
    
    public interface IMath
    {
        int Add(int x, int y);
        int Sub(int x, int y);
    }


    public interface INewMath
    {
        int Add(int x, int y);
        int Sub(int x, int y);
    }
}
