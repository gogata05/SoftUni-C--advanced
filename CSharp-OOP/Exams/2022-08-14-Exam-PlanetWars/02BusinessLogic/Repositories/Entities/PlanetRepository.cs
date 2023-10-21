﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories.Entities
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models;


        public void AddItem(IPlanet model)
        {
            this.models.Add(model);
        }
        public IPlanet FindByName(string name)
            => models.FirstOrDefault(x => x.Name == name);
        public bool RemoveItem(string name)
            => models.Remove(models.FirstOrDefault(x => x.Name == name));
        
    }
}
