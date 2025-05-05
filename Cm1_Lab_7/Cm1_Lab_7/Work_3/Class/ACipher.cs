using System.Text;

namespace Cm1_Lab_7;

// Клас шифрування через зсув кожного символу на одну позицію вище
public class ACipher : ICipher
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
                    encoded = (char)((c - 65 + 1) % 26 + 65);
                }
                else
                {
                    // Літери нижнього регістру (a-z: 97-122)
                    encoded = (char)((c - 97 + 1) % 26 + 97);
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

        StringBuilder result = new StringBuilder();

        foreach (char c in text)
        {
            char decoded = c;

            if (char.IsLetter(c))
            {
                if (char.IsUpper(c))
                {
                    // Літери верхнього регістру (A-Z: 65-90)
                    decoded = (char)((c - 65 + 25) % 26 + 65); // +25 еквівалентно -1 по модулю 26
                }
                else
                {
                    // Літери нижнього регістру (a-z: 97-122)
                    decoded = (char)((c - 97 + 25) % 26 + 97); // +25 еквівалентно -1 по модулю 26
                }
            }

            result.Append(decoded);
        }

        return result.ToString();
    }
}        