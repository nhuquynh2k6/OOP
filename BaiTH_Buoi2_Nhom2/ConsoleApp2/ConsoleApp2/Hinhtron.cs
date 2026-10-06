using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Hinhtron : Hinh2D
    {
        double r;

        public double R { get => r; set => r = value; }

        public override void Nhap()
        {
            Console.Write("Nhap vao ban kinh: ");
            R = double.Parse(Console.ReadLine());
        }
        public override void Hienthi()
        {
            Console.WriteLine($"Hinh tron ban kinh R = {R} co dien tich = {TinhDT()}");
        }
        public override double TinhDT()
        {
            return R * R * Math.PI;
        }
    }
}
