namespace CustomProgram
{
    // Interface: Defines the Color parameters that each IColorPalette needs to provide.
    public interface IColorPalette
    {
        public Color DarkBlue { get; }
        public Color LightBlue { get; }
        public Color LightYellow { get; }
        public Color LightGreen { get; }
        public Color DarkGreen { get; }
        public Color Orange { get; }
        public Color LightBrown { get; }
        public Color DarkBrown { get; }
        public Color Villager { get; }
        public Color TextMain { get; }
        public Color TextSecondary { get; }
        public Color Invalid { get; }
    }
}
