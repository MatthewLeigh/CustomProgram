namespace CustomProgram
{
    public class Fish : Animal
    {
        private Item _sushi = new Item(ItemType.Food, "Sushi", "Seaweed, rice, fish");

        public Fish(Point2D coords) : base("Fish", "The chicken of the sea", coords, 6)
        {
            Inventory.Add(_sushi);
        }

        // Instance draws itself to the screen.
        public override void Draw()
        {
            Color _color = ColorPalette.Instance().Current.Orange;
            SplashKit.FillRectangle(_color, DrawX, DrawY, TileSize, TileSize);
        }

        public override void DrawName()
        {
            Color _color = ColorPalette.Instance().Current.TextSecondary;
            SplashKit.DrawText(StringFormatter.FirstCharInWordsToUpper(Name), _color, DrawX + (TileSize * 1.5), DrawY);
        }
    }
}
