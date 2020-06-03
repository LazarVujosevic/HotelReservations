using HotelReservations;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RequestOutsiderangeTest()
        {
            HotelBusiness hb = new HotelBusiness();
            hb.InsertRooms(1);
            Assert.AreEqual(hb.BookRoom((-4, 2)), false);
            Assert.AreEqual(hb.BookRoom((200, 400)), false);
        }

        [Test]
        public void RequestsAreAcceptedTest()
        {
            HotelBusiness hb = new HotelBusiness();
            hb.InsertRooms(3);
            Assert.AreEqual(hb.BookRoom((0, 5)), true);
            Assert.AreEqual(hb.BookRoom((7, 13)), true);
            Assert.AreEqual(hb.BookRoom((3, 9)), true);
            Assert.AreEqual(hb.BookRoom((5, 7)), true);
            Assert.AreEqual(hb.BookRoom((6, 6)), true);
            Assert.AreEqual(hb.BookRoom((0, 4)), true);
        }

        [Test]
        public void RequestsAreDeclinedTest()
        {
            HotelBusiness hb = new HotelBusiness();
            hb.InsertRooms(3);
            Assert.AreEqual(hb.BookRoom((1, 3)), true);
            Assert.AreEqual(hb.BookRoom((2, 5)), true);
            Assert.AreEqual(hb.BookRoom((1, 9)), true);
            Assert.AreEqual(hb.BookRoom((0, 15)), false);
        }

        [Test]
        public void RequestsCanBeAcceptedAfterDeclineTest()
        {
            HotelBusiness hb = new HotelBusiness();
            hb.InsertRooms(3);
            Assert.AreEqual(hb.BookRoom((1, 3)), true);
            Assert.AreEqual(hb.BookRoom((0, 15)), true);
            Assert.AreEqual(hb.BookRoom((1, 9)), true);
            Assert.AreEqual(hb.BookRoom((2, 5)), false);
            Assert.AreEqual(hb.BookRoom((4, 9)), true);
        }

        [Test]
        public void ComplexRequestTest()
        {
            HotelBusiness hb = new HotelBusiness();
            hb.InsertRooms(2);
            Assert.AreEqual(hb.BookRoom((1, 3)), true);
            Assert.AreEqual(hb.BookRoom((0, 4)), true);
            Assert.AreEqual(hb.BookRoom((2, 3)), false);
            Assert.AreEqual(hb.BookRoom((5, 5)), true);
            Assert.AreEqual(hb.BookRoom((4, 10)), true);
            Assert.AreEqual(hb.BookRoom((10, 10)), true);
            Assert.AreEqual(hb.BookRoom((6, 7)), true);
            Assert.AreEqual(hb.BookRoom((8, 10)), false);
            Assert.AreEqual(hb.BookRoom((8, 9)), true);
        }
    }
}