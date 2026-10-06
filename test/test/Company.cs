using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Company
    {
        List<Employee> Employees = new List<Employee>();
        public void AddEmployee(Employee emp)
        {
            foreach (Employee e in Employees)
            {
                if (e.EmployeeId == emp.EmployeeId)
                    return;
                Employees.Add(e);
            }
        }
        public bool RemoveEmployee(string id)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].EmployeeId == id) 
                {
                    Employees.RemoveAt(i);
                    return true;
                } 
            }
            return false;
        }
        public Employee FindEmployeeById(string id)
        {
            foreach (var e in Employees)
                if (e.EmployeeId == id)
                    return e;
            return null;
        }
        public double CalculateTotalPayroll()
        {
            double total = 0;
            foreach (var e in Employees)
                total += e.CalculateSalary();
            return total;
        }
        public List<Employee> GetEmployeesByDepartment(string dept)
        {
            var kq = new List<Employee>();
            foreach (var e in Employees)
                if(e.Department.ToUpper() == dept.ToUpper())
                    kq.Add(e);
            return kq;
        }
        public void SortEmployeesBySalaryDescending()
        {
            Employee tmp;
            for (int i = 0; i < Employees.Count-1; i++)
                for(int j=1;i<Employees.Count;j++)
                    if (Employees[j].CalculateSalary()>Employees[i].CalculateSalary())
                    {
                        tmp = Employees[j];
                        Employees[j] = Employees[i];
                        Employees[i]= tmp;
                    }
        }
        public Dictionary<string, int> CountEmployeesByType()
        {
            var count = new Dictionary<string, int>();
            foreach (var e in Employees)
            {
                string type = e.GetType().Name;
                if(count.ContainsKey(type)) 
                    count[type]++;
                else count[type] = 1;
            }
            return count;
        }
        public List<Employee> GetTopHighestPaid(int topCount)
        {
                if (topCount <= 0 || Employees == null)
                {
                    return new List<Employee>();
                }

                // 1. Tạo một bản sao để sắp xếp
                List<Employee> tempEmployees = new List<Employee>(Employees);
                int n = tempEmployees.Count;

                // 2. Chỉ cần sắp xếp topCount phần tử đầu tiên
                for (int i = 0; i < topCount && i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        // So sánh lương: Nếu Employee j có lương cao hơn Employee i
                        if (tempEmployees[j].CalculateSalary() > tempEmployees[i].CalculateSalary())
                        {
                            // Hoán đổi vị trí
                            Employee temp = tempEmployees[i];
                            tempEmployees[i] = tempEmployees[j];
                            tempEmployees[j] = temp;
                        }
                    }
                }

                // 3. Lấy topCount nhân viên đã sắp xếp
                List<Employee> topEmployees = new List<Employee>();
                for (int i = 0; i < topCount && i < n; i++)
                {
                    topEmployees.Add(tempEmployees[i]);
                }

                return topEmployees;
            }
        public void DisplayAll()
        {
            foreach (var emp in Employees)
            {
                Console.WriteLine(emp.GetInfo());
            }
        }
    }
    }

