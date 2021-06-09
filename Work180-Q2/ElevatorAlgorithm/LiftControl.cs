using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevatorAlgorithm
{
    public class LiftControl
    {
        public List<Passenger> WaitingPassengers { get; set; }

        public Lift Lift = new();

        public LiftControl()
        {
            WaitingPassengers = new List<Passenger>();
        }

        /// <summary>
        /// Returns true if any passengers were disembarked.
        /// </summary>
        /// <returns></returns>
        public bool DisembarkPassengers(int level)
        {
            bool anyDisEmbarkedPassengers = false;

            // Find passengers who are going to the specified level.
            var disembarkingPassengers = Lift.Passengers.Where(p => p.DestinationLevel == level).ToList();
            if (disembarkingPassengers.Any())
            {
                // Remove from the current passenger list the ones who is disembarking.
                Lift.Passengers = Lift.Passengers.Where(p => p.DestinationLevel != level).ToList();
                anyDisEmbarkedPassengers = true;
            }

            return anyDisEmbarkedPassengers;
        }

        /// <summary>
        /// Returns true if any passengers embarked in the lift.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool EmbarkPassengers(int level)
        {
            bool anyEmbarkingPassengers = false;
          
            // Find passengers that are embarking in the specified level.
            var embarkingPassengers = WaitingPassengers.Where(p => p.OriginLevel == level);
            if (embarkingPassengers.Any())
            {
                anyEmbarkingPassengers = true;

                // Let passengers enter lift
                Lift.Passengers.AddRange(embarkingPassengers);

                // Fewer passengers now left waiting
                WaitingPassengers = WaitingPassengers.Where(p => p.OriginLevel != level).ToList();
            }           

            return anyEmbarkingPassengers;
        }

        /// <summary>
        /// Embarks and disembarks passengers into and out of the lift.
        /// </summary>
        /// <param name="level"></param>
        private void Stop(int level)
        {
            EmbarkPassengers(level);
            DisembarkPassengers(level);
        }

        /// <summary>
        /// Returns the destination level which has the shortest stops from the specified level.
        /// </summary>
        /// <returns></returns>
        public int CalculateOptimalStopLevel(int level)
        {
            int stopLevel = level;

            // 1. If there are passengers in the lift, what is closest level to disembark?
            if (Lift.Passengers.Any())
            {
                int closestDisembarkingLevel =
                    Lift.Passengers.OrderBy(p => Math.Abs(p.DestinationLevel - level))
                        .First()
                        .DestinationLevel;
                stopLevel = closestDisembarkingLevel;               
            }

            // 2. If there are waiting passengers, what is closest level to embark?
            if (WaitingPassengers.Any())
            {
                int closestEmbarkingLevel = WaitingPassengers.GroupBy(p => new { p.OriginLevel }).OrderByDescending(g => g.Count()).First().Key.OriginLevel;

                stopLevel = (closestEmbarkingLevel > stopLevel) ? closestEmbarkingLevel : stopLevel;
            }          
            

            return stopLevel;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Travel()
        {
            // 1. Stop to embark/disembark on this current level.
            Stop(Lift.CurrentLevel);

            // 2. Determine the next optimal stop to embark/disembark.
            int destinationLevel = CalculateOptimalStopLevel(Lift.CurrentLevel);           
            Lift.CurrentLevel = destinationLevel;
        }

        /// <summary>
        /// Returns the number of stops for the travel.
        /// </summary>
        /// <returns></returns>
        public int StartTravel()
        {
            var stopCount = 0;
            while (AnyWaitingPassengers() || Lift.Passengers.Any())
            {
                Travel();
                stopCount++;
            }

            return stopCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="destination"></param>
        public void UpdateStatus(int current, int destination)
        {
            Lift.CurrentLevel = current;
            Lift.DestinationLevel = destination;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originLevel"></param>
        /// <param name="destinationLevel"></param>
        public void AddPassengerToPickup(int originLevel, int destinationLevel)
        {
            WaitingPassengers.Add(new Passenger(originLevel, destinationLevel));
        }

        /// <summary>
        /// Returns true if there any waiting passengers.
        /// </summary>
        /// <returns></returns>
        public bool AnyWaitingPassengers()
        {
            return WaitingPassengers.Any();
        }
    }
}
