using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thc4
{
    internal class Sach
    {
        private string mss;
        private string ts;
        private long gia;
        public Sach(string mss, string ts, long gia)
        {
            this.mss = mss;
            this.ts = ts;
            this.gia = gia;
        }
        public long Gia
        {
            get { return gia; }
            set
            {
                if (ts=="")
                {
                    Console.WriteLine("ten ko rong");
                }
                else if (value > 0)
                {
                    gia = value;
                }
                else
                {
                    Console.WriteLine("gia phải > 0");
                }
            }
        }
        public override string ToString()
        {
            return $"mss: {mss}, ts: {ts}, gia: {gia}";
        }
    }
}




