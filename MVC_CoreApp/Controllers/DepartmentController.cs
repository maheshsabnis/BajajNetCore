using Microsoft.AspNetCore.Mvc;
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
    public class DepartmentController : Controller
    {
        // Referece for DepartmentDataAccess

        DepartmentDataAccess deptDa;

        /// <summary>
        /// Injecting DepartmentDataAccess to the current class
        /// where as DepartmentDataAccess is registered in DI Container
        /// in Program.cs
        /// </summary>
        /// <param name="da"></param>
        public DepartmentController(DepartmentDataAccess da)
        {
            deptDa = da;  
        }

        /// <summary>
        /// Applying Action Filter on Action Method
        /// </summary>
        /// <returns></returns>
        //[LogFilter]
        public IActionResult Index()
        {
            var records = deptDa.GetDepartments();
            return View(records);
        }

        public IActionResult Create()
        {
            var entity = new Department();
            // PAss an EMptyDepartment Object to View
            return View(entity);
        }

        /// <summary>
        /// This will be executed when POST request is made from UI
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Department rec) 
        {
            //try
            //{
            // Check for the Validtity of the Model Class
            if (ModelState.IsValid)
            {
                // Before calling ass please check if the DeptNo is already present
                var dept = deptDa.GetDepartments().Where(d => d.DeptNo == rec.DeptNo).FirstOrDefault();
                if (dept != null)
                {
                    // define a ViewData to pass additional information to UI
                   // ViewData["Message"] = $"DeptNo {rec.DeptNo} is already exist";
                   //ViewBag.Message = $"DeptNo {rec.DeptNo} is already exist";
                    throw new Exception($"DeptNo {rec.DeptNo} is already exist");
                    //return View(dept);

                }
                else
                {
                    var entity = deptDa.AddDepartment(rec);
                    // Navigate to 'Index' action method so that
                    // it will show the 'Index' view with
                    // newly added record
                    return RedirectToAction("Index");
                }
            }
            else
            {
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
            //       //ControllerName = "Department",
            //       //ActionName =  "Create",
            //       ControllerName = this.RouteData.Values["controller"].ToString(),
            //       ActionName= this.RouteData.Values["action"].ToString(),
            //       ErrorMessage= ex.Message
            //    });
            //}
        }

        public IActionResult Edit(int id)
        { 
            var record = deptDa.GetDepartment(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(int id, Department rec) 
        {
            if (rec.Capacity == 0)
                throw new Exception("USeless Department");
            var record = deptDa.UpdateDepartment(id, rec);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var record = deptDa.DeleteDepartment(id);
            return RedirectToAction("Index");
        }


        public IActionResult ShowDetails(int id)
        {
            var deptUniqueId = id;
            // TempData["DeptUniqueId"] = id;
            // Saving Data in Session State
            HttpContext.Session.SetInt32("DeptUniqueId", id);

            // Get the Department Objet based on DeptUniqueId
            var dept = deptDa.GetDepartment(id);
            // HttpContext.Session.SetString("Dept", JsonSerializer.Serialize(dept));
            // The Custom Session Extension
            HttpContext.Session.SetObject<Department>("Dept", dept);

            // Respond the Index Action Method of EmployeeController
            return RedirectToAction("Index", "Employee");
        }
    }


}
