using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class NhanVienBienChe:NhanVien
    {
        public double LuongCoBan { get; set; }
        public double HeSoLuong { get; set; }
        public double Thuong { get; set; }

        // Ghi đè (override) phương thức NhapThongTin
        public override void NhapThongTin()
        {
            // Gọi phương thức của lớp Cha để nhập thông tin chung
            base.NhapThongTin();

            // Nhập thông tin riêng của lớp Con
            Console.Write("Nhap Luong Co Ban: ");
            LuongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Nhap He So Luong: ");
            HeSoLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap Thuong: ");
            Thuong = double.Parse(Console.ReadLine());
        }

        // Ghi đè (override) phương thức HienThiThongTin
        public override void HienThiThongTin()
        {
            // Gọi phương thức của lớp Cha để hiển thị thông tin chung
            base.HienThiThongTin();

            // Hiển thị thông tin riêng
            Console.WriteLine($"Loai: Bien Che, Luong Co Ban: {LuongCoBan}, He So: {HeSoLuong}, Thuong: {Thuong}");
        }

        // Ghi đè (override) phương thức TinhLuong
        public override double TinhLuong()
        {
            return LuongCoBan * HeSoLuong + Thuong;
        }
    }
}
