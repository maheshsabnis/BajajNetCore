using Core_CQRS_API.CQRSPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_CQRS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentQueryController : ControllerBase
    {
        IDepartmentQueryService _queryService;
        public DepartmentQueryController(IDepartmentQueryService queryService)
        {
            _queryService = queryService;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_queryService.GetDepartments());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_queryService.GetDepartmentsById(id));
        }
    }
}
