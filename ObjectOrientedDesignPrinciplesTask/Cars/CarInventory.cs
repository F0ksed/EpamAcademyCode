namespace ObjectOrientedDesignPrinciplesTask.Cars
{
    internal class CarInventory
    {
        private List<CarInventoryEntry> entries = new List<CarInventoryEntry>();

        public List<CarInventoryEntry> GetAll()
        {
            List<CarInventoryEntry> outputValue = new();
            foreach (CarInventoryEntry entry in entries)
            {
                outputValue.Add(new CarInventoryEntry(entry.CarType));
                outputValue[^1].Quantity = entry.Quantity;
                outputValue[^1].CostPerUnit = entry.CostPerUnit;
            }
            return outputValue;
        }

        public void AddNewModel(string brand, string model)
        {
            foreach (var entry in entries)
            {
                if (brand == entry.CarType.Brand && model == entry.CarType.Model)
                {
                    entries.Add(new CarInventoryEntry(entry.CarType));
                    return;
                }
            }
            entries.Add(new CarInventoryEntry(new CarType(brand, model)));
        }

        public void SetQuanitiy(int position, int quantitny)
        {
            if (position >= 0 && position < entries.Count)
            {
                entries[position].Quantity = quantitny;
            }
        }

        public void SetCost(int position, int costPerUnit)
        {
            if (position >= 0 && position < entries.Count)
            {
                entries[position].CostPerUnit = costPerUnit;
            }
        }

        public void AddNewEntry(string brand, string model, int quantity, int costPerUnit)
        {
            AddNewModel(brand, model);
            SetQuanitiy(entries.Count - 1, quantity);
            SetCost(entries.Count - 1, costPerUnit);
        }

    }
}
