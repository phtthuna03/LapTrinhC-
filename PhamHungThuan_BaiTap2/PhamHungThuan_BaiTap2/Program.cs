using System;
using System.Collections.Generic;
using System.Linq;

namespace PhamHungThuan_BaiTap2
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }
        public int DepartmentId { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách các department
            List<Department> departments = new List<Department>
        {
            new Department { ID = 1, Name = "IT" },
            new Department { ID = 2, Name = "HR" },
            new Department {ID = 3, Name = "Marketing"}
        };

            // Tạo danh sách các Employee
            List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 1, Name = "Pham Hung Thuan", Age = 30, Salary = 50000, Birthday = new DateTime(1990, 5, 15), DepartmentId = 1 },
            new Employee { ID = 2, Name = "Do Phu Huy", Age = 25, Salary = 60000, Birthday = new DateTime(1995, 8, 20), DepartmentId = 2 },
            new Employee { ID = 3, Name = "Nguyen Tan Tuan", Age = 35, Salary = 70000, Birthday = new DateTime(1989, 3, 10), DepartmentId = 3 },
            new Employee { ID = 4, Name = "Luu Bao Quoc", Age = 40, Salary = 80000, Birthday = new DateTime(1984, 12, 5), DepartmentId = 1 },
            new Employee { ID = 5, Name = "Mai Thanh Tung", Age = 33, Salary = 90000, Birthday = new DateTime(1987, 4, 17), DepartmentId = 2 }
        };

            // Max, min, average salary của Employee
            var maxSalary = employees.Max(e => e.Salary);
            var minSalary = employees.Min(e => e.Salary);
            var averageSalary = employees.Average(e => e.Salary);

            Console.WriteLine($"Max Salary: {maxSalary}");
            Console.WriteLine($"Min Salary: {minSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");

            // Join và Group
            var join = from emp in employees
                            join dept in departments on emp.DepartmentId equals dept.ID into empDept
                            select new
                            {
                                EmployeeName = emp.Name,
                                DepartmentName = empDept.FirstOrDefault()?.Name
                            };

            Console.WriteLine("\nJoin :");
            foreach (var item in join)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}, Department: {item.DepartmentName ?? "Unknown"}");
            }

            // Left Join
            var leftJoin = from dept in departments
                                join emp in employees on dept.ID equals emp.DepartmentId into empDept
                                from ed in empDept.DefaultIfEmpty()
                                select new
                                {
                                    DepartmentName = dept.Name,
                                    EmployeeName = ed != null ? ed.Name : "No employee"
                                };

            Console.WriteLine("\nLeft Join:");
            foreach (var item in leftJoin)
            {
                Console.WriteLine($"Department: {item.DepartmentName}, Employee: {item.EmployeeName}");
            }

            // Right Join
            var rightJoin = from emp in employees
                                 join dept in departments on emp.DepartmentId equals dept.ID into empDept
                                 from ed in empDept.DefaultIfEmpty()
                                 select new
                                 {
                                     EmployeeName = emp.Name,
                                     DepartmentName = ed != null ? ed.Name : "No department"
                                 };

            Console.WriteLine("\nRight Join:");
            foreach (var item in rightJoin)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}, Department: {item.DepartmentName}");
            }

            // Max, min tuổi của Employee
            var maxAge = employees.Max(e => e.Age);
            var minAge = employees.Min(e => e.Age);

            Console.WriteLine($"\nMax Age: {maxAge}");
            Console.WriteLine($"Min Age: {minAge}");

            Console.ReadKey();
        }
    }

}
