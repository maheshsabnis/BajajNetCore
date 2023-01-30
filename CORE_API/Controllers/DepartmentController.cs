using CORE_API.MOdels;
using CORE_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORE_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        // Lets inject the IDataService<Department,int>

        IDataService<Department, int> deptServ;

        public DepartmentController(IDataService<Department,int> data)
        {
            deptServ= data; 
        }

        // All Http Async Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var records = await deptServ.GetAsync();
            return Ok(records);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = await deptServ.GetAsync(id);
            return Ok(record);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Department dept)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    // Check if the DEptNo is already exists
                   var d = (await deptServ.GetAsync()).Where(r=>r.DeptNo.Trim() == dept.DeptNo.Trim()).FirstOrDefault();
                    if (d != null)
                        throw new Exception($"Department with DeptNo: {dept.DeptNo}  is already exist");
                    var result = await deptServ.CreateAsync(dept);
                    return Ok(result);
                }
                // rETURN Validation Errors
                return BadRequest(ModelState);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department dept)
        {
            if (ModelState.IsValid) 
            {
                var result = await deptServ.UpdateAsync(id,dept);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await deptServ.DeleteAsync(id);
            return Ok(result);
        }


    }
}
