using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace QuanLyTruongHoc{
    public class ClassManager{
        private List<Class> listClasses = new List<Class>();

        // Thêm lớp học
        public void AddClass(Class lop){
            if (FindClass(lop.ClassId) != null){
                Console.WriteLine("Class is already in the list");
                return;
            }
            listClasses.Add(lop);
            Console.WriteLine("Add class successfully");
        }

        // Sửa thông tin lớp học
        public void EditClass(string classId, string className, Lecturer lecturers){
            Class lop = FindClass(classId);
            if (lop != null){
                lop.ClassName = className;
                lop.Lecturers = lecturers;
                Console.WriteLine("Edit class successfully");
            }else{
                Console.WriteLine("Class not found");
            }
        }
        // Xóa lớp học
        public void DeleteClass(string classId){
            Class lop = FindClass(classId);
            if (lop != null){
                listClasses.Remove(lop);
                Console.WriteLine("Delete class successfully");
            }else{
                Console.WriteLine("Class not found");
            }
        }

        // Thêm sinh viên vào lớp
        public void AddStudentToClass(string classId, Student sv){
            Class lop = FindClass(classId);
            if (lop != null){
                if (lop.ListStudents.Any(student => student.StudentId.Equals(sv.StudentId, StringComparison.OrdinalIgnoreCase))){
                    Console.WriteLine("Student is already in the class");
                    return;
                }
                lop.ListStudents.Add(sv);
                Console.WriteLine("Add student to class successfully");
            }else{
                Console.WriteLine("Class not found");
            }
        }
        // Xóa sinh viên
        public void DeleteStudentFromClass(string classId, string studentId){
            Class lop = FindClass(classId);
            if (lop != null){
                Student sv = lop.ListStudents.FirstOrDefault(student => student.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase));
                if (sv != null){
                    lop.ListStudents.Remove(sv);
                    Console.WriteLine("Delete student from class successfully");
                }else{
                    Console.WriteLine("Student not found");
                }
            }else{
                Console.WriteLine("Class not found");
            }
        }

        // Hiển thị danh sách lớp học
        public void Display(){
            foreach (var lop in listClasses){
                lop.Display();
            }
        }

        // Tìm lớp học theo mã lớp học
        public Class FindClass(string classId){
            return listClasses.FirstOrDefault(lop => lop.ClassId.Equals(classId, StringComparison.OrdinalIgnoreCase));
        }

        // Tìm kiếm lớp học theo tên
        public List<Class> SearchClass(string name){
            return listClasses.Where(lop => lop.ClassName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // Lấy danh sách lớp học
        public List<Class> GetListClasses(){
            return listClasses;
        }
    }
    public class ClassManagement{
        public static void ClassManagers(ClassManager classManager){
            bool isExit = false;
            while (!isExit){
                Console.WriteLine("\n--- Class Manager ---");
                Console.WriteLine("1. Add class");
                Console.WriteLine("2. Edit class");
                Console.WriteLine("3. Delete class");
                Console.WriteLine("4. Add student to class");
                Console.WriteLine("5. Delete student from class");
                Console.WriteLine("6. Display class list");
                Console.WriteLine("7. Search class");
                Console.WriteLine("8. Exit");
                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice){
                    case 1:
                    // Thêm lớp học
                        Console.Write("Enter class id: ");
                        string classId = Console.ReadLine();
                        Console.Write("Enter class name: ");
                        string className = Console.ReadLine();
                        Console.Write("Enter lecturer id: ");
                        string lecturerId = Console.ReadLine();
                        lecturerId gv = lecturerManager.FindLecturer(lecturerId);
                        if (gv = null){
                            Console.WriteLine("Lecturer not found");
                            break;
                        }
                        Class lop = new Class(classId, className, gv);
                        classManager.AddClass(lop);
                        break;
                    case 2:
                    // Sửa thông tin lớp học
                        Console.Write("Enter class id: ");
                        classId = Console.ReadLine();
                        Console.Write("Enter new class name: ");
                        string newClassName = Console.ReadLine();
                        Console.Write("Enter new lecturer id: ");
                        string newLecturerId = Console.ReadLine();
                        Lecturer gv = lecturerManager.FindLecturer(newLecturerId);
                        if (gv == null){
                            Console.WriteLine("Lecturer not found");
                            break;
                        }
                        classManager.EditClass(classId, newClassName, gv);
                        break;
                    case 3:

                }
            }
        }
    }
}