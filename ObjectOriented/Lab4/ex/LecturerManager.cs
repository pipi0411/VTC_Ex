using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuanLyTruongHoc
{
    public class LecturerManager
    {
        private List<Lecturer> listLecturers = new List<Lecturer>();

        // Thêm giảng viên 
        public void AddLecturer(Lecturer gv)
        {
            if (FindLecturer(gv.LecturerId) != null)
            {
                Console.WriteLine("Lecturer is already in the list");
                return;
            }
            listLecturers.Add(gv);
            Console.WriteLine("Add lecturer successfully");
        }

        // Sửa thông tin giảng viên
        public void EditLectures(string lecturerId, string name, DateTime date, string faculty, string specialized)
        {
            Lecturer gv = FindLecturer(lecturerId);
            if (gv != null)
            {
                gv.Name = name;
                gv.Date = date;
                gv.Faculty = faculty;
                gv.Specialized = specialized;
                Console.WriteLine("Edit lecturer successfully");
            }
            else
            {
                Console.WriteLine("Lecturer not found");
            }
        }

        // Xóa giảng viên
        public void DeleteLecturer(string lecturerId)
        {
            Lecturer gv = FindLecturer(lecturerId);
            if (gv != null)
            {
                listLecturers.Remove(gv);
                Console.WriteLine("Delete lecturer successfully");
            }
            else
            {
                Console.WriteLine("Lecturer not found");
            }
        }

        // Hiển thị danh sách giảng viên
        public void Display()
        {
            foreach (var gv in listLecturers)
            {
                gv.Display();
            }
        }

        // Tìm giảng viên theo mã giảng viên
        public Lecturer FindLecturer(string lecturerId)
        {
            return listLecturers.FirstOrDefault(gv => gv.LecturerId.Equals(lecturerId, StringComparison.OrdinalIgnoreCase));
        }

        // Tìm kiếm giảng viên theo tên
        public List<Lecturer> SearchLecturer(string name)
        {
            return listLecturers.Where(gv => gv.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // Lấy danh sách giảng viên
        public List<Lecturer> GetListLecturers()
        {
            return listLecturers;
        }
    }

    public static class LecturerManagement
    {
        public static void LecturerManagers(LecturerManager lecturerManager)
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("\n--- Lecturer Manager ---");
                Console.WriteLine("1. Add lecturer");
                Console.WriteLine("2. Edit lecturer");
                Console.WriteLine("3. Delete lecturer");
                Console.WriteLine("4. Display lecturer list");
                Console.WriteLine("5. Search lecturer by name");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // Adding a new lecturer
                        Console.Write("Enter lecturer id: ");
                        string lecturerId = Console.ReadLine();

                        Console.Write("Enter lecturer name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter date of birth (dd/MM/yyyy): ");
                        DateTime date;
                        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            Console.WriteLine("Invalid date format, please enter again (dd/MM/yyyy)");
                        }

                        Console.Write("Enter faculty: ");
                        string faculty = Console.ReadLine();

                        Console.Write("Enter specialized: ");
                        string specialized = Console.ReadLine();

                        Lecturer gv = new Lecturer(lecturerId, name, date, faculty, specialized);
                        lecturerManager.AddLecturer(gv);
                        break;

                    case 2:
                        // Editing an existing lecturer
                        Console.Write("Enter lecturer id: ");
                        string editLecturerId = Console.ReadLine();

                        Console.Write("Enter new lecturer name: ");
                        string editName = Console.ReadLine();

                        Console.Write("Enter new date of birth (dd/MM/yyyy): ");
                        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        {
                            Console.WriteLine("Invalid date format, please enter again (dd/MM/yyyy)");
                        }

                        Console.Write("Enter new faculty: ");
                        string editFaculty = Console.ReadLine();

                        Console.Write("Enter new specialized: ");
                        string editSpecialized = Console.ReadLine();

                        lecturerManager.EditLectures(editLecturerId, editName, date, editFaculty, editSpecialized);
                        break;

                    case 3:
                        // Deleting a lecturer
                        Console.Write("Enter lecturer id: ");
                        string deleteLecturerId = Console.ReadLine();
                        lecturerManager.DeleteLecturer(deleteLecturerId);
                        break;

                    case 4:
                        // Displaying the list of lecturers
                        lecturerManager.Display();
                        break;

                    case 5:
                        // Searching for lecturers
                        Console.WriteLine("1. Search by id");
                        Console.WriteLine("2. Search by name");
                        Console.Write("Choose: ");
                        int searchChoice = Convert.ToInt32(Console.ReadLine());
                        switch (searchChoice)
                        {
                            case 1:
                                Console.Write("Enter lecturer id: ");
                                string searchLecturerId = Console.ReadLine();
                                Lecturer foundLecturer = lecturerManager.FindLecturer(searchLecturerId);
                                if (foundLecturer == null)
                                {
                                    Console.WriteLine("Lecturer not found");
                                }
                                else
                                {
                                    foundLecturer.Display();
                                }
                                break;

                            case 2:
                                Console.Write("Enter lecturer name: ");
                                string searchName = Console.ReadLine();
                                List<Lecturer> listLecturers = lecturerManager.SearchLecturer(searchName);
                                if (listLecturers.Count == 0)
                                {
                                    Console.WriteLine("Lecturer not found");
                                }
                                else
                                {
                                    foreach (var lecturer in listLecturers)
                                    {
                                        lecturer.Display();
                                    }
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
