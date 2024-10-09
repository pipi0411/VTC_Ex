// Lớp quản lý sinh viên
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace QuanLyTruongHoc{
    public class StudentManager{
        private List<Student> listStudents = new List<Student>();
        // Thêm sinh viên
        public void AddStudent(Student sv){
            if (FindStudent(sv.StudentId) != null){
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
        // Tìm kiếm sinh viên theo tên
        public List<Student> SearchStudent(string name){
            return listStudents.Where(sv => sv.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        // Lấy danh sách sinh viên
        public List<Student> GetListStudents(){
            return listStudents;
        }
    }

     public static class StudentManagement
    {
        public static void StudentManagers(StudentManager studentManager)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("\n--- Student management ---");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Edit student");
                Console.WriteLine("3. Delete student");
                Console.WriteLine("4. Display list student");
                Console.WriteLine("5. Search student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter student id: ");
                        string studentId = Console.ReadLine();
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter date of birth (dd/MM/yyyy): ");
                        DateTime date;
                        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            Console.WriteLine("Invalid date format. Please enter again (dd/MM/yyyy)");
                        }
                        Console.Write("Enter class: ");
                        string classStudent = Console.ReadLine();
                        Console.Write("Enter average score: ");
                        double averageScore;
                        while (!double.TryParse(Console.ReadLine(), out averageScore))
                        {
                            Console.WriteLine("Invalid score. Please enter again");
                        }
                        studentManager.AddStudent(new Student(studentId, name, date, classStudent, averageScore));
                        break;
                    case 2:
                        Console.Write("Enter student id: ");
                        studentId = Console.ReadLine();
                        Console.Write("Enter new student name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter new date of birth (dd/MM/yyyy): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out date))
                        {
                            Console.WriteLine("Invalid date format. Please enter again (dd/MM/yyyy)");
                        }
                        Console.Write("Enter new class: ");
                        classStudent = Console.ReadLine();
                        Console.Write("Enter new average score: ");
                        while (!double.TryParse(Console.ReadLine(), out averageScore))
                        {
                            Console.WriteLine("Invalid score. Please enter again");
                        }
                        studentManager.EditStudent(studentId, name, date, classStudent, averageScore);
                        break;
                    case 3:
                        Console.Write("Enter student id: ");
                        studentId = Console.ReadLine();
                        studentManager.DeleteStudent(studentId);
                        break;
                    case 4:
                        studentManager.Display();
                        break;
                    case 5:
                        Console.WriteLine("1. Search by id");
                        Console.WriteLine("2. Search by name");
                        Console.Write("Choose: ");
                        int searchChoice = Convert.ToInt32(Console.ReadLine());
                        switch(searchChoice){
                            case 1:
                            Console.Write("Enter student id: ");
                            studentId = Console.ReadLine();
                            Student sv = studentManager.FindStudent(studentId);
                            if (sv == null){
                                Console.WriteLine("Student not found");
                            }else{
                                sv.Display();
                            }
                            break;
                            case 2:
                            Console.Write("Enter student name: ");
                            name = Console.ReadLine();
                            List<Student> listStudents = studentManager.SearchStudent(name);
                            if (listStudents.Count == 0){
                                Console.WriteLine("Student not found");
                            }else{
                                foreach (var student in listStudents){
                                    student.Display();
                                }
                            }
                            break;
                        }
                        break;
                    case 6:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
    
}
   