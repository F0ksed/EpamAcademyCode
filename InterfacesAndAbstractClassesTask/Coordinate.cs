namespace InterfacesAndAbstractClassesTask
{
    /// <summary>
    /// Keeps xyz coordinates of objects and time for trajectory calculations.
    /// Checks if input is positive. Default values are 0;
    /// </summary>
    public struct Coordinate
    {
        private double x = 0;
        private double y = 0;
        private double z = 0;
        private double time = 0;

        public double X
        {
            get { return x; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinates outside of acceptable range.");
                }
                x = value;
            } 
        }
        public double Y
        {
            get { return y; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinates outside of acceptable range.");
                }
                y = value;
            }
        }
        public double Z
        {
            get { return z; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinates outside of acceptable range.");
                }
                z = value;
            }
        }
        public double Time
        {
            get { return time; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative time.");
                }
                time = value;
            }
        }

        public Coordinate(double x, double y, double z) 
        { 
            X = x;
            Y = y;
            Z = z;
        }

        public Coordinate(double x, double y, double z, double time)
        {
            X = x;
            Y = y;
            Z = z;
            Time = time;
        }
    }
}
