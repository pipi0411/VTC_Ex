using System;
namespace QuanLyTruongHoc{

// Lớp class quản lý thông tin lớp học
public class Class
{
    public string ClassId { get; set; }
    public string ClassName { get; set; }
    public Lecturer Lecturers { get; set; }
    public List<Student> ListStudents { get; set; }
    public Class(string classId, string className, Lecturer lecturers)
    {
        ClassId = classId;
        ClassName = className;
        Lecturers = lecturers;
        ListStudents = new List<Student>();
    }
    public void Display()
    {
        Console.WriteLine($"Class ID: {ClassId}, Class Name: {ClassName}, Lecturer: {Lecturers.Name}");
        Console.WriteLine("List of students:");
        foreach (var sv in ListStudents){
            Console.WriteLine($"\t{sv.StudentId}, {sv.Name}");
        }
    }
}
}