namespace CustomProgram
{
    public class Duck : Animal
    {
        private Item _duckBreast = new Item(ItemType.Food, "Duck Breast", "Tastes like chicken!");

        // Constructor :
        public Duck(Point2D coords) : base("Duck", "Quack", coords, 6)
        {
            Inventory.Add(_duckBreast);
        }

        // Instance draws itself to the screen.
        public override void Draw()
        {
            Color _color = ColorPalette.Instance().Current.LightBrown;
            SplashKit.FillRectangle(_color, DrawX, DrawY, TileSize, TileSize);
        }

        // Instance draws it's Name to the screen next to itself.
        public override void DrawName()
        {
            Color _color = ColorPalette.Instance().Current.TextSecondary;
            SplashKit.DrawText(StringFormatter.FirstCharInWordsToUpper(Name), _color, DrawX + (TileSize * 1.5), DrawY);
        }
    }
}
