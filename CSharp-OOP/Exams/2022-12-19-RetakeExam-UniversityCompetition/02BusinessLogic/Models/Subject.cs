using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;
namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {

        protected Subject(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            Rate = rate;
        }

        private int id;
        public int Id 
        { 
            get => id; 
            private set => id = value; 
        }

        

        private string name;
        public string Name 
        { 
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            } 
        }

        private double rate;
        public double Rate 
        { 
            get => rate; 
            private set => rate = value; 
        }
    }
}
