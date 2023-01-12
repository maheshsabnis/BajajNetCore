// See https://aka.ms/new-console-template for more information
using CS_ABstract_Polymorphism.ModelClasses;

Console.WriteLine("Using Abstract CLass");

Rectangle rect = new Rectangle(100,500);
Console.WriteLine($"Area of Rectangle is = {rect.GetArea()}");

Circle circle = new Circle(40);
Console.WriteLine($"ARea of Circl  is = {circle.GetArea()}");

// INstantiating the Derived class using BAse class Reference

// Compile Time Polymorphism for providing actual instances
// of DErived class

// Actual Instance of REactangle
Shape shape = new Rectangle(500,600);

Console.WriteLine($"ARea of REactangle using Share Ref is = {shape.GetArea()}");
// Actual Instance of Cirle
shape = new Circle(80);
Console.WriteLine($"ARea of Circle using Share Ref is = {shape.GetArea()}");


// Lets create an Instance of the LandReporter class

LandReporter reporter = new LandReporter(); 

// Let the clien choose teh shape with its dimensions

Rectangle rectangle= new Rectangle(1000,500);
Console.WriteLine($"Received aread from LandReporter is = {reporter.PrintArea(rectangle)}");

Circle c = new Circle (900);
Console.WriteLine($"Received Areat from LandReporter is = {reporter.PrintArea(c)}");



Console.ReadLine();
