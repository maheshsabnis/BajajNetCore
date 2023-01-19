using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_CoreApp.Data
{
    /// <summary>
    /// IdentityDbContext: This is the base class to REad and Write 
    /// USers, ROles, etc. information from the Security Database
    /// Mentioned in appsettings.json in DefaultConnectionString
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}