using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Code_First.Models
{
    public class NewBajajDbContext : DbContext
    {
        public NewBajajDbContext()
        {
        }
        /// <summary>
        /// DbSet aka MApping of Entity Classes with Db-Tables
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NewBajajDb;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Hay Category you have Mutiple Products and each product has one Category
            // and it is Referred using CategoryKeyId 

            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Products) // One-to-Many RelationShip
                        .WithOne(p => p.Category) // One-to-One Ralationship
                        .HasForeignKey(f => f.CategoryKeyId); // Foreign Key

                
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
