// See https://aka.ms/new-console-template for more information
using CS_Derivation.ModelClasses;

Console.WriteLine("DEMO Inheritence");
Shape shape = new Shape(10, 20);

Console.WriteLine($"Area of Shape is = {shape.GetArea()}");

Rectangle rect = new Rectangle(100, 200);
Console.WriteLine($"Area of Rectangle is = {rect.GetRectArea()}" );
Console.WriteLine($"Area of SHare using Rectangle's Instance is = {rect.GetArea()}");



Console.ReadLine();
