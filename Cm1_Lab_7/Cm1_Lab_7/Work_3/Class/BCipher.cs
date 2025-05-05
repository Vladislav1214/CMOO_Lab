using System.Text;

namespace Cm1_Lab_7;

// Клас шифрування через заміну кожної літери на літеру, розташовану на тій же позиції з кінця алфавіту
public class BCipher : ICipher
{
    public string Encode(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        StringBuilder result = new StringBuilder();
        
        foreach (char c in text)
        {
            char encoded = c;
            
            if (char.IsLetter(c))
            {
                if (char.IsUpper(c))
                {
                    // Літери верхнього регістру (A-Z: 65-90)
                    encoded = (char)('A' + ('Z' - c)); // Заміна A->Z, B->Y, C->X і т.д.
                }
                else
                {
                    // Літери нижнього регістру (a-z: 97-122)
                    encoded = (char)('a' + ('z' - c)); // Заміна a->z, b->y, c->x і т.д.
                }
            }
            
            result.Append(encoded);
        }
        
        return result.ToString();
    }

    public string Decode(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        // Для цього шифру операція дешифрування ідентична операції шифрування
        return Encode(text);
    }
}