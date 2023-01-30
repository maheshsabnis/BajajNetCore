using Core_CQRS_API.Models;

namespace Core_CQRS_API.CQRSPattern
{
    public interface IDepartmentCommandService
    {
        Department CreateDepartment(Department department);
    }
}
