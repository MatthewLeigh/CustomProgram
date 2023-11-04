namespace CustomProgram
{
    public abstract class Character : DrawableObject
    {
        private string _name;
        private string _description;
        private Inventory _inventory;
        private Phrases _phrases;

        // Construtor:
        public Character(string name, string description, Point2D coords, int tileSize) : base(coords, tileSize)
        {
            _name = name.ToLower();
            _description = description.ToLower();
            _inventory = new Inventory();
            _phrases = new Phrases();
        }

        // Returns a List of formatted strings with the Characters Name, Description, Coords, and Inventory. 
        public List<string> FullDescription()
        {
            List<string> _description = new List<string>();

            _description.Add($"{StringFormatter.FirstCharInWordsToUpper(Name)}, {StringFormatter.FirstCharInStringToUpper(Description)}.");
            _description.Add($"{X.ToString("0000")}, {Y.ToString("0000")}");

            foreach (Item item in _inventory.Items)
            {
                _description.Add($"- {StringFormatter.FirstCharInWordsToUpper(item.Name)} ({item.ItemType})");
            }

            return _description;
        }

        // Character Child class will draw it's own Name to the screen.
        public abstract void DrawName();


        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public Inventory Inventory { get { return _inventory; } }
        public Phrases Phrases { get { return _phrases; } }
    }
}
