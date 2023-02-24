using ObjectOrientedDesignPrinciplesTask.Commands;
using System.Diagnostics;

public class CarConsole
{
    static void Main(string[] args)
    {
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        CommandHandler handler = CommandHandler.Create();
        Invoker invoker = new();

        invoker.SetCommand(new MakeInventoryCommand(handler, args));
        invoker.ExecuteCommand();

        while (true) 
        {
            string input = Console.ReadLine();

            switch (true)
            {
                case true when input.Contains("exit"):
                    {
                        return; //seems like an overkill to make a separate command for that
                    }
                case true when input.Contains("count"):
                    {
                        invoker.SetCommand(new CountCommand(handler, input));
                        invoker.ExecuteCommand();                        
                        break;
                    }
                case true when input.Contains("average price"):
                    {
                        invoker.SetCommand(new AveragePriceCommand(handler, input));
                        invoker.ExecuteCommand();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Command not recognised.");
                        break;
                    }
            }
        }
    }
}