using Core_MinimalAPIs.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BajajCompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnStr"));

});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Urls.Add("http://localhost:4000");
app.Urls.Add("http://localhost:5000");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapGet("/departments", async(BajajCompanyContext context) =>{
    var result = await context.Departments.ToListAsync();
    return Results.Ok(result);
});

app.MapGet("/departments/{id}", async (int id, BajajCompanyContext context) => {
    var result = await context.Departments.FindAsync(id);
    return Results.Ok(result);
});

app.MapPost("/departments", async(Department dept, BajajCompanyContext ctx) => {
  var result = await ctx.Departments.AddAsync(dept);
    await ctx.SaveChangesAsync();
    return Results.Ok(result.Entity);
});

app.MapPut("/departments/{id}", async(int id, Department dept, BajajCompanyContext ctx) => {
        var deptToUpdate = await ctx.Departments.FindAsync(id);
    if (deptToUpdate != null)
    {
        deptToUpdate.DeptNo = dept.DeptNo;  
        deptToUpdate.DeptName   = dept.DeptName;
        deptToUpdate.Capacity = dept.Capacity;
        deptToUpdate.Location= dept.Location;   
        await ctx.SaveChangesAsync();
    }
    return Results.Ok(deptToUpdate);
});

app.MapDelete("/departments/{id}", async(int id, BajajCompanyContext ctx) => {
    var deptToDelete = await ctx.Departments.FindAsync(id);
    if (deptToDelete != null)
    {
        ctx.Departments.Remove(deptToDelete); 
        await ctx.SaveChangesAsync();
    }
    return Results.Ok("Record Deleted");
});


app.Run();

 