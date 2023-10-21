using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;
        public SupplementRepository()
        {
            this.supplements = new List<ISupplement>();
        }
        public IReadOnlyCollection<ISupplement> Models() => this.supplements.AsReadOnly();

        public void AddNew(ISupplement model) => this.supplements.Add(model);

        public ISupplement FindByStandard(int interfaceStandard) => this.supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);

        public bool RemoveByName(string typeName) => this.supplements.Remove(this.supplements.FirstOrDefault(x => x.GetType().Name == typeName));
    }
}
