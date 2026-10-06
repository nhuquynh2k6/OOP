using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_THB1
{
    internal class Sach
    {
        string MaSoSach = "B12345";
        string TenSach = "Bai tap OOP";
        int Gia = 70000;
        public double TinhGiaBan(double GiaGiam)
        {
            return Gia - GiaGiam;
        }
        public double GiaNQuyen(int SoLuong)
        {
            return Gia * SoLuong;
        }
        public double GiaNQuyenCoGiam(int SoLuong, double GiaGiam)
        {
            return (Gia - GiaGiam) * SoLuong;
        }
        public int TinhGiaBan(int GiaGiam, int n=1)
        {
            return (Gia - GiaGiam) * n;
        }
    }
}
