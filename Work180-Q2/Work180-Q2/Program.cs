using System;
using System.Linq;
using ElevatorAlgorithm;

namespace Work180_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfRequests = 5;
            LiftControl liftControl = new LiftControl();

            var pickupCount = 0;
            var random = new Random();
            while (pickupCount < numberOfRequests)
            {
                var originLevel = random.Next(1, Building.NUMSTORIES + 1);
                var destinationLevel = random.Next(1, Building.NUMSTORIES + 1);
                if (originLevel != destinationLevel)
                {
                    liftControl.AddPassengerToPickup(originLevel, destinationLevel);
                    pickupCount++;
                }
            }

            var stopCount = 0;
            while (liftControl.AnyWaitingPassengers() || liftControl.Lift.Passengers.Any())
            {
                liftControl.Travel();
                stopCount++;
            }

            Console.WriteLine("Transported {0} passengers to their requested destinations in {1} stops.", pickupCount, stopCount);
            Console.ReadLine();
        }
    }
}
