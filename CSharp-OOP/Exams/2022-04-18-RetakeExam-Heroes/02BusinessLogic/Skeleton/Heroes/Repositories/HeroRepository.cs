using System.Collections.Generic;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models;

        public HeroRepository()
        {
            models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => models.AsReadOnly();
        public void Add(IHero model)
        {
            models.Add(model);
        }

        public bool Remove(IHero model)
        => models.Remove(model);


        public IHero FindByName(string name)
            => models.Find(x => x.Name == name);
    }
}