using System;
namespace QuanLyTruongHoc{

// Lớp Lecturer kế thừa từ Person
public class Lecturer : Person
{
    public string LecturerId { get; set; }
    public string Faculty { get; set; }
    public string  Specialized { get; set; }

    public Lecturer(string lecturerId, string name, DateTime date, string faculty, string specialized) : base(name, date)
    {
        LecturerId = lecturerId;
        Faculty = faculty;
        Specialized = specialized;
    }

    public override void Display()
    {
        Console.WriteLine($"Lecturer ID: {LecturerId}, Name: {Name}, Date of birth: {Date.ToShortDateString()}, Faculty: {Faculty}, Specialized: {Specialized}");
    }
}
}