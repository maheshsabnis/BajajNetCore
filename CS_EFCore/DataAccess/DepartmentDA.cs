using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_EFCore.Models;


namespace CS_EFCore.DataAccess
{
    public class DepartmentDA
    {
        // define DbCOntext reference
        BajajCompanyContext ctx;

        public DepartmentDA()
        {
            // Instantiate the DbContext
            ctx = new BajajCompanyContext();
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
