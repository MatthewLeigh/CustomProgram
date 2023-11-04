namespace CustomProgram
{
    public class Cow : Animal
    {
        private Item _steak = new Item(ItemType.Food, "Steak", "Grilled to perfection");

        // Constructor: 
        public Cow(Point2D coords) : base("Cow", "Just a big ol' moo cow", coords, 10)
        {
            Inventory.Add(_steak);
        }

        // Instance draws itself to the screen.
        public override void Draw()
        {
            Color _color = ColorPalette.Instance().Current.DarkBrown;
            SplashKit.FillRectangle(_color, DrawX, DrawY, TileSize, TileSize / .66);
        }

        // Instance draws it's Name to the screen next to itself.
        public override void DrawName()
        {
            Color _color = ColorPalette.Instance().Current.TextSecondary;
            SplashKit.DrawText(StringFormatter.FirstCharInWordsToUpper(Name), _color, DrawX + (TileSize * 1.5), DrawY);
        }
    }
}
