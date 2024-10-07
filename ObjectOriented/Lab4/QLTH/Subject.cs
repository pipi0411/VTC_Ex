using System;
namespace QuanLyTruongHoc;

// Lớp Subject
public class Subject
{
    public string SubjectId { get; set; }
    public string SubjectName { get; set; }

    public Subject(string subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void Display()
    {
        Console.WriteLine($"Subject ID: {SubjectId}, Subject Name: {SubjectName}");
    }
}

