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
}
