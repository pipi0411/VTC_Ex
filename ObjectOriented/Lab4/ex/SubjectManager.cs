using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace QuanLyTruongHoc{
    public class SubjectManager{
        private List<Subject> listSubjects = new List<Subject>();

        // Thêm môn học
        public void AddSubject(Subject mh){
            if (FindSubject(mh.SubjectName) != null){
                Console.WriteLine("Subject is already in the list");
                return;
            }
            listSubjects.Add(mh);
            Console.WriteLine("Add subject successfully");
        }

        // Sửa thông tin môn học
        public void EditSubject(string subjectId, string subjectName){
            Subject mh = FindSubject(subjectName);
            if (mh != null){
                mh.SubjectName = subjectName;
                Console.WriteLine("Edit subject successfully");
            }else{
                Console.WriteLine("Subject not found");
            }
        }
        // Xóa môn học
        public void DeleteSubject(string subjectId){
            Subject mh = FindSubject(subjectId);
            if (mh != null){
                listSubjects.Remove(mh);
                Console.WriteLine("Delete subject successfully");
            }else{
                Console.WriteLine("Subject not found");
            }
        }

        // Hiển thị danh sách môn học
        public void Display(){
            foreach (var mh in listSubjects){
                mh.Display();
            }
        }

        // Tìm môn học theo mã môn học
        public Subject FindSubject(string subjectId){
            return listSubjects.FirstOrDefault(mh => mh.SubjectId.Equals(subjectId, StringComparison.OrdinalIgnoreCase));
        }

        // Tìm kiếm môn học theo tên
        public List<Subject> SearchSubject(string name){
            return listSubjects.Where(mh => mh.SubjectName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // Lấy danh sách môn học
        public List<Subject> GetListSubjects(){
            return listSubjects;
        }
    }
}