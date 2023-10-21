using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;
        public RobotRepository()
        {
            this.robots = new List<IRobot>();
        }
        public IReadOnlyCollection<IRobot> Models() => this.robots.AsReadOnly();

        public void AddNew(IRobot model)
        {
           this.robots.Add(model);
        }


        public bool RemoveByName(string robotModel) => this.robots.Remove(this.robots.FirstOrDefault(x => x.Model == robotModel));

        public IRobot FindByStandard(int interfaceStandard) 
            => this.robots.FirstOrDefault(x => x.InterfaceStandards.Any(y => y == interfaceStandard));

    }
}
