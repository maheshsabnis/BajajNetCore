using CORE_API.AUthServiceInfra;
using CORE_API.CustomMiddlewares;
using CORE_API.MOdels;
using CORE_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// REgisterig the SecurityDbNewCOntext in DI

builder.Services.AddDbContext<SecurityDbNewContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecureConnection"));
});


// Add services to the container.
// For API Controllers
builder.Services.AddDbContext<BajajCompanyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"));
});


// Register IDentity for USerManager<IdentityUser> and SIgnInManager<IdentityUser>
// THe USer Details are stored in SQL Server Database
// THis is Accessed using the SecurityDbNewContext
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<SecurityDbNewContext>();


// Register the Services based on interface impletemented by them

builder.Services.AddScoped<IDataService<Department,int>, DepartmentDataService>();
builder.Services.AddScoped<IDataService<Employee,int>,EmployeeDataService>();
builder.Services.AddScoped<AUthService>();
builder.Services.AddScoped<INewDataService<Department, int>, DepartmentDataNewService>();

// COnfigure the CORS Service
// FOr all Headers, Origins, and Methods
builder.Services.AddCors(options => 
{
    options.AddPolicy("CORS", policy => 
    {
       policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

// REgister the Authentication Service for Token Validation


// Inform to the Host that the Current API is using Token BAsed AUthorication 

// Logic for Token Verification
byte[] secretKey = Convert.FromBase64String(builder.Configuration["JWTSettings:SecretKey"]);
builder.Services.AddAuthentication(x =>
{
    // set the Scheme for HEader Value Verification
    // HTTP Request Header MUST use the Authorzation:'Bearer <TOKEN-VALUE>'
    // in Request
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // The Request is verified for Checking if it is for Log-In
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Validate the Token
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true; // THis will make sure that the tokne is saved in teh Server's Process so that it can be validated against the received token from the request
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Signeture Verification
        IssuerSigningKey = new SymmetricSecurityKey(secretKey), // Decrypt the Infrmatio from token to validate it
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



// COde Ensd Here

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"), // https://localhost:5532/api/Employee?api-version=1.0
        new HeaderApiVersionReader("X-Version"), // X-Version:1.0
        new MediaTypeApiVersionReader("ver")); // Content-Type:ver=1.0
});


// Lets modify the response type as JSON
// Disabing the Camel Casing JSON Serializatin for the
// Response
builder.Services.AddControllers()
    .AddJsonOptions(options => 
                options.JsonSerializerOptions.PropertyNamingPolicy = null
    ); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// The Swagger DOcumetations for Testing APIs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


 

// WebApplicationBuilder class, implements the 'IApplicationBuilder' Interface

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // MIddlewares for Swagger UI
    // to Generate HTML Page and JSON Documentation 
    // THat describes the REST API
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


// COfigure the CORS Middleware so that HTTP Pipeline will vaidate 
// theincomming request beased on poliy settings for Headers,methods,and Origins

app.UseCors("CORS");

app.UseAuthentication();
app.UseAuthorization();
// Register the Custom Exception Middleware
app.UseException();


// Link the Request to ApiControllers
app.MapControllers();

app.Run();
