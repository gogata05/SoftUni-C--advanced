namespace RobotService.Models
{
    using RobotService.Models.Contracts;
    public abstract class Supplement : ISupplement
    {
        public Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        private int interfaceStandard;
        public int InterfaceStandard
        {
            get => interfaceStandard;
            private set => interfaceStandard = value;
        }

        private int batteryUsage;
        public int BatteryUsage
        {
            get => batteryUsage;
            private set => batteryUsage = value;
        }
    }
}
