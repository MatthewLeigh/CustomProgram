namespace CustomProgram
{
    public class Bold : IColorPalette
    {
        private Color _darkBlue = Color.DarkBlue;
        private Color _lightBlue = Color.Blue;
        private Color _lightYellow = Color.Yellow;
        private Color _lightGreen = Color.Green;
        private Color _darkGreen = Color.DarkGreen;
        private Color _orange = Color.Orange;
        private Color _lightBrown = Color.SandyBrown;
        private Color _darkBrown = Color.Brown;
        private Color _villager = Color.Black;
        private Color _textMain = Color.Black;
        private Color _textSecondary = Color.DarkGray;
        private Color _invalid = Color.Red;

        public Color DarkBlue { get { return _darkBlue; } }
        public Color LightBlue { get { return _lightBlue; } }
        public Color LightYellow { get { return _lightYellow; } }
        public Color LightGreen { get { return _lightGreen; } }
        public Color DarkGreen { get { return _darkGreen; } }
        public Color Orange { get { return _orange; } }
        public Color LightBrown { get { return _lightBrown; } }
        public Color DarkBrown { get { return _darkBrown; } }
        public Color Villager { get { return _villager; } }
        public Color TextMain { get { return _textMain; } }
        public Color TextSecondary { get { return _textSecondary; } }
        public Color Invalid { get { return _invalid; } }
    }
}
