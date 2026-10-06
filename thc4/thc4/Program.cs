using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thc4
{
    internal class Program
    {
        static void Main()
        {
            //TaiKhoan tk = new TaiKhoan(123456, "Nguyen Van Tam", 10000000);
            //Console.WriteLine(tk);
            Sach sach = new Sach("B12345", "bt oop", 70000);
            Console.WriteLine(sach);
            Console.ReadKey();
        }
    }
}
