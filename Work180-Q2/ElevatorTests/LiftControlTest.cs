using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorAlgorithm;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class LifControlTest
    {
        [TestMethod]
        public void AssertNoWaitingPassengers()
        {
            LiftControl lc = new();
            Assert.IsFalse(lc.WaitingPassengers.Any());
        }

        /// <summary>
        /// No passengers should be disembarked when there are no passengers in the lift.
        /// </summary>
        [TestMethod]
        public void WhenNoWaitingPassengersExpectDisembarkPassengersReturnsFalse()
        {
            LiftControl lc = new();
            Assert.IsFalse(lc.DisembarkPassengers(0));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void WhenLiftTravelsWithPassengerExpectDisembarkPassengersReturnsTrueOn()
        {
            LiftControl lc = new();
            lc.AddPassengerToPickup(0, 1);
            lc.EmbarkPassengers(0);

            // Mock the lift to have travelled from 0 to 1.
            lc.Lift.CurrentLevel = 1;
            Assert.IsTrue(lc.DisembarkPassengers(0));
        }

        /// EmbarkPasssengers Tests here
        [TestMethod]
        public void WhenNoPassengerIsPickedUpExpectEmbarkPassengersReturnsFalse()
        {
            LiftControl lc = new();
            Assert.IsFalse(lc.EmbarkPassengers(0));
        }

        [TestMethod]
        public void WhenPassengerIsPickedUpExpectEmbarkPassengersReturnsTrue()
        {
            LiftControl lc = new();

            lc.AddPassengerToPickup(0, 1);
            Assert.IsTrue(lc.EmbarkPassengers(0));
        }       

        [TestMethod]
        public void WhenNoPassengerIsPickedUpExpectAnyWaitingPassengersReturnsFalse()
        {
            LiftControl lc = new();           
            Assert.IsFalse(lc.AnyWaitingPassengers());
        }

        [TestMethod]
        public void WhenPassengerIsPickedUpExpectAnyWaitingPassengersReturnsTrue()
        {
            LiftControl lc = new();

            lc.AddPassengerToPickup(0, 1);
            Assert.IsTrue(lc.AnyWaitingPassengers());
        }
    }


}
