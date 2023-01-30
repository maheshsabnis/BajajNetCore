using CORE_API.MOdels;
using CORE_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace CORE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")] //api-version=1.0
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class EmployeeController : ControllerBase
    {
        // Lets inject the IDataService<Employee,int>

        IDataService<Employee, int> empServ;

        public EmployeeController(IDataService<Employee,int> data)
        {
            empServ= data; 
        }

        // All Http Async Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var records = await empServ.GetAsync();
            return Ok(records);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = await empServ.GetAsync(id);
            return Ok(record);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var result = await empServ.CreateAsync(emp);
                return Ok(result);
            }
            // rETURN Validation Errors
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee emp)
        {
            if (ModelState.IsValid) 
            {
                var result = await empServ.UpdateAsync(id,emp);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await empServ.DeleteAsync(id);
            return Ok(result);
        }


    }
}
