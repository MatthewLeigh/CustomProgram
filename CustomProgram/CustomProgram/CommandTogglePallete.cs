namespace CustomProgram
{
    public class CommandTogglePalette : ICommand
    {
        private bool _continuous;

        // Constructor: 
        public CommandTogglePalette()
        {
            _continuous = false;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.

        public void Execute()
        {
            ColorPalette.Instance().Rotate();
        }

        public bool Continuous { get { return _continuous; } }
    }
}
