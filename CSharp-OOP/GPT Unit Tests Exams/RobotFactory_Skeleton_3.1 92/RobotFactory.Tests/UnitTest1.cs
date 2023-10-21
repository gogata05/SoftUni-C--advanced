using NUnit.Framework;
using RobotFactory;
using System.Linq;

namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("TestFactory", 5);
        }

        [Test]
        public void ProduceRobot_ShouldIncreaseCount()
        {
            factory.ProduceRobot("ModelA", 5000, 1);
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobot_ShouldReturnCorrectMessage_WhenFactoryCapacityIsNotExceeded()
        {
            string message = factory.ProduceRobot("ModelA", 5000, 1);
            Assert.IsTrue(message.Contains("Produced -->"));
        }

        [Test]
        public void ProduceRobot_ShouldReturnCorrectMessage_WhenFactoryCapacityIsExceeded()
        {
            factory = new Factory("TestFactory", 1);
            factory.ProduceRobot("ModelA", 5000, 1);
            string message = factory.ProduceRobot("ModelB", 6000, 1);
            Assert.AreEqual("The factory is unable to produce more robots for this production day!", message);
        }

        [Test]
        public void ProduceSupplement_ShouldIncreaseCount()
        {
            factory.ProduceSupplement("SupplementA", 1);
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeRobot_ShouldAddSupplement_WhenConditionsAreMet()
        {
            Robot robot = new Robot("ModelA", 5000, 1);
            Supplement supplement = new Supplement("SupplementA", 1);
            factory.Robots.Add(robot);
            factory.Supplements.Add(supplement);

            bool result = factory.UpgradeRobot(robot, supplement);
            Assert.IsTrue(result);
            Assert.AreEqual(supplement, robot.Supplements[0]);
        }

        [Test]
        public void UpgradeRobot_ShouldNotAddSupplement_WhenInterfaceStandardsDontMatch()
        {
            Robot robot = new Robot("ModelA", 5000, 1);
            Supplement supplement = new Supplement("SupplementA", 2);
            factory.Robots.Add(robot);
            factory.Supplements.Add(supplement);

            bool result = factory.UpgradeRobot(robot, supplement);
            Assert.IsFalse(result);
        }

        [Test]
        public void UpgradeRobot_ShouldNotAddSupplement_WhenAlreadyAdded()
        {
            Robot robot = new Robot("ModelA", 5000, 1);
            Supplement supplement = new Supplement("SupplementA", 1);
            robot.Supplements.Add(supplement);
            factory.Robots.Add(robot);
            factory.Supplements.Add(supplement);

            bool result = factory.UpgradeRobot(robot, supplement);
            Assert.IsFalse(result);
        }

        [Test]
        public void SellRobot_ShouldReturnRobotWithHighestPriceUnderLimit()
        {
            Robot robot1 = new Robot("ModelA", 5000, 1);
            Robot robot2 = new Robot("ModelB", 4000, 1);
            Robot robot3 = new Robot("ModelC", 6000, 1);
            factory.Robots.Add(robot1);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Robot result = factory.SellRobot(5500);
            Assert.AreEqual(robot1, result);
        }

        [Test]
        public void SellRobot_ShouldReturnNull_WhenNoRobotCanBeSold()
        {
            Robot robot1 = new Robot("ModelA", 5000, 1);
            Robot robot2 = new Robot("ModelB", 4000, 1);
            Robot robot3 = new Robot("ModelC", 6000, 1);
            factory.Robots.Add(robot1);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Robot result = factory.SellRobot(3500);
            Assert.IsNull(result);
        }
    }
}
