using Core_CQRS_API.Models;

namespace Core_CQRS_API.CQRSPattern
{
    public interface IDepartmentQueryService
    {
        List<Department> GetDepartments();
        Department GetDepartmentsById(int departmentId);
    }
}
