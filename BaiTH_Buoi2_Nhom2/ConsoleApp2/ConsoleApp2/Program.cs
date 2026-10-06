using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so luong hinh: ");
            int n = int.Parse(Console.ReadLine());

            Hinh2D[] dsHinh = new Hinh2D[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Ban tao hinh gi (Hinh tron: t): ");
                string c = Console.ReadLine().Substring(0, 1);

                if (c.ToUpper() == "T")
                {
                    Hinhtron a = new Hinhtron();
                    a.Nhap();
                    dsHinh[i] = a;
                }
                else
                {
                    HinhCN a = new HinhCN();
                    a.Nhap();
                    dsHinh[i] = a;
                }

            }

            int pos_maxDT = 0;
            for (int i = 0; i < dsHinh.Length; i++)
            {
                if (dsHinh[i].TinhDT() > dsHinh[pos_maxDT].TinhDT())
                {
                    pos_maxDT = i;
                }
            }

            dsHinh[pos_maxDT].Hienthi();

        }
    }
}
