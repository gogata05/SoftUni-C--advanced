using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;
namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;
        public UniversityRepository()
        {
            this.models = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models => this.models.AsReadOnly();

        public void AddModel(IUniversity model)
        {
            this.models.Add(model);
        }

        public IUniversity FindById(int id)
            => this.models.FirstOrDefault(x => x.Id == id);

        public IUniversity FindByName(string name)
            => this.models.FirstOrDefault(x => x.Name == name);

        public bool RemoveById(int id)
            => this.models.Remove(this.models.FirstOrDefault(x => x.Id == id));

        public bool RemoveByName(string name)
            => this.models.Remove(this.models.FirstOrDefault(x => x.Name == name));

        public int CountUniversities()
            => this.models.Count();

        public IReadOnlyCollection<IUniversity> GetAllUniversities()
            => this.Models;
    }
}
