using Microsoft.AspNetCore.Mvc;
using MVC_CoreApp.Models;
using MVC_CoreApp.Services;

namespace MVC_CoreApp.Controllers
{
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
            var entity = deptDa.AddDepartment(rec);
            // Navigate to 'Index' action method so that
            // it will show the 'Index' view with
            // newly added record
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        { 
            var record = deptDa.GetDepartment(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(int id, Department rec) 
        {
            var record = deptDa.UpdateDepartment(id, rec);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var record = deptDa.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }

}
