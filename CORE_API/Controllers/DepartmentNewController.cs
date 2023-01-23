using CORE_API.MOdels;
using CORE_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace CORE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentNewController : ControllerBase
    {
        INewDataService<Department, int> deptServ;

        public DepartmentNewController(INewDataService<Department, int> deptServ)
        {
            this.deptServ = deptServ;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response = await deptServ.GetAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response = await deptServ.GetAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Department dept)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response = await deptServ.CreateAsync(dept);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Department dept)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response = await deptServ.UpdateAsync(id,dept);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseObject<Department> response = new ResponseObject<Department>();
            response = await deptServ.DeleteAsync(id);
            return Ok(response);
        }
    }
}
