namespace CustomProgram
{
    public abstract class DrawableObject
    {
        private Point2D _spawnCoords;
        private Point2D _currentCoords;

        private int _tileSize;

        // Constructor:
        public DrawableObject(Point2D coords, int tileSize)
        {
            _spawnCoords = coords;
            _currentCoords = coords;

            _tileSize = tileSize;
        }

        // Constructor: Converts the int X and Y values to a Point2D instance and passes this to the main constructor.
        public DrawableObject(int x, int y, int tileSize) : this(new Point2D() { Y = y, X = x }, tileSize) { }

        // The DrawableObject draws itself to the screen.
        public abstract void Draw();


        public Point2D SpawCoords { get { return _spawnCoords; } }
        public Point2D Coords { get { return _currentCoords; } set { _currentCoords = value; } }
        public double X { get { return _currentCoords.X; } set { _currentCoords.X = value; } }
        public double Y { get { return _currentCoords.Y; } set { _currentCoords.Y = value; } }
        public double DrawX { get { return _currentCoords.X - (_tileSize / 2); } }
        public double DrawY { get { return _currentCoords.Y - (_tileSize / 2); } }
        public int TileSize { get { return _tileSize; } }
    }
}
