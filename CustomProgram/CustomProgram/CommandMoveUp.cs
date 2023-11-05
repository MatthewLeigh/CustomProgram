namespace CustomProgram
{
    public class CommandMoveUp : ICommand
    {
        private Character _character;
        private Navigator _navigator;
        private bool _continuous;

        // Constructor: 
        public CommandMoveUp(Character character, Navigator navigator)
        {
            _character = character;
            _navigator = navigator;
            _continuous = true;
        }

        // Implements ICommand interface by implementing the code that should occur when the command is invoked.
        public void Execute()
        {
            if (CanMoveOntoTile())
            { 
                _character.Y -= 1;
            }
        }

        // Based on the underlying Tile in Map, determines if the Character can move in this direction or not.
        private bool CanMoveOntoTile()
        {
            if (_character.Y > 0)
            {
                Point2D _proposedCoords = new Point2D { X = _character.X, Y = _character.Y - 1 };
                bool _hasSwimWear = _character.Inventory.HasItemOfType(ItemType.SwimWear);

                return _navigator.CanBeOnTile(_proposedCoords, true, _hasSwimWear);
            }
            return false;
        }

        public bool Continuous { get { return _continuous; } }
    }
}
