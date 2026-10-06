using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    abstract class Employee
    {
        string employeeId, fullName, department;
        DateTime hireDate;
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public Employee(string id, string name, DateTime hireDate, string dept)
        {
            EmployeeId = id;
            FullName = name;
            HireDate = hireDate;
            Department = dept;
        }
        public abstract double CalculateSalary();
        public virtual string GetInfo()
        {
            return $"Ma nhan vien: {EmployeeId} \n Ho ten: {FullName} \n Ngay vao lam: {HireDate} \n Phong: {Department}";
        }
    }
}
