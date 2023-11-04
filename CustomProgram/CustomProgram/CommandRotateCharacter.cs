namespace CustomProgram
{
    public class CommandRotateCharacter : ICommand
    {
        private CharacterManager _characterManager;
        private bool _continuous;

        // Constructor: 
        public CommandRotateCharacter(CharacterManager characterManager) 
        {
            _characterManager = characterManager;
            _continuous = false;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        public void Execute()
        {
            _characterManager.RotateCharacter();
        }

        public bool Continuous { get { return _continuous; } }

    }
}
