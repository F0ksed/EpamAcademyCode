namespace PracticalTask3.CarParts
{
    public class Chassis
    {
        public int Wheels { get; init; } = 0;
        public string Vin { get; init; } = "n/a";
        public int Load { get; init; } = 0;

        public string GetDescription()
        {
            return ("\n" + Wheels + " wheeled chassis, number " +
                Vin + ". Max payload " + Load + "kg.");
        }
    }
}
