using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_THB1
{
    internal class PhanSo
    {
        private int TuSo;
        private int MauSo;
        public PhanSo() 
        {
            TuSo = 0;
            MauSo = 1;
        }
        public PhanSo(int TuSo) : this()
        {
            this.TuSo = TuSo;
            this.MauSo = 1;
        }
        public PhanSo(int TuSo, int MauSo) : this()
        {
            this.TuSo = TuSo;
            this.MauSo = MauSo;
        }
        public void Print()
        {
            Console.WriteLine($"Phan so la: {TuSo}/{MauSo}");
        }
    }
}
