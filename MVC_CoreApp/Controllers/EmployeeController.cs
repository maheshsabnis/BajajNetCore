using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CoreApp.CustomFilters;
using MVC_CoreApp.CustomSessionExtensions;
using MVC_CoreApp.Models;
using MVC_CoreApp.Services;
using System.Text.Json;

namespace MVC_CoreApp.Controllers
{
    /// <summary>
    /// APplying Action Filter at Controller Level
    /// Hence applied for all action methods in the Current Controller
    /// </summary>
   // [LogFilter]
    public class EmployeeController : Controller
    {
        // Referece for EmployeeDataAccess

        EmployeeDataAccess empDa;
        DepartmentDataAccess deptDa;

        /// <summary>
        /// Injecting EmployeeDataAccess to the current class
        /// where as EmployeeDataAccess is registered in DI Container
        /// in Program.cs
        /// </summary>
        /// <param name="da"></param>
        public EmployeeController(EmployeeDataAccess da, DepartmentDataAccess d)
        {
            empDa = da;  
            deptDa = d;
        }

        /// <summary>
        /// Applying Action Filter on Action Method
        /// </summary>
        /// <returns></returns>
        //[LogFilter]
        public IActionResult Index()
        {
            List<Employee> records= new List<Employee>();
            // read data from TempData
            //  int deptUniqueId = Convert.ToInt32( TempData["DeptUniqueId"]);
            // Retrieve data from Session
            int deptUniqueId = Convert.ToInt32(HttpContext.Session.GetInt32("DeptUniqueId"));

            //Department deptData = JsonSerializer.Deserialize<Department>(HttpContext.Session.GetString("Dept"));

            Department deptData = HttpContext.Session.GetObjet<Department>("Dept");
            if (deptUniqueId == 0)
            {
                records = empDa.GetEmployees();
            }
            else
            { 
              records = empDa.GetEmployees().Where(e=>e.DeptUniqueId == deptUniqueId).ToList();
            }

            // Before Leaving Index Action Method 'Keep' TempData

            //TempData.Keep();

            return View(records);
        }

        public IActionResult Create()
        {
            int deptUniqueId = Convert.ToInt32(HttpContext.Session.GetInt32("DeptUniqueId"));
            // var id = Convert.ToInt32(TempData["DeptUniqueId"]); 
            var entity = new Employee();
            // Get Departments and its DeptName
            // We are taking SelectListItem list because
            // asp-items only accepts IEnumerable<SelectListItem>
            List<SelectListItem> depts = new List<SelectListItem>();
            foreach (var dept in deptDa.GetDepartments())
            {
                depts.Add(new SelectListItem(dept.DeptName, dept.DeptUniqueId.ToString()));
            }

            ViewBag.Departments = depts;
            // PAss an EMptyEmployee Object to View
            return View(entity);
        }

        /// <summary>
        /// This will be executed when POST request is made from UI
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Employee rec) 
        {
            var id = Convert.ToInt32(TempData["DeptUniqueId"]);
            //try
            //{
            // Check for the Validtity of the Model Class
            if (ModelState.IsValid)
            {
                // Before calling ass please check if the DeptNo is already present
                var dept = empDa.GetEmployees().Where(d => d.EmpNo == rec.EmpNo).FirstOrDefault();
                if (dept != null)
                { 
                    throw new Exception($"DeptNo {rec.EmpNo} is already exist");
                    
                }
                else
                {
                    var entity = empDa.AddEmployee(rec);
                    // Navigate to 'Index' action method so that
                    // it will show the 'Index' view with
                    // newly added record
                    return RedirectToAction("Index");
                }
            }
            else
            {
                List<SelectListItem> depts = new List<SelectListItem>();
                foreach (var dept in deptDa.GetDepartments())
                {
                    depts.Add(new SelectListItem(dept.DeptName, dept.DeptUniqueId.ToString()));
                }

                ViewBag.Departments = depts;
                // Stey on the Same Page to show Error MEssages
                return View(rec);
            }
            //}
            //catch (Exception ex)
            //{
            //    // Return Error Page, this is present in
            //    // 'Shared' sub-folder of 'Views' folder
            //    return View("Error", new ErrorViewModel() 
            //    {
            //       //ControllerName = "Employee",
            //       //ActionName =  "Create",
            //       ControllerName = this.RouteData.Values["controller"].ToString(),
            //       ActionName= this.RouteData.Values["action"].ToString(),
            //       ErrorMessage= ex.Message
            //    });
            //}
        }

        public IActionResult Edit(int id)
        { 
            var record = empDa.GetEmployee(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee rec) 
        {
            if (rec.Salary == 0)
                throw new Exception("USeless Employee");
            var record = empDa.UpdateEmployee(id, rec);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var record = empDa.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }

}
