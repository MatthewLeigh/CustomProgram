namespace CustomProgram
{
    public class InitialiseCharacterItems
    {
        private static InitialiseCharacterItems? instance;
        private bool _initialized = false;

        private Inventory _gameItems;
        private Item _flippers;
        private Item _fishingNet;
        private Item _glasses;

        private Random _random = new Random();

        // Private Constructor: 
        private InitialiseCharacterItems()
        {
            _flippers = new Item(ItemType.SwimWear, "Flippers", "Helps you swim");
            _fishingNet = new Item(ItemType.Weapon, "Fishing Net", "Big enough to catch a cow-sized fish!");
            _glasses = new Item(ItemType.Vision, "Glasses", "You can see everything now!");

            _gameItems = new Inventory();
            _gameItems.Add(_flippers);
            _gameItems.Add(_fishingNet);
            _gameItems.Add(_glasses);
        }

        // Singleton Class. Provides access to the instance.
        public static InitialiseCharacterItems Instance()
        {
            if (instance == null)
            {
                instance = new InitialiseCharacterItems();
            }
            return instance;
        }

        // Distribute Game Items amongst the List of Characters.
        // Can only be invoked once. If already initialized, method does not execute and code.
        public void Distribute(List<Character> characters)
        {
            if (!_initialized)
            {
                if (characters.Count >= _gameItems.Items.Count)
                {
                    for (int i = 0; i < _gameItems.Items.Count; i++)
                    {
                        characters[i].Inventory.Add(_gameItems.Items[i]);
                    }
                }
                else
                {
                    foreach (Item item in _gameItems.Items)
                    {
                        characters[_random.Next(characters.Count - 1)].Inventory.Add(item);
                    }
                }
                _initialized = true;
            }
        }
    }
}
