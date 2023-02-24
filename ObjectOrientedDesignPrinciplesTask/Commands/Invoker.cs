namespace ObjectOrientedDesignPrinciplesTask.Commands
{
    internal class Invoker
    {
        ICommand command;

        public void SetCommand(ICommand command) 
        {
            this.command = command;
        }

        public void ExecuteCommand() 
        {
            if (command != null)
            {
                command.Execute();
            }
        }
    }
}
