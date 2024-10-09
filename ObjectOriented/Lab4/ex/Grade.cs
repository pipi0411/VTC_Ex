using System;
namespace QuanLyTruongHoc{
// Lớp Grade
public class Grade
{
    public string StudentId { get; set; }
    public string SubjectId { get; set; }

    public double Score { get; set; }

    public Grade(string studentId, string subjectId, double score)
    {
        StudentId = studentId;
        SubjectId = subjectId;
        Score = score;
    }

    public void Display()
    {
        Console.WriteLine($"Student ID: {StudentId}, Subject ID: {SubjectId}, Score: {Score}");
    }

}
}