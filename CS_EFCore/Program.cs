// See https://aka.ms/new-console-template for more information

using CS_EFCore.Models;
using CS_EFCore.DataAccess;
using System.Text.Json;

Console.WriteLine("DEMO EF Core");

DepartmentDA deptDa = new DepartmentDA();
// Read all Departments

var depts = deptDa.GetDepartments();

foreach (var d in depts)
{
    Console.WriteLine($"DeptUniqueId : {d.DeptUniqueId} DeptNo : {d.DeptNo} DeptName: {d.DeptName} Capacity: {d.Capacity} Location: {d.Location}");
}

// INsert
Department dept = new Department() 
{
   // DeptUniqueId = 4,
    DeptNo = "Dept-60",
    DeptName = "Accounts",
    Capacity = 45,
    Location = "Pune"
};

var NewDept = deptDa.AddDepartment(dept);


 var result = deptDa.DeleteDepartment(dept.DeptUniqueId);

Console.WriteLine($"Department Deleted = {result}");

Console.ReadLine();
