using NUnit.Framework;
using System;
using PlanetWars;

namespace PlanetWars.Tests
{
    [TestFixture]
    public class PlanetWarsTests
    {
        private Planet planet;
        private Weapon weapon;

        [SetUp]
        public void Setup()
        {
            planet = new Planet("Earth", 10000.00);
            weapon = new Weapon("Gun", 100.00, 5);
        }

        [Test]
        public void ConstructorShouldInitializePlanetCorrectly()
        {
            Assert.AreEqual("Earth", planet.Name);
            Assert.AreEqual(10000.00, planet.Budget);
        }

        [Test]
        public void ProfitShouldIncreasePlanetBudgetCorrectly()
        {
            planet.Profit(1000.00);
            Assert.AreEqual(11000.00, planet.Budget);
        }

        [Test]
        public void SpendFundsShouldDecreasePlanetBudgetCorrectly()
        {
            planet.SpendFunds(1000.00);
            Assert.AreEqual(9000.00, planet.Budget);
        }

        [Test]
        public void SpendFundsShouldThrowInvalidOperationExceptionWhenFundsAreInsufficient()
        {
            Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(11000.00));
        }

        [Test]
        public void AddWeaponShouldIncreasePlanetWeaponsCorrectly()
        {
            planet.AddWeapon(weapon);
            Assert.AreEqual(1, planet.Weapons.Count);
        }

        [Test]
        public void AddWeaponShouldThrowInvalidOperationExceptionWhenWeaponAlreadyExists()
        {
            planet.AddWeapon(weapon);
            Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
        }

        [Test]
        public void RemoveWeaponShouldDecreasePlanetWeaponsCorrectly()
        {
            planet.AddWeapon(weapon);
            planet.RemoveWeapon(weapon.Name);
            Assert.AreEqual(0, planet.Weapons.Count);
        }

        [Test]
        public void UpgradeWeaponShouldIncreaseWeaponDestructionLevelCorrectly()
        {
            planet.AddWeapon(weapon);
            planet.UpgradeWeapon(weapon.Name);
            Assert.AreEqual(6, weapon.DestructionLevel);
        }

        [Test]
        public void UpgradeWeaponShouldThrowInvalidOperationExceptionWhenWeaponDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("NonExistentWeapon"));
        }

        [Test]
        public void DestructOpponentShouldThrowInvalidOperationExceptionWhenOpponentIsStronger()
        {
            var opponent = new Planet("Mars", 10000.00);
            opponent.AddWeapon(new Weapon("SuperWeapon", 1000.00, 20));

            Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
        }

        [Test]
        public void DestructOpponentShouldReturnCorrectMessageWhenOpponentIsWeaker()
        {
            var opponent = new Planet("Mars", 1000.00);
            planet.AddWeapon(weapon);

            var result = planet.DestructOpponent(opponent);
            Assert.AreEqual("Mars is destructed!", result);
        }
        [Test]
        public void NameShouldThrowArgumentExceptionWhenNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Planet("", 1000.00));
            Assert.Throws<ArgumentException>(() => new Planet(null, 1000.00));
        }

        [Test]
        public void BudgetShouldThrowArgumentExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(() => new Planet("Earth", -1000.00));
        }

        [Test]
        public void AddWeaponShouldNotThrowWhenWeaponIsNull()
        {
            Assert.DoesNotThrow(() => planet.AddWeapon(null));
            Assert.AreEqual(1, planet.Weapons.Count);
        }

        [Test]
        public void RemoveWeaponShouldNotThrowWhenWeaponDoesNotExist()
        {
            Assert.DoesNotThrow(() => planet.RemoveWeapon("NonExistentWeapon"));
        }

        [Test]
        public void MilitaryPowerRatioShouldCalculateCorrectly()
        {
            planet.AddWeapon(new Weapon("Gun", 100.00, 5));
            planet.AddWeapon(new Weapon("Bomb", 200.00, 10));

            Assert.AreEqual(15, planet.MilitaryPowerRatio);
        }
        [Test]
        public void SpendFundsShouldThrowInvalidOperationExceptionWithCorrectMessageWhenFundsAreInsufficient()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(11000.00));
            Assert.That(ex.Message, Is.EqualTo("Not enough funds to finalize the deal."));
        }

        [Test]
        public void AddWeaponShouldThrowInvalidOperationExceptionWithCorrectMessageWhenWeaponAlreadyExists()
        {
            planet.AddWeapon(weapon);
            var ex = Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon));
            Assert.That(ex.Message, Is.EqualTo($"There is already a {weapon.Name} weapon."));
        }

        [Test]
        public void UpgradeWeaponShouldThrowInvalidOperationExceptionWithCorrectMessageWhenWeaponDoesNotExist()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("NonExistentWeapon"));
            Assert.That(ex.Message, Is.EqualTo($"NonExistentWeapon does not exist in the weapon repository of {planet.Name}"));
        }

        [Test]
        public void DestructOpponentShouldThrowInvalidOperationExceptionWithCorrectMessageWhenOpponentIsStronger()
        {
            var opponent = new Planet("Mars", 10000.00);
            opponent.AddWeapon(new Weapon("SuperWeapon", 1000.00, 20));

            var ex = Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(opponent));
            Assert.That(ex.Message, Is.EqualTo($"{opponent.Name} is too strong to declare war to!"));
        }

        [Test]
        public void TestWeaponNuclearProperty()
        {
            Weapon weapon1 = new Weapon("NuclearBomb", 2000.00, 10);
            Assert.IsTrue(weapon1.IsNuclear);
        }

        [Test]
        public void TestWeaponIncreaseDestructionLevel()
        {
            weapon.IncreaseDestructionLevel();
            Assert.AreEqual(6, weapon.DestructionLevel);
        }

        [Test]
        public void TestWeaponPriceExceptionMessage()
        {
            var ex = Assert.Throws<ArgumentException>(() => weapon.Price = -100);
            Assert.That(ex.Message, Is.EqualTo("Price cannot be negative."));
        }
    }
}
