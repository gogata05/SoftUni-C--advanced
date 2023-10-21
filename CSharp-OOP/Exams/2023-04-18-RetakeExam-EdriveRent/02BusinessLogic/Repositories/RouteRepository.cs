namespace EDriveRent.Repositories
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> models;
        public RouteRepository()
        {
            this.models = new List<IRoute>();
        }
        
        public IReadOnlyCollection<IRoute> GetAll() => this.models;

        public void AddModel(IRoute route)
        {
            this.models.Add(route);
        }
        public IRoute FindById(string identifier) => this.models.FirstOrDefault(u => u.RouteId == int.Parse(identifier));
        public bool RemoveById(string identifier) => this.models.Remove(this.FindById(identifier));
    }
}
