using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de3
{
    internal class SaleRecord
    {
        public string MaHD { get; set; }
        public DateTime NgayBan { get; set; }
        public Item ItemBan { get; set; } // Đối tượng hàng hóa (tham chiếu)
        public int SoLuong { get; set; }

        // Constructor
        public SaleRecord(string maHD, DateTime ngayBan, Item itemBan, int soLuong)
        {
            MaHD = maHD;
            NgayBan = ngayBan;
            ItemBan = itemBan;
            SoLuong = soLuong;
        }

        public double CalculateSubTotal()
        {
            // Tổng tiền = Giá bán * Số lượng
            return ItemBan.GiaBan * SoLuong;
        }
    }
}

