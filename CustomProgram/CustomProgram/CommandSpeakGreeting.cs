namespace CustomProgram
{
    public class CommandSpeakGreeting : ICommand
    {
        private Character _character;

        private bool _continuous;

        // COnstructor: 
        public CommandSpeakGreeting(Character character)
        {
            _character = character;
            _continuous = true;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        // Draws the Phrase to the screen above the Character.
        public void Execute()
        {
            double _x = _character.X + (_character.TileSize / 2);
            double _y = _character.Y - 20;
            string _string = _character.Phrases.Retrieve(PhraseKey.Greeting);
            Color _color = ColorPalette.Instance().Current.TextSecondary;

            SplashKit.DrawText(_string, _color, _x, _y);
        }

        public bool Continuous { get { return _continuous; } }
    }
}
