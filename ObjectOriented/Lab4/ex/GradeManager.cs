using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace QuanLyTruongHoc {
    public class GradeManager {
        private List<Grade> listGrades = new List<Grade>();

        // Add grade
        public void AddGrade(Grade score) {
            if (score == null) {
                Console.WriteLine("Grade cannot be null.");
                return;
            }
            listGrades.Add(score);
            Console.WriteLine("Add grade successfully");
        }

        // Edit grade
        public void EditGrade(string studentId, string subjectId, double newScore) {
            Grade grade = FindGrade(studentId, subjectId);
            if (grade != null) {
                grade.Score = newScore;
                Console.WriteLine("Edit grade successfully");
            } else {
                Console.WriteLine("Grade not found");
            }
        }

        // Delete grade
        public void DeleteGrade(string studentId, string subjectId) {
            Grade grade = FindGrade(studentId, subjectId);
            if (grade != null) {
                listGrades.Remove(grade);
                Console.WriteLine("Delete grade successfully");
            } else {
                Console.WriteLine("Grade not found");
            }
        }

        // Display list of grades
        public void Display() {
            if (listGrades.Count == 0) {
                Console.WriteLine("No grades available.");
                return;
            }

            foreach (var grade in listGrades) {
                grade.Display();
            }
        }

        // Find grade by student ID and subject ID
        public Grade FindGrade(string studentId, string subjectId) {
            return listGrades.FirstOrDefault(grade => 
                grade.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase) && 
                grade.SubjectId.Equals(subjectId, StringComparison.OrdinalIgnoreCase));
        }

        // Search grades by student ID
        public List<Grade> SearchGradeByStudentId(string studentId) {
            return listGrades.Where(grade => grade.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Search grades by subject ID
        public List<Grade> SearchGradeBySubjectId(string subjectId) {
            return listGrades.Where(grade => grade.SubjectId.Equals(subjectId, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
    public class GradeManagement {
        public static void GradeManagers(GradeManager gradeManager, StudentManager studentManager, SubjectManager subjectManager) {
            bool isExit = false;
            while (!isExit) {
                Console.WriteLine("\n--- Grade Manager ---");
                Console.WriteLine("1. Add grade");
                Console.WriteLine("2. Edit grade");
                Console.WriteLine("3. Delete grade");
                Console.WriteLine("4. Display grade list");
                Console.WriteLine("5. Search grade");
                Console.WriteLine("6. Exit");
                Console.Write("Choose: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        // Add grade
                        Console.Write("Enter student id: ");
                        string studentId = Console.ReadLine();
                        Student students = studentManager.FindStudent(studentId);
                        if (students == null) {
                            Console.WriteLine("Student not found");
                            return;
                        }
                        Console.Write("Enter subject id: ");
                        string subjectId = Console.ReadLine();
                        Subject subjects = subjectManager.FindSubject(subjectId);
                        if (subjects == null) {
                            Console.WriteLine("Subject not found");
                            return;
                        }
                        Console.Write("Enter score: ");
                        double score;
                        while (!double.TryParse(Console.ReadLine(), out score)){
                            Console.WriteLine("Invalid score. Please enter again.");
                        }
                        gradeManager.AddGrade(new Grade(studentId, subjectId, score));
                        break;
                    case 2:
                        // Edit grade
                        Console.Write("Enter student id: ");
                        studentId = Console.ReadLine();
                        Console.Write("Enter subject id: ");
                        subjectId = Console.ReadLine();
                        Console.Write("Enter new score: ");
                        double newScore;
                        while (!double.TryParse(Console.ReadLine(), out newScore)){
                            Console.WriteLine("Invalid score. Please enter again.");
                        }
                        gradeManager.EditGrade(studentId, subjectId, newScore);
                        break;
                    case 3:
                        // Delete grade
                        Console.Write("Enter student id: ");
                        studentId = Console.ReadLine();
                        Console.Write("Enter subject id: ");
                        subjectId = Console.ReadLine();
                        gradeManager.DeleteGrade(studentId, subjectId);
                        break;
                    case 4:
                        // Display grade list
                        gradeManager.Display();
                        break;
                    case 5:
                        // Search grade
                        Console.WriteLine("1. Search grade by student id and subject id");
                        Console.WriteLine("2. Search grade by student id");
                        Console.WriteLine("3. Search grade by subject id");
                        Console.Write("Choose: ");
                        int searchChoice = Convert.ToInt32(Console.ReadLine());
                        switch (searchChoice) {
                            case 1:
                                Console.Write("Enter student id: ");
                                studentId = Console.ReadLine();
                                Console.Write("Enter subject id: ");
                                subjectId = Console.ReadLine();
                                Grade grade = gradeManager.FindGrade(studentId, subjectId);
                                if (grade == null) {
                                    Console.WriteLine("Grade not found");
                                }else{
                                    grade.Display();
                                }
                                break;
                            case 2:
                                Console.Write("Enter student id: ");
                                studentId = Console.ReadLine();
                                List<Grade> listGrades = gradeManager.SearchGradeByStudentId(studentId);
                                if (listGrades.Count == 0) {
                                    Console.WriteLine("Grade not found");
                                }else{
                                    foreach (var gradeItem in listGrades) {
                                        gradeItem.Display();
                                    }
                                }
                                break;
                            case 3:
                                Console.Write("Enter subject id: ");
                                subjectId = Console.ReadLine();
                                listGrades = gradeManager.SearchGradeBySubjectId(subjectId);
                                if (listGrades.Count == 0) {
                                    Console.WriteLine("Grade not found");
                                }else{
                                    foreach (var gradeItem in listGrades) {
                                        gradeItem.Display();
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
