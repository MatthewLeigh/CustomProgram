namespace CustomProgram
{
    public class CommandManager : IUpdateEachCycle
    {
        private Navigator _cartographer;
        private CharacterManager _characterManager;

        private List<CommandInvoker> _utilityInvokers;
        private List<CommandInvoker> _characterInvokers;

        private ICommand _rotateCharacter;
        private ICommand _togglePalette;
        private ICommand _toggleDisplayAnimalNames;
        private ICommand _moveDown;
        private ICommand _moveUp;
        private ICommand _moveLeft;
        private ICommand _moveRight;
        private ICommand _speakGreeting;
        private ICommand _speakTakeItem;
        private ICommand _speakGiveItem;
        private ICommand _speakCapture;
        private ICommand _giveItem;
        private ICommand _takeItem;
        private ICommand _capture;

        private CommandInvoker _rKeyInvoker;
        private CommandInvoker _tKeyInvoker;
        private CommandInvoker _eKeyInvoker;
        private CommandInvoker _downKeyInvoker;
        private CommandInvoker _upKeyInvoker;
        private CommandInvoker _leftKeyInvoker;
        private CommandInvoker _rightKeyInvoker;
        private CommandInvoker _shiftKeyInvoker;
        private CommandInvoker _crtlKeyInvoker;
        private CommandInvoker _spaceKeyInvoker;
        private CommandInvoker _cKeyInvoker;

        // Constructor: 
        public CommandManager(Navigator cartographer, CharacterManager charcaterManager) 
        {
            _cartographer = cartographer;
            _characterManager = charcaterManager;

            _utilityInvokers = new List<CommandInvoker>();
            SetUtilities();

            _characterInvokers = new List<CommandInvoker>();
            SetCharacter();
        }

        // Instantiate Command > Instantiate Invoker with Command > Add Invoker to List.
        // These are the commands which are not specific to the current character, and do not need to be updated when the current charcater is changed.
        // Clears the List at the start of the method to ensure no unwanted artifacts remain.
        public void SetUtilities()
        {
            _utilityInvokers.Clear();

            _rotateCharacter = new CommandRotateCharacter(_characterManager);
            _rKeyInvoker = new CommandInvoker(_rotateCharacter, KeyCode.RKey);
            _utilityInvokers.Add(_rKeyInvoker);

            _togglePalette = new CommandTogglePalette();
            _tKeyInvoker = new CommandInvoker(_togglePalette, KeyCode.TKey);
            _utilityInvokers.Add(_tKeyInvoker);

            _toggleDisplayAnimalNames = new CommandToggleDisplayAnimalNames(_characterManager);
            _eKeyInvoker = new CommandInvoker(_toggleDisplayAnimalNames, KeyCode.EKey);
            _utilityInvokers.Add(_eKeyInvoker);
        }

        // Instantiate Command > Instantiate Invoker with Command > Add Invoker to List.
        // These are the commands which are specific to the current character, and do need to be updated when the current charcater is changed.
        // Clears the List at the start of the method to ensure no unwanted artifacts remain.
        public void SetCharacter()
        {
            _characterInvokers.Clear();
            Character _character = _characterManager.CurrentCharacter;

            _moveDown = new CommandMoveDown(_character, _cartographer);
            _downKeyInvoker = new CommandInvoker(_moveDown, KeyCode.DownKey);
            _characterInvokers.Add(_downKeyInvoker);

            _moveUp = new CommandMoveUp(_character, _cartographer);
            _upKeyInvoker = new CommandInvoker(_moveUp, KeyCode.UpKey);
            _characterInvokers.Add(_upKeyInvoker);

            _moveLeft = new CommandMoveLeft(_character, _cartographer);
            _leftKeyInvoker = new CommandInvoker(_moveLeft, KeyCode.LeftKey);
            _characterInvokers.Add(_leftKeyInvoker);

            _moveRight = new CommandMoveRight(_character, _cartographer);
            _rightKeyInvoker = new CommandInvoker(_moveRight, KeyCode.RightKey);
            _characterInvokers.Add(_rightKeyInvoker);

            _speakGreeting = new CommandSpeakGreeting(_character);
            _shiftKeyInvoker = new CommandInvoker(_speakGreeting, KeyCode.LeftShiftKey);
            _characterInvokers.Add(_shiftKeyInvoker);

            _speakTakeItem = new CommandSpeakTakeItem(_character);
            _takeItem = new CommandTakeItem();
            _crtlKeyInvoker = new CommandInvoker(_speakTakeItem, _takeItem, KeyCode.LeftCtrlKey);
            _characterInvokers.Add(_crtlKeyInvoker);

            _speakGiveItem = new CommandSpeakGiveItem(_character);
            _giveItem = new CommandGiveItem();
            _spaceKeyInvoker = new CommandInvoker(_speakGiveItem, _giveItem, KeyCode.SpaceKey);
            _characterInvokers.Add(_spaceKeyInvoker);

            _speakCapture = new CommandSpeakCapture(_character);
            _capture = new CommandCapture();
            _cKeyInvoker = new CommandInvoker(_speakCapture, _capture, KeyCode.CKey);
            _characterInvokers.Add(_cKeyInvoker);
        }

        // Implements IUpdateEachCycle interface by calling all the classes methods which need to update each gameplay cycle.
        public void RunCycle()
        {
            try
            {
                SetCharacter();
                Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Calls each of the CommandInvoker objects to execute if their trigger has been invoked. 
        public void Execute()
        {
            List<CommandInvoker> _invokers = _utilityInvokers.Concat(_characterInvokers).ToList();

            foreach (CommandInvoker command in _invokers)
            {
                try
                {
                    command.Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
