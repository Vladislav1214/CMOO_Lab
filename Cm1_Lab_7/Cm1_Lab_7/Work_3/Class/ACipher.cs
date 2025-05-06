using System.Text;

namespace Cm1_Lab_7;

// Клас шифрування через зсув кожного символу на одну позицію вище
public class ACipher : ICipher
{
    private const string AlphabetLowerUkr = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
    private const string AlphabetUpperUkr = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
    private const string AlphabetLowerEng = "abcdefghijklmnopqrstuvwxyz";
    private const string AlphabetUpperEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private char EcodeFun(string arr, char c)
    {
        int index = arr.IndexOf(c);
        return arr[(index + 1) % arr.Length];;
    }
    
    private char DecodeFun(string arr, char c)
    {
        int index = arr.IndexOf(c);
        return arr[(index - 1 + arr.Length) % arr.Length];;
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
                    encoded = EcodeFun(AlphabetUpperUkr, c);
                else if (AlphabetUpperEng.Contains(c))
                    encoded = EcodeFun(AlphabetUpperEng, c);
            }
            else if (char.IsLower(c))
            {
                if (AlphabetLowerUkr.Contains(c))
                    encoded = EcodeFun(AlphabetLowerUkr, c);
                else if (AlphabetLowerEng.Contains(c))
                    encoded = EcodeFun(AlphabetLowerEng, c);
            }
            
            result.Append(encoded);
        }
        
        return result.ToString();
    }

    public string Decode(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        
        StringBuilder result = new StringBuilder();
        
        foreach (char c in text)
        {
            char dencoded = c;
            
            if (char.IsUpper(c))
            {
                if (AlphabetUpperUkr.Contains(c))
                    dencoded = DecodeFun(AlphabetUpperUkr, c);
                else if (AlphabetUpperEng.Contains(c))
                    dencoded = DecodeFun(AlphabetUpperEng, c);
            }
            else if (char.IsLower(c))
            {
                if (AlphabetLowerUkr.Contains(c))
                    dencoded = DecodeFun(AlphabetLowerUkr, c);
                else if (AlphabetLowerEng.Contains(c))
                    dencoded = DecodeFun(AlphabetLowerEng, c);
            }
            
            result.Append(dencoded);
        }
        
        return result.ToString();
    }
}        