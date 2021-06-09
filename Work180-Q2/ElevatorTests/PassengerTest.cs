using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorAlgorithm;

namespace Tests
{
    [TestClass]
    public class PassengerTest
    {
        [TestMethod]
        public void AssertOriginLevel()
        {
            int expected = 0;
            Passenger p = new Passenger(expected, 1);
            Assert.AreEqual(expected, p.OriginLevel);
        }

        [TestMethod]
        public void AssertDestinationLevel()
        {
            int expected = 1;
            Passenger p = new Passenger(0, expected);
            Assert.AreEqual(expected, p.DestinationLevel);
        }

        [TestMethod]
        public void AssertDirectionGoingUp()
        {
            Direction expected = Direction.GoingUp;
            Passenger p = new Passenger(0, 1);           
            Assert.AreEqual(expected, p.Direction);
        }

        [TestMethod]
        public void AssertDirectionGoingDown()
        {
            Direction expected = Direction.GoingDown;
            Passenger p = new Passenger(1, 0);
            Assert.AreEqual(expected, p.Direction);
        }
    }


}
