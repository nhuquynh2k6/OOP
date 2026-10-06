using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTHBuoi4
{
    internal class PhanSo
    {
        public PhanSo() : this(0, 1)
        {
        }

        public PhanSo(int ts, int ms)
        {
            MS = ms;
            TS = ts;
            RutGon();
        }

        public void RutGon()
        {
            int ucln = GCD(Math.Abs(TS), Math.Abs(MS));
            MS = MS / ucln;
            TS = TS / ucln;
        }

        private int tS, mS;
        public int TS { get => tS; set => tS = value; }

        public int MS
        {
            get => mS; set
            {
                if (value == 0) return;
                mS = value;
            }
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(a, b);
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.TS + b.TS, a.MS + b.MS);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.TS - b.TS, a.MS - b.MS);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.TS * b.TS, a.MS * b.MS);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            return a * new PhanSo(b.MS, b.TS);
        }

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            return (a.TS == b.TS) && (a.MS == b.MS);
        }

        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.TS * b.MS > b.TS * a.MS;
        }

        public static bool operator <(PhanSo a, PhanSo b)
        {
            return !(a == b || a > b);
        }

        public static bool operator >=(PhanSo a, PhanSo b)
        {
            return !(a < b);
        }

        public static bool operator <=(PhanSo a, PhanSo b)
        {
            return !(a > b);
        }

        public static explicit operator double(PhanSo b)
        {
            return (double)b.TS / b.MS;
        }
    }
}