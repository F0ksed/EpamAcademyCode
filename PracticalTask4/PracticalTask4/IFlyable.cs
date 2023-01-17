namespace PracticalTask4
{
    ///<summary>
    ///Baseline interface for all flying objects.
    ///</summary>
    public interface IFlyable
    {
        /// <summary>
        /// Should be used for moving to the required destination.
        /// </summary>
        /// <param name="target">Requested end point.</param>
        public void FlyTo(Coordinate target);
        /// <summary>
        /// Should be used for caclucating time it would take 
        /// to arrive to the required destination.
        /// </summary>
        /// <param name="target">Requested end point.</param>
        public void GetFlyTime(Coordinate target);
    }
}