namespace ObjectOrientedDesignPrinciplesTask.Commands
{
    internal class AveragePriceCommand: ICommand
    {
        CommandHandler handler;
        string payload;

        public AveragePriceCommand(CommandHandler handler, string payload)
        {
            this.handler = handler;
            this.payload = payload;
        }

        public void Execute() 
        {
            handler.ExecuteAveragePriceCommand(payload);
        }
    }
}
