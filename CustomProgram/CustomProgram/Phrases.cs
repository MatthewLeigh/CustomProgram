namespace CustomProgram
{
    // Enumeration: Available PhraseKeys to access Phrases from the Dictionary.
    public enum PhraseKey
    {
        Greeting,
        Capture,
        TakeItem,
        GiveItem
    }
    public class Phrases
    {
        private string _defaultGreeting = "Hi There!";
        private string _defaultCapture = "Gotcha!";
        private string _defaultTakeItem = "Can I have that?";
        private string _defaultGiveItem = "Please, take this!";

        private Dictionary<PhraseKey, string> _phrases = new Dictionary<PhraseKey, string>();

        // Constructor :
        public Phrases()
        {
            SetDefault();
        }

        // Sets each Phrase in the Dictionary to a default string.
        public void SetDefault()
        {
            _phrases.Clear();
            _phrases.Add(PhraseKey.Greeting, _defaultGreeting);
            _phrases.Add(PhraseKey.Capture, _defaultCapture);
            _phrases.Add(PhraseKey.TakeItem, _defaultTakeItem);
            _phrases.Add(PhraseKey.GiveItem, _defaultGiveItem);
        }

        // Sets each phrase in the dictionary to a dynamic string.
        public void SetPhrases(Character character, Character? nearby)
        {
            _phrases.Clear();
            _phrases.Add(PhraseKey.Greeting, SetGreeting(nearby));
            _phrases.Add(PhraseKey.Capture, SetCapture(nearby));
            _phrases.Add(PhraseKey.TakeItem, SetTakeItem(nearby));
            _phrases.Add(PhraseKey.GiveItem, SetGiveItem(character, nearby));
        }

        // Set the Greeting Phrase based on nearby Character.
        private string SetGreeting(Character? nearby)
        {
            if (nearby != null)
            {
                return $"Hi There, {StringFormatter.FirstCharInStringToUpper(nearby.Name)}!";
            }
            return _defaultGreeting;
        }

        // Set the Captrue Phrase based on nearby Character.
        private string SetCapture(Character? nearby)
        {
            if (nearby != null)
            {
                if (nearby is Animal)
                {
                    return $"Gotcha, {StringFormatter.FirstCharInStringToUpper(nearby.Name)}!";
                }
                return $"Sorry about that, {StringFormatter.FirstCharInStringToUpper(nearby.Name)}";

            }
            return _defaultCapture;
        }

        // Set the TakeItem Phrase based on Nearby Character.
        private string SetTakeItem(Character? nearby)
        {
            if (nearby != null)
            {
                if (nearby is Animal)
                {
                    return $"Come here, {StringFormatter.FirstCharInStringToUpper(nearby.Name)}!";
                }
                if (nearby is Villager)
                {
                    if (nearby.Inventory.Items.Count > 0)
                    {
                        return $"Thanks for the {StringFormatter.FirstCharInStringToUpper(nearby.Inventory.Items.First().Name)}";
                    }
                    else
                    {
                        return "Can I borrow some money?";
                    }
                }
            }
            return _defaultTakeItem;
        }

        // Set the GiveItem Phrase based on Inventory and nearby Character.
        private string SetGiveItem(Character character, Character? nearby)
        {
            if (!character.Inventory.HasItemOfType(ItemType.Food))
            {
            return "I wish I had some food to share";
            }

            if (nearby != null)
            {
                if (nearby is Villager)
                {
                    return $"Please take some food";
                }
            }
            return "Who can I share all this food with?";
        }

        // Retrieve the Phrase at the PhraseKey.
        public string Retrieve(PhraseKey key)
        {
            if (_phrases != null)
            {
                return _phrases[key];
            }
            return "error retrieveing phrase";
        }
    }
}
