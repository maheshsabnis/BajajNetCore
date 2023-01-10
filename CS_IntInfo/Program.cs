// See https://aka.ms/new-console-template for more information
Console.WriteLine("Understanding int DataType");

int x=1000000000;

int y = 1000000000;
// Only for the Current Expression
// Convert y to long (8 bytes)
long res = x * Convert.ToInt64(y);


Console.WriteLine("sum = " + res);


Console.ReadLine();
