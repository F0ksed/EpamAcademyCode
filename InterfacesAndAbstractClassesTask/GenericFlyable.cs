namespace InterfacesAndAbstractClassesTask
{
    /// <summary>
    /// Contains implementations of FlyTo and GetFlyTime
    /// to use for IO information to the console.
    /// </summary>
    public abstract class GenericFlyable : IFlyable
    {
        internal Coordinate currentPosition;
        internal double baseFlightSpeed, maxAltitude; 
        protected List<Coordinate> flySchedule = new();

        public GenericFlyable(Coordinate location)
        {
            currentPosition = location;
        }

        public void FlyTo(Coordinate target)
        {
            double timeTaken = 0;
            if (target.Z > maxAltitude) 
            {
                Console.WriteLine("Requested altitude exceeds allowed maximum.");
                target.Z = maxAltitude;
            }

            flySchedule = PrecalculateFlightPath(currentPosition, target);

            Console.WriteLine($"Starting. Current coordinates {flySchedule[0].X: 0.000}, {flySchedule[0].Y: 0.000}, {flySchedule[0].Z: 0.000}. " +
                $"Target {flySchedule[^1].X: 0.000}, {flySchedule[^1].Y: 0.000}, {flySchedule[^1].Z: 0.000}.");

            for (int i = 1; i < flySchedule.Count; i++)
            {
                timeTaken += flySchedule[i].Time;
                Console.WriteLine($"Flying. Current coordinates {flySchedule[i].X: 0.000}, {flySchedule[i].Y: 0.000}, {flySchedule[i].Z: 0.000}, " +
                    $"time in flight {timeTaken: 0.00} hours.");
            }

            Console.WriteLine($"Arrived. Current coordinates {flySchedule[^1].X: 0.000}, {flySchedule[^1].Y: 0.000}, {flySchedule[^1].Z: 0.000}, " +
                $"time in flight {timeTaken: 0.00} hours.");
            currentPosition = new Coordinate(flySchedule[^1].X, flySchedule[^1].Y, flySchedule[^1].Z);
        }

        public void GetFlyTime(Coordinate target)
        {
            double timeRequired = 0;

            if (target.Z > maxAltitude)
            {
                Console.WriteLine("Requested altitude exceeds allowed maximum.");
                target.Z = maxAltitude;
            }

            flySchedule = PrecalculateFlightPath(currentPosition, target);
            for (int i = 0; i < flySchedule.Count; i++) 
            {
                timeRequired += flySchedule[i].Time; 
            }

            Console.WriteLine($"The flight will take {timeRequired: 0.00} hours.");
        }

        /// <summary>
        /// Provides a method to call for calculating trajectory of a flight.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of coordinates with time it will take to reach every one.</returns>
        protected abstract List<Coordinate> PrecalculateFlightPath(Coordinate location, Coordinate target);
    }
}