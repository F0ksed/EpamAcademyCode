namespace PracticalTask4
{
    /// <summary>
    /// Contains implementations of FlyTo and GetFlyTime
    /// to use for IO information to the console.
    /// </summary>
    public abstract class GenericFlyable : IFlyable
    {
        internal Coordinate currentPosition;
        internal double flightSpeed, maxAltitude; 
        protected List<Coordinate> flySchedule = new();

        public GenericFlyable(Coordinate location)
        {
            currentPosition = location;
        }

        public void FlyTo(Coordinate target)
        {
            double time = 0;
            if (target.Z > maxAltitude) 
            {
                Console.WriteLine("Requested altitude exceeds allowed maximum.");
                target.Z = maxAltitude;
            }

            flySchedule = PrecalculateFlight(currentPosition, target);

            Console.WriteLine("Starting. Current coordinates {0:0.000}, {1:0.000}, {2:0.000}. " +
                "Target {3:0.000}, {4:0.000}, {5:0.000}.\"",
                  flySchedule[0].X, flySchedule[0].Y, flySchedule[0].Z, 
                  flySchedule[^1].X, flySchedule[^1].Y, flySchedule[^1].Z);

            for (int i = 1; i < flySchedule.Count; i++)
            {
                time += flySchedule[i].Time;
                Console.WriteLine("Flying. Current coordinates {0:0.000}, {1:0.000}, {2:0.000}, " +
                    "time in flight {3:0.00} hours.", 
                    flySchedule[i].X, flySchedule[i].Y, flySchedule[i].Z, time);
            }

            Console.WriteLine("Arrived. Current coordinates {0:0.000}, {1:0.000}, {2:0.000}, " +
                "time in flight {3:0.00} hours.",
                  flySchedule[^1].X, flySchedule[^1].Y, flySchedule[^1].Z, time);
            currentPosition = new Coordinate(flySchedule[^1].X, flySchedule[^1].Y, flySchedule[^1].Z);
        }

        public void GetFlyTime(Coordinate target)
        {
            double time = 0;

            if (target.Z > maxAltitude)
            {
                Console.WriteLine("Requested altitude exceeds allowed maximum.");
                target.Z = maxAltitude;
            }

            flySchedule = PrecalculateFlight(currentPosition, target);
            for (int i = 0; i < flySchedule.Count; i++) 
            { 
                time += flySchedule[i].Time; 
            }

            Console.WriteLine("The flight will take {0:0.00} hours.", time);
        }

        /// <summary>
        /// Provides a method to call for calculating trajectory of a flight.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of coordinates with time it will take to reach every one.</returns>
        protected abstract List<Coordinate> PrecalculateFlight(Coordinate location, Coordinate target);
    }
}