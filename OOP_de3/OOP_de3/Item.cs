using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de3
{
    internal class Item
    {
        public string MaHH { get; set; }
        public string TenHH { get; set; }
        public double GiaBan { get; set; }
        public int SoLuongTon { get; set; }

        // Constructor
        public Item(string maHH, string tenHH, double giaBan, int soLuongTon)
        {
            MaHH = maHH;
            TenHH = tenHH;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }

        public void ReduceStock(int qty)
        {
            if (SoLuongTon >= qty)
            {
                SoLuongTon -= qty;
            }
            else
            {
                // Tránh số âm nếu logic kiểm tra bị bỏ qua
                SoLuongTon = 0;
            }
        }

        public void IncreaseStock(int qty)
        {
            SoLuongTon += qty;
        }

        public string GetInfo()
        {
            return $"[HH] Mã: {MaHH} | Tên: {TenHH} | Giá: {GiaBan:N0} VND | Tồn: {SoLuongTon}";
        }
    }
}
