﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;

namespace PlanetWars.Repositories.Entities
{
    internal class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;
        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => models;

        
        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }
        
        public IWeapon FindByName(string name)
            => models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name) 
            => models.Remove(models.FirstOrDefault(x => x.GetType().Name == name));
    }
}
