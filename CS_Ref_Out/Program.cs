// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Ref and  Out");
int a = 10, b = 20;
Console.WriteLine($"Original a = {a} and b = {b}");
// using the by ref
// the parameter passing by ref MUST be having an initial value
XChange(ref a, ref b);
Console.WriteLine($"After XChange Call a = {a} and b = {b}");


Dictionary<int, string> keyValues = new Dictionary<int, string>();
keyValues.Add(1, "A");
keyValues.Add(2, "B");
keyValues.Add(3, "C");
keyValues.Add(4, "D"); 
keyValues.Add(5, "E");
// Out also pass the reference to method but this does not have initial value
// instead the method process this parameter and set its value
//string val;
keyValues.TryGetValue(6, out string  val);
Console.WriteLine(val);

Console.WriteLine();
Console.WriteLine($"2 Parameters {AddValues(1,2)}");
Console.WriteLine($"3 Parameters {AddValues(1, 2,3)}");
Console.WriteLine($"4 Parameters {AddValues(1, 2,3,4)}");
Console.WriteLine($"5 Parameters {AddValues(1, 2,3,4,5)}");


Console.ReadLine();

static void XChange(ref int x,ref int y)
{
    Console.WriteLine($"Before XChange in method  x = {x} and y = {y}");

    int z = x;
    x = y;
    y = z;
    Console.WriteLine($"After XChange in method  x = {x} and y = {y}");

}

/// params: used to pass variable number of paameters to a method
/// x and y are fixed
static int AddValues(int x,int y, params int[] arr)
{
    int sum = 0;

    foreach (int i in arr)
    {
        sum += i;
    }

    return sum;
}
