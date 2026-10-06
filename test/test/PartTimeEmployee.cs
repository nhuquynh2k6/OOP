using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class PartTimeEmployee:Employee
    {
        int hourlyRate, hoursWorked;
        public int HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public PartTimeEmployee(string id, string name, DateTime hireDate, string dept, int hourlyRate, int hoursWorked) : base(id, name, hireDate, dept)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
        public override string GetInfo()
        {
            return base.GetInfo()+$"Thoi vu: {HoursWorked}";
        }
    }
}
