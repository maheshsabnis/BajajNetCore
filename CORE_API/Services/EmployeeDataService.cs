using CORE_API.MOdels;
using Microsoft.EntityFrameworkCore;

namespace CORE_API.Services
{
    public class EmployeeDataService : IDataService<Employee, int>
    {
        BajajCompanyContext ctx;
        public EmployeeDataService(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Employee> IDataService<Employee, int>.CreateAsync(Employee entity)
        {
            // wait for the Operation to be completed and then return result /  output
            var result =  await ctx.Employees.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return result.Entity; // Newly added entity will be returned
        }

        async Task<Employee> IDataService<Employee, int>.DeleteAsync(int id)
        {
            var rec = await ctx.Employees.FindAsync(id);
            ctx.Employees.Remove(rec);
            await ctx.SaveChangesAsync();
            return rec;
        } 

        async Task<IEnumerable<Employee>> IDataService<Employee, int>.GetAsync()
        {
            return await ctx.Employees.ToListAsync();
        }

        async Task<Employee> IDataService<Employee, int>.GetAsync(int id)
        {
            return await ctx.Employees.FindAsync(id);
        }

        async Task<Employee> IDataService<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            var rec = await ctx.Employees.FindAsync(id);
            if (rec != null)
            {
                rec.EmpNo = entity.EmpNo;
                rec.EmpName = entity.EmpName;
                rec.Designation= entity.Designation;
                rec.Salary = entity.Salary;
                rec.DeptUniqueId = entity.DeptUniqueId;
                await ctx.SaveChangesAsync();   
                return rec;
            }
            return null;
        }
    }
}
