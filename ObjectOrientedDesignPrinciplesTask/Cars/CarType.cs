namespace ObjectOrientedDesignPrinciplesTask.Cars
{
    internal class CarType : ICarType
    {
        private string brand, model;

        public string Brand 
        { 
            get { return brand; }
            init { brand = value.ToLower(); } 
        }
        public string Model
        {
            get { return model; }
            init { model = value.ToLower(); }
        }

        public CarType(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
    }
}
