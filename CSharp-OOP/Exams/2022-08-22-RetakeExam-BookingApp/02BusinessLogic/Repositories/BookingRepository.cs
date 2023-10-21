namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using BookingApp.Repositories.Contracts;
    using BookingApp.Models.Bookings.Contracts;
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> models;
        public BookingRepository()
        {
            this.models = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            models.Add(model);
        }

        public IBooking Select(string criteria)
            => models.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);

        public IReadOnlyCollection<IBooking> All()
            => models;
    }
}
