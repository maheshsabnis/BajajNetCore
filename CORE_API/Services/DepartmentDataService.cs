using CORE_API.MOdels;
using Microsoft.EntityFrameworkCore;

namespace CORE_API.Services
{
    public class DepartmentDataService : IDataService<Department, int>
    {
        BajajCompanyContext ctx;
        public DepartmentDataService(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Department> IDataService<Department, int>.CreateAsync(Department entity)
        {
            // wait for the Operation to be completed and then return result /  output
            var result =  await ctx.Departments.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return result.Entity; // Newly added entity will be returned
        }

        async Task<Department> IDataService<Department, int>.DeleteAsync(int id)
        {
            var rec = await ctx.Departments.FindAsync(id);
            ctx.Departments.Remove(rec);
            await ctx.SaveChangesAsync();
            return rec;
        } 

        async Task<IEnumerable<Department>> IDataService<Department, int>.GetAsync()
        {
            return await ctx.Departments.ToListAsync();
        }

        async Task<Department> IDataService<Department, int>.GetAsync(int id)
        {
            return await ctx.Departments.FindAsync(id);
        }

        async Task<Department> IDataService<Department, int>.UpdateAsync(int id, Department entity)
        {
            var rec = await ctx.Departments.FindAsync(id);
            if (rec != null)
            {
                rec.DeptNo = entity.DeptNo;
                rec.DeptName = entity.DeptName;
                rec.Capacity= entity.Capacity;
                rec.Location = entity.Location;
                await ctx.SaveChangesAsync();
                return rec;
            }
            return null; 
        }
    }
}
