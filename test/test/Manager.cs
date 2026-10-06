using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Manager:FullTimeEmployee
    {
        int numberOfSubordinates;

        public int NumberOfSubordinates { get => numberOfSubordinates; set => numberOfSubordinates = value; }
        public Manager(string id, string name, DateTime hireDate, string dept, double baseSalary, double bonusRate, int subordinates) : base(id, name, hireDate, dept, baseSalary, bonusRate)
        {
            NumberOfSubordinates = subordinates;
        }
        public override double CalculateSalary()
        {
            return BaseSalary + 500000 * (NumberOfSubordinates / 5);
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $"Quan li {NumberOfSubordinates} nguoi";
        }
    }
}
