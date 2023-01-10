// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string firstName = "JAmes";
string middleNAme = "Andrew";
string lastNAme = "BOnd";

// older style

string name = firstName + " " + middleNAme + " " + lastNAme;
Console.WriteLine(name);

string fullName = $"{firstName} {middleNAme} {lastNAme}";
Console.WriteLine($"Name = {fullName}");

Console.ReadLine();
