using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_CoreApp.CustomFilters;
using MVC_CoreApp.Data;
using MVC_CoreApp.Models;
using MVC_CoreApp.Services;
using System.Reflection;
// 1. Beginning of the ASP.NET Core Execution
// THis is used to build require Objects those are used during
// execution
// a. Dependency Container aka Service Container
// b. Middlewares aka HTTP Request Pipeline
// THis is 'WebApplicationBuilder' class. This is used to
// Assemble all necessary object for ASP.NET Core App
var builder = WebApplication.CreateBuilder(args);


// a. Add services to the container aka Dependency Container
// REading the ConnectionString from appsettings.json file using ConfigurationManager class
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// builder.Services offers 'Dependency Container' so that heavy-loaded objet are already registered
// in it



// 1.a.1: Register the ApplicationDbContext in DI COntainer
// so that its instance will be available for performing data operations
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register the BajabCompanyContext class in DI Container
builder.Services.AddDbContext<BajajCompanyContext>(options => 
{
    // Read the Connection String of name AppConection from appsettings.json
      options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
 });

// REgister the Additional Service classes

builder.Services.AddScoped<DepartmentDataAccess>();
builder.Services.AddScoped<EmployeeDataAccess>();


// Added in .NET 6 standard Error Page
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Later to Learn
// INternally, this registers following two classed in DI Container
// 1. UserManager<IdentityUser>, class used to create, read, update, and delete users
// 2. SignInManager<IdentityUser>, class used to Manage LogIn, and LogOff
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>(); // USers will be stored in SQL Server Database and will be read using ENtityFrameworkCore using ApplicationDbContext  


// Now Instead of using Just UserManager and SignInManager, also register and Resolve RoleManager

// The AddIdentity<IdentityUser, IdentityRole> will Register and Resolve the folowing
// UserManager<IdentityUser>
// SignInManager<IdentityUser>
// RoleManager<IdentityRole>
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();
// AddDefaultUI(): Will load Login PAge as well as Access Denined Page

// Add the AddRazorPages() service so that with USerManager, RoleManager, and SignManager the Register and Login Pages (RAzor Pages) will be executed

builder.Services.AddRazorPages();

// Defining the policies aka Group for Roles

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("ReadPolicy", policy => 
    {
        policy.RequireRole("Manager", "Clerk", "Operator");
    });

    options.AddPolicy("CreatePolicy", policy =>
    {
        policy.RequireRole("Manager", "Clerk");
    });
    options.AddPolicy("EditDeletePolicy", policy =>
    {
        policy.RequireRole("Manager");
    });
});



// COnfgure the Session Service
builder.Services.AddSession(options=> 
{
    // Session Time out will be 20 mins
   options.IdleTimeout = TimeSpan.FromMinutes(20);
});


// 1.a.4: A method tat is used to accept requesr for MVC Controllers
// and handle its execution to return Views

// Define Action FIlter in GLobal Level for MVC and API Cotrollers
builder.Services.AddControllersWithViews(options => 
{
    //options.Filters.Add(typeof(LogFilterAttribute));
    //// Register the Exception Filter
    //options.Filters.Add(typeof(AppExceptionFilterAttribute));
});


// Middlewares
var app = builder.Build();
// Helps to load necessary objects to Manage the HTTP Request Pipeline

//b. Configure the HTTP request pipeline aka Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // Error page for Production
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Map the Http Request with Https
app.UseHttpsRedirection();

// Configure the Session Middleware so that the
// HttpPipeline will know that the current request will be monitored usig the
// Session Objects i.e. HttpCOntext.Session

app.UseSession();

// Read wwwroot folder
app.UseStaticFiles();
// Read the Controller/Action from the Http Reqiest URL and
// accordingly Route to that controller an ask ASP.NET Core to Process the HTTP Request
app.UseRouting();

// Indentity (Later)
app.UseAuthentication();
app.UseAuthorization();

// MVC Route MApping
// Template Expressio as :{controller}/{action}/{id?}
// {controller}: Name of the Controller class (excluding 'Controller' word)
// {action}: The Nam eof the action methd of that controller whih will be executed
// {id?}: The optioal parameter to the action method
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// USed only in case of using Indeityt Views (Later)
app.MapRazorPages();
// RUn the Application
app.Run();
