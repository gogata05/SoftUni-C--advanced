using System;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
            this.NumberOfWins = 0;
        }

        private string fullName;
        public string FullName
        {
            get => fullName; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            } 

        }

        private IFormulaOneCar car;
        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }

        private int wins;
        public int NumberOfWins
        {
            get => wins;
            private set => value = wins;
        }

        public bool CanRace { get; private set; }
        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            wins++;
        }

        public override string ToString()
        => $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}
