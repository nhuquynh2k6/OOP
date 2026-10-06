using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class HinhCN : Hinh2D
    {
        double chieungang, chieudung;

        public double Chieungang { get => chieungang; set => chieungang = value; }
        public double Chieudung { get => chieudung; set => chieudung = value; }

        public override void Nhap()
        {
            Console.Write("Nhap vao chieu dung: ");
            Chieudung = double.Parse(Console.ReadLine());
            Console.Write("Nhap vao chieu ngang: ");
            Chieungang = double.Parse(Console.ReadLine());

        }
        public override void Hienthi()
        {
            Console.WriteLine($"Hinh chu nhat co chieu ngang = {Chieungang}, chieu dung = {Chieudung} co dien tich = {TinhDT()}");
        }
        public override double TinhDT()
        {
            return Chieungang * Chieudung;
        }


    }
}
