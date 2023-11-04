namespace CustomProgram
{
    public class StringFormatter
    {
        // Converts the first Char in a string to UpperCase, and all remaining characters to LowerCase.
        public static string FirstCharInStringToUpper(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException("s");
            }

            char[] _array = s.ToLower().ToCharArray();
            _array[0] = char.ToUpper(_array[0]);

            return new string(_array);
        }

        // Converts the first Char in each word in a string to UpperCase, and all remaining characters to LowerCase.
        public static string FirstCharInWordsToUpper(string s)
        {
            List<string> _array = s.Split(' ').ToList();
            string _returnString = string.Empty;

            int index = 0;
            foreach (string word in _array)
            {
                _returnString += FirstCharInStringToUpper(word);

                if (index < _array.Count - 1)
                {
                    _returnString += ' ';
                }
            }
            return _returnString;
        }
    }
}
