namespace PracticalTask4
{
    /// <summary>
    /// Aircraft increases speed by 10 km/h every 10 km of flight from an initial speed of 200 km/h.
    /// Similar to the bird, it cannot fly at the altitudes above 14 km or below 200m.
    /// Unlike the bird, altitude can only be changed in the process of moving forward
    /// and no faster than a set value.
    /// </summary>
    public class Plane : GenericFlyable
    {
        double maxFlightSpeed = 700;
        double threshold = 10; //the distance that needs to be passed before speed increases.
        double acceleration = 10; //how much does speed change after the required distance is covered.
        double verticalRate = 5.6 / 0.3; //how much distance is required to be flown to change altitude a certain amount.
        double minAltitude = 0.2;

        public Plane(Coordinate location) : base(location)
        {
            maxAltitude = 14;
            flightSpeed = 200;
            currentPosition = location;
            currentPosition.Z = (currentPosition.Z > maxAltitude) ? maxAltitude : currentPosition.Z;
            currentPosition.Z = (currentPosition.Z < minAltitude) ? 0 : currentPosition.Z;
        }

        protected override List<Coordinate> PrecalculateFlight(Coordinate location, Coordinate target)
        {
            double distance = 0;
            double steps; //How many steps there are in the route. Flight speed grows every step unless max.
            double time = 0;
            double localFlightSpeed = flightSpeed;
            List<Coordinate> points = new();
            List<Coordinate> timePoints = new() { new Coordinate(location.X, location.Y, location.Z, time) };

            points.AddRange(Cruise(location, target));

            while (timePoints[^1].X != target.X || timePoints[^1].Y != target.Y || 
                timePoints[^1].Z != target.Z)
            {
                for (int i = 1; i < points.Count; i++)
                {
                    distance += Math.Sqrt(Math.Pow(points[i].X - points[i - 1].X, 2) +
                                          Math.Pow(points[i].Y - points[i - 1].Y, 2) +
                                          Math.Pow(points[i].Z - points[i - 1].Z, 2));
                    steps = Math.Floor(distance / threshold);

                    for (double d = 1; d <= steps; d++)
                    {
                        distance -= threshold;
                        time += threshold / localFlightSpeed;
                        if (Math.Floor(time) >= 1)
                        {
                            time -= 1;
                            timePoints.Add(new Coordinate (((steps - d) * points[i - 1].X + d * points[i].X) / steps,
                                                           ((steps - d) * points[i - 1].Y + d * points[i].Y) / steps,
                                                           ((steps - d) * points[i - 1].Z + d * points[i].Z) / steps, 1 ));
                        }

                        localFlightSpeed += (localFlightSpeed < maxFlightSpeed) ? acceleration : 0;
                    }

                    timePoints.Add(new Coordinate(points[i].X, points[i].Y, points[i].Z, time));
                    time = 0;
                }
            }

            return timePoints;
        }

        /// <summary>
        /// Provides trajectory calculation.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of xyz coordinates.</returns>
        protected List<Coordinate> Cruise(Coordinate location, Coordinate target)
        {
            List<Coordinate> points = new() { location };

            if (location.Z != target.Z || (location.Z == 0 && target.Z == 0)) //checks if altitude change will be required
            {
                if (target.Z < minAltitude)
                {
                    points.AddRange(ChangeAltitude(points[^1], 
                        new Coordinate(target.X, target.Y, minAltitude)));
                }
                else
                {
                    points.AddRange(ChangeAltitude(points[^1], target));
                }

                points.Add(new Coordinate(target.X, target.Y, points[^1].Z));

                if (target.Z < minAltitude)
                {
                    points.AddRange(ChangeAltitude(points[^1], target));
                }
            }
            else
            {
                points.Add(target);
            }

            return points;
        }

        /// <summary>
        /// Provides logic for movement in Z coordinate.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of xyz coordinates.</returns>
        protected List<Coordinate> ChangeAltitude(Coordinate location, Coordinate target)
        {
            List<Coordinate> points = new();
            var reqDistance = Math.Abs((target.Z - location.Z) * verticalRate); //distance that will need to be flown to change to the required altitude
            var distance = Math.Sqrt(Math.Pow(target.X - location.X, 2) + Math.Pow(target.Y - location.Y, 2));

            //coorditanes that need to be targeted to cover a distance from reqDistance 
            double xAct = (target.X - location.X != 0) ? 
                (target.X * (reqDistance / distance)) :
                (distance == 0) ? (target.X + Math.Sqrt(Math.Pow(reqDistance, 2) / 2)) : 0;
            double yAct = (target.Y - location.Y != 0) ? 
                (target.Y * (reqDistance / distance)) :
                (distance == 0) ? (target.Y + Math.Sqrt(Math.Pow(reqDistance, 2) / 2)) : 0;

            switch (target.Z - location.Z)
            {
                case > 0: //ascent
                    {
                        points.Add(new Coordinate(xAct, yAct, target.Z));
                        break;
                    }
                case < 0: //descent
                    {
                        if (target.Z < minAltitude)
                        {
                            points.Add(new Coordinate (xAct, yAct, location.Z));
                            points.Add(target);
                        }
                        else
                        {
                            points.Add(new Coordinate(xAct, yAct, target.Z));
                        }
                        break;
                    }
            }

            return points;
        }
    }
}
