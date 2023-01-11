using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_OOPs_Understanding
{
    public class MyClass
    {
        string Name;
        protected int value = 0;
        internal string firstName = "Ethan";

        void Display()
        {
            Console.WriteLine("Private Display");
        }
        internal void InternalDisplay()
        {
            Console.WriteLine("Internal Display");
        }

        internal void CallingStaticMethodFromMyStaticClass()
        {
            MyStaticClass.SetI(); // INcrement
            Console.WriteLine($"After Incremet in MyCall i = {MyStaticClass.GetI()}");
        }
    }


    // DEfining the Static Class

    public static class MyStaticClass
    {
        private static int i = 10;

        public static void SetI()
        {
            // Incrementing
            i++;
        }
        public static int GetI() 
        {
            return i;
        }
    }

}
