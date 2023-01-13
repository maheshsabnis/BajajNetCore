// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO List");
// List only for integers
List<int> intList = new List<int>();
intList.Add(10);
intList.Add(20);
intList.Add(30);
intList.Add(40);
List<string> strList = new List<string>();
strList.Add("Tejas");
strList.Add("Mahesh");
strList.Add("Ramesh");
strList.Add("Ram");
strList.Add("Kaustubh");
strList.Add("Krishna");
strList.Add("Sameer");

List<Employee> employees = new List<Employee>();

employees.Add(new Employee() { EmpNo = 101, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 102, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 80000 });
employees.Add(new Employee() { EmpNo = 103, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 104, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 70000 });
employees.Add(new Employee() { EmpNo = 105, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 106, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 60000 });
employees.Add(new Employee() { EmpNo = 107, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 108, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 50000 });
employees.Add(new Employee() { EmpNo = 109, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 40000 });
employees.Add(new Employee() { EmpNo = 110, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 111, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 30000 });
employees.Add(new Employee() { EmpNo = 112, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 20000 });
employees.Add(new Employee() { EmpNo = 113, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 10000 });
employees.Add(new Employee() { EmpNo = 114, EmpName = "Bjay", DeptName = "IT2", Desigation = "Manager", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 115, EmpName = "Cjay", DeptName = "IT3", Desigation = "Director", Salary = 90000 });
employees.Add(new Employee() { EmpNo = 116, EmpName = "Djay", DeptName = "IT4", Desigation = "Manager", Salary = 40000 });
employees.Add(new Employee() { EmpNo = 117, EmpName = "Ajay", DeptName = "IT1", Desigation = "Director", Salary = 70000 });
employees.Add(new Employee() { EmpNo = 118, EmpName = "Ajay", DeptName = "IT2", Desigation = "Manager", Salary = 80000 }); 
employees.Add(new Employee() { EmpNo = 119, EmpName = "Ajay", DeptName = "IT3", Desigation = "Director", Salary = 10000 });

int sum = 0;
foreach (Employee emp in employees)
{

    if (emp.DeptName == "IT1" && emp.Salary < 50000)
    {
        Console.WriteLine($"EmpNo {emp.EmpNo} EmpNAme : {emp.EmpName} Salary : {emp.Salary}");
        sum += emp.Salary;
    }

}
Console.WriteLine($"Sum = {sum}");
Console.WriteLine();
Console.WriteLine();
// Using LINQ
Console.WriteLine("USing LINQ");
// REac only Thse employees from DEptNAme as 'IT1' and convert th result into the 'List'
// usig ToList() / ToArray() method
var result1 = employees.Where(e => e.DeptName == "IT1").ToArray();
PrintResult(result1);

// Lets calculate sum of emloyees for IT1 DeptName

sum = result1.Sum(e=>e.Salary);
Console.WriteLine($"Sum using LINQ is = {sum}");
Console.WriteLine();
Console.WriteLine("Sum of Salary Group by DeptName");

var result3 = employees.GroupBy(e => e.DeptName)
    .Select(e => e.Sum(e => e.Salary));

foreach (var record in result3)
{
    Console.WriteLine($"{record}");
}

Console.WriteLine();
Console.WriteLine("USing Delarative Queries");

var result4 = from emp in employees
              where emp.DeptName == "IT1"
              select emp;

PrintResult(result4);
Console.WriteLine();
Console.WriteLine("Using Group");

var result5 = (from emp in employees
              group emp by emp.DeptName into deptgroup  // Create groups based on Group key
              select new {  // Create class w/o name
                 DeptName = deptgroup.Key,
                 Salary = deptgroup.Sum(e=>e.Salary)
              }).ToList();

foreach (var record in result5)
{
    Console.WriteLine($"DeptName : {record.DeptName} and Sum of Salary is = {record.Salary}");
}

Console.WriteLine();
Console.WriteLine("ALl EMployees by Descending order of EmpNAme");

var result6 = from emp in employees
              orderby emp.EmpName descending
              select emp;
PrintResult(result6);

Console.ReadLine();

static void PrintResult(IEnumerable<Employee> emps)
{
    foreach (Employee emp in emps)
    {
        Console.WriteLine($"Emp: {emp.EmpNo} EmpName: {emp.EmpName} DeptName: {emp.DeptName} Designation: {emp.Desigation} Salary: {emp.Salary}");
    } 
}


public class Employee
{
    public int EmpNo { get; set; }
    public string? EmpName { get; set; }
    public string? DeptName { get; set; }
    public string? Desigation { get; set; }
    public int Salary { get; set; }
}