namespace CustomProgram
{
    public class CharacterManager : IUpdateEachCycle
    {
        private bool _displayStats = true;
        private bool _displayAnimalNames = false;
        private int _characterIndex = 0;
        private int _numVillagers;
        private int _numAnimals;

        private List<Character> _characters;
        private List<Character> _playableCharacters;

        private Navigator _navigator;
        private CharacterFactory _characterFactory;

        // Constructor: 
        public CharacterManager(Navigator navigator, int numVillagers, int numAnimals)
        {
            _numVillagers = numVillagers;
            _numAnimals = numAnimals;
            EnsureEnoughAnimals();

            _characters = new List<Character>(_numVillagers + _numAnimals);
            _playableCharacters = new List<Character>(_numVillagers);

            _navigator = navigator;
            _characterFactory = new CharacterFactory(_navigator);

            InstantiateCharacters();
            SetUpPlayableCharcaters();

        }

        // Constructor: Pass default numVillagers and numAnimals to main constructor.
        public CharacterManager(Navigator navigator) : this(navigator, 3, 15) { }

        // Ensures that there is always atelast one Animal for every Villager.
        private void EnsureEnoughAnimals()
        {
            if (_numAnimals < _numVillagers)
            {
                _numAnimals = _numVillagers;
            }
        }

        // Instantiate Characters based on int _numVillagers and int_numAnimals. 
        private void InstantiateCharacters()
        {
            for (int i = 0; i < _numVillagers;  i++)
            {
                _characters.Add(_characterFactory.Instantiate(CharacterType.Villager));
            }

            for (int i = 0; i < _numAnimals; i++)
            {
                CharacterType _animal = (CharacterType)SplashKit.Rnd(1, 4);
                _characters.Add(_characterFactory.Instantiate(_animal));
            }
        }

        // Adds all Villagers to _playableCharacters list. 
        // Calls InitilialiseCharacterItems Singleton class to distribute game Items amongst characters.
        private void SetUpPlayableCharcaters()
        {
            foreach (Character character in _characters)
            {
                if (character is Villager)
                {
                    _playableCharacters.Add(character);
                }
            }
            InitialiseCharacterItems.Instance().Distribute(_playableCharacters);
        }

        // Calls all Characters to draw themselves to the screen.
        // Animals have certain checks they need to pass to determine if they will be drawn, and if their name will be drawn.
        public void Draw()
        {
            foreach (Character character in _characters)
            {
                if (character is Animal)
                {
                    if (_playableCharacters[_characterIndex].Inventory.HasItemOfType(ItemType.Vision))
                    {
                        character.Draw();

                        if (_displayAnimalNames)
                        {
                            character.DrawName();
                        }

                    }
                }
            }

            foreach (Character character in _characters)
            {
                if (character is Villager)
                {
                    character.Draw();
                }
            }
        }

        // Draws the current Character's 'stats' to the top left of the screen.
        // 'Stats' are the strings returned by calling FullDescription() on the Character.
        public void DrawStats()
        {
            if (_displayStats)
            {
                Color _color = ColorPalette.Instance().Current.TextMain;
                int _x = 15;
                int _y = 15;
                int _lineSpacing = 15;

                foreach (string line in CurrentCharacter.FullDescription())
                {
                    SplashKit.DrawText(line, _color, _x, _y);
                    _y += _lineSpacing;
                }
            }
        }

        // Increment the character index by one, or reset to zero if already at max.
        public void RotateCharacter()
        {
            if (_characterIndex < (_playableCharacters.Count - 1))
            {
                _characterIndex++;
            }
            else
            {
                _characterIndex = 0;
            }
        }

        // Toogle the bool _displayAnimalNames.
        public void ToggleDisplayAnimalNames()
        {
            _displayAnimalNames = !_displayAnimalNames;
        }

        // Implements IUpdateEachCycle interface by calling all the classes methods which need to update each gameplay cycle.
        public void RunCycle()
        {
            try
            {
                Draw();
                DrawStats();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public Character CurrentCharacter { get {  return _playableCharacters[_characterIndex]; } }
        public List<Character> AllCharcaters { get { return _characters; } } 
        public List<Character> PlayableCharacters { get { return _playableCharacters; } } 
        public int CurrentCharacterIndex { get { return _characterIndex; } }
    }
}
