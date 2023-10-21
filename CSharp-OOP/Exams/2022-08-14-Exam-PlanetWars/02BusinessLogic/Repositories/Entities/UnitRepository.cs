using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories.Entities
{
    internal class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;
        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => models;

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }
        
        public IMilitaryUnit FindByName(string name)
            => models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
            => models.Remove(models.FirstOrDefault(x => x.GetType().Name == name));
    }
}
