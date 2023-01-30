using Core_API_CQRS.Models;

namespace Core_API_CQRS.CQRSPattern
{
    public class DepartmentQueryRepository : IDepartmentQueriesRepository
    {
        BajajCompanyContext ctx;

        public DepartmentQueryRepository(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        Department IDepartmentQueriesRepository.GetByDeptNo(int dno)
        {
            return ctx.Departments.Find(dno);
        }
    }


    public class DepartmentCommandRepository : IDepartmentCommandRepository
    {
        BajajCompanyContext ctx;

        public DepartmentCommandRepository(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }

        Department IDepartmentCommandRepository.SaveDepartment(Department dept)
        {
            ctx.Departments.Add(dept);
            ctx.SaveChanges();
            return dept;
        }
    }
}
