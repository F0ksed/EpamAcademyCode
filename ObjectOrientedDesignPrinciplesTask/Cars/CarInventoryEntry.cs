namespace ObjectOrientedDesignPrinciplesTask.Cars
{
    internal class CarInventoryEntry
    {
        private int quantity, costPerUnit;

        public ICarType CarType { get; init; }
        public int Quantity { get; set; }
        public int CostPerUnit { get; set; }

        public CarInventoryEntry(ICarType carType)
        {
            CarType = carType;
        }
    }
}
