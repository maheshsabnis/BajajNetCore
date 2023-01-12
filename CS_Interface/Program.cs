// See https://aka.ms/new-console-template for more information
using CS_Interface.Models;

Console.WriteLine("DEMO Interface");

// Class INstance
Mathematics m = new Mathematics();
Console.WriteLine($"Add = {m.Add(3,4)}");
Console.WriteLine($"Sub = {m.Sub(5,4)}");

// INterface Reference instantiated using class
IMath m1 = new Mathematics();
Console.WriteLine($"Add = {m1.Add(3, 4)}");
Console.WriteLine($"Sub = {m1.Sub(5, 4)}");

IMath m2 = new NewMath();

Console.WriteLine($"New Math Add = {m2.Add(100,200)}");
Console.WriteLine($"New Math Sub = {m2.Sub(100, 200)}");

INewMath m3 = new NewMath();

Console.WriteLine($"New Math Add = {m3.Add(100, 200)}");
Console.WriteLine($"New Math Sub = {m3.Sub(100, 200)}");


Console.ReadLine();
