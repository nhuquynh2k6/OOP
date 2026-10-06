using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_THB1
{
    internal class Circle
    {
        int r = 1;
        public double TinhDT()
        {
            return Math.PI * r * r;
        }
        public double TinhCV()
        {
            return 2 * Math.PI * r;
        }
    }
}
