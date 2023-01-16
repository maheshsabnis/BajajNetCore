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
