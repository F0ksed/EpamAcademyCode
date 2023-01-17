namespace PracticalTask3.CarParts
{
    public class Engine
    {
        public int Power { get; init; } = 0;
        public int Volume { get; init; } = 0;
        public string Type { get; init; } = "n/a";
        public string Serial { get; init; } = "n/a";

        public string GetDescription()
        {
            return ("\n" + Power + " hp " + Volume + " cc " + Type +
                " engine. Serial number " + Serial + ".");
        }
    }
}
