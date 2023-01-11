// See https://aka.ms/new-console-template for more information
using CS_OOPs_Understanding;

Console.WriteLine("Understanding OOPs Concepts");
MyClass m = new MyClass();
//m.Name = "dd"; // Error because Name is Private
// 
// m.value = 100; ?? Error because value is protected

Console.WriteLine($"INternal firstName = {m.firstName}");

MyClass m1 = new();
Console.WriteLine($"ACcess firstName without class instace {m1.firstName} ");

//m1.Display(); // Priate method is not accessible

m1.InternalDisplay();

if (m == m1)
{
    Console.WriteLine("THey are same");
}
else
{
    Console.WriteLine("They are different");
}

// USing Static CLass
Console.WriteLine($"Initial i in Static = {MyStaticClass.GetI()}");
MyStaticClass.SetI();
Console.WriteLine($"After increment i in Static = {MyStaticClass.GetI()}");

Console.WriteLine($"Next Call i in Static = {MyStaticClass.GetI()}");
MyStaticClass.SetI();
Console.WriteLine($"After increment in next call i in Static = {MyStaticClass.GetI()}");

m1.CallingStaticMethodFromMyStaticClass();








Console.ReadLine();




