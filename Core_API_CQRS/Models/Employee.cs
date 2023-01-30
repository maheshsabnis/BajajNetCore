using System;
using System.Collections.Generic;

namespace Core_API_CQRS.Models
{
    public partial class Employee
    {
        public int EmpUniqueId { get; set; }
        public string EmpNo { get; set; } = null!;
        public string EmpName { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int Salary { get; set; }
        public int? DeptUniqueId { get; set; }

        public virtual Department? DeptUnique { get; set; }
    }
}
