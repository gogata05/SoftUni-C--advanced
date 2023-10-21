namespace BookingApp.Models.Rooms
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Room : IRoom
    {

        protected Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
        }
        private int bedCapacity;
        public int BedCapacity => bedCapacity;

        private double pricePerNight = 0;
        public double PricePerNight
        {
            get => this.pricePerNight;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PricePerNightNegative));
                }
                pricePerNight = value;
            }
        }
        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
