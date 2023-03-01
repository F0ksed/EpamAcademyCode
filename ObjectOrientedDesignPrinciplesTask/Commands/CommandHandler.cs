using ObjectOrientedDesignPrinciplesTask.Cars;
using System.Diagnostics;

namespace ObjectOrientedDesignPrinciplesTask.Commands
{
    internal class CommandHandler
    {
        private static CommandHandler singletonRef;
        CarInventory carInventory;

        private CommandHandler() {}

        public static CommandHandler Create()
        {
            if (singletonRef == null)
            {
                singletonRef = new CommandHandler();
            }
            return singletonRef; 
        }
        
        public void MakeInventory(string[] input)
        {
            carInventory = new();

            try
            {
                for (int i = 0; i < input.Length; i += 4)
                {
                    carInventory.AddNewEntry(input[i], input[i + 1], int.Parse(input[i + 2]), int.Parse(input[i + 3]));
                }
            }
            catch (Exception e) when (e is IndexOutOfRangeException ||
                                      e is FormatException)
            {
                Trace.WriteLine(e);
                carInventory = new(); //reset inventory so it won't remain half-filled with possibly incorrect input
                return;
            }

            Console.WriteLine("List formed successfully, input your command.");
        }

        public void ExecuteCountCommand(string input)
        {
            object output;

            switch (input) 
            {
                case "count types":
                    {
                        output = (from entry in carInventory.GetAll() 
                                    group entry by entry.CarType.Brand).Count();
                        break;
                    }
                case "count all":
                    {
                        output = (from entry in carInventory.GetAll() 
                                    select +entry.Quantity).Sum();
                        break;
                    }
                    default: 
                    {
                        output = "Command not recognised.";
                        break;
                    }
            }

            Console.WriteLine(output);
        }

        public void ExecuteAveragePriceBrandCommand(string input)
        {
            int priceSum = (from entry in carInventory.GetAll() select entry.CostPerUnit).Sum();
            int brandCount = (from entry in carInventory.GetAll() select entry).Count();

            if (input is not "average price")
            {
                input = input.Replace("average price ", "");
                foreach (var entry in carInventory.GetAll()) 
                {
                    if (entry.CarType.Brand != input)
                    {
                        priceSum -= entry.CostPerUnit;
                        brandCount -= 1;
                    }
                }
            }
            if (brandCount >0) 
            {
                Console.WriteLine(priceSum/brandCount);
                return;
            }

            Console.WriteLine("No entries found for the requested value.");

        }
    }
}
