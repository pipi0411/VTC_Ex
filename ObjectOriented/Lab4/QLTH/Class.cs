using System;
namespace QuanLyTruongHoc.Lecturer;

// Lớp class quản lý thông tin lớp học
public class Class
{
    public string ClassId { get; set; }
    public string ClassName { get; set; }
    public Lecturer Lecturer { get; set; }
}