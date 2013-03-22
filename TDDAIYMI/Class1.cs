using NUnit.Framework;

namespace TDDAIYMI
{
    public interface ICanDisplayRoomPrices
    {
        void DisplayPrice(int price);
    }

    [TestFixture]
    public class Class1 : ICanDisplayRoomPrices
    {
        private static int _expected;

        [Test]
        public void TestPriceIsDisplayed()
        {
            const int priceOfRoom = 79;
            DisplayPrice(priceOfRoom);
            Assert.That(_expected, Is.EqualTo(priceOfRoom));
        }

        [Test]
        public void BookADoubleRoomPriceDisplayedIs60()
        {
            var rate = new RoomRate(60).Price();
            var room = new Room(rate);
            int priceOfRoom = room.Price();
            var display = this;
            new Hotel(display).Book(room);
            Assert.That(_expected, Is.EqualTo(priceOfRoom));
        }

        public void DisplayPrice(int price)
        {
            _expected = price;
        }
    }

    public class RoomRate
    {
        private readonly int _price;

        public RoomRate(int price)
        {
            _price = price;
        }

        public int Price()
        {
            return _price;
        }
    }

    public class Room
    {
        private readonly int _price;

        public Room(int price)
        {
            _price = price;
        }

        public int Price()
        {
            return _price;
        }
    }

    public class Hotel
    {
        private readonly ICanDisplayRoomPrices _canDisplayRoomPrices;

        public Hotel(ICanDisplayRoomPrices canDisplayRoomPrices)
        {
            _canDisplayRoomPrices = canDisplayRoomPrices;
        }

        public void Book(Room room)
        {
            _canDisplayRoomPrices.DisplayPrice(room.Price());
        }
    }
}