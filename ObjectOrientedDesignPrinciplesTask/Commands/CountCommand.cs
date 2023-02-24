namespace ObjectOrientedDesignPrinciplesTask.Commands
{
    internal class CountCommand: ICommand
    {
        CommandHandler handler;
        string payload;

        public CountCommand(CommandHandler handler, string payload)
        {
            this.handler = handler;
            this.payload = payload;
        }

        public void Execute()
        {
            handler.ExecuteCountCommand(payload);
        }
    }
}
