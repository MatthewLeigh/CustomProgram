namespace CustomProgram
{
    // Enumeration: Lists the Character child classes that this method can instantiate. 
    public enum CharacterType
    {
        Villager,
        Fish,
        Duck,
        Cow
    }
    public class CharacterFactory
    {
        private Navigator _navigator;
        private Random _random = new Random();

        // Constructor: 
        public CharacterFactory(Navigator navigator)
        {
            _navigator = navigator;
        }

        // Returns a new Character of the CharacterType specified.
        public Character Instantiate(CharacterType type)
        {
            Point2D _coords;

            switch (type)
            {
                case CharacterType.Villager:
                    string _name = ReadRandomLine("../../../Text/Names.txt");
                    string _description = ReadRandomLine("../../../Text/Descriptions.txt");
                    _coords = _navigator.RandomCoords(true, false);
                    return new Villager(_name, _description, _coords);

                case CharacterType.Fish:
                    _coords = _navigator.RandomCoords(false, true);
                    return new Fish(_coords);

                case CharacterType.Duck:
                    _coords = _navigator.RandomCoords(true, true);
                    return new Duck(_coords);

                case CharacterType.Cow:
                    _coords = _navigator.RandomCoords(true, false);
                    return new Cow(_coords);

                default:
                    throw new NotSupportedException();
            }
        }

        // Opens a file and returns a random line from it as a string.
        private string ReadRandomLine(string fileLocation)
        {
            StreamReader _reader = new StreamReader(fileLocation);

            try
            {
                int _lines = Convert.ToInt32(_reader.ReadLine());
                int _line = _random.Next(0, _lines);

                for (int i = 0; i < _line; i++) // Loop to skip over lines.
                {
                    _reader.ReadLine();
                }

                return _reader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return " ";
            }
            finally
            {
                _reader.Close();
            }
        }
    }
}
