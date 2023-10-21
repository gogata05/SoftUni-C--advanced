namespace BookingApp.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Hotels.Contacts;
    using Contracts;

    public class HotelRepository :IRepository<IHotel>
    {
        private List<IHotel> models;

        public HotelRepository()
        {
            this.models = new List<IHotel>();   
        }
        public void AddNew(IHotel model)
        {
            models.Add(model);
        }

        public IHotel Select(string criteria)
            => models.FirstOrDefault(x => x.FullName == criteria);

        public IReadOnlyCollection<IHotel> All()
            => models;
    }
}
