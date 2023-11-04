namespace CustomProgram
{
    //
    // Note: Unresolved issues with CharacterManager CurrentCharacter mean that Class has not been implemented yet.
    // Class to be used as a utility to allow for interactions between characters.
    // E.g., Allows Commands such as CommandGiveItem to work.
    //

    public class PhraseManager : IUpdateEachCycle
    {
        private CharacterManager _characterManager;

        // Constructor :
        public PhraseManager(CharacterManager characterManager) 
        {
            _characterManager = characterManager;
        }

        // Implements IUpdateEachCycle interface by calling all the classes methods which need to update each gameplay cycle.
        public void RunCycle()
        {
            SetPhrases();
        }

        // Set's the Phrases for all Characters. 
        // Phrases are updated each game to reflect changes in which Character's are nearby, and Item's in Inventories.
        // Phrases for not current characters are set to Defaults.
        public void SetPhrases()
        {
 
            foreach (Character character in _characterManager.PlayableCharacters)
            {
                character.Phrases.SetDefault();

            }
            
            Character _current = _characterManager.CurrentCharacter;
            List<Character> _allCharacters = _characterManager.AllCharcaters;
            Character? _nearby = DetectNearby.Instance().WhichCharacterAmICloseTo(_current, _allCharacters);

            _current.Phrases.SetPhrases(_current, _nearby);
        }
    }
}
