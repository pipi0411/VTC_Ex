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

    public class SubjectManagement{
        public static void SubjectManagers(SubjectManager subjectManager){
            bool isExit = false;
            while(!isExit){
                Console.WriteLine("\n--- Subject Manager ---");
                Console.WriteLine("1. Add subject");
                Console.WriteLine("2. Edit subject");
                Console.WriteLine("3. Delete subject");
                Console.WriteLine("4. Display subject list");
                Console.WriteLine("5. Search subject");
                Console.WriteLine("6. Exit");
                Console.Write("Choose a function: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    case 1:
                    // Thêm môn học
                        Console.Write("Enter subject id: ");
                        string subjectId = Console.ReadLine();
                        Console.Write("Enter subject name: ");
                        string subjectName = Console.ReadLine();
                        Subject mh = new Subject(subjectId, subjectName);
                        subjectManager.AddSubject(mh);
                        break;
                    case 2:
                    // Sửa thông tin môn học
                        Console.Write("Enter subject id: ");
                        string subjectIdEdit = Console.ReadLine();
                        Console.Write("Enter new subject name: ");
                        string subjectNameEdit = Console.ReadLine();
                        subjectManager.EditSubject(subjectIdEdit, subjectNameEdit);
                        break;
                    case 3:
                    // Xóa môn học
                        Console.Write("Enter subject id: ");
                        string subjectIdDelete = Console.ReadLine();
                        subjectManager.DeleteSubject(subjectIdDelete);
                        break;
                    case 4:
                    // Hiển thị danh sách môn học
                        subjectManager.Display();
                        break;
                    case 5:
                    // Tìm kiếm môn học 
                        Console.Write("1. Search by subject id");
                        Console.Write("2. Search by subject name");
                        Console.Write("Choose a function: ");
                        int searchChoice = Convert.ToInt32(Console.ReadLine());
                        switch (searchChoice){
                            case 1:
                                Console.Write("Enter subject id: ");
                                string subjectIdSearch = Console.ReadLine();
                                Subject mhSearch = subjectManager.FindSubject(subjectIdSearch);
                                if (mhSearch != null){
                                    mhSearch.Display();
                                }else{
                                    Console.WriteLine("Subject not found");
                                }
                                break; 
                            case 2:
                                Console.Write("Enter subject name: ");
                                string subjectNameSearch = Console.ReadLine();
                                List<Subject> listSubjects = subjectManager.SearchSubject(subjectNameSearch);
                                if (listSubjects.Count > 0){
                                    foreach (var m in listSubjects){
                                        m.Display();
                                    }
                                }else{
                                    Console.WriteLine("Subject not found");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                        break;
                    case 6:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}