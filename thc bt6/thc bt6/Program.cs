
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thc_bt6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap diem toan:");
            double diemToan = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhap diem Ly:");
            double diemLy = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhap diem Hoa:");
            double diemHoa = double.Parse(Console.ReadLine());

            if (diemToan >= 6.5 && diemLy >= 5.5 && diemHoa >= 5.0 && (diemToan + diemLy + diemHoa >= 18.0 || (diemToan + diemLy >= 14.0)))
            {
                Console.WriteLine("Chuc mung! Ban da trung tuyen.");
            }
            else
            {
                Console.WriteLine("Rat tiec, ban khong du dieu kien trung tuyen.");
            }
            Console.ReadKey();
        }
    }
}
