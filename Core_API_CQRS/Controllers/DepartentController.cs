using Core_API_CQRS.CQRSPattern;
using Core_API_CQRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartentController : ControllerBase
    {
        IDepartmentQueriesRepository _queryRepo;
        IDepartmentCommandRepository _commandRepo;

        public DepartentController(IDepartmentCommandRepository commandRepo,IDepartmentQueriesRepository queryRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
        }

        [HttpGet]
        public IActionResult Get(int id) 
        {
            return Ok(_queryRepo.GetByDeptNo(id));
        }

        [HttpPost]
        public IActionResult Post(Department dept)
        {
            return Ok(_commandRepo.SaveDepartment(dept));
        }
    }
}
