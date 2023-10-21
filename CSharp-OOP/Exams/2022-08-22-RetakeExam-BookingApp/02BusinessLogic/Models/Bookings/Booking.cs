using System;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        public Booking(IRoom room, int ResidenceDuration, int adultsCount, int childrenCount, int bookingNumber )
        {
            this.Room = room;
            this.ResidenceDuration = ResidenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }
        public IRoom Room { get; private set; }

        private int residenceDuration;
        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                residenceDuration = value;
            }
        }
        private int adultsCount;
        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }
                adultsCount = value;
            }
        }
        private int childrenCount;
        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                }
                childrenCount = value;
            }
        }

        private int bookingNumber;
        public int BookingNumber => bookingNumber;

        public string BookingSummary()
        {
            var totalPaid = Math.Round(ResidenceDuration * Room.PricePerNight, 2);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {totalPaid:F2} $");
            return sb.ToString().TrimEnd();
        }
    }
}
