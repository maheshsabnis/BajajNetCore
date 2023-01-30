using Core_CQRS_API.CQRSPattern;
using Core_CQRS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_CQRS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentCommandController : ControllerBase
    {
        IDepartmentCommandService _commandService;
        public DepartmentCommandController(IDepartmentCommandService commandService)
        {
            _commandService = commandService;
        }
        [HttpPost]
        public IActionResult Post(Department department)
        {
            var res = _commandService.CreateDepartment(department);
            return Ok(res);
        }
    }
}
