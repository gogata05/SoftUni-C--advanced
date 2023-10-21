﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        public Captain(string name)
        {
            FullName = name;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }

        private string fullName;
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        private int combatExperience;
        public int CombatExperience 
        {
            get => combatExperience;
            private set => combatExperience = value;
        }
        

        private List<IVessel> vessels;
        public ICollection<IVessel> Vessels => vessels.AsReadOnly();

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if (vessels.Any())
            {
                foreach (IVessel vessel in vessels)
                {
                    sb.AppendLine();
                    sb.Append(vessel.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
