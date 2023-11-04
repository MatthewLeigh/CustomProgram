namespace CustomProgram
{
    public class CommandGiveItem : ICommand
    {
        private bool _continuos;

        public CommandGiveItem() 
        {
            _continuos = false;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        //
        // Note: Code has not been implemented yet.
        // Intention: Transfer an Item from the Character's Inventory and a nearby Character's Inventory. Transfers an ItemType.Food Item first, if available.
        public void Execute()
        {
            throw new NotImplementedException("*Give Item to Nearby Character* (CommandGiveItem.Execute() is not implemented.)");
        }

        public bool Continuous { get { return _continuos; } }
    }
}
