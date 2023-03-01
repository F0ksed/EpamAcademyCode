namespace ObjectOrientedDesignPrinciplesTask.Commands
{
    internal class AveragePriceBrandCommand: ICommand
    {
        CommandHandler handler;
        string payload;

        public AveragePriceBrandCommand(CommandHandler handler, string payload)
        {
            this.handler = handler;
            this.payload = payload;
        }

        public void Execute() 
        {
            handler.ExecuteAveragePriceBrandCommand(payload);
        }
    }
}
