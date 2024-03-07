using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt1
{
    class Program
    {
        static void Main(string[] args)
        {
            nhanvien[] nhanvienz = new nhanvien[10];
            khachhang[] khachhang = new khachhang[1];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"____Nhap thong tin cho nhan vien thu {i + 1}____");
                nhanvienz[i] = new nhanvien();
                nhanvienz[i].thongtin();
                nhanvienz[i].xuat();

            }
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"____Nhap thong tin cho khach hang thu {i + 1}___");
                khachhang[i] = new khachhang();
                khachhang[i].thongtin();
                khachhang[i].xuat();

            }
            Array.Sort(nhanvienz);
            Console.WriteLine("____Danh sach nhan vien_____");
            Console.WriteLine("Danh sach nhan vien");
            foreach (var nhanVien in nhanvienz)
            {
                nhanVien.xuat();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public class nguoi
        {
            public String Ten { get; set; }
            public String Diachi { get; set; }
            public String Email { get; set; }
            public String SDT { get; set; }

            public void nhap()
            {
                Console.WriteLine("nhap ho va ten");
                Ten = Console.ReadLine();
                Console.WriteLine("nhap dia chi");
                Diachi = Console.ReadLine();
                Console.WriteLine("nhap email");
                Email = Console.ReadLine();
                Console.WriteLine("nhap so dien thoai");
                SDT = Console.ReadLine();
            }
            public void xuat(){
                Console.WriteLine($"Ho va ten: {Ten} , Diachi: {Diachi},Email:{Email},So dien thoai:{SDT} ");
              } 
             }
        public class nhanvien:nguoi,IComparable<nhanvien>
        {
            public String bangcap { get; set; }
            public int CompareTo(nhanvien other)
            {
                // So sánh theo tên
                return String.Compare(this.Ten, other.Ten, StringComparison.OrdinalIgnoreCase);
            }
            public new void thongtin()
            {
                Console.WriteLine("nhap bang cap");
                bangcap = Console.ReadLine();
                base.nhap();
               
            }
            public new void xuat()
            {
                Console.WriteLine($"Bang Cap:{ bangcap}");
                base.xuat();
            }

        }
        public class khachhang:nguoi
        {
            public String loaikh { get; set; }
            public new void thongtin()
            {
                Console.WriteLine("nhap loai khach hang");
                loaikh = Console.ReadLine();
                base.nhap();
               
            }
            public new void xuat()
            {
                Console.WriteLine($"Loai khach hang:{ loaikh}");
                base.xuat();
            }
        }
                
        }
    }

