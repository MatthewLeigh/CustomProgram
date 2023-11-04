namespace CustomProgram
{
    public class Map : IUpdateEachCycle
    {
        private Noise _noise;
        private List<Point2D> _coordsList;
        private Dictionary<Point2D, Tile> _tilesAtCoords;

        private int _startingX;
        private int _startingY;
        private int _numX;
        private int _numY;
        private int _tileSize;

        private List<int> _tilesXList;
        private List<int> _tilesYList;

        // Constructor: 
        public Map(int startingX, int startingY, int numX, int numY, int tileSize)
        {
            _noise = new Noise(numX, numY);
            _coordsList = new List<Point2D>();
            _tilesAtCoords = new Dictionary<Point2D, Tile>();

            _startingX = startingX;
            _startingY = startingY;
            _numX = numX;
            _numY = numY;
            _tileSize = tileSize;

            _tilesXList = new List<int>();
            _tilesYList = new List<int>();

            Generate();
        }

        // Constructor: Passess the main constructor default 0,0 Cartersian Coordinates for the startingX and startingY location.
        public Map(int numX, int numY, int tileSize) : this(0, 0, numX, numY, tileSize) { }

        // Generate a List of Tiles based on the Map's Noise values.
        // For each X and Y location where a Tile is required, generate a Tile and Point2D. Add these to a dictionary. 
        // Clear the Dictionary and List before generating new Keys, to avoid unwanted values remaining.
        private void Generate()
        {
            _tilesAtCoords.Clear();
            _coordsList.Clear();

            _tilesXList = SetTilesCoordsOneDimension(_startingX, _numX, _tileSize);
            _tilesYList = SetTilesCoordsOneDimension(_startingY, _numY, _tileSize);

            for (int n = 0; n < _numY; n++)
            {
                for (int m = 0; m < _numX; m++)
                {
                    Tile _tile = new Tile(_noise.Matrix[m, n]);
                    Point2D _coords = new Point2D() { X = _tilesXList[m], Y = _tilesYList[n] };
                    _coordsList.Add(_coords);
                    _tilesAtCoords.Add(_coords, _tile);
                }
            }
        }

        // Updates the X and Y coordinates for the Tiles in the Map based on the tileSize passed in.
        public void UpdateMapTileSize(int tileSize)
        {
            _tileSize = tileSize;
            Generate();
        }

        // Updates the the starting X and Y coordinates for the Map.
        public void UpdateMapBaseCoords(int startingX, int startingY)
        {
            _startingX = startingX;
            _startingY = startingY;
            Generate();
        }

        // Sets all the X or Y coordinates for the Tiles in the Map.
        private List<int> SetTilesCoordsOneDimension(int startingPoint, int numTile, int tileSize)
        {
            List<int> _returnCoords = new List<int>();

            for (int i = 0; i < numTile; i++)
            {
                int _value = startingPoint + (i * tileSize);
                _returnCoords.Add(_value);
            }
            return _returnCoords;
        }

        // Calls each Tile in the Map to Draw itself.
        public void Draw()
        {
            for (int i = 0; i < _coordsList.Count; i++)
            {
                Tile _tile = _tilesAtCoords[_coordsList[i]];
                Point2D _point2D = _coordsList[i];
                _tile.Draw(_point2D, _tileSize);
            }
        }

        // Calls all the classes methods which need to update each gameplay cycle.
        public void RunCycle()
        {
            Draw();
            try
            {
                Draw();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Dictionary<Point2D, Tile> TilesAtCoords { get { return _tilesAtCoords; } }
        public List<Point2D> CoordsList { get { return _coordsList; } }
        public int X { get { return _startingX; } }
        public int Y { get { return _startingY; } }
        public int NumX { get { return _numX; } }
        public int NumY { get { return _numY; } }
        public int TileSize { get { return _tileSize; } }
        public int Width { get { return _numX * _tileSize; } }
        public int Height { get { return _numY * _tileSize; } }
        public List<int> TilesXList { get { return _tilesXList; } }
        public List<int> TilesYList { get { return _tilesYList; } }
    }
}
