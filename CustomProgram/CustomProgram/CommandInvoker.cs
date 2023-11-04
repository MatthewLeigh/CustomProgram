namespace CustomProgram
{
    public class CommandInvoker
    {
        private ICommand _command;
        private ICommand? _secondaryCommand;
        private KeyCode _key;

        // Constructor: Takes two ICommand objects.
        public CommandInvoker(ICommand command, ICommand? secondaryCommand, KeyCode key)
        {
            _command = command;
            _secondaryCommand = secondaryCommand;
            _key = key;
        }

        // Constructor: Takes a single ICommand object.
        public CommandInvoker(ICommand command, KeyCode key) : this(command, null, key) { }

        // Sets a new ICommand to the primary command.
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        // Sets a new ICommand to the secondary command.
        public void SetSecondaryCommand(ICommand command)
        {
            _secondaryCommand = command;
        }

        // Sets a new trigger to invoke the ICommand/s.
        public void SetTrigger(KeyCode key)
        {
            _key = key;
        }

        // Calls ExecuteCommand for the primary and secondary ICommand objects.
        public void Execute()
        {
            ExecuteCommand(_command);
            ExecuteCommand(_secondaryCommand);
        }

        // Calls the ICommand to Execute() if the trigger has been invoked.
        // If the command is Continuous, SplashKit.KeyDown will invoke the command for each game cycle that it is invoked.
        // If the command is !Continuous, SplashKit.KeyType will invoke the command once for each time the trigger is pressed.
        private void ExecuteCommand(ICommand? command)
        {
            if (command != null)
            {
                if (command.Continuous && SplashKit.KeyDown(_key))
                {
                    command.Execute();
                }

                if (!command.Continuous && SplashKit.KeyTyped(_key))
                {
                    command.Execute();
                }
            }
        }
    }
}
