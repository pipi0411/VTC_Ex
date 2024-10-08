using System;
namespace QuanLyTruongHoc{
    public class Program{
        public static void Main(string[] args){
            Console.WriteLine("Hello Student Management System");
            Student student = new Student("SV001", "Nguyen Van A", new DateTime(2000, 1, 1), "12A1", 8.5);
            student.Display();
            Lecturer lecturer = new Lecturer("GV001", "Tran Van B", new DateTime(1970, 1, 1), "CNTT", "Lap trinh C#");
            lecturer.Display();
            Subject subject = new Subject("MH001", "Lap trinh C#");
            subject.Display();
            Grade grade = new Grade("SV001", "Lap trinh C#", 8.5);
            grade.Display();
            Class class1 = new Class("12A1", "Lop 12A1", lecturer);
            class1.ListStudents.Add(student);
            class1.Display();
            Console.ReadKey();
        }
    }
}