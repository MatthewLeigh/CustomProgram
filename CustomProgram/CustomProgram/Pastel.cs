namespace CustomProgram
{
    public class Pastel : IColorPalette
    {
        private Color _darkBlue = Color.RGBColor(96, 182, 255);
        private Color _lightBlue = Color.RGBColor(135, 196, 255);
        private Color _lightYellow = Color.RGBColor(249, 181, 114);
        private Color _lightGreen = Color.RGBColor(153, 176, 128);
        private Color _darkGreen = Color.RGBColor(116, 142, 99);
        private Color _orange = Color.RGBColor(255, 155, 80);
        private Color _lightBrown = Color.RGBColor(218, 221, 177);
        private Color _darkBrown = Color.RGBColor(72, 54, 29);
        private Color _villager = Color.RGBColor(187, 90, 90);
        private Color _textMain = Color.RGBColor(39, 40, 41);
        private Color _textSecondary = Color.RGBColor(35, 34, 30);
        private Color _invalid = Color.Red;

        public Color DarkBlue { get { return _darkBlue;} }
        public Color LightBlue { get { return _lightBlue;} }
        public Color LightYellow { get { return _lightYellow;} }
        public Color LightGreen { get { return _lightGreen;} }
        public Color DarkGreen { get { return _darkGreen;} }
        public Color Orange { get { return _orange;} }
        public Color LightBrown { get { return _lightBrown; } }
        public Color DarkBrown { get { return _darkBrown; } }
        public Color Villager { get { return _villager; } }
        public Color TextMain { get { return _textMain; } }
        public Color TextSecondary { get { return _textSecondary; } }
        public Color Invalid { get { return _invalid;} }
    }
}
