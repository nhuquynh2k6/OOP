using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_THB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SinhVien sinhVien = new SinhVien();
            //sinhVien.Print();

            //Circle circle = new Circle();
            //Console.WriteLine($"Dien tich: {circle.TinhDT()}");
            //Console.WriteLine($"Chu vi: {circle.TinhCV()}");

            //Sach sach = new Sach();
            //Console.WriteLine($"Gia ban sach: {sach.TinhGiaBan(10000)}");
            //Console.WriteLine($"Gia ban n quyen sach: {sach.GiaNQuyen(5)}");
            //Console.WriteLine($"Gia ban n quyen sach co giam gia: {sach.GiaNQuyenCoGiam(5,20000)}");
            //Console.WriteLine($"Gia ban sach: {sach.TinhGiaBan(10000,2)}");

            //PhanSo ps1 = new PhanSo();
            //ps1.Print();
            //PhanSo ps2 = new PhanSo(5);
            //ps2.Print();
            //PhanSo ps3 = new PhanSo(4, 7);
            //ps3.Print();

            int tu = 2;
            int mau = 8;
            int ucln=RutGon.RutGonPhanSo(ref tu, ref mau);
            Console.WriteLine($"Phan so da rut gon: {tu/ucln}/{mau/ucln}");
            Console.ReadKey();
        }
    }
}
