namespace CustomProgram
{
    public abstract class Animal : Character
    {
        public Animal(string name, string description, Point2D coords, int tileSize) : base(name, description, coords, tileSize) { }
    }
}
