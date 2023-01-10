using System.Collections;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Collections");
// a Collection having increasing size of storage based 
// on data added in it
ArrayList arrayList = new ArrayList();

arrayList.Add(10); // int
arrayList.Add(20);
arrayList.Add(30);
arrayList.Add(10.4); // double
arrayList.Add(20.5);
arrayList.Add(30.7);
arrayList.Add(40.8);
arrayList.Add("Mahesh"); // string
arrayList.Add("Sabnis");
arrayList.Add('A'); // char
arrayList.Add('b');

// Print data
foreach (object o in arrayList)
{
    Console.WriteLine("Type of current entry is = " + o.GetType() + " and value of Current entry =" + o);
}
Console.WriteLine("Printing only INtegers");

foreach (object o in arrayList)
{
    // cjeck if the current entry in of the type int
    if (o.GetType() == typeof(int))
    {
        Console.WriteLine("Type of current entry is = " + o.GetType() + " and value of Current entry =" + (int)o);
    }
    
}
Console.ReadLine();    
