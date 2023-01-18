using MVC_CoreApp.Models;

namespace MVC_CoreApp.Services
{
    public class EmployeeDataAccess
    {
        // Reference for BajajCompanyContext

        BajajCompanyContext ctx;

        /// <summary>
        /// Inject an instance of BajajCompanyContext to the 
        /// current class by receiving the Instance of BajajCompanyContext
        /// class from D.I. Container created in Program.cs
        /// This is known as "Constructor Injection"
        /// </summary>
        /// <param name="ctx"></param>
        public EmployeeDataAccess(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }
        public List<Employee> GetEmployees()
        {
            return ctx.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            var emp = ctx.Employees.Find(id);
            return emp;
        }

        public Employee AddEmployee(Employee emp)
        {
            ctx.Employees.Add(emp);
            ctx.SaveChanges();
            return emp;
        }
        public Employee UpdateEmployee(int id, Employee emp)
        {
            var empToUpdate = ctx.Employees.Find(id);
            if (empToUpdate != null)
            {
                empToUpdate.EmpNo = emp.EmpNo;
                empToUpdate.EmpName = emp.EmpName;
                empToUpdate.Designation = emp.Designation;
                empToUpdate.Salary = emp.Salary;
                empToUpdate.DeptUniqueId = emp.DeptUniqueId;
                ctx.SaveChanges();
                return empToUpdate;
            }
            return null;
        }

        public bool DeleteEmployee(int id)
        {
            var empToDelete = ctx.Employees.Find(id);
            if (empToDelete != null)
            {
                ctx.Employees.Remove(empToDelete);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
