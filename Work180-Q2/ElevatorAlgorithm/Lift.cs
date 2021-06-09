using System.Collections.Generic;


namespace ElevatorAlgorithm
{
    /// <summary>
    /// 
    /// </summary>
    public class Lift
    {
        public Lift()
        {
            Passengers = new List<Passenger>();
            WaitingPassengers = new List<Passenger>();
        }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentLevel { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int DestinationLevel { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public Direction Direction
        {
            get
            {
                return CurrentLevel == 1
                    ? Direction.GoingUp
                    : DestinationLevel > CurrentLevel ? Direction.GoingUp : Direction.GoingDown;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Passenger> Passengers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Passenger> WaitingPassengers { get; set; }

    }
}
