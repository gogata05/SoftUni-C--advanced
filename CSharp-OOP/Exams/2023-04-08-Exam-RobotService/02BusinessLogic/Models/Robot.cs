using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {

            Model = model;
            BatteryCapacity = batteryCapacity;
            this.batteryLevel = batteryCapacity;
            this.convertionCapacityIndex = convertionCapacityIndex;
            this.interfaceStandards = new List<int>();
        }

        private string model;
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNullOrWhitespace));
                }
                model = value;
            }
        }

        private int batteryCapacity;
        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BatteryCapacityBelowZero));
                }
                batteryCapacity = value;
            }
        }

        private int batteryLevel;
        public int BatteryLevel => this.batteryLevel;

        private int convertionCapacityIndex;
        public int ConvertionCapacityIndex => this.convertionCapacityIndex;

        private List<int> interfaceStandards;
        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandards;

        public virtual void Eating(int minutes)
        {
            int totalCapacity = convertionCapacityIndex * minutes;

            if (totalCapacity > BatteryCapacity - BatteryLevel)
            {
                batteryLevel = batteryCapacity;
            }
            else
            {
                batteryLevel += totalCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (consumedEnergy <= this.batteryLevel)
            {
                this.batteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.batteryLevel -= supplement.BatteryUsage;
            this.interfaceStandards.Add(supplement.InterfaceStandard);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {this.Model}:");
            sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {this.BatteryLevel}");
            sb.Append($"--Supplements installed: ");

            if (this.InterfaceStandards.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                sb.Append(string.Join(" ", this.InterfaceStandards));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
