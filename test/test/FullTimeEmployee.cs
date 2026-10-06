using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class FullTimeEmployee:Employee
    {
        double baseSalary, bonusRate;
        public double BaseSalary { get => baseSalary; set => baseSalary = value; }
        public double BonusRate { get => bonusRate; set => bonusRate = value; }
        public FullTimeEmployee(string id, string name, DateTime hireDate, string dept, double baseSalary, double bonusRate) : base(id, name, hireDate, dept)
        {
            BaseSalary = baseSalary;
            BonusRate = Math.Max(0, Math.Min(0.3, bonusRate));
        }
        public override double CalculateSalary()
        {
            if (BonusRate > 0.3)
            {
                return BaseSalary * (1 + 0.3);
            }
            return BaseSalary * (1 + BonusRate);

        }
        public override string GetInfo()
        {
            return base.GetInfo() + $"Thuong chinh thuc: {BonusRate}";
        }
    }
}
