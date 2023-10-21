namespace EDriveRent.Models
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Utilities.Messages;
    using System;
    public abstract class Vehicle : IVehicle
    {

        protected Vehicle(string brand, string model, double maxMilage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            this.maxMilage = maxMilage;
            LicensePlateNumber = licensePlateNumber;
            this.batteryLevel = 100;
            this.isDamaged = false;
        }
        private string brand;
        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));
                }
                brand = value;
            }
        }
        private string model;
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));
                }
                model = value;
            }
        }
        private string licensePlateNumber;
        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LicenceNumberRequired));
                }
                licensePlateNumber = value;
            }
        }
        private double maxMilage;//Why not sets here?
        public double MaxMileage => this.maxMilage;

        private int batteryLevel;
        public int BatteryLevel => batteryLevel;

        private bool isDamaged;
        public bool IsDamaged => isDamaged;

        public void ChangeStatus()
        {
            if (!IsDamaged)
            {
                this.isDamaged = true;
            }
            else
            {
                this.isDamaged = false;
            }
        }
        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage/this.maxMilage)*100);
            this.batteryLevel -= (int)percentage;
            if (this.GetType().Name == nameof(CargoVan))
            {
                this.batteryLevel -= 5;
            }
        }
        public void Recharge()
        {
            this.batteryLevel = 100;
        }
        public override string ToString()
        {
            string vehicleCondition;
            if (isDamaged)
            {
                vehicleCondition = "damaged";
            }
            else
            {
                vehicleCondition = "OK";
            }
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {vehicleCondition}";
        }
    }
}
