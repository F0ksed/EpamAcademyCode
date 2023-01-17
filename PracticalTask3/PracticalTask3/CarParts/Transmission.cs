namespace PracticalTask3.CarParts
{
    public class Transmission
    {
        public int Gears { get; init; } = 0;
        public string Type { get; init; } = "n/a";
        public string Manufacturer { get; init; } = "n/a";

        public string GetDescription()
        {
            return ("\n" + Gears + " speed " + Type +
                " transmission, manufactured by " + Manufacturer + ".");
        }
    }
}
