using CORE_API.MOdels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORE_API.Controllers
{
    /// <summary>
    /// THe Ation Method will be access with its name
    /// https://localhost:7257/api/DepartmentBinder/[action-method-name]
    /// </summary>
    [Route("api/[controller]/[action]")]
    //[ApiController]
    public class DepartmentBinderController : ControllerBase
    {
        BajajCompanyContext ctx;
        public DepartmentBinderController(BajajCompanyContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpPost]
        [ActionName("PostFromBody")]
        public async Task<IActionResult> PostFromBody([FromBody] Department dept)
        {
            return Ok();
        }

        /// <summary>
        /// THe Ation Method will be access with its name
        /// https://localhost:7257/api/DepartmentBinder/PostParams?dno=Dept-009&dname=myd&cap=90&loc=iii
        /// </summary>
        [HttpPost]
        [ActionName("PostParams")]
        public async Task<IActionResult> PostParams(string dno, string dname, int cap, string loc )
        {
            // REad parameters and save them into object
            Department department = new Department() 
            {
               DeptNo = dno,
               DeptName= dname,
               Capacity= cap,
               Location= loc
            };   

            return Ok();
        }


        /// <summary>
        /// THe Ation Method will be access with its name
        /// https://localhost:7257/api/DepartmentBinder/PostFromQuery?dno=Dept-009&dname=myd&cap=90&loc=iii
        /// </summary>
        [HttpPost]
        [ActionName("PostFromQuery")]
        public async Task<IActionResult> PostFromQuery([FromQuery]Department dept)
        {
           

            return Ok();
        }


        /// <summary>
        /// THe Ation Method will be access with its name
        /// https://localhost:7257/api/DepartmentBinder/PostFromRoute/Dept009/JDJD/666/Pune
        /// </summary>
        [HttpPost("{DeptNo}/{DeptName}/{Capacity}/{Location}")]
        [ActionName("PostFromRoute")]
        public async Task<IActionResult> PostFromRoute([FromRoute] Department dept)
        {


            return Ok();
        }
    }
}
