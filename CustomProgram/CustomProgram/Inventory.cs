namespace CustomProgram
{
    public class Inventory
    {
        private List<Item> _items;

        // Constructor:
        public Inventory()
        {
            _items = new List<Item>();
        }

        // Returns true if _items containts the Item which is passed in. Otherwise, returns false.
        public bool HasItem(Item item)
        {
            foreach (Item checkItem in _items)
            {
                if (checkItem == item)
                {
                    return true;
                }
            }
            return false;
        }

        // Returns True if _items contains an Item of the passed in ItemType.
        public bool HasItemOfType(ItemType type)
        {
            foreach (Item item in _items)
            {
                if (item.ItemType == (type))
                {
                    return true;
                }
            }
            return false;
        }

        // Adds an Item to the _items List.
        public void Add(Item item)
        {
            _items.Add(item);
        }

        // Adds a List<Item> to the _items List.
        public void Add(List<Item> items)
        {
            foreach (Item item in items)
            {
                _items.Add(item);
            }
        }

        // Returns the Item, and does not remove the object from _items.
        // Throws an ArgumentException if Item is not in _items.
        public Item Fetch(Item item)
        {
            foreach (Item checkItem in _items)
            {
                if (checkItem == item)
                {
                    return checkItem;
                }
            }
            throw new ArgumentException("Item is not currently in this Inventory");
        }

        // Returns the Item, and removes the object from _items.
        public Item Take(Item item)
        {
            Item _takenItem = Fetch(item);
            _items.Remove(_takenItem);
            return _takenItem;
        }

        // Returns the first Item of a specified ItemType.
        // Returns null if no Items of specifiec ItemType in List.
        public Item? TakeItemOfType(ItemType type)
        {
            foreach (Item item in _items)
            {
                if (item.ItemType == type)
                {
                    return Take(item);
                }
            }
            return null;
        }

        public List<Item> Items { get { return _items; } }
    }
}
