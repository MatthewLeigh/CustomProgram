﻿namespace CustomProgram
{
    public class CommandMoveRight : ICommand
    {
        private Character _character;
        private Navigator _navigator;
        private bool _continuous;

        // Constructor: 
        public CommandMoveRight(Character character, Navigator navigator)
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
                _character.X += 1;
            }
        }

        // Based on the underlying Tile in Map, determines if the Character can move in this direction or not.
        private bool CanMoveOntoTile()
        {
            if (_character.X < _navigator.MapWidth)
            {
                Point2D _proposedCoords = new Point2D { X = _character.X + 1, Y = _character.Y };
                bool _hasSwimWear = _character.Inventory.HasItemOfType(ItemType.SwimWear);

                if (_navigator.CanBeOnTile(_proposedCoords, true, _hasSwimWear))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Continuous { get { return _continuous; } }
    }
}
