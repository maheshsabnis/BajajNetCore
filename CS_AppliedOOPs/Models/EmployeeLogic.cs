using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AppliedOOPs.Models
{
    internal class EmployeeLogic
    {
        // ArrayList EmployeeDTO
        ArrayList employees = new ArrayList();

        public void AddEmployee(EmployeeDTO employee)
        { 
            employees.Add(employee);
        }

        public ArrayList GetEmployees()
        {
            return employees;
        }
    }
}
