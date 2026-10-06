using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Đảm bảo Console hỗ trợ tiếng Việt
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            QuanLyCongTy congTy = new QuanLyCongTy();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine("   HE THONG QUAN LY LUONG (DEMO)");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Them Nhan Vien Moi");
                Console.WriteLine("2. Hien Thi Bang Luong Toan Cong Ty");
                Console.WriteLine("3. Tinh Tong Quy Luong");
                Console.WriteLine("4. Tim Nhan Vien Luong Cao Nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Moi ban chon chuc nang: ");

                string luaChon = Console.ReadLine();
                Console.Clear(); // Xóa màn hình cho gọn

                switch (luaChon)
                {
                    case "1":
                        congTy.ThemNhanVien();
                        break;
                    case "2":
                        congTy.HienThiBangLuong();
                        break;
                    case "3":
                        congTy.TinhTongQuyLuong();
                        break;
                    case "4":
                        congTy.TimNhanVienLuongCaoNhat();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Da thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Chuc nang khong hop le. Vui long chon lai.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
