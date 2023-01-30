using Core_API_CQRS.Models;

namespace Core_API_CQRS.CQRSPattern
{
    public interface IDepartmentCommandRepository
    {
        Department SaveDepartment(Department dept);
    }


    public interface IDepartmentQueriesRepository
    {
        Department GetByDeptNo(int dno);
    }
}
