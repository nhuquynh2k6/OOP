using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                AcademyManager manager = new AcademyManager();

                // --- 1. THÊM SINH VIÊN & KHÓA HỌC ---
                Console.WriteLine("--- 1. THÊM SINH VIÊN VÀ KHÓA HỌC ---");

                // 5 Sinh viên
                Student sv1 = new Student("S001", "Nguyễn Văn An", new DateTime(2003, 5, 15));
                Student sv2 = new Student("S002", "Trần Thị Bình", new DateTime(2002, 11, 22));
                Student sv3 = new Student("S003", "Lê Văn Cường", new DateTime(2004, 1, 1));
                Student sv4 = new Student("S004", "Phạm Thị Duyên", new DateTime(2003, 8, 10));
                manager.AddStudent(sv1);
                manager.AddStudent(sv2);
                manager.AddStudent(sv3);
                manager.AddStudent(sv4);

                // 3 Khóa học
                Course kh1 = new Course("IT101", "Lập trình C# cơ bản", 3);
                Course kh2 = new Course("CS202", "Cấu trúc dữ liệu", 4);
                Course kh3 = new Course("MT301", "Toán rời rạc", 2);
                manager.AddCourse(kh1);
                manager.AddCourse(kh2);
                manager.AddCourse(kh3);

                // --- 2. TẠO LƯỢT ĐĂNG KÝ (Enrollment) ---
                Console.WriteLine("\n--- 2. TẠO LƯỢT ĐĂNG KÝ ---");

                // SV1: An
                manager.RegisterEnrollment(new Enrollment(sv1, kh1, 8.5)); // Qua môn
                manager.RegisterEnrollment(new Enrollment(sv1, kh3, 4.0)); // Chưa qua

                // SV2: Bình
                manager.RegisterEnrollment(new Enrollment(sv2, kh1, 9.0)); // Qua môn
                manager.RegisterEnrollment(new Enrollment(sv2, kh2, 7.5)); // Qua môn

                // SV3: Cường
                manager.RegisterEnrollment(new Enrollment(sv3, kh2, 3.0)); // Chưa qua

                // SV4: Duyên
                manager.RegisterEnrollment(new Enrollment(sv4, kh1, 6.5)); // Qua môn
                manager.RegisterEnrollment(new Enrollment(sv4, kh2, 9.5)); // Qua môn
                manager.RegisterEnrollment(new Enrollment(sv4, kh3, 8.0)); // Qua môn


                // --- 3. HIỂN THỊ THÔNG TIN KHÓA HỌC ---
                Console.WriteLine("\n--- 3. HIỂN THỊ THÔNG TIN KHÓA HỌC (IT101) ---");
                Console.WriteLine(kh1.GetInfo());

                // --- 4. TÍNH GPA CỦA SINH VIÊN CỤ THỂ (SV4: Duyên) ---
                // Duyên: (6.5*3 + 9.5*4 + 8.0*2) / (3+4+2) = (19.5 + 38 + 16) / 9 = 73.5 / 9 = 8.17
                Console.WriteLine("\n--- 4. TÍNH GPA CỦA SV4 (Phạm Thị Duyên) ---");
                double gpaDuyen = manager.CalculateGPA("S004");
                Console.WriteLine($"GPA của Duyên: {gpaDuyen:N2}");

                // --- 5. TÌM SINH VIÊN ĐĂNG KÝ KHÓA HỌC "IT101" ---
                // An (S001), Bình (S002), Duyên (S004)
                Console.WriteLine("\n--- 5. SINH VIÊN ĐĂNG KÝ 'Lập trình C# cơ bản' (IT101) ---");
                var studentsInCSharp = manager.GetStudentsByCourse("IT101");
                Console.WriteLine($"Có {studentsInCSharp.Count} sinh viên đã đăng ký khóa IT101:");
                foreach (var student in studentsInCSharp)
                {
                    Console.WriteLine($"- {student.GetInfo()}");
                }
            }
        }
    }
}
