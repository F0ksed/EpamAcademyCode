namespace ObjectOrientedDesignPrinciplesTask.Commands
{
    internal class MakeInventoryCommand: ICommand
    {
        CommandHandler handler;
        string[] payload;

        public MakeInventoryCommand(CommandHandler handler, string[] payload)
        {
            this.handler = handler;
            this.payload = payload;
        }

        public void Execute() 
        {
            handler.MakeInventory(payload);
        }
    }
}
