namespace EDriveRent.Models
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Utilities.Messages;
    using System;
    public class User : IUser
    {
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenseNumber;
            this.rating = 0;
            this.isBlocked = false;
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FirstNameNull));
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
                    throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));
                }
                lastName = value;
            }
        }

        private string drivingLicenseNumber;
        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DrivingLicenseRequired));
                }
                drivingLicenseNumber = value;
            }
        }
        private double rating;
        public double Rating => this.rating;

        private bool isBlocked;
        public bool IsBlocked => this.isBlocked;

        public void DecreaseRating()
        {
            if (this.rating < 2)
            {
                this.rating = 0;
                this.isBlocked = true;
            }
            else
            {
                this.rating -= 2;
            }
        }
        public void IncreaseRating()
        {
            if (this.rating < 10)
            {
                this.rating += 0.5;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} Driving license: {this.drivingLicenseNumber} Rating: {this.rating}";
        }
    }
}
