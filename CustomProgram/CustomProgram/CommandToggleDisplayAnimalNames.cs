namespace CustomProgram
{
    public class CommandToggleDisplayAnimalNames : ICommand
    {
        CharacterManager _characterManager;
        private bool _continuous;

        // Constructor: 
        public CommandToggleDisplayAnimalNames(CharacterManager characterManager)
        {
            _characterManager = characterManager;
            _continuous = false;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        public void Execute()
        {
            _characterManager.ToggleDisplayAnimalNames();
        }

        public bool Continuous { get { return _continuous; } }

    }
}
