namespace CustomProgram
{
    public class ColorPalette
    {
        private static ColorPalette? _instance;

        private List<IColorPalette> _palettes;
        private IColorPalette _current;

        private int _index = 0;

        // Private Constructor:
        private ColorPalette()
        {
            _palettes = new List<IColorPalette>
            {
                new Pastel(),
                new Bold(),
            };

            _current = _palettes[_index];
        }

        // Singleton Class. Provides access to the instance.
        // Allows a single point in the program to set and get the IColorPalette
        public static ColorPalette Instance()
        {
            if (_instance == null)
            {
                _instance = new ColorPalette();
            }
            return _instance;
        }

        // Increment the pallete index by one, or reset to zero if already at max.
        // Set current palette based on new index.
        public void Rotate()
        {
            if (_index < _palettes.Count - 1) 
            {
                _index++;
            }
            else
            {
                _index = 0;
            }
            _current = _palettes[_index];
        }

        public IColorPalette Current { get { return _current; } set { _current = value; } }
    }
}
