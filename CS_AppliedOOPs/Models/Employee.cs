using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AppliedOOPs.Models
{
    internal class Employee
    {
        int _EmpNo;
        string _EmpName;
        decimal _Salary;

        // Lets define public properties to REad / Write
        // value for Privatte Data Members
        public int EmpNo
        {
            get { return _EmpNo; } // Read
            set 
            {
                /// Property with Self-Validating Logic
                /// This is now a Smart Property aka Intelligent Field
                if (value <= 0)
                {
                    _EmpNo = 0;
                }
                else
                {
                    _EmpNo = value;
                }
            } // Write
        }
         
        public string EmpName
        { 
            get { return _EmpName; }
            set { _EmpName = value; }
        }

        public decimal Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

    }
    /// <summary>
    /// Class wih Auto-Implemented properties 
    /// </summary>
    internal class EmployeeDTO
    {
        // The compiler will implicitly define private members
        // as Backing Filed e.g. k_EmpNo
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }

    }
}
