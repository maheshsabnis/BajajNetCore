// Importing the namespace to use all classes under this namespace 
using CS_SimpleOOPs;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Simple OOPs in C#");

// Lets INstantiate the class
// THis is instance creation
// THis will call the default (aka zero-argument) constructor
ClsMath m1 = new ClsMath();
// THis will call parametrized constructor
// THis will initialize private member of the class 
ClsMath m2 = new ClsMath(10,20);

m2.PrintMemeberValues();

int addResult = m2.Add();
Console.WriteLine($"Add  = {addResult}");
char cont;
do
{
Console.WriteLine("Mul: For Multiplication");
Console.WriteLine("Div: For Division");
Console.WriteLine("Square: For (X + Y) Square");
Console.WriteLine("XSquare: For X Square");
Console.WriteLine("YSquare: For Y Square");
Console.WriteLine("XCube: For X Cube");
Console.WriteLine("YCube: For Y Cube");

Console.WriteLine("Enter your Choice");
string opType = Console.ReadLine();
 
    switch (opType)
    {
        case "Mul":
            Console.WriteLine($" Multiplication = {m2.ProcessValues(opType)} ");
            break;
        case "Div":
            Console.WriteLine($" Division = {m2.ProcessValues(opType)} ");
            break;
        case "Square":
            Console.WriteLine($" Square = {m2.ProcessValues(opType)} ");
            break;
        case "XSquare":
            Console.WriteLine($" X-Square = {m2.ProcessValues(opType)} ");
            break;
        case "YSquare":
            Console.WriteLine($" Y-Square = {m2.ProcessValues(opType)} ");
            break;
        case "XCube":
            Console.WriteLine($" X-Cube = {m2.ProcessValues(opType)} ");
            break;
        case "YCube":
            Console.WriteLine($" Y-Cobe = {m2.ProcessValues(opType)} ");
            break;
        default:
            Console.WriteLine("Wrong Choice");
            break;
    }

    Console.WriteLine("Do you want to continue");
     
    cont = Convert.ToChar(Console.ReadLine());
    Console.Clear();
} while (cont == 'Y' || cont == 'y');

Console.ReadLine();    
