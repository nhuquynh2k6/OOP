using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class NhanVienHopDong:NhanVien
    {
        public int SoGioLamViec { get; set; }
        public double DonGiaGio { get; set; }

        // Ghi đè (override) phương thức NhapThongTin
        public override void NhapThongTin()
        {
            base.NhapThongTin(); // Gọi lớp Cha
            Console.Write("Nhap So Gio Lam Viec: ");
            SoGioLamViec = int.Parse(Console.ReadLine());
            Console.Write("Nhap Don Gia Gio: ");
            DonGiaGio = double.Parse(Console.ReadLine());
        }

        // Ghi đè (override) phương thức HienThiThongTin
        public new void HienThiThongTin()
        {
            base.HienThiThongTin(); // Gọi lớp Cha
            Console.WriteLine($"Loai: Hop Dong, So Gio: {SoGioLamViec}, Don Gia: {DonGiaGio}");
        }

        // Ghi đè (override) phương thức TinhLuong
        public override double TinhLuong()
        {
            return SoGioLamViec * DonGiaGio;
        }
    }
}
