// See https://aka.ms/new-console-template for more information
Console.WriteLine("Demo Arrays");

int x = 10;
// Print value of x and the DataTYpe aka TYpe of x
Console.WriteLine(" Value of x = " + x + " TYpe of x = " + x.GetType());
// Boxing x into the Universal Type object
object o = x;

Console.WriteLine(" Type stored in o = " + o.GetType() + "  value stored in object is = " + o);

// Retrieving value from Object and store it in int
// AN Explicit TypeCasting
// 1. Check the type of data stored in o
// 2. REad the Data and Cast it 
int  y = (int)o; // UnBoxing

Console.WriteLine("y = " + y);

// defining array
// Datatype [] identitifier = new DataType[SIZE]
// Always Fixed-Type of data
int[] arr = new int[6];
// add data in array
// 1. Initialize directly to its index
arr[0] = 10;
arr[1] = 20;
arr[2] = 30;
arr[3] = 40;
arr[4] = 50;
arr[5] = 60;

// Print array
for(int i = 0; i< arr.Length;i++)
{
    Console.WriteLine(" arr[i] =  " + arr[i]);
}
Console.WriteLine();

// 2. Add data in array in loop
Console.WriteLine("Enter Data for Array");
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Data in Array");
for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine(" Data ar index " + i + " = " + arr[i] );
}



Console.ReadLine();
