namespace CustomProgram
{
    public class CommandCapture : ICommand
    {
        private bool _continuos;

        // Constructor: 
        public CommandCapture()
        {
            _continuos = false;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        //
        // Note: Code has not been implemented yet.
        // Inention: Take an Item for a nearby Animal and remove the instance of the Animal. 
        public void Execute()
        {
            throw new NotImplementedException("*Take Item from nearby Animal. Remove Animal instance.* (CommandCapture.Execute() is not implemented.)");
        }

        public bool Continuous { get { return _continuos; } }
    }
}
