using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using MVC_CoreApp.CustomValidators;

namespace MVC_CoreApp.Models
{
    public partial class Employee
    {
        public int EmpUniqueId { get; set; }
        [Required(ErrorMessage="EmpNo is Must")]
        public string EmpNo { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public string Designation { get; set; } = null!;
        [NumericNonNegative(ErrorMessage ="Salary Cannot be -ve")]
        public int Salary { get; set; }
        public int? DeptUniqueId { get; set; }

        public virtual Department? DeptUnique { get; set; }
    }
}
