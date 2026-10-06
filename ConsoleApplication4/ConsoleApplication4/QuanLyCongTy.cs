using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class QuanLyCongTy
    {
        // Danh sách này có thể chứa cả NhanVienBienChe và NhanVienHopDong
        // vì cả hai đều "là một" NhanVien (tính Kế thừa)
        private List<NhanVien> dsNhanVien = new List<NhanVien>();

        public void ThemNhanVien()
        {
            Console.WriteLine("\n--- THEM NHAN VIEN ---");
            Console.WriteLine("Chon loai nhan vien: 1. Bien Che, 2. Hop Dong");
            Console.Write("Lua chon cua ban: ");
            string luaChon = Console.ReadLine();

            // Khai báo biến nv bằng kiểu LỚP CƠ SỞ (NhanVien)
            NhanVien nvMoi;

            if (luaChon == "1")
            {
                // Khởi tạo đối tượng là LỚP DẪN XUẤT (NhanVienBienChe)
                nvMoi = new NhanVienBienChe();
            }
            else if (luaChon == "2")
            {
                // Khởi tạo đối tượng là LỚP DẪN XUẤT (NhanVienHopDong)
                nvMoi = new NhanVienHopDong();
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le.");
                return;
            }

            // Gọi phương thức NhapThongTin()
            // Đây là tính ĐA HÌNH:
            // C# sẽ tự động gọi phương thức `NhapThongTin()`
            // của `NhanVienBienChe` hoặc `NhanVienHopDong`
            // tùy thuộc vào đối tượng thực tế được tạo (new)
            nvMoi.NhapThongTin();

            dsNhanVien.Add(nvMoi);
            Console.WriteLine("=> Da them nhan vien thanh cong!");
        }

        public void HienThiBangLuong()
        {
            Console.WriteLine("\n--- BANG LUONG TOAN CONG TY ---");
            if (dsNhanVien.Count == 0)
            {
                Console.WriteLine("Chua co nhan vien nao trong danh sach.");
                return;
            }

            foreach (NhanVien nv in dsNhanVien)
            {
                // ĐA HÌNH khi gọi HienThiThongTin()
                nv.HienThiThongTin();

                // ĐA HÌNH khi gọi TinhLuong()
                double luong = nv.TinhLuong();

                Console.WriteLine($"==> Luong Thuc Linh: {luong:N0} VND"); // Format cho đẹp
                Console.WriteLine("---------------------------------");
            }
        }

        public void TinhTongQuyLuong()
        {
            double tongLuong = 0;
            foreach (NhanVien nv in dsNhanVien)
            {
                // ĐA HÌNH: C# tự động gọi TinhLuong() đúng của từng loại
                tongLuong += nv.TinhLuong();
            }

            Console.WriteLine($"\n*** TONG QUY LUONG CONG TY PHAI TRA: {tongLuong:N0} VND ***");
        }

        public void TimNhanVienLuongCaoNhat()
        {
            if (dsNhanVien.Count == 0)
            {
                Console.WriteLine("Chua co nhan vien nao trong danh sach.");
                return;
            }

            // Giả sử NV đầu tiên có lương cao nhất
            NhanVien nvCaoNhat = dsNhanVien[0];
            double luongCaoNhat = nvCaoNhat.TinhLuong(); // Đa hình

            // Duyệt phần còn lại của danh sách
            foreach (NhanVien nv in dsNhanVien.Skip(1))

            {
                double luongHienTai = nv.TinhLuong(); // Đa hình
                if (luongHienTai > luongCaoNhat)
                {
                    luongCaoNhat = luongHienTai;
                    nvCaoNhat = nv;
                }
            }

            Console.WriteLine("\n--- NHAN VIEN CO LUONG CAO NHAT ---");
            nvCaoNhat.HienThiThongTin(); // Đa hình
            Console.WriteLine($"==> Voi muc luong: {luongCaoNhat:N0} VND");
        }
    }
}
