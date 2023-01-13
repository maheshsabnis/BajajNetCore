// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var employees = new Employees();
try
{
    // Get the FIrst Occurance of the the Employee having EmpName as Ajay
    // var emp = employees.Where(e => e.EmpName == "Ajay1").First();

    var emp = employees.Where(e => e.EmpName == "Ajay1").FirstOrDefault();
    // if the LINQ query or any other operation is returning a 'Reference type' aka class object
    // then always check for 'null' and if the object is null then throw exception
    // COnditionally Throw Exception
    if (emp == null)
        throw new Exception("The EMployee is not available");

    Console.WriteLine($"EmpNo {emp.EmpNo} EmpName {emp.EmpName} DeptName {emp.DeptName}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error Occuured : {ex.Message}");
}





Console.ReadLine();


public class Employee
{
    public int EmpNo { get; set; }
    public string? EmpName { get; set; }
    public string? DeptName { get; set; }
    public string? Desigation { get; set; }
    public int Salary { get; set; }
}

public class Employees : List<Employee>
{
    public Employees()
    {
        Add(new Employee() { EmpNo = 101, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 90000 });
        Add(new Employee() { EmpNo = 102, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 80000 });
        Add(new Employee() { EmpNo = 103, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 90000 });
        Add(new Employee() { EmpNo = 104, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 70000 });
        Add(new Employee() { EmpNo = 105, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 90000 });
        Add(new Employee() { EmpNo = 106, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 60000 });
        Add(new Employee() { EmpNo = 107, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 90000 });
        Add(new Employee() { EmpNo = 108, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 50000 });
        Add(new Employee() { EmpNo = 109, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 40000 });
        Add(new Employee() { EmpNo = 110, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 90000 });
        Add(new Employee() { EmpNo = 111, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 30000 });
        Add(new Employee() { EmpNo = 112, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 20000 });
        Add(new Employee() { EmpNo = 113, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 10000 });
        Add(new Employee() { EmpNo = 114, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 90000 });
        Add(new Employee() { EmpNo = 115, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 90000 });
        Add(new Employee() { EmpNo = 116, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 40000 });
        Add(new Employee() { EmpNo = 117, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 70000 });
        Add(new Employee() { EmpNo = 118, EmpName = "Ajay", DeptName = "IT2", Desigation = "Manager", Salary = 80000 });
        Add(new Employee() { EmpNo = 119, EmpName = "Ajay", DeptName = "IT3", Desigation = "Director", Salary = 10000 });
    }
}
