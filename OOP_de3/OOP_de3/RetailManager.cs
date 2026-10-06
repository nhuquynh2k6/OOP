using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de3
{
    internal class RetailManager
    {
        List<Item> Items=new List<Item>();
        List<SaleRecord> Sales=new List<SaleRecord>();
        public void AddItem(Item i)
        {
            foreach (var item in Items)
                if (item.MaHH == i.MaHH)
                    return;
                    Items.Add(i);
        }
        public bool PlaceSale(SaleRecord s)
        {
                // BƯỚC 1: Tìm đúng đối tượng Item trong kho (dùng MaHH)
                Item itemInStock = null;

                foreach (var item in Items)
                {
                    // Điều kiện tìm kiếm phải là MaHH
                    if (item.MaHH.Equals(s.ItemBan.MaHH, StringComparison.OrdinalIgnoreCase))
                    {
                        itemInStock = item;
                        break; // Tìm thấy thì dừng vòng lặp
                    }
                }

                // 1. Kiểm tra vật phẩm có tồn tại trong danh sách quản lý không
                if (itemInStock == null)
                {
                    Console.WriteLine($" Bán hàng thất bại: Vật phẩm '{s.ItemBan.TenHH}' không tồn tại trong kho.");
                    return false;
                }

                // 2. Kiểm tra tồn kho
                if (itemInStock.SoLuongTon < s.SoLuong)
                {
                    Console.WriteLine($" Bán hàng thất bại: Vật phẩm '{itemInStock.TenHH}' chỉ còn {itemInStock.SoLuongTon}, không đủ {s.SoLuong} để bán.");
                    return false;
                }

                // 3. Thực hiện giao dịch (Chỉ khi 2 điều kiện trên thành công)

                // Giảm số lượng tồn kho của vật phẩm đã tìm thấy
                itemInStock.ReduceStock(s.SoLuong);

                // Thêm bản ghi bán hàng vào danh sách Sales
                Sales.Add(s);

                Console.WriteLine($" Bán hàng thành công: HD {s.MaHD} - {s.SoLuong} x {itemInStock.TenHH}. Tồn kho còn lại: {itemInStock.SoLuongTon}");
                return true;
            }
        public Item FindItemById(string id)
        {
            foreach(var item in Items)
                if(item.MaHH==id)
                    return item;
            return null;
        }
        public double CalculateTotalRevenue(DateTime from, DateTime to)
        {
            double total = 0;
            foreach (var sale in Sales)
                if (sale.NgayBan >= from && sale.NgayBan <= to)
                    total += sale.CalculateSubTotal();
            return total;
        }
        public Item FindBestSellingItem()
        {
            var totalSold = new Dictionary<string, int>();

            foreach (var sale in Sales)
            {
                string maHH = sale.ItemBan.MaHH;
                int qty = sale.SoLuong;

                // Nếu MaHH đã tồn tại trong Dictionary, cộng dồn số lượng
                if (totalSold.ContainsKey(maHH))
                {
                    totalSold[maHH] += qty;
                }
                else
                {
                    totalSold.Add(maHH, qty);
                }
            }

            if (totalSold.Count == 0)
            {
                return null;
            }

            // BƯỚC 2: Tìm MaHH có số lượng bán cao nhất (Best Seller)
            string bestSellingMaHH = "";
            int maxQty = -1; // Biến tạm lưu trữ số lượng bán tối đa

            // Duyệt qua Dictionary để tìm Key/Value lớn nhất
            foreach (var kvp in totalSold)
            {
                if (kvp.Value > maxQty)
                {
                    maxQty = kvp.Value;          // Cập nhật số lượng tối đa
                    bestSellingMaHH = kvp.Key;   // Cập nhật mã hàng hóa bán chạy nhất
                }
            }

            // BƯỚC 3: Trả về đối tượng Item tương ứng

            // Tìm đối tượng Item từ danh sách Items dựa trên MaHH đã tìm được
            Item bestSeller = null;
            foreach (var item in Items)
            {
                if (item.MaHH.Equals(bestSellingMaHH, StringComparison.OrdinalIgnoreCase))
                {
                    bestSeller = item;
                    break;
                }
            }

            return bestSeller;
        }
        public List<SaleRecord> GetSalesByDate(DateTime date)
        {
            List<SaleRecord> records = new List<SaleRecord>();
            foreach (var sale in Sales)
                if(sale.NgayBan==date)
                    records.Add(sale);
            return records;
        }
    }
}

