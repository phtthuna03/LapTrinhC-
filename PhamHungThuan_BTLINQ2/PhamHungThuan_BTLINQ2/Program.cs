using System;
using System.Collections.Generic;
using System.Linq;

namespace PhamHungThuan_BTLINQ2
{
    class Department
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Department(string name)
        {
            Name = name;
        }
    }

    class Position
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Position(string name)
        {
            Name = name;
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }

        public Employee(string name, string description, int age, Department department, Position position)
        {
            Name = name;
            Description = description;
            Age = age;
            Department = department;
            Position = position;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Danh sách phòng ban
            List<Department> departments = new List<Department>
            {
                new Department ("Phong nhan su" ),
                new Department ("Phong tai chinh - ke toan" ),
                new Department ("Phong Marketing"),
                new Department ("Phong cong nghe thong tin")
            };

            //Danh sách vị trí công việc
            List<Position> positions = new List<Position>
            {
                new Position ("Chuyen vien tuyen dung"),
                new Position ("Chuyen vien ke toan"),
                new Position ("Chuyen vien CEO"),
                new Position ("Chuyen vien ho tro CNTT")
            };

            //Danh sách nhân viên và gán phòng ban, vị trí công việc cho từng nhân viên
            List<Employee> employees = new List<Employee>
            {
                new Employee ("Pham Hung Thuan", "HR Manager", 25, departments[0], positions[0]),
                new Employee ("Nguyen Tan Tuan", "Financial Analyst", 27, departments[1], positions[1]),
                new Employee ("Luu Bao Quoc", "SEO Executive", 22, departments[2], positions[2]),
                new Employee ("Pham Quy", "Senior Developer", 29, departments[3], positions[3])
            };

            Console.Write("Tu khoa tim kiem: ");
            string keyword = Console.ReadLine();
            Console.Write("Tuoi tu: ");
            int minAge = int.Parse(Console.ReadLine());
            Console.Write("Đen: ");
            int maxAge = int.Parse(Console.ReadLine());
            Console.Write("Vi tri: ");
            string positionKeyword = Console.ReadLine();
            Console.Write("Phong ban: ");
            string departmentKeyword = Console.ReadLine();


            var searchResult = employees.Where(emp =>
                (emp.Name.Contains(keyword) || emp.Description.Contains(keyword)) &&
                emp.Age >= minAge &&
                emp.Age <= maxAge &&
                (emp.Position.Name.Contains(positionKeyword) || emp.Position.Description.Contains(positionKeyword)) &&
                (emp.Department.Name.Contains(departmentKeyword) || emp.Department.Description.Contains(departmentKeyword)))
            .ToList();

            // In ra kết quả tìm kiếm
            Console.WriteLine("\nKet qua tim kiem:");
            foreach (var emp in searchResult)
            {
                Console.WriteLine($"Ten: {emp.Name}, Tuoi: {emp.Age}, Phong ban: {emp.Department.Name}, Vi tri: {emp.Position.Name}");
            }
            Console.ReadKey();
        }
    }
}