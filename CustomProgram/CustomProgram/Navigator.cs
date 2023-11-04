namespace CustomProgram
{
    public class Navigator
    {
        //
        // Note: 'Wetness' refers to whether the represented TileType is 'wet' or 'dry'. Refer to TileType enum in Tile class.
        // TileTypes of Sand or higher are considered dry.
        // Tile Types of Water or lower are considered wet.
        // TileType == 0 is None and represents an invalid Tile.
        //

        private Map _map;
        private List<Point2D> _dryTileLocations;
        private List<Point2D> _wetTileLocations;
        private List<Point2D> _allTileLocations;

        private Random _random = new Random();

        // Constructor: 
        public Navigator(Map map)
        {
            _map = map;
            _allTileLocations = CoordsForAllTilesofCertainWetness(true, true);
            _dryTileLocations = CoordsForAllTilesofCertainWetness(true, false);
            _wetTileLocations = CoordsForAllTilesofCertainWetness(false, true);
        }

        // Returns the TileType at the Point2D location that is passed in.
        public TileType OnTileType(Point2D coords)
        {
            int _roundedX = 0;
            foreach (int x in _map.TilesXList)
            {
                if (coords.X >= x)
                {
                    _roundedX = x;
                }
            }

            int _roundedY = 0;
            foreach (int y in _map.TilesYList)
            {
                if (coords.Y >= y)
                {
                    _roundedY = y;
                }
            }

            Point2D _roundedCoords = new Point2D() { X = _roundedX, Y = _roundedY };

            foreach (Point2D _tileCoords in _allTileLocations)
            {
                if (_roundedCoords.X == _tileCoords.X && _roundedCoords.Y == _tileCoords.Y)
                {
                    return _map.TilesAtCoords[_tileCoords].TileType;
                }
            }

            throw new Exception("Could not locate which Tile the object at these coords is currently on.");
        }

        // Returns a List of the Point2D coords of all Tiles of the passed in TileType.
        public List<Point2D> CoordsForAllTilesOfType(TileType type)
        {
            List<Point2D> _returnList = new List<Point2D>();

            foreach (Point2D point in _map.CoordsList)
            {
                if (_map.TilesAtCoords[point].TileType == type)
                {
                    _returnList.Add(point);
                }
            }

            if (_returnList.Count > 0)
            {
                return _returnList;
            }

            throw new Exception($"No Tiles of TileType {type} exist within the Map");
        }

        // Returns a List of the Point2D coords of all Tiles of the passed in List of TileTypes.
        public List<Point2D> CoordsForAllTilesOfType(List<TileType> types)
        {
            List<Point2D> _returnList = new List<Point2D>();

            foreach (TileType type in types)
            {
                _returnList.AddRange(CoordsForAllTilesOfType(type));
            }

            if (_returnList.Count > 0)
            {
                return _returnList;
            }

            throw new Exception("No Tiles of the specified TileType exist within the Map");
        }

        // Returns a List of the Point2D coords of all WalkableTiles or not WalkableTiles depending on bool passed in.
        // TileType enums of Sand or higher are considered dry. TileType enums greater than None and lower than Sand are considered wet.
        public List<Point2D> CoordsForAllTilesofCertainWetness(bool isDry, bool isWet)
        {
            List<TileType> _validTileTypes = new List<TileType>();

            foreach (TileType type in Enum.GetValues(typeof(TileType)))
            {
                if (isDry)
                {
                    if (type >= TileType.Sand)
                    {
                        _validTileTypes.Add(type);
                    }
                }
                if (isWet)
                {
                    if (type > TileType.None && type < TileType.Sand)
                    {
                        _validTileTypes.Add(type);
                    }
                }
            }
            return CoordsForAllTilesOfType(_validTileTypes);
        }

        // Returns True if the Point2D coords on a Tile of the Specified Wetness
        public bool CanBeOnTile(Point2D coords, bool onDry, bool onWet)
        {
            TileType _onType = OnTileType(coords);

            if (onDry && onWet)
            {
                return (_onType > TileType.None);
            }

            if (onDry && !onWet)
            {
                return (_onType >= TileType.Sand);
            }

            if (!onDry && onWet)
            {
                return (_onType > TileType.None && _onType < TileType.Sand);
            }

            if (!onDry && !onWet)
            {
                throw new ArgumentException("Atleast one of 'onDry' and 'onWet' must be True.");
            }

            return false;
        }

        // Returns a random Point2D Coordiante where the Tile meets to parameters.
        public Point2D RandomCoords(bool onDry, bool onWet)
        {
            if (onDry && onWet)
            {
                return _allTileLocations[_random.Next(_allTileLocations.Count - 1)];
            }

            if (onDry && !onWet)
            {
                return _dryTileLocations[_random.Next(_dryTileLocations.Count - 1)];
            }

            if (!onDry && onWet)
            {
                return _wetTileLocations[_random.Next(_wetTileLocations.Count - 1)];
            }

            if (!onDry && !onWet)
            {
                throw new ArgumentException("Atleast one of 'onDry' and 'onWet' must be True.");
            }

            throw new Exception();
        }

        public int MapHeight { get { return _map.Height; } }
        public int MapWidth { get { return _map.Width; } }
    }
}
