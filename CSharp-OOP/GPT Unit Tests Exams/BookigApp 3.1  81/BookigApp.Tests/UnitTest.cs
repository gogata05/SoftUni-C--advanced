using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            this.hotel = new Hotel("Test Hotel", 3);
        }

        [Test]
        public void TestHotelInitialization()
        {
            Assert.AreEqual("Test Hotel", hotel.FullName);
            Assert.AreEqual(3, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);
            Assert.IsEmpty(hotel.Rooms);
            Assert.IsEmpty(hotel.Bookings);
        }

        [Test]
        public void TestAddRoom()
        {
            Room room = new Room(2, 50);
            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
            Assert.IsTrue(hotel.Rooms.Contains(room));
        }

        [Test]
        public void TestBookRoomWithInvalidAdults()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 1, 100));
        }

        [Test]
        public void TestBookRoomWithInvalidChildren()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 1, 100));
        }

        [Test]
        public void TestBookRoomWithInvalidResidenceDuration()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 1, 0, 100));
        }

        [Test]
        public void TestBookRoomWithoutEnoughBeds()
        {
            hotel.AddRoom(new Room(2, 50));
            hotel.BookRoom(3, 0, 1, 100);

            Assert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void TestBookRoomWithoutEnoughBudget()
        {
            hotel.AddRoom(new Room(2, 100));
            hotel.BookRoom(1, 0, 1, 50);

            Assert.IsEmpty(hotel.Bookings);
            Assert.AreEqual(0, hotel.Turnover);
        }


        [Test]
        public void TestBookRoomSuccessfully()
        {
            hotel.AddRoom(new Room(2, 50));
            hotel.BookRoom(1, 0, 2, 200);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(2 * 50, hotel.Turnover);
        }

        [Test]
        public void TestBookingNumberIncrement()
        {
            hotel.AddRoom(new Room(2, 50));
            hotel.BookRoom(1, 0, 1, 100);
            hotel.BookRoom(1, 0, 1, 100);

            var bookingList = hotel.Bookings.ToList();

            Assert.AreEqual(2, bookingList.Count);
            Assert.AreEqual(1, bookingList[0].BookingNumber);
            Assert.AreEqual(2, bookingList[1].BookingNumber);
        }
    }
}


