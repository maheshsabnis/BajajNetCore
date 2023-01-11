// See https://aka.ms/new-console-template for more information
using CS_AppliedOOPs.Models;
using System.Collections;

Console.WriteLine("OOPs for Application Development");

//Employee emp = new Employee();

//emp.EmpNo = -1; // Write Data to Public Property (call set part)
//emp.EmpName = "Mahesh";
//emp.Salary = 100000;

//Console.WriteLine("Reading EMployee Info");
//// REad data from Property (call get part)
//Console.WriteLine($"EmpNo : {emp.EmpNo}, EmpName: {emp.EmpName}, Salary: {emp.Salary}");

// Object Initializer
// Provided the Object has Public Properties
EmployeeDTO e1 = new EmployeeDTO() 
{
  EmpNo = 101,EmpName = "Ajay",Salary=56000,Designation="Manager",DeptName="IT"  
};
EmployeeDTO e2 = new EmployeeDTO()
{
    EmpNo = 102,
    EmpName = "Kumar",
    Salary = 46000,
    Designation = "Lead",
    DeptName = "IT"
};
EmployeeDTO e3 = new EmployeeDTO()
{
    EmpNo = 103,
    EmpName = "Suraj",
    Salary = 36000,
    Designation = "Engineer",
    DeptName = "IT"
};

EmployeeLogic logic = new EmployeeLogic();
logic.AddEmployee(e1);
logic.AddEmployee(e2);
logic.AddEmployee(e3);

ArrayList emps = logic.GetEmployees();

foreach (EmployeeDTO emp in emps)
{
    Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Salary} {emp.Designation} {emp.DeptName}");
}





Console.ReadLine();
