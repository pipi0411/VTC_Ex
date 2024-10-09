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
}