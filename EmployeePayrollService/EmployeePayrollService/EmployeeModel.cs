using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public int BasicPay { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Deduction { get; set; }
        public string TaxablePay { get; set; }
        public string IncomeTax { get; set; }
        public string NetPay { get; set; }
        public string Department { get; set; }

        public EmployeeModel(int empId, string empName, string gender, int basicPay, string phoneNumber, string address, string deduction, string taxablePay, string incomeTax, string netPay, string department)
        {
            EmpId = empId;
            EmpName = empName;
            Gender = gender;
            BasicPay = basicPay;
            PhoneNumber = phoneNumber;
            Address = address;
            Deduction = deduction;
            TaxablePay = taxablePay;
            IncomeTax = incomeTax;
            NetPay = netPay;
            Department = department;
        }
    }
}

