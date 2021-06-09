using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElevatorAlgorithm;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class CodeChallengeTest
    {
        /// <summary>
        /// Passenger summons lift on the ground floor. Once in, chooses to go to level 5.
        /// </summary>
        [TestMethod]
        public void TestCase1()
        {
            LiftControl lc = new();        
            
            lc.AddPassengerToPickup(0, 5);

            // Expect 1 stop
            Assert.AreEqual(1, lc.StartTravel());
        }

        /// <summary>
        /// Passenger summons lift on level 6 to go down. A passenger on level 4 summons the lift to go down. They both choose L1.
        /// </summary>
        [TestMethod]
        public void TestCase2()
        {
            LiftControl lc = new();
         
            lc.AddPassengerToPickup(6, 1);
            lc.AddPassengerToPickup(4, 1);

            // Expect 3 stops
            Assert.AreEqual(3, lc.StartTravel());
        }

        /// <summary>
        /// Passenger 1 summons lift to go up from L2. Passenger 2 summons lift to go down from L4.Passenger 1 chooses to go to L6.Passenger 2 chooses to go to Ground Floor
        /// </summary>
        [TestMethod]
        public void TestCase3()
        {
            LiftControl lc = new();           
          
            lc.AddPassengerToPickup(2, 6);
            lc.AddPassengerToPickup(4, 0);

            int expected = 4;
            Assert.AreEqual(expected, lc.StartTravel());
        }

        /// <summary>
        /// Passenger 1 summons lift to go up from Ground. They choose L5. Passenger2 summons lift to go down from L4.Passenger 3 summons lift to go down from
        /// L10.Passengers 2 and 3 choose to travel to Ground.
        /// </summary>
        [TestMethod]
        public void TestCase4()
        {
            LiftControl lc = new();

            lc.AddPassengerToPickup(0, 5);
            lc.AddPassengerToPickup(4, 0);
            lc.AddPassengerToPickup(10, 0);

            int expected = 4;
            Assert.AreEqual(expected, lc.StartTravel());
        }
    }


}
