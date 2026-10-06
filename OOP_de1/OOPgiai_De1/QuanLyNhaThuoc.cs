using KTGK_CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNTT2411024_DuongNhuQuynh_De1
{
    //MSSV: CNTT2411024
    //Ho ten: Dương Như Quỳnh
    //Đề 1
    internal class QuanLyNhaThuoc
    {
        private List<Thuoc> danhSachThuoc;
        private List<BenhNhan> danhSachBN;
        private List<DonThuoc> danhSachDT;
        private Dictionary<string, double> chietKhauTheoLoai;

        public List<Thuoc> DanhSachThuoc { get => danhSachThuoc; set => danhSachThuoc = value; }
        public List<BenhNhan> DanhSachBN { get => danhSachBN; set => danhSachBN = value; }
        public List<DonThuoc> DanhSachDT { get => danhSachDT; set => danhSachDT = value; }
        public void ChietKhauTheoLoai()
        {
            if (chietKhauTheoLoai == null)
            {
                chietKhauTheoLoai = new Dictionary<string, double>()
            {
                { "VIP", 0.10 },
            { "Thuong", 0.05 },
            { "Moi", 0.00 }
            };
                Console.WriteLine($"Khoi tao thanh cong");
            }
        }
        public void CapNhatSoLuongTon(int maThuoc, int soLuongNhapThem)
        {
            foreach (var thuoc in danhSachThuoc)
            {
                if (thuoc.MaThuoc == maThuoc)
                    thuoc.SoLuongTon += soLuongNhapThem;
                return;
            }
        }
        public List<Thuoc> TimKiemThuocTheoNhaSanXuat(string nhaSanXuat)
        {
            List<Thuoc> thuoc = new List<Thuoc>();
            foreach (var t in thuoc)
            {
                if (t.NhaSanXuat.ToUpper() == nhaSanXuat.ToUpper())
                {
                    thuoc.Add(t);
                }
            }
            return thuoc;
        }
        public bool ThemDonThuoc(DonThuoc dt)
        {
            bool exit = false;
            foreach (var b in danhSachBN)
            {
                if (b.MaBN.ToUpper() == dt.MaBN.ToUpper())
                {
                     exit = true;
                    break;
                }
            }
            if (!exit)
            {
                return false;
            }
            foreach (var chitiet in dt.ChiTiet)
            {
                Thuoc thuocInStock = null;
                foreach (var t in danhSachThuoc)
                {
                    if (t.MaThuoc == chitiet.MaThuoc)
                    {
                        thuocInStock = t;
                        break;
                    }
                }
                if (thuocInStock == null)
                {
                    return false;
                }
                if (chitiet.SoLuong <= 0)
                {
                    return false;
                }
                if (chitiet.SoLuong >= thuocInStock.SoLuongTon)
                {
                    return false;
                }
                double giaBanToiThieu = thuocInStock.GiaNhap * 1.1;
                if (chitiet.DonGia < giaBanToiThieu)
                {
                    return false;
                }
            }
            foreach (var chitiet in dt.ChiTiet)
            {
                foreach (var t in danhSachThuoc)
                {
                    if (t.MaThuoc == chitiet.MaThuoc)
                    {
                        t.SoLuongTon -= chitiet.SoLuong;
                        break;
                    }
                }
            }
            DanhSachDT.Add(dt);
            return true;

        }
        public BenhNhan ThongKeBenhNhanChiTieuNhieuNhat(int thang, int nam)
        {
            var chiTieuBenhNhan = new Dictionary<string, double>();
            foreach (var dt in danhSachDT)
            {
                if (dt.NgayKe.Month != thang || dt.NgayKe.Year != nam)
                    continue;
            }
            BenhNhan bn = null;
            foreach (var b in danhSachBN)
            {
                if (b.MaBN == bn.MaBN)
                {
                    bn = b;
                    break;
                }
                if (bn == null)
                {
                    continue;
                }
                double phanTramChietKhau = 0.0;
                if (chietKhauTheoLoai.ContainsKey(bn.LoaiBN))
                {
                    phanTramChietKhau = chietKhauTheoLoai[bn.LoaiBN];
                }
                double tongTienChiTiet = 0;
                foreach (var ct in dt.ChiTiet)
                {
                    tongTienChiTiet += ct.DonGia * ct.SoLuong;
                }
                double tongTienThanhToan = (tongTienChiTiet - phanTramChietKhau);
                string maBN = dt.MaBN;
            }
            
        }
    }
}
