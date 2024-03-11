using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thc_bt5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap nam kiem tra:");
            int year = int.Parse(Console.ReadLine());

            if (IsLeapYear(year))
            {
                Console.WriteLine($"Nam {year} la nam nhuan.");
            }
            else
            {
                Console.WriteLine($"Nam {year} khong phai nam nhuan.");
            }
            Console.ReadKey();
        }

        static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
