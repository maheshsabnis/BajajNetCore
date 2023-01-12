
namespace CS_Delegate
{
    // 1. DEfine a deegate. Ake sure that, it has same
    // signeture (input and output prameters) as that o the methos
    // which will be invoked using the delegate

    public delegate double OperaionHandler(double a, double b);

    class Program
    {
        static void Main(string[] args) 
        {
            double x  =20; double y = 10;
            Console.WriteLine("Using Delegate");
            Console.WriteLine("Direct Call");

            var result1 = GetRaisedTo(x,y);

            Console.WriteLine($"{x} raised to  {y} is = {result1}");
            Console.WriteLine("Ends Here");
            Console.WriteLine();
            Console.WriteLine("Using Delegate");
            // 2.Define a Delegate INstance and pass the address of method to it
            OperaionHandler handler1 = new OperaionHandler(GetRaisedTo);
            // 3. Pass the Parameters to Delegate reference so that it can invoke
            // method and get result from the execution
            var result2 = handler1(20, 10);
            Console.WriteLine($"Result using delegate is = {result2}");
            Console.WriteLine("Ends Here");
            Console.WriteLine();
            Console.WriteLine("C# 2.0 Anynymous Method, method without name");
            OperaionHandler handler2 = delegate (double a, double b) 
            {
                return (a * a) + 2 * a * b + (b * b);
            };
            Console.WriteLine($"Process ing values of {x} and {y} = {handler2(x,y)}");
            Console.WriteLine("End Here");
            Console.WriteLine();
            Console.WriteLine("Passing Delegate to Method as Input parameter");
            PrintResult(handler2);
            Console.WriteLine("Ends Here");
            Console.WriteLine();
            Console.WriteLine("PAss Implementation Directly to methiod that aceept delegate as input parameter");
            PrintResult(delegate(double m, double n) { return Math.Pow(m, n) * n; });
            Console.WriteLine("Ends Here");
            Console.WriteLine("The C# 3.0 Lambda Expressions, a simplification to pass implementation to a method that has input parameter as delegate");
            PrintResult((a, b) => { return (a * b) + (b * b) + (a * a) + (Math.Pow(a, 4)); });
            Console.WriteLine("Ends Here");
            Console.ReadLine();
        }

        /// <summary>
        /// A Method having 2 docuble input parameters and returns double
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static double GetRaisedTo(double x, double y)
        {
          return Math.Pow(x, y);
        }

        static void PrintResult(OperaionHandler handler)
        {
            Console.WriteLine($"After Processing result = {handler(20,10)}");
        }
    }
}