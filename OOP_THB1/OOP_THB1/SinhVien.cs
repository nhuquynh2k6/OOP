using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_THB1
{
    internal class SinhVien
    {
        string MaSV = "TH161234";
        string TenSV = "Nguyen Van Tu";
        int NamSinh = 1998;
        string DiaChi = "155 Su Van Hanh, F13, Q10";
        public void Print()
        {
            Console.WriteLine($"Ma sinh vien: {MaSV}");
            Console.WriteLine($"Ten sinh vien: {TenSV}");
            Console.WriteLine($"Nam sinh: {NamSinh}");
            Console.WriteLine($"Dia chi: {DiaChi}");
        }
    }
}
