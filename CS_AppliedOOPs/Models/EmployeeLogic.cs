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

        /// <summary>
        /// MOdify the method for Not Accepting Employee With Same EmpNo
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(EmployeeDTO employee)
        { 

            employees.Add(employee);
        }


        /// <summary>
        /// Method to Update Exisiting Employee from ArrayLIst
        /// </summary>
        /// <returns></returns>

        /// Method to Delete an Existing Employe from Array List


        public ArrayList GetEmployees()
        {
            return employees;
        }
    }
}
