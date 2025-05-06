using System.Text;

namespace Cm1_Lab_7;

// Клас шифрування через заміну кожної літери на літеру, розташовану на тій же позиції з кінця алфавіту
public class BCipher : ICipher
{
    private const string AlphabetLowerUkr = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
    private const string AlphabetUpperUkr = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
    private const string AlphabetLowerEng = "abcdefghijklmnopqrstuvwxyz";
    private const string AlphabetUpperEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    private char MirrorChar(string arr, char c)
    {
        return arr[arr.Length - 1 - arr.IndexOf(c)];
    }

    public string Encode(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        StringBuilder result = new StringBuilder();
        
        foreach (char c in text)
        {
            char encoded = c;
            
            if (char.IsUpper(c))
            {
                if (AlphabetUpperUkr.Contains(c))
                    encoded = MirrorChar(AlphabetUpperUkr, c);
                else if (AlphabetUpperEng.Contains(c))
                    encoded = MirrorChar(AlphabetUpperEng, c);
            }
            else if (char.IsLower(c))
            {
                if (AlphabetLowerUkr.Contains(c))
                    encoded = MirrorChar(AlphabetLowerUkr, c);
                else if (AlphabetLowerEng.Contains(c))
                    encoded = MirrorChar(AlphabetLowerEng, c);
            }
            
            result.Append(encoded);
        }
        
        
        return result.ToString();
    }

    public string Decode(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        
        return Encode(text);
    }
}