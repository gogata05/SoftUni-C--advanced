﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed; 
            ArmorThickness  = armorThickness;
            targets = new List<string>();
        }

        private string name;
        public string Name
        {
            get=> name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }
        private ICaptain captain;
        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                captain = value;
            }
        }

        private double armourThickness;
        public double ArmorThickness
        {
            get => armourThickness;
            set
            {
                if (value < 0)
                {
                    armourThickness = 0;
                }
                else
                {
                    armourThickness = value;
                }
            }
        }

        private double mainWeaponCaliber;
        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set => mainWeaponCaliber = value;
        }

        private double speed;
        public double Speed { get; protected set; }

        private List<string> targets;
        public ICollection<string> Targets => targets.AsReadOnly();
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= mainWeaponCaliber;
            targets.Add(target.Name);
        }

        public virtual void RepairVessel() {}
        public override string ToString()
        {
            var text = Targets.Any() ? string.Join(", ", targets) : "None";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.Append(" *Targets: " + text);

            return sb.ToString().TrimEnd();
        }
    }
}
