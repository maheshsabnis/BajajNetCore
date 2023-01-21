using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CORE_API.CustomValidators;
namespace CORE_API.MOdels
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptUniqueId { get; set; }
        [Required(ErrorMessage = "DeptNo is required")]
        public string DeptNo { get; set; } = null!;
        [Required(ErrorMessage = "DeptName is required")]
        public string DeptName { get; set; } = null!;
        [Required(ErrorMessage = "Capacity is required")]
        [NumericNonNegative]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
