using System;
namespace QuanLyTruongHoc{

// Lớp Student kế thừa từ lớp Person
    public class Student : Person
    {
        public string StudentId { get; set; }
        public string ClassStudent { get; set; }
        public double AverageScore { get; set; }

        public Student(string studentId, string name, DateTime date, string classStudent, double averageScore) : base(name, date)
        {
            StudentId = studentId;
            ClassStudent = classStudent;
            AverageScore = averageScore;
        }

        public override void Display()
        {
            Console.WriteLine($"Student ID: {StudentId}, Name: {Name}, Date of birth: {Date.ToShortDateString()}, Class: {ClassStudent}, Average score: {AverageScore}");
        }
    }

    // Lớp quản lý sinh viên
    public class StudentManager{
        private List<Student> listStudents = new List<Student>();
        // Thêm sinh viên
        public void AddStudent(Student sv){
            if (FindStudent(sv.Student) != null){
                Console.WriteLine("Student is already in the list");
                return;
            }
            listStudents.Add(sv);
            Console.WriteLine("Add student successfully");
        }

        // Sửa thông tin sinh viên
        public void EditStudent(string studentId, string name, DateTime date, string classStudent, double averageScore){
            Student sv = FindStudent(studentId);
            if (sv != null){
                sv.Name = name;
                sv.Date = date;
                sv.ClassStudent = classStudent;
                sv.AverageScore = averageScore;
                Console.WriteLine("Edit student successfully");
            }else{
                Console.WriteLine("Student not found");
            }
        }

        // Xóa sinh viên
        public void DeleteStudent(string studentId){
            Student sv = FindStudent(studentId);
            if (sv != null){
                listStudents.Remove(sv);
                Console.WriteLine("Delete student successfully");
            }else{
                Console.WriteLine("Student not found");
            }
        }
        // Hiển thị danh sách sinh viên
        public void Display(){
            foreach (var sv in listStudents){
                sv.Display();
            }
        }

        // Tìm sinh viên theo mã sinh viên
        public Student FindStudent(string studentId){
            return listStudents.FirstOrDefault(sv => sv.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase));
        }
    }
}