using NUnit.Framework;
using VehicleGarage;
using System.Collections.Generic;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Garage garage;
        private Vehicle vehicle;

        [SetUp]
        public void Setup()
        {
            garage = new Garage(3);
            vehicle = new Vehicle("Brand", "Model", "1234");
        }

        [Test]
        public void VehicleInitializationTest()
        {
            Assert.AreEqual("Brand", vehicle.Brand);
            Assert.AreEqual("Model", vehicle.Model);
            Assert.AreEqual("1234", vehicle.LicensePlateNumber);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void GarageInitializationTest()
        {
            Assert.AreEqual(3, garage.Capacity);
            Assert.IsNotNull(garage.Vehicles);
        }

        [Test]
        public void AddVehicleTest_Success()
        {
            var result = garage.AddVehicle(vehicle);

            Assert.IsTrue(result);
            Assert.AreEqual(1, garage.Vehicles.Count);
            Assert.AreEqual(vehicle, garage.Vehicles[0]);
        }

        [Test]
        public void AddVehicleTest_Failure_CapacityExceeded()
        {
            garage.AddVehicle(new Vehicle("Brand1", "Model1", "1111"));
            garage.AddVehicle(new Vehicle("Brand2", "Model2", "2222"));
            garage.AddVehicle(new Vehicle("Brand3", "Model3", "3333"));

            var result = garage.AddVehicle(vehicle);

            Assert.IsFalse(result);
            Assert.AreEqual(3, garage.Vehicles.Count);
        }

        [Test]
        public void AddVehicleTest_Failure_SameLicensePlate()
        {
            garage.AddVehicle(vehicle);
            var newVehicle = new Vehicle("Brand1", "Model1", "1234");

            var result = garage.AddVehicle(newVehicle);

            Assert.IsFalse(result);
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void ChargeVehiclesTest()
        {
            var vehicle2 = new Vehicle("Brand1", "Model1", "1111") { BatteryLevel = 50 };
            var vehicle3 = new Vehicle("Brand2", "Model2", "2222") { BatteryLevel = 80 };

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);

            var vehiclesCharged = garage.ChargeVehicles(80);

            Assert.AreEqual(2, vehiclesCharged);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
            Assert.AreEqual(100, vehicle3.BatteryLevel);
        }

        [Test]
        public void DriveVehicleTest_NoAccident()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("1234", 20, false);

            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.IsFalse(vehicle.IsDamaged);
        }

        [Test]
        public void DriveVehicleTest_Accident()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("1234", 20, true);

            Assert.AreEqual(80, vehicle.BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void RepairVehiclesTest()
        {
            var vehicle2 = new Vehicle("Brand1", "Model1", "1111") { IsDamaged = true };
            var vehicle3 = new Vehicle("Brand2", "Model2", "2222") { IsDamaged = true };

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);

            var result = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 2", result);
            Assert.IsFalse(vehicle2.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);
        }
    }
}
