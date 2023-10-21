using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;
namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        
        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.coveredExams = new List<int>();
        }

        private int id;
        public int Id
        {
            get => id;
            private set => id = value;
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                lastName = value;
            }
        }
        private List<int> coveredExams;
        public IReadOnlyCollection<int> CoveredExams => this.coveredExams;

        private IUniversity university;
        public IUniversity University => this.university;

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.university = university;
        }
    }
}
