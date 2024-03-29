﻿namespace InterfacesAndAbstractClassesTask
{
    ///<summary>
    ///The drone hovers in the air every 10 minutes of flight for 1 minute.
    ///The drone is incapable of flying at a distance of more than 1000 km.
    ///The drone is incapable of flying at altitude above 10 km.
    ///</summary>
    internal class Drone : GenericFlyable
    {
        double maxRange = 1000;
        double flyTimeBeforeHover;
        double hoverTime; //How long the drone will hover every step

        public Drone(Coordinate location) : base(location)
        {
            maxAltitude = 10;
            flyTimeBeforeHover = 10.0 / 60.0;
            hoverTime = 1.0 / 60.0;
            baseFlightSpeed = 70;
            currentPosition = location;
            currentPosition.Z = (currentPosition.Z > maxAltitude) ? maxAltitude : currentPosition.Z;
        }


        protected override List<Coordinate> PrecalculateFlightPath(Coordinate location, Coordinate target)
        {
            List<Coordinate> points = new();
            double timeRequired;
            double timePassed = 0;
            var speedVectors = new double[3];
            var distance = Math.Sqrt(Math.Pow((target.X - location.X), 2) +
                                        Math.Pow((target.Y - location.Y), 2) +
                                        Math.Pow((target.Z - location.Z), 2));

            if (distance > maxRange)
            {
                Console.WriteLine("Set target is outside maximum flying distance.");

                //basically same vector length calculation
                //where calculated distance is reduced by the fraction of (maxRange / distance)
                target.X = (target.X>= location.X) ? 
                    location.X + (Math.Sqrt(Math.Pow(maxRange, 2) -
                    Math.Pow((target.Y - location.Y) * (maxRange / distance), 2) -
                    Math.Pow((target.Z - location.Z) * (maxRange / distance), 2))) :
                    location.X - (Math.Sqrt(Math.Pow(maxRange, 2) -
                    Math.Pow((target.Y - location.Y) * (maxRange / distance), 2) -
                    Math.Pow((target.Z - location.Z) * (maxRange / distance), 2)));

                target.Y = (target.Y >= location.Y) ? 
                    location.Y + (Math.Sqrt(Math.Pow(maxRange, 2) -
                    Math.Pow((target.X - location.X), 2) -
                    Math.Pow((target.Z - location.Z) * (maxRange / distance), 2))) :
                    location.Y - (Math.Sqrt(Math.Pow(maxRange, 2) -
                    Math.Pow((target.X - location.X), 2) -
                    Math.Pow((target.Z - location.Z) * (maxRange / distance), 2)));

                target.Z = (target.Z >= location.Z) ?
                    location.Z + (Math.Sqrt(Math.Pow(maxRange, 2) -
                    Math.Pow((target.X - location.X), 2) -
                    Math.Pow((target.Y - location.Y), 2))) :
                    location.Z - (Math.Sqrt(Math.Pow(maxRange, 2) -
                    Math.Pow((target.X - location.X), 2) -
                    Math.Pow((target.Y - location.Y), 2)));

                distance = maxRange;
            }

            timeRequired = distance / baseFlightSpeed;
            speedVectors[0] = (target.X - location.X) / timeRequired;
            speedVectors[1] = (target.Y - location.Y) / timeRequired;
            speedVectors[2] = (target.Z - location.Z) / timeRequired;
            points.Add(new Coordinate(location.X, location.Y, location.Z, timePassed));
            for (double i = 0; i <= timeRequired; i += flyTimeBeforeHover)
            {
                timePassed += flyTimeBeforeHover + hoverTime;
                if (timePassed >= 1)
                {
                    points.Add(new Coordinate (location.X + (speedVectors[0] * i), 
                        location.Y + (speedVectors[1] * i),
                        location.Z + (speedVectors[2] * i), timePassed));
                    timePassed -= 1;
                }
            }

            points.Add(new Coordinate(target.X, target.Y, target.Z, timePassed));
            return points;
        }
    }
}
