# EF COre Code-First

1. Install EF Core Packages

	- dotnet add package Microsoft.EntityFrameworkCore -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.Tools -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.11
				- dotnet add package Microsoft.EntityFrameworkCore.Relational -v 6.0.11

2. Create Model CLasses and Establsih Relationships across them
	 Ref. Models/ModelsClasses.cs
```` csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CS_Code_First.Models
{
    public class Category
    {
        /// <summary>
        /// Primary Identity Key
        /// </summary>
        [Key]
        public int CategoryKeyId { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int BasePrice { get; set; }
        // One-to-Many Ralationships
        public ICollection<Product>? Products { get; set; }
    }

    public class Product
    {
        /// <summary>
        /// Primary Identity Key
        /// </summary>
        [Key]
        public int ProductKeyId { get; set; }
        public string? ProductId { get; set;}
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public int CategoryKeyId { get; set; } // Foreign Key
        public Category? Category { get; set; } // Reference for One-to-One Relatinship
    }
}

````

3. Add a class that is derived from 'DbContext' class
    - Define DbSet<EntityClasses> property
    - Override OnModelCOnfiguring() method with the Connection String
```` csharp
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
            base.OnModelCreating(modelBuilder);
        }
    }
}

````


4. Run the FOllowing Command to Generate 'Migrations'
    - This is class that contais C# code to Create Table
    - dotnet ef migrations add [MIGRATION-NAME] -c [NAMESPACE.DBCONTEXTCLASSNAME]
    - e.g.
        - dotnet ef migrations add firstMigration -c CS_Code_First.Models.NewBajajDbContext

    - This will generate a 'Migrations' folder in project with Migration class filw that will contains code for creating table using C#
    - Note: Review it carefully if it is logically incorrect against your requirements, then remove thsi incorrect migration
        - dotnet ef migrations remove
5. Now Carefully design ralationships un 'OnModelCreating()' mehod of DbContext

```` csharp
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

````

6. Now apply these migrations. using the Following command

    - dotnet ef database update -c [NAMESPACE.DBCONTEXTCLASSNAME]
    - e.g.
        - dotnet ef database update -c CS_Code_First.Models.NewBajajDbContext
    - This will Generate Database and Tables in it based on DbSet
7. For any updated in Model classes, Generate migrations and Update database
    - COmmands exp,ained in Step 4 and Step 6
8. Final Model classes

```` csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CS_Code_First.Models
{
    public class Category
    {
        /// <summary>
        /// Primary Identity Key
        /// </summary>
        [Key]
        public int CategoryKeyId { get; set; }
        /// <summary>
        /// Required Attribute for Mandatory value for Property
        /// </summary>
        [Required]
        /// The String Lenghth to set the MAx length for value in property
        /// THis is avaialable only for String
        [StringLength(20)]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(200)]
        public string? CategoryName { get; set; }
        [Required]
        public int BasePrice { get; set; }
        // One-to-Many Ralationships
        public ICollection<Product>? Products { get; set; }
    }

    public class Product
    {
        /// <summary>
        /// Primary Identity Key
        /// </summary>
        [Key]
        public int ProductKeyId { get; set; }
        [Required]
        [StringLength(20)]
        public string? ProductId { get; set;}
        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(200)]
        public string? Manufacturer { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryKeyId { get; set; } // Foreign Key
        public Category? Category { get; set; } // Reference for One-to-One Relatinship
    }
}


````