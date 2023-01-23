using CORE_API.MOdels;
using Microsoft.EntityFrameworkCore;

namespace CORE_API.Services
{
    public class DepartmentDataNewService : INewDataService<Department, int>
    {
        BajajCompanyContext ctx;

        public DepartmentDataNewService(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<ResponseObject<Department>> INewDataService<Department, int>.CreateAsync(Department entity)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            try
            {
               

                var rec = await ctx.Departments.AddAsync(entity);
                await ctx.SaveChangesAsync();

                response.Record = rec.Entity; // The newly created REcord
                response.StatusMessage = $"REcord is created successfully";
                response.StatusCode = 200;
               
            }
            catch (Exception ex)
            {
                response.StatusMessage = $"Error occurred {ex.Message}";
                response.StatusCode = 200;
            }
            return response;
        }

        async Task<ResponseObject<Department>> INewDataService<Department, int>.DeleteAsync(int id)
        {
            ResponseObject<Department> response = new ResponseObject<Department>()   ;

            var rec = await ctx.Departments.FindAsync(id);
            if (rec == null)
            {
                response.StatusMessage = $"REcord based on {id} is not found";
                response.StatusCode = 404; // N0t Fund
                return response ;
            }
            ctx.Departments.Remove(rec);
            await ctx.SaveChangesAsync();
            response.StatusMessage = $"REcord based on {id} is deleted";
            response.StatusCode = 200; // N0t Fund
            return response;
        }

        async Task<ResponseObject<Department>> INewDataService<Department, int>.GetAsync()
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response.Records = await ctx.Departments.ToListAsync();
            response.StatusMessage = "OPeration completed Successfuly";
            response.StatusCode = 200;
            return response;

        }

        async Task<ResponseObject<Department>> INewDataService<Department, int>.GetAsync(int id)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response.Record = await ctx.Departments.FindAsync(id);
            response.StatusMessage = "OPeration completed Successfuly";
            response.StatusCode = 200;
            return response;
        }

        async Task<ResponseObject<Department>> INewDataService<Department, int>.UpdateAsync(int id, Department entity)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            var rec = await ctx.Departments.FindAsync(id);
            if (rec == null)
            {
                response.StatusMessage = $"REcord based on {id} is not found";
                response.StatusCode = 404; // N0t Fund
                return response;
            }

            rec.DeptNo = entity.DeptNo;
            rec.DeptName = entity.DeptName;
            rec.Capacity= entity.Capacity;  
            rec.Location= entity.Location;
            await ctx.SaveChangesAsync();
            response.StatusMessage = "Update OPeration completed Successfuly";
            response.StatusCode = 200;
            return response;
        }
    }
}
