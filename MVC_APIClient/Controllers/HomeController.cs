using Microsoft.AspNetCore.Mvc;
using MVC_APIClient.Models;
using MVC_APIClient.MOdels;
using System.Diagnostics;
using System.Net.Http.Json;

namespace MVC_APIClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// The class to access APIs
        /// </summary>
        HttpClient client;
        string url;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            url = "https://localhost:7257/api";
        }

        public async Task<IActionResult> Index()
        {
            var response = await client.GetFromJsonAsync<ResponseObject<Department>>($"{url}/DepartmentNew");

            var records = response.Records;

            return View(records);
        }

        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public  async Task<IActionResult> Create(Department dept)
        {
            ResponseObject<Department> resp = new ResponseObject<Department>();
             
               var response = await client.PostAsJsonAsync<Department>($"{url}/DepartmentNew", dept);

            
            return RedirectToAction("Index");
        }


        public IActionResult ClientUI()
        {
            return View();
        }


        
        public IActionResult SearchUI()
        {
            return View(new SearchModel());
        }
        [HttpPost]
        public async Task<IActionResult> SearchUI(SearchModel search)
        {
            var response = await client.GetFromJsonAsync<string>($"https://localhost:7257/api/Search/fetch/{search.Expression}");


            
            return View();
        }


        public IActionResult FileUpload()
        {
            return View();
        }





    }
}