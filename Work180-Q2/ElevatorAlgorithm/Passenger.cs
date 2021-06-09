using System;

namespace ElevatorAlgorithm
{
    /// <summary>
    /// Person riding in and out of a lift.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originLevel"></param>
        /// <param name="destination"></param>
        public Passenger(int originLevel, int destinationLevel)
        {
            OriginLevel = originLevel;
            DestinationLevel = destinationLevel;
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// For queries.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Level where passenger is embarking.
        /// </summary>
        public int OriginLevel { get; private set; }

        /// <summary>
        /// Level where passenger is disembarking.
        /// </summary>
        public int DestinationLevel { get; private set; }

        /// <summary>
        /// Direction of where passenger is going.
        /// </summary>
        public Direction Direction
        {
            get { return OriginLevel < DestinationLevel ? Direction.GoingUp : Direction.GoingDown; }
        }
    }   
}
