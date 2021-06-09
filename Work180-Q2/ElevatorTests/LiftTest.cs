using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorAlgorithm;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class LifTest
    {
        [TestMethod]
        public void AssertNoPassengers()
        {           
            Lift l = new();
            Assert.IsFalse(l.Passengers.Any());
        }

        [TestMethod]
        public void AssertNoWaitingPassengers()
        {
            Lift l = new();
            Assert.IsFalse(l.WaitingPassengers.Any());
        }

        [TestMethod]
        public void AssertDefaultCurrentLevel()
        {
            int expected = 0;
            Lift l = new();
            Assert.AreEqual(expected, l.CurrentLevel);
        }

        [TestMethod]
        public void AssertDefaultDestinationLevel()
        {
            int expected = 0;
            Lift l = new();
            Assert.AreEqual(expected, l.DestinationLevel);
        }
    }


}
