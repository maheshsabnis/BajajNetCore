using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORE_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        /// <summary>
        /// Val1: Search Croteria 1
        /// Val2: Search Criteria 2
        /// Filter: and / or condition
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="filter"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        [HttpGet("{val1}/{filter}/{val2}")]
        [ActionName("getdata")]
        public IActionResult GetData(string val1, string filter, string val2)
        {
            switch (filter)
            {
                case "OR":
                    break;
                case "AND":
                    break;
                default:
                    break;
            }

            return Ok();
        }


        [HttpGet("{expression}")]
        [ActionName("fetch")]
        public IActionResult Fetch(string expression)
        { 
            return Ok();
        }

    }
}
