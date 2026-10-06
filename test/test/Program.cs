using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();

            company.AddEmployee(new FullTimeEmployee("F001", "An Nguyen", new DateTime(2020, 1, 1), "Sale", 50000, 0.3));   
            company.AddEmployee(new FullTimeEmployee("F002", "Bao Tran",  new DateTime(2021, 5, 15), "Marketing", 45000, 0.15));
            company.AddEmployee(new FullTimeEmployee("F003", "Chau Le",  new DateTime(2022, 8, 20), "Sales", 40000, 0.05));    
            company.AddEmployee(new FullTimeEmployee("F004", "Dung Vo",  new DateTime(2023, 3, 10), "IT", 60000, 0.0));       
            company.AddEmployee(new PartTimeEmployee("P001", "Em Pham",  new DateTime(2024, 1, 1), "IT", 200, 160));        
            company.AddEmployee(new PartTimeEmployee("P002", "Giang Huynh",  new DateTime(2024, 4, 1), "HR", 180, 120));     
            company.AddEmployee(new PartTimeEmployee("P003", "Hung Luu",  new DateTime(2024, 6, 1), "Marketing", 250, 80));      

            company.AddEmployee(new Manager("M001", "Khoi Do", new DateTime(2018, 11, 1), "IT", 90000, 0.3, 15000));     
            company.AddEmployee(new Manager("M002", "Lam Phan",  new DateTime(2019, 3, 1), "Sales", 70000, 0.3, 10000));     
            company.AddEmployee(new Manager("M003", "Minh Ngo",  new DateTime(2020, 7, 1), "HR", 55000, 0.2, 5000));
            Console.WriteLine("Da them 10 nhan vien");

            company.DisplayAll();

            company.CalculateTotalPayroll();

            company.CountEmployeesByType();

            company.GetEmployeesByDepartment("IT");

            company.GetTopHighestPaid(5);

            company.SortEmployeesBySalaryDescending();
            Console.ReadKey();
        }
    }
}
