using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CORE_API.MOdels
{
    /// <summary>
    /// THis class will be used to generate the 
    /// ASP.NET Core Security Database with Security Tables in it 
    /// </summary>
    public class SecurityDbNewContext : IdentityDbContext<IdentityUser>
    {
        public SecurityDbNewContext(DbContextOptions<SecurityDbNewContext> options):base(options)
        {

        }
    }
}
