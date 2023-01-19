using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CoreApp.Models;

namespace MVC_CoreApp.Controllers
{
    /// <summary>
    /// Controller that will be used to Create Roles and Assign Role to USer
    /// </summary>
    public class RoleController : Controller
    {
        // Use this class to assign Role to User
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// Inject THe RoleManager , and UserManager
        /// </summary>
        public RoleController(RoleManager<IdentityRole> role,UserManager<IdentityUser> user)
        {
            roleManager= role;
            userManager= user;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public IActionResult Create(IdentityRole role)
        { 
            // Role Will be Added Asynchrnously
           var result =  roleManager.CreateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = $"Some Error Occured While Cresting Role {result.Succeeded}";
                return View(role);
            }
        }

        public IActionResult AssignRoleToUser()
        {
            // 1. Read All Roles
            List<SelectListItem> roleList = new List<SelectListItem>();
            foreach (var role in roleManager.Roles)
            {
                roleList.Add(new SelectListItem(role.Name, role.Name));
            }
            // 2. Get All USers
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var usr in userManager.Users)
            {
                userList.Add(new SelectListItem(usr.UserName, usr.UserName));
            }
            ViewBag.RoleList = roleList;
            ViewBag.UserList = userList;

            return View(new UserRole());
        }
        [HttpPost]
        public IActionResult AssignRoleToUser(UserRole userRole)
        {

            // 1. Read All Roles
            List<SelectListItem> roleList = new List<SelectListItem>();
            foreach (var role in roleManager.Roles)
            {
                roleList.Add(new SelectListItem(role.Name, role.Name));
            }
            // 2. Get All USers
            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var usr in userManager.Users)
            {
                userList.Add(new SelectListItem(usr.UserName, usr.UserName));
            }
            ViewBag.RoleList = roleList;
            ViewBag.UserList = userList;

            // 1. Get User oBject aka IdentityUser based on Email
            // 
            IdentityUser user = userManager.FindByNameAsync(userRole.UserName).Result;
            if (user != null)
            {
                // Then Assign Role to user
                var result = userManager.AddToRoleAsync(user, userRole.RoleName).Result;
                if (result.Succeeded)
                {
                    ViewBag.Message = $"{userRole.RoleName} is assigned to {user.UserName}";
                 
                    return RedirectToAction("Index");
                }
            }

            return View(new UserRole());
        }
    }
}
