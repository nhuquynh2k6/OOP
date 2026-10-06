using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_de2
{
    internal class AcademyManager
    {
        List<Student> Students=new List<Student>();
        List<Course> Courses=new List<Course>();
        List<Enrollment> Enrollments=new List<Enrollment>();
        public void AddStudent(Student s)
        {
            foreach (var student in Students)
                if (student.MaSV==s.MaSV)
                    return;
            Students.Add(s);
        }
        public void AddCourse(Course c)
        {
            foreach(var student in Courses)
                if(student.MaKH==c.MaKH)
                    return;
            Courses.Add(c);
        }
        public bool RegisterEnrollment(Enrollment e)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            foreach(var student in enrollments)
                if(student.SinhVien.MaSV==e.SinhVien.MaSV && e.KhoaHoc.MaKH==student.KhoaHoc.MaKH)
                return true;
            return false;
        }
        public Student FindStudentById(string id)
        {
            foreach(var student in Students)
                if(student.MaSV==id)
                    return student;
            return null;
        }
        public double CalculateGPA(string studentId)
        {
            double total = 0.0;
            int totalTinChi = 0;
            foreach (var student in Enrollments)
                if (student.SinhVien.MaSV==studentId)
                {
                    total += student.Diem * student.KhoaHoc.SoTinChi;
                    totalTinChi += student.KhoaHoc.SoTinChi;
                }
            if (totalTinChi == 0)
                return 0.0;
            return total/totalTinChi;
        }
        public List<Student> GetStudentsByCourse(string courseId)
        {
            List<Student> students = new List<Student>();
            foreach(var e in Enrollments)
            {
                if (e.KhoaHoc.MaKH.Equals(courseId, StringComparison.OrdinalIgnoreCase))
                {
                    bool isAdded = false;
                    foreach (var s in students)
                    {
                        if (s.MaSV == e.SinhVien.MaSV)
                        {
                            isAdded = true;
                            break;
                        }
                    }
                    if (!isAdded)
                        students.Add(e.SinhVien);
                }

            }   
            return students;

        }
    }
}
