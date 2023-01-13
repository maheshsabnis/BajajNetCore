// See https://aka.ms/new-console-template for more information
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
Console.WriteLine("DEMO Serialization");

Employee emp = new Employee() { EmpNo = 101, EmpName = "ABC" };

var jsonData =  JsonSerializer.Serialize(emp);

Console.WriteLine(jsonData);


Employee e1 = JsonSerializer.Deserialize<Employee>(jsonData);
Console.WriteLine($"After DEserialization : EmpNo : {e1.EmpNo} and EmpName: {e1.EmpName}");


// SerializeData();

//DeserializeData();


Console.ReadLine();

static void SerializeData()
{
    // Help to write the CLR object into the strem by converting it into the
    // Binary format
    BinaryFormatter bf = new BinaryFormatter();
    string streamPath = @"C:\BajajNetApps\emp.dat";
    // define a FileStream so that data can be witten into it
    FileStream Fs = new FileStream(streamPath, FileMode.CreateNew);

    // Define an Instance that is to be serialized

    Employee emp = new Employee() { EmpNo = 101, EmpName = "ABC" };

    // Now Serialize
    bf.Serialize(Fs, emp);

    Fs.Close();
    Fs.Dispose();
}

static void DeserializeData()
{
    BinaryFormatter bf = new BinaryFormatter();
    string streamPath = @"C:\BajajNetApps\emp.dat";
    // Open the STream so that data can be read from it
    FileStream Fs = new FileStream(streamPath, FileMode.Open);

    // Define an Instance that is to be serialized

    Employee emp = (Employee) bf.Deserialize(Fs);
    Fs.Close();
    Fs.Dispose();


    Console.WriteLine($"Data from Stream is EmpNo : {emp.EmpNo}, EmpName : {emp.EmpName}");
}


/// <summary>
/// Applying Attribute on the class to define
/// its behavior so currently it is mareked to
/// write data into the stream
/// </summary>
[Serializable]
public class Employee
{
    public int EmpNo { get; set; }
    public string? EmpName { get; set; }
}
