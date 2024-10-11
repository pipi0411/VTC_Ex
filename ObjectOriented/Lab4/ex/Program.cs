using System;
namespace QuanLyTruongHoc{
    public class Program{
        public static void Main(string[] args){
            // Khởi tạo các Manager
            StudentManager studentManager = new StudentManager();
            LecturerManager lecturerManager = new LecturerManager();
            SubjectManager subjectManager = new SubjectManager();
            GradeManager gradeManager = new GradeManager();
            ClassManager classManager = new ClassManager();

            bool isExit = false;
            while (!isExit){
                Console.WriteLine("\n--- School Management System  ---");
                Console.WriteLine("1. Stutdent Management");
                Console.WriteLine("2. Lecturer Management");
                Console.WriteLine("3. Subject Management");
                Console.WriteLine("4. Class Management");
                Console.WriteLine("5. Grade Management");
                Console.WriteLine("6. Exit");
                Console.Write("Select function: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice){
                    case 1:
                        StudentManagement.StudentManagers(studentManager);
                        break;
                    case 2:
                        LecturerManagement.LecturerManagers(lecturerManager);
                        break;
                    case 3:
                        SubjectManagement.SubjectManagers(subjectManager);
                        break;
                    case 4:
                        ClassManagement.ClassManagers(classManager, lecturerManager, studentManager);
                        break;
                    case 5:
                        GradeManagement.GradeManagers(gradeManager, studentManager, subjectManager);
                        break;
                    case 6:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại");
                        break;
                }
            }
        }
    }
}