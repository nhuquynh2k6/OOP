using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    abstract class NhanVien
    {
        public string MaNV { get; set; } 
        public string HoTen { get; set; }
        public string Email { get; set; }

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap MaNV: ");
            MaNV = Console.ReadLine();
            Console.Write("Nhap Ho Ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap Email: ");
            Email = Console.ReadLine();
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"MaNV: {MaNV}, Ho Ten: {HoTen}, Email: {Email}");
        }

        // Phương thức virtual để tính lương
        // Lớp cơ sở có thể có một mức lương tối thiểu, hoặc 0
        public abstract double TinhLuong();
        
    }
}
