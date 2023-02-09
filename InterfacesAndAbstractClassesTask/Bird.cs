namespace InterfacesAndAbstractClassesTask
{
    /// <summary>
    /// The bird flies the entire distance at a constant speed in the range of 0-20 km/h (set randomly).
    /// It also cannot fly at the altitudes above 10 km or below 50m.
    /// In case starting point ais set below the minimum altitude
    /// the bird focuses on reaching the minimum altitude first and initiates the flight after.
    /// For final point similar logic applies in reverse.
    /// </summary>
    public class Bird : GenericFlyable
    {
        double minAltitude = 0.05;

        public Bird(Coordinate location) : base(location)
        {
            var random = new Random();
            maxAltitude = 10;
            baseFlightSpeed = random.Next(1, 21);
            Console.WriteLine($"Bird speed is set at {baseFlightSpeed} km/h.");
            currentPosition = location;
            currentPosition.Z = (currentPosition.Z > maxAltitude) ? maxAltitude : currentPosition.Z;
            currentPosition.Z = (currentPosition.Z < minAltitude) ? 0 : currentPosition.Z;
        }

        protected override List<Coordinate> PrecalculateFlightPath(Coordinate location, Coordinate target)
        {
            List<Coordinate> points = new() { new Coordinate(location.X, location.Y, location.Z, 0) }; 

            if (location.Z < minAltitude) 
            { 
                points.AddRange(ChangeAltitude(location, minAltitude));  
            }
            if (target.Z >= minAltitude)
            {
                points.AddRange(Cruise(points[^1], target));
                return points;
            }
            
            points.AddRange(ChangeAltitude(points[^1], 0));
            return points;
        }

        /// <summary>
        /// Provides trajectory calculation.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of coordinates with time it will take to reach every one.</returns>
        protected List<Coordinate> Cruise(Coordinate location, Coordinate target)
        {
            List<Coordinate> points = new(); 
            var speedVectors = new double[3];
            double timePassed = 0;
            var distance = Math.Sqrt(Math.Pow((target.X - location.X), 2) +
                                        Math.Pow((target.Y - location.Y), 2) +
                                        Math.Pow((target.Z - location.Z), 2));
            double timeRequired = distance / baseFlightSpeed;

            speedVectors[0] = (target.X - location.X) / timeRequired; 
            speedVectors[1] = (target.Y - location.Y) / timeRequired; 
            speedVectors[2] = (target.Z - location.Z) / timeRequired;

            while (timePassed + 1 <= timeRequired)
            {
                location.X += speedVectors[0]; 
                location.Y += speedVectors[1]; 
                location.Z += speedVectors[2];
                points.Add(new Coordinate(location.X, location.Y, location.Z, 1));
                timePassed++;
            }

            points.Add(new Coordinate(target.X, target.Y, target.Z, timeRequired - timePassed));
            return points;
        }

        /// <summary>
        /// Provides logic for movement in Z coordinate.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of xyz coordinates.</returns>
        protected List<Coordinate> ChangeAltitude(Coordinate location, double targetHeight)
        {
            List<Coordinate> points;
            points = Cruise(location, new Coordinate(location.X, location.Y, targetHeight));
            return points;
        }
    }
}
