namespace ObjectOrientedDesignPrinciplesTask.Cars
{
    internal class CarType : ICarType
    {
        public string Brand { get; init; }
        public string Model { get; init; }

        public CarType(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
    }
}
