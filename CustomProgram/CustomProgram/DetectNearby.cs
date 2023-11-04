namespace CustomProgram
{
    //
    // Note: Unresolved issues with CharacterManager CurrentCharacter mean that Class has not been implemented yet.
    // Class to be used as a utility to allow for interactions between characters.
    // E.g., Allows Commands such as CommandGiveItem to work.
    //

    public class DetectNearby
    {
        private static DetectNearby? _instance;
        private int _distance = 30;

        // Private Constructor :
        private DetectNearby()
        {

        }

        // Singleton Class. Provides access to the instance.
        public static DetectNearby Instance()
        {
            if (_instance == null)
            {
                _instance = new DetectNearby();
            }
            return _instance;
        }

        // Returns True if Charcater a and Character b are within _distance of eachother. Otherwise, returns false.
        private bool IsClose(Character a, Character b)
        {
            if (a.X <= b.X + _distance && a.X >= b.X - _distance)
            {
                if (a.Y <= b.Y + _distance && a.Y >= b.Y - _distance)
                {
                    return true;
                }
            }
            return false;
        }

        // Returns true if the Charcater is within _distance of any Character's from the List.
        public bool AmICloseToAnyCharacter(Character character, List<Character> characters)
        {
            List<Character> _checkableCharacters = characters;
            _checkableCharacters.Remove(character);

            foreach (Character checkCharacter in _checkableCharacters)
            {
                if (IsClose(character, checkCharacter))
                {
                    return true;
                }
            }
            return false;
        }

        // Returns the Character the the specified Character is closest too. 
        // Returns False if no Characters are within _distance.
        public Character? WhichCharacterAmICloseTo(Character character, List<Character> characters)
        {
            List<Character> _checkableCharacters = characters;
            _checkableCharacters.Remove(character);

            List<Character> _nearbyCharcaters = new List<Character>();

            foreach (Character checkCharacter in _nearbyCharcaters)
            {
                if (IsClose(character, checkCharacter))
                {
                    _nearbyCharcaters.Add(checkCharacter);
                }
            }

            switch (_nearbyCharcaters.Count)
            {
                case 0:
                    return null;

                case 1:
                    return _nearbyCharcaters[0];

                default:
                    List<double> _displacements = new List<double>();

                    foreach (Character checkCharacter in _nearbyCharcaters)
                    {
                        _displacements.Add(Displacement(character, checkCharacter));
                    }

                    int i = _displacements.IndexOf(_displacements.Max());
                    return _nearbyCharcaters[i];
            }
        }

        // Calculates the Displacement of Character a from Character b by adding the absolute distance between the X and Y of the Coords of each Character.
        private double Displacement(Character a, Character b)
        {
            double _displacement = 0;
            _displacement += Math.Abs(a.X - b.X);
            _displacement += Math.Abs(a.Y - b.Y);
            return _displacement;
        }
    }
}
