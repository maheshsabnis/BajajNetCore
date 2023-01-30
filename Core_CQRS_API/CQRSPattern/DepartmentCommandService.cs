using Core_CQRS_API.Models;

namespace Core_CQRS_API.CQRSPattern
{
    public class DepartmentCommandService : IDepartmentCommandService
    {
        BajajCompanyContext ctx;
        public DepartmentCommandService(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        Department IDepartmentCommandService.CreateDepartment(Department department)
        {
            var result = ctx.Departments.Add(department);
            ctx.SaveChanges();
            return result.Entity;
        }
    }
}
