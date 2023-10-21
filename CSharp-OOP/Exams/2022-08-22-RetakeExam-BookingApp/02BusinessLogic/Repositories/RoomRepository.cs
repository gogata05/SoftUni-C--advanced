using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> models;
        public RoomRepository()
        {
            this.models = new List<IRoom>();
        }
        public IReadOnlyCollection<IRoom> All() 
            => models;

        public void AddNew(IRoom model)
        {
            this.models.Add(model);
        }

        public IRoom Select(string criteria)
            => models.FirstOrDefault(x => x.GetType().Name == criteria);

    }
}
