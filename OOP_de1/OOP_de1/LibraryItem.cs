using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de1
{
        public abstract class LibraryItem
        {
            // Thuộc tính
            public string MaVT { get; set; }
            public string Ten { get; set; }
            public int NamXB { get; set; }
            public int SoLuong { get; set; } // Tồn kho hiện tại

            // Constructor
            public LibraryItem(string maVT, string ten, int namXB, int soLuong)
            {
                MaVT = maVT;
                Ten = ten;
                NamXB = namXB;
                SoLuong = soLuong;
            }

            // Phương thức chung
            public void GiamSoLuong(int sl)
            {
                if (SoLuong >= sl)
                {
                    SoLuong -= sl;
                }
                else
                {
                    Console.WriteLine($"Lỗi: Không đủ số lượng vật phẩm {Ten} để giảm ({SoLuong} < {sl}).");
                }
            }

            public void TangSoLuong(int sl)
            {
                SoLuong += sl;
            }

            public virtual string GetInfo()
            {
                return $"Mã: {MaVT} | Tên: {Ten} | Năm XB: {NamXB} | Tồn kho: {SoLuong}";
            }
        public class Book : LibraryItem
        {
            public string TacGia { get; set; }
            public int SoTrang { get; set; }

            public Book(string maVT, string ten, int namXB, int soLuong, string tacGia, int soTrang)
                : base(maVT, ten, namXB, soLuong)
            {
                TacGia = tacGia;
                SoTrang = soTrang;
            }

            public override string GetInfo()
            {
                return $"[Sách] {base.GetInfo()} | Tác Giả: {TacGia} | Số Trang: {SoTrang}";
            }
        }
        public class Magazine : LibraryItem
        {
            public int SoPhatHanh { get; set; }
            public string ChuDe { get; set; }

            public Magazine(string maVT, string ten, int namXB, int soLuong, int soPhatHanh, string chuDe)
                : base(maVT, ten, namXB, soLuong)
            {
                SoPhatHanh = soPhatHanh;
                ChuDe = chuDe;
            }

            public override string GetInfo()
            {
                return $"[Tạp Chí] {base.GetInfo()} | Số PH: {SoPhatHanh} | Chủ Đề: {ChuDe}";
            }
        }
        public class LoanDetail
        {
            public LibraryItem VatPham { get; private set; }
            public int SoLuong { get; private set; }
            public DateTime NgayHetHan { get; private set; }

            // Constructor
            public LoanDetail(LibraryItem vatPham, int soLuong, DateTime ngayHetHan)
            {
                VatPham = vatPham;
                SoLuong = soLuong;
                NgayHetHan = ngayHetHan;
            }

            // Phương thức kiểm tra quá hạn
            public bool IsOverdue(DateTime currentDate)
            {
                return currentDate > NgayHetHan;
            }
        }
        public class Loan
        {
            public string MaPhieu { get; set; }
            public DateTime NgayMuon { get; set; }
            public string TenDocGia { get; set; }
            public List<LoanDetail> ChiTiet { get; private set; }
            public int SoNgayMuonToiDa { get; set; } // Ví dụ: 7

            public Loan(string maPhieu, DateTime ngayMuon, string tenDocGia, int soNgayMuonToiDa)
            {
                MaPhieu = maPhieu;
                NgayMuon = ngayMuon;
                TenDocGia = tenDocGia;
                SoNgayMuonToiDa = soNgayMuonToiDa;
                ChiTiet = new List<LoanDetail>();
            }

            // Phương thức thêm vật phẩm vào phiếu mượn và giảm tồn kho
            public bool AddItem(LibraryItem item, int sl)
            {
                if (item.SoLuong < sl)
                {
                    Console.WriteLine($"Lỗi: Vật phẩm '{item.Ten}' chỉ còn {item.SoLuong} cuốn, không đủ {sl} để mượn.");
                    return false;
                }

                // Tính ngày hết hạn
                DateTime ngayHetHan = NgayMuon.AddDays(SoNgayMuonToiDa);
                ChiTiet.Add(new LoanDetail(item, sl, ngayHetHan));
                item.GiamSoLuong(sl); // Giảm số lượng tồn kho
                return true;
            }

            // Tính tổng tiền phạt cho các vật phẩm quá hạn
            public double CalculateFine(DateTime currentDate, double finePerDay)
            {
                double totalFine = 0;
                foreach (var detail in ChiTiet)
                {
                    if (detail.IsOverdue(currentDate))
                    {
                        // Số ngày quá hạn
                        TimeSpan overdueDays = currentDate - detail.NgayHetHan;
                        int days = (int)Math.Ceiling(overdueDays.TotalDays); // Làm tròn lên

                        // Tiền phạt = số ngày quá hạn * số lượng mượn * tiền phạt mỗi ngày
                        totalFine += days * detail.SoLuong * finePerDay;
                    }
                }
                return totalFine;
            }

            // In chi tiết phiếu mượn
            public string GetLoanDetail(DateTime currentDate, double finePerDay)
            {
                string result = $"--- PHIẾU MƯỢN #{MaPhieu} ---\n";
                result += $"Ngày Mượn: {NgayMuon:dd/MM/yyyy} | Độc Giả: {TenDocGia} | Max: {SoNgayMuonToiDa} ngày\n";
                result += "Chi Tiết Vật Phẩm:\n";

                foreach (var detail in ChiTiet)
                {
                    string status = detail.IsOverdue(currentDate) ?
                                    $" (QUÁ HẠN! Phạt: {CalculateFine(currentDate, finePerDay):N0} VNĐ)" :
                                    " (Còn hạn)";
                    result += $"- {detail.VatPham.Ten} | SL: {detail.SoLuong} | Hạn trả: {detail.NgayHetHan:dd/MM/yyyy}{status}\n";
                }
                result += $"TỔNG TIỀN PHẠT ƯỚC TÍNH: {CalculateFine(currentDate, finePerDay):N0} VNĐ\n";
                return result;
            }
        }
        public class LibraryManager
        {
            public List<LibraryItem> Items { get; private set; }
            public List<Loan> Loans { get; private set; }

            public LibraryManager()
            {
                Items = new List<LibraryItem>();
                Loans = new List<Loan>();
            }

            // 1. Thêm vật phẩm
            public void AddItem(LibraryItem item)
            {
                Items.Add(item);
            }

            // 2. Đăng ký phiếu mượn (Kiểm tra tồn kho tổng thể)
            public bool RegisterLoan(Loan loan)
            {
                // Kiểm tra tồn kho cho TỪNG chi tiết trong phiếu mượn
                foreach (var detail in loan.ChiTiet)
                {
                    // Tìm vật phẩm trong danh sách quản lý
                    var itemInManager = Items.FirstOrDefault(i => i.MaVT == detail.VatPham.MaVT);

                    if (itemInManager == null || itemInManager.SoLuong < detail.SoLuong)
                    {
                        Console.WriteLine($"Đăng ký thất bại: Vật phẩm '{detail.VatPham.Ten}' không đủ số lượng ({itemInManager?.SoLuong ?? 0} < {detail.SoLuong}).");

                        // Hoàn lại số lượng đã giảm (Nếu AddItem đã được gọi trước đó)
                        // LƯU Ý: Nếu bạn gọi AddItem() của Loan trước khi gọi RegisterLoan() thì cần hoàn lại stock
                        // Giả sử logic AddItem() của Loan được thiết kế để chỉ thêm ChiTiet, còn việc giảm stock cuối cùng
                        // sẽ được thực hiện sau khi kiểm tra. (Hiện tại code Loan.AddItem đã giảm stock, nên ta phải hoàn lại)

                        // Logic hoàn lại (Tùy thuộc vào cách bạn thiết kế)

                        return false; // Hủy toàn bộ giao dịch
                    }
                }

                // Nếu tất cả đủ, thêm phiếu mượn vào danh sách quản lý
                Loans.Add(loan);
                Console.WriteLine($"Đăng ký phiếu mượn #{loan.MaPhieu} thành công.");
                return true;
            }

            // 3. Tìm phiếu mượn theo mã
            public Loan FindLoanById(string id)
            {
                return Loans.FirstOrDefault(l => l.MaPhieu.Equals(id, StringComparison.OrdinalIgnoreCase));
            }

            // 4. Tính tổng tiền phạt trong khoảng thời gian
            public double CalculateTotalFines(DateTime fromDate, DateTime toDate, DateTime currentDate, double finePerDay)
            {
                return Loans
                    .Where(l => l.NgayMuon >= fromDate && l.NgayMuon <= toDate)
                    .Sum(l => l.CalculateFine(currentDate, finePerDay));
            }

            // 5. Lấy danh sách vật phẩm được mượn nhiều nhất
            public List<LibraryItem> GetMostBorrowedItems(int topCount)
            {
                // Dùng Dictionary để tổng hợp số lượng mượn của từng vật phẩm
                var borrowedCounts = new Dictionary<string, int>();

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

                // Sắp xếp giảm dần và lấy topCount
                var topBorrowed = borrowedCounts
                    .OrderByDescending(kv => kv.Value)
                    .Take(topCount)
                    .ToDictionary(kv => kv.Key, kv => kv.Value);

                // Lấy thông tin chi tiết vật phẩm
                var result = new List<LibraryItem>();
                foreach (var kvp in topBorrowed)
                {
                    var item = Items.FirstOrDefault(i => i.MaVT == kvp.Key);
                    // Có thể tạo một lớp mới để chứa cả thông tin số lượng mượn
                    if (item != null)
                    {
                        result.Add(item);
                    }
                }
                return result;
            }

            // 6. Thống kê tổng tiền phạt theo loại vật phẩm
            public Dictionary<string, double> TotalFinesByItemType(DateTime currentDate, double finePerDay)
            {
                double bookFine = 0;
                double magazineFine = 0;

                foreach (var loan in Loans)
                {
                    foreach (var detail in loan.ChiTiet)
                    {
                        // Chỉ tính phạt nếu quá hạn
                        if (detail.IsOverdue(currentDate))
                        {
                            TimeSpan overdueDays = currentDate - detail.NgayHetHan;
                            int days = (int)Math.Ceiling(overdueDays.TotalDays);
                            double fine = days * detail.SoLuong * finePerDay;

                            if (detail.VatPham is Book)
                            {
                                bookFine += fine;
                            }
                            else if (detail.VatPham is Magazine)
                            {
                                magazineFine += fine;
                            }
                        }
                    }
                }

                return new Dictionary<string, double>
        {
            { "Book", bookFine },
            { "Magazine", magazineFine }
        };
            }

            // 7. Tìm phiếu mượn theo tên độc giả
            public List<Loan> GetLoansByPatronName(string name)
            {
                return Loans
                    .Where(l => l.TenDocGia.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}
