namespace CustomProgram
{
    public class GameManager : IUpdateEachCycle
    {
        private string _gameName;
        private int _numTilesX;
        private int _numTilesY;
        private int _tileSize;

        private Map _map;
        private Window _window;
        private Navigator _navigator;
        private CharacterManager _characterMangaer;
        private CommandManager _commandManager;
        // private PhraseManager _phraseManager; // To Be Implemented.

        private List<IUpdateEachCycle> _updatesEachCycle;

        // Constructor :
        public GameManager(string gameName, int numTilesX, int numTilesY, int tileSize)
        {
            _gameName = gameName;
            _numTilesX = numTilesX;
            _numTilesY = numTilesY;
            _tileSize = tileSize;

            _map = new Map(_numTilesX, _numTilesY, _tileSize);
            _window = new Window(_gameName, _map.Width, _map.Height);

            _navigator = new Navigator(_map);
            _characterMangaer = new CharacterManager(_navigator);
            _commandManager = new CommandManager(_navigator, _characterMangaer);
            // _phraseManager = new PhraseManager(_characterMangaer); // To Be Implemented.

            _updatesEachCycle = new List<IUpdateEachCycle> { _map, _characterMangaer, _commandManager, }; // _phraseManager // To Be Implemented.
        }

        // Constructor: Pass default values to main constructor.
        public GameManager() : this("No Man Is An Island", 50, 40, 16) { }

        // Implements IUpdateEachCycle interface. Calls all IUpdateEachCycle objects in GameManager to RunCycle().
        public void RunCycle()
        {
            foreach (IUpdateEachCycle updateClass in _updatesEachCycle)
            {
                try
                {
                    updateClass.RunCycle();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public Window GameWindow { get { return _window; } }
    }
}
