namespace CustomProgram
{
    // Enumeration: TileType can be thought of in terms of layers of elevation. The greater the enumerable value, the higher the elevation of the tile.     
    public enum TileType
    {
        None,
        DeepWater,
        Water,
        Sand,
        Grass,
        Forest
    }

    public class Tile
    {
        private TileType _type;
        private bool _isWalkable;

        // Constructor: Creates a Tile of the TileType requested.
        public Tile(TileType type)
        {
            _type = type;
            _isWalkable = SetIsWalkable();
        }

        // Constructor: Creates a Tile with a TileType based on method CenvertNoiseValueToTileType.
        public Tile(float noiseValue)
        {
            if (noiseValue >= 0 && noiseValue <= 255)
            {
                _type = ConvertNoiseValueToTileType(noiseValue);
                _isWalkable = SetIsWalkable();
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Parameter noiseValue must be between 0 and 255 inclusive. Constructor received value of {noiseValue}.");
            }
        }

        // Tile draws itself to the screen using SplashKit.FillRectangle() based on coordiantes passed in.
        public void Draw(Point2D coords, int tileSize)
        {
            Color _color = SetColor();
            SplashKit.FillRectangle(_color, coords.X, coords.Y, tileSize, tileSize);
        }

        // Returns True if the TileType is Sand or higher. Otherwise, return False.
        private bool SetIsWalkable()
        {
            return (_type >= TileType.Sand);
        }

        // Converts a float value between 0 and 255 inclusive to a TileType.
        // Values have been arbitrarily selected based on trial and error when float _scale in class Noise is 0.04f.
        // Note: Implementation could be improved so that the two classes do not depend on each other.
        private TileType ConvertNoiseValueToTileType(float noiseValue)
        {
            switch (noiseValue)
            {
                case < 60:
                    return TileType.DeepWater;

                case < 120:
                    return TileType.Water;

                case < 140:
                    return TileType.Sand;

                case < 180:
                    return TileType.Grass;

                case <= 255:
                    return TileType.Forest;

                default:
                    return TileType.None;
            }
        }

        // Determines which Color the Tile should be drawn as, based on it's TileType.
        private Color SetColor()
        {
            IColorPalette _colorPalette = ColorPalette.Instance().Current;

            switch (_type)
            {
                case TileType.DeepWater:
                    return _colorPalette.DarkBlue;

                case TileType.Water:
                    return _colorPalette.LightBlue;

                case TileType.Sand:
                    return _colorPalette.LightYellow;

                case TileType.Grass:
                    return _colorPalette.LightGreen;

                case TileType.Forest:
                    return _colorPalette.DarkGreen;

                default:
                    return _colorPalette.Invalid;
            }
        }

        public TileType TileType { get { return _type; } }
        public bool IsWalkable { get { return _isWalkable; } }
    }
}
