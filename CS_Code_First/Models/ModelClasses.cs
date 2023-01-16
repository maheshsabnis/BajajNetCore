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
