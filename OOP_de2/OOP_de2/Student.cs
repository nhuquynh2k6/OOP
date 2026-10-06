using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de2
{
    using System; // Cần thiết cho DateTime

    // --- Lớp 1: Student (Sinh Viên) ---
    public class Student
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }

        // Constructor
        public Student(string maSV, string tenSV, DateTime ngaySinh)
        {
            MaSV = maSV;
            TenSV = tenSV;
            NgaySinh = ngaySinh;
        }

        public string GetInfo()
        {
            return $"[SV] Mã: {MaSV} | Tên: {TenSV} | Ngày Sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }

    // --- Lớp 2: Course (Khóa Học) ---
    public class Course
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public int SoTinChi { get; set; }

        // Constructor
        public Course(string maKH, string tenKH, int soTinChi)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SoTinChi = soTinChi;
        }

        public string GetInfo()
        {
            return $"[KH] Mã: {MaKH} | Tên: {TenKH} | Tín Chỉ: {SoTinChi}";
        }
    }

    // --- Lớp 3: Enrollment (Đăng Ký) - Đã kiểm tra và xác nhận cấu trúc đúng ---
    public class Enrollment
    {
        // Cần đảm bảo lớp Student và Course đã được định nghĩa
        public Student SinhVien { get; set; }
        public Course KhoaHoc { get; set; }
        public double Diem { get; set; }

        // Constructor
        public Enrollment(Student sinhVien, Course khoaHoc, double diem)
        {
            SinhVien = sinhVien;
            KhoaHoc = khoaHoc;
            Diem = diem;
        }

        // Phương thức kiểm tra qua môn
        public bool IsPassed()
        {
            return Diem >= 5.0;
        }

        public string GetEnrollmentInfo()
        {
            string status = IsPassed() ? "Đã qua" : "Chưa qua";
            return $"{SinhVien.TenSV} - Khóa học {KhoaHoc.TenKH} | Điểm: {Diem:N1} | Trạng thái: {status}";
        }
    }
}

