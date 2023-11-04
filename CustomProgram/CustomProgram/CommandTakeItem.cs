namespace CustomProgram
{
    public class CommandTakeItem : ICommand
    {
        private bool _continuos;
        public CommandTakeItem()
        {
            _continuos = false;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        //
        // Note: Code has not been implemented yet.
        // Inention: Take an Item for a nearby Villager's Inventory. 
        public void Execute()
        {
            throw new NotImplementedException("*Take Item from nearby Villager* (CommandTakeItem.Execute() is not implemented.)");
        }

        public bool Continuous { get { return _continuos; } }
    }
}
