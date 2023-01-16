using System;
using System.Collections.Generic;

namespace CS_EFCore.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptUniqueId { get; set; }
        public string DeptNo { get; set; } = null!;
        public string DeptName { get; set; } = null!;
        public int Capacity { get; set; }
        public string Location { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
