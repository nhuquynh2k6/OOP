using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_THB1
{
    internal class RutGon
    {
        public static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
        public static int RutGonPhanSo(ref int tuSo, ref int mauSo)
        {
            if (mauSo == 0)
            {
                throw new ArgumentException("Mẫu số không thể là 0");
            }

            int ucln = UCLN(tuSo, mauSo);

            int tuSoMoi = tuSo / ucln;
            int mauSoMoi = mauSo / ucln;

            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
            return ucln;
        }
    }
}
