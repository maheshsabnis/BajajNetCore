using MVC_CoreApp.Models;

namespace MVC_CoreApp.Services
{
    public class DepartmentDataAccess
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
        public DepartmentDataAccess(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }
        public List<Department> GetDepartments()
        {
            return ctx.Departments.ToList();
        }

        public Department GetDepartment(int id)
        {
            var dept = ctx.Departments.Find(id);
            return dept;
        }

        public Department AddDepartment(Department dept)
        {
            ctx.Departments.Add(dept);
            ctx.SaveChanges();
            return dept;
        }
        public Department UpdateDepartment(int id, Department dept)
        {
            var deptToUpdate = ctx.Departments.Find(id);
            if (deptToUpdate != null)
            {
                deptToUpdate.DeptNo = dept.DeptNo;
                deptToUpdate.DeptName = dept.DeptName;
                deptToUpdate.Capacity = dept.Capacity;
                deptToUpdate.Location = dept.Location;
                ctx.SaveChanges();
                return deptToUpdate;
            }
            return null;
        }

        public bool DeleteDepartment(int id)
        {
            var deptToDelete = ctx.Departments.Find(id);
            if (deptToDelete != null)
            {
                ctx.Departments.Remove(deptToDelete);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
