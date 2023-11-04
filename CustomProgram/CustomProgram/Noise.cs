using SimplexNoise;

namespace CustomProgram
{
    public class Noise
    {
        private float _scale = 0.04f; // Lower = flatter world.
        private int _rows;
        private int _columns;
        private float[,] _matrix;

        // Constructor:
        public Noise(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _matrix = Generate(rows, columns);
        }

        // Generates and returns a random 2D SimplexNoise float matrix. 
        private float[,] Generate(int rows, int columns)
        {
            Random _random = new Random();
            SimplexNoise.Noise.Seed = _random.Next();
            return SimplexNoise.Noise.Calc2D(rows, columns, _scale);
        }

        public int Rows { get { return _rows; } }
        public int Columns { get { return _columns; } }
        public float[,] Matrix { get { return _matrix; } }
    }
}
