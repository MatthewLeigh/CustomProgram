namespace CustomProgram
{
    public class Villager : Character
    {
        // Constructor :
        public Villager(string name, string description, Point2D coords) : base(name, description, coords, 8)
        {

        }

        // Instance draws itself to the screen.
        public override void Draw()
        {
            Color _color = ColorPalette.Instance().Current.Villager;
            SplashKit.FillRectangle(_color, DrawX, DrawY, TileSize, TileSize);
            DrawName();
        }

        // Instance draws it's Name to the screen next to itself.
        public override void DrawName()
        {
            Color _color = ColorPalette.Instance().Current.TextSecondary;
            SplashKit.DrawText(StringFormatter.FirstCharInWordsToUpper(Name), _color, DrawX + (TileSize * 1.5), DrawY);
        }
    }
}
