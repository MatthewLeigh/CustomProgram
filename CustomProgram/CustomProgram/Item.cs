namespace CustomProgram
{
    // Enumeration: ItemType impacts how an Item is used within the game.
    public enum ItemType
    {
        SwimWear,
        Weapon,
        Vision,
        Food
    }

    public class Item
    {
        public ItemType _type;
        public string _name;
        public string _description;

        // Constructor:
        public Item(ItemType type, string name, string description)
        {
            _type = type;
            _name = name.ToLower();
            _description = description.ToLower();
        }

        public ItemType ItemType { get { return _type; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
    }
}
