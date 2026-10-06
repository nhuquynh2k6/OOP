using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP_de1.LibraryItem;

namespace OOP_de1
{
    internal class LibraryManager
    {
        List<LibraryItem> items=new List<LibraryItem>();
        List<Loan> Loans=new List<Loan>();
        public void AddItem(LibraryItem p)
        {
            foreach (var item in items)
                if (item.MaVT.Equals(p.MaVT, StringComparison.OrdinalIgnoreCase))
                    return;
            items.Add(p);
        }
        public bool RegisterLoan(Loan loan)
        {
                // Danh sách lưu trữ các thay đổi thành công để có thể hoàn tác
                List<LoanDetail> successfulUpdates = new List<LoanDetail>();

                foreach (var detail in loan.ChiTiet)
                {
                    // 1. Kiểm tra tồn kho
                    if (detail.VatPham.SoLuong < detail.SoLuong)
                    {
                        Console.WriteLine($"\n Lỗi: Vật phẩm '{detail.VatPham.Ten}' không đủ. Tiến hành hoàn tác...");

                        // THỰC HIỆN HOÀN TÁC:
                        // Tăng lại số lượng cho các vật phẩm đã giảm thành công trước đó
                        foreach (var updatedDetail in successfulUpdates)
                        {
                            updatedDetail.VatPham.TangSoLuong(updatedDetail.SoLuong);
                        }
                        return false; // Hủy toàn bộ giao dịch
                    }

                    // 2. Thực hiện Giảm Stock ngay lập tức
                    detail.VatPham.GiamSoLuong(detail.SoLuong);

                    // 3. Ghi nhận thay đổi thành công
                    successfulUpdates.Add(detail);
                }

                // Nếu vòng lặp hoàn thành mà không có lỗi, giao dịch thành công.
                Loans.Add(loan);
                Console.WriteLine($"\n Đăng kí phiếu mượn #{loan.MaPhieu} thành công (1 vòng lặp).");
                return true;
            }
        public Loan FindLoanById(string id)
        {
            foreach (var e in Loans)
                if (e.MaPhieu == id)
                    return e;
            return null;
        }
        public double CalculateTotalFines(DateTime fromDate, DateTime toDate, double finePerDay)
        {
            double total = 0;
            DateTime currentDate = DateTime.Now;
            foreach (var l in Loans)
                if (l.NgayMuon >= fromDate && l.NgayMuon <= toDate)
                    total += l.CalculateFine(currentDate, finePerDay);
            return total;
        }
        public List<LibraryItem> GetMostBorrowedItems(int topCount)
        {
            var borrowedCounts = new Dictionary<string, int>();

            // Vòng lặp 1: Tổng hợp số lượng mượn
            foreach (var loan in Loans)
            {
                foreach (var detail in loan.ChiTiet)
                {
                    string maVT = detail.VatPham.MaVT;
                    int sl = detail.SoLuong;

                    if (borrowedCounts.ContainsKey(maVT))
                    {
                        borrowedCounts[maVT] += sl;
                    }
                    else
                    {
                        borrowedCounts.Add(maVT, sl);
                    }
                }
            }

            // Chuyển Dictionary sang List<KeyValuePair> để sắp xếp
            var sortedList = borrowedCounts.ToList();

            // Sắp xếp thủ công (Bubble Sort) giảm dần theo Value (Số lượng mượn)
            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                for (int j = i + 1; j < sortedList.Count; j++)
                {
                    if (sortedList[i].Value < sortedList[j].Value)
                    {
                        var tmp = sortedList[i];
                        sortedList[i] = sortedList[j];
                        sortedList[j] = tmp;
                    }
                }
            }

            // Lấy topCount vật phẩm
            List<LibraryItem> mostBorrowedItems = new List<LibraryItem>();
            int numLoan = Math.Min(topCount, sortedList.Count);

            for (int i = 0; i < numLoan; i++)
            {
                string maVT = sortedList[i].Key;
                // Tìm LibraryItem từ mã VT (dùng FirstOrDefault để tìm kiếm)
                LibraryItem item = items.FirstOrDefault(p => p.MaVT == maVT);
                if (item != null)
                {
                    mostBorrowedItems.Add(item);
                }
            }

            return mostBorrowedItems;

        }
        public Dictionary<string, double> TotalFinesByItemType(DateTime currentDate, double finePerDay)
        {
            Dictionary<string, double> output = new Dictionary<string, double>()
            {
                { "Book", 0}, { "Magazine", 0}
            };
            foreach (var loan in Loans)
            {
                foreach (var detail in loan.ChiTiet)
                {
                    // Chỉ tính phạt nếu quá hạn
                    if (detail.IsOverdue(currentDate))
                    {
                        // Tính tiền phạt cho chi tiết mượn này
                        TimeSpan overdueDays = currentDate - detail.NgayHetHan;
                        int days = (int)Math.Ceiling(overdueDays.TotalDays);
                        double fine = days * detail.SoLuong * finePerDay;

                        // Kiểm tra loại vật phẩm
                        if (detail.VatPham is Book)
                            output["Book"] += fine;
                        else if (detail.VatPham is Magazine)
                            output["Magazine"] += fine;
                    }
                }
            }
            return output;
        }
        public List<Loan> GetLoansByPatronName(string name)
        {
            List<Loan> result = new List<Loan>();

            foreach (var loan in Loans)
            {
                // So sánh tên không phân biệt chữ hoa/thường
                if (loan.TenDocGia.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(loan);
                }
            }
            return result;
        }
    }
}
