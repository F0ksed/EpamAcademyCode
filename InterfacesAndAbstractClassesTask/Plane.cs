namespace InterfacesAndAbstractClassesTask
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
        double distanceToIncreaseSpeed = 10; //the distance that needs to be passed before speed increases.
        double accelerationAmount = 10; //how much does speed change after the required distance is covered.
        double rateOfClimb = 5.6 / 0.3; //how much distance is required to be flown to change altitude a certain amount.
        double minAltitude = 0.2;

        public Plane(Coordinate location) : base(location)
        {
            maxAltitude = 14;
            baseFlightSpeed = 200;
            currentPosition = location;
            currentPosition.Z = (currentPosition.Z > maxAltitude) ? maxAltitude : currentPosition.Z;
            currentPosition.Z = (currentPosition.Z < minAltitude) ? 0 : currentPosition.Z;
        }

        protected override List<Coordinate> PrecalculateFlightPath(Coordinate location, Coordinate target)
        {
            double distance = 0;
            double numberOfSpeedIncreases; //How many steps there are in the route. Flight speed grows every step unless max.
            double timePassed = 0;
            double currentFlightSpeed = baseFlightSpeed;
            List<Coordinate> routePoints = new();
            List<Coordinate> routePointsWithTime = new() { new Coordinate(location.X, location.Y, location.Z, timePassed) };

            routePoints.AddRange(Cruise(location, target));

            while (routePointsWithTime[^1].X != target.X || routePointsWithTime[^1].Y != target.Y ||
                routePointsWithTime[^1].Z != target.Z)
            {
                for (int i = 1; i < routePoints.Count; i++)
                {
                    distance += Math.Sqrt(Math.Pow(routePoints[i].X - routePoints[i - 1].X, 2) +
                                          Math.Pow(routePoints[i].Y - routePoints[i - 1].Y, 2) +
                                          Math.Pow(routePoints[i].Z - routePoints[i - 1].Z, 2));
                    numberOfSpeedIncreases = Math.Floor(distance / distanceToIncreaseSpeed);

                    for (double d = 1; d <= numberOfSpeedIncreases; d++)
                    {
                        distance -= distanceToIncreaseSpeed;
                        timePassed += distanceToIncreaseSpeed / currentFlightSpeed;
                        if (Math.Floor(timePassed) >= 1)
                        {
                            timePassed -= 1;
                            Coordinate currentCoordinate = new();
                            currentCoordinate.X = ((numberOfSpeedIncreases - d) * routePoints[i - 1].X + d * routePoints[i].X) / 
                                numberOfSpeedIncreases;
                            currentCoordinate.Y = ((numberOfSpeedIncreases - d) * routePoints[i - 1].Y + d * routePoints[i].Y) / 
                                numberOfSpeedIncreases;
                            currentCoordinate.Z = ((numberOfSpeedIncreases - d) * routePoints[i - 1].Z + d * routePoints[i].Z) / 
                                numberOfSpeedIncreases;
                            currentCoordinate.Time = 1;
                            routePointsWithTime.Add(currentCoordinate);
                        }

                        currentFlightSpeed += (currentFlightSpeed < maxFlightSpeed) ? accelerationAmount : 0;
                    }

                    routePointsWithTime.Add(new Coordinate(routePoints[i].X, routePoints[i].Y, routePoints[i].Z, timePassed));
                    timePassed = 0;
                }
            }

            return routePointsWithTime;
        }

        /// <summary>
        /// Provides trajectory calculation.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of xyz coordinates.</returns>
        protected List<Coordinate> Cruise(Coordinate location, Coordinate target)
        {
            List<Coordinate> routePoints = new() { location };

            if (location.Z != target.Z || (location.Z == 0 && target.Z == 0)) //checks if altitude change will be required
            {
                if (target.Z < minAltitude)
                {
                    routePoints.AddRange(ChangeAltitude(routePoints[^1], 
                        new Coordinate(target.X, target.Y, minAltitude)));
                }
                else
                {
                    routePoints.AddRange(ChangeAltitude(routePoints[^1], target));
                }

                routePoints.Add(new Coordinate(target.X, target.Y, routePoints[^1].Z));

                if (target.Z < minAltitude)
                {
                    routePoints.AddRange(ChangeAltitude(routePoints[^1], target));
                }
            }
            else
            {
                routePoints.Add(target);
            }

            return routePoints;
        }

        /// <summary>
        /// Provides logic for movement in Z coordinate.
        /// </summary>
        /// <param name="location">Starting point.</param>
        /// <param name="target">Requested end point.</param>
        /// <returns>List of xyz coordinates.</returns>
        protected List<Coordinate> ChangeAltitude(Coordinate location, Coordinate target)
        {
            List<Coordinate> routePoints = new();
            var requiredDistance = Math.Abs((target.Z - location.Z) * rateOfClimb); //distance that will need to be flown to change to the required altitude
            var givenDistance = Math.Sqrt(Math.Pow(target.X - location.X, 2) + Math.Pow(target.Y - location.Y, 2));

            //coorditanes that need to be targeted to cover a distance from requiredDistance 
            double xAfterCorrection = (target.X - location.X != 0) ? 
                (target.X * (requiredDistance / givenDistance)) :
                (givenDistance == 0) ? (target.X + Math.Sqrt(Math.Pow(requiredDistance, 2) / 2)) : 0;
            double yAfterCorrection = (target.Y - location.Y != 0) ? 
                (target.Y * (requiredDistance / givenDistance)) :
                (givenDistance == 0) ? (target.Y + Math.Sqrt(Math.Pow(requiredDistance, 2) / 2)) : 0;

            switch (target.Z - location.Z)
            {
                case > 0: //ascent
                    {
                        routePoints.Add(new Coordinate(xAfterCorrection, yAfterCorrection, target.Z));
                        break;
                    }
                case < 0: //descent
                    {
                        if (target.Z < minAltitude)
                        {
                            routePoints.Add(new Coordinate (xAfterCorrection, yAfterCorrection, location.Z));
                            routePoints.Add(target);
                        }
                        else
                        {
                            routePoints.Add(new Coordinate(xAfterCorrection, yAfterCorrection, target.Z));
                        }
                        break;
                    }
            }

            return routePoints;
        }
    }
}
