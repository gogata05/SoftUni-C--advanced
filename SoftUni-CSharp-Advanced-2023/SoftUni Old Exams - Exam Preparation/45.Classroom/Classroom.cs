using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student != null)
            {
                this.students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var studentsInSubject = this.students.Where(s => s.Subject == subject).ToList();

            if (studentsInSubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in studentsInSubject)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
