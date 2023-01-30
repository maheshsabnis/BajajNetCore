using Core_CQRS_API.Models;

namespace Core_CQRS_API.CQRSPattern
{
    public class DepartmentQueryService : IDepartmentQueryService
    {
        BajajCompanyContext ctx;

        public DepartmentQueryService(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        List<Department> IDepartmentQueryService.GetDepartments()
        {
            return ctx.Departments.ToList();
        }

        Department IDepartmentQueryService.GetDepartmentsById(int departmentId)
        {
            return ctx.Departments.Find(departmentId);
        }
    }
}
