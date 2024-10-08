using System;
namespace QuanLyTruongHoc{
// Lớp Grade
public class Grade
{
    public string StudentId { get; set; }
    public string SubjectName { get; set; }

    public double Score { get; set; }

    public Grade(string studentId, string subjectName, double score)
    {
        StudentId = studentId;
        SubjectName = subjectName;
        Score = score;
    }

    public void Display()
    {
        Console.WriteLine($"Student ID: {StudentId}, Subject Name: {SubjectName}, Score: {Score}");
    }

}
}